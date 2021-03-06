using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class wrally : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score;
            public byte UnusedB;
            public byte RallyEasy;
            public byte UnusedC;
            public byte RallyMedium;
            public byte UnusedD;
            public byte RallyHard;
            public byte UnusedE;
            public byte RallyExpert;
            public byte UnusedF;
            public byte RallyTotal;
        }

        public wrally()
        {
            m_numEntries = 36;
            m_format = "RANK|SCORE|NAME|RALLY POINTS(EASY)|RALLY POINTS(MEDIUM)|RALLY POINTS(HARD)|RALLY POINTS(EXPERT)|RALLY POINTS(TOTAL)";
            m_gamesSupported = "wrally,wrallya,wrallyb";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append((char)(int)data[i]);

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
                data[i] = (byte)((int)str[i]);

            return data;
        }

        public int GetRally(string rally)
        {
            if (rally.Equals("--"))
                return 0xff;
            
            return Convert.ToInt32(rally);
        }

        public string GetRally(int rally)
        {
            if (rally == 0xff)
                return "--";

            return rally.ToString();
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int rallyE = GetRally(args[3]);
            int rallyM = GetRally(args[4]);
            int rallyH = GetRally(args[5]);
            int rallyX = GetRally(args[6]);
            int rallyT = GetRally(args[7]);

            int rank = NumEntries;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            //Do not change the below.
            hiscoreData.Score = HiConvert.IntToByteArrayHexAsHex(score, 3);
            hiscoreData.Name = new byte[3];
            HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name));
            hiscoreData.RallyEasy = (byte)rallyE;
            hiscoreData.RallyMedium = (byte)rallyM;
            hiscoreData.RallyHard = (byte)rallyH;
            hiscoreData.RallyExpert = (byte)rallyX;
            hiscoreData.RallyTotal = (byte)rallyT;
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            #region DETERMINE RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * Marshal.SizeOf(typeof(HiscoreData));
                byte[] tmp = { m_data[offset + 5], m_data[offset + 6], m_data[offset + 7] };

                int scoreToCompare = HiConvert.ByteArrayHexAsHexToInt(tmp);
                if (score > scoreToCompare)
                {
                    rank = i;
                    break;
                }
            }
            #endregion

            #region ADJUST
            int adjust = -1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            for (int i = adjust; i >= 0; i--)
            {
                if (rank > i)
                    break;

                int offsetOldLoc = i * Marshal.SizeOf(typeof(HiscoreData));
                int offsetNewLoc = (i + 1) * Marshal.SizeOf(typeof(HiscoreData));

                for (int j = 0; j < byteArray.Length; j++)
                    m_data[offsetNewLoc + j] = m_data[offsetOldLoc + j];

            }

            #endregion

            #region REPLACE NEW
            if (rank < NumEntries)
            {
                offset = rank * Marshal.SizeOf(typeof(HiscoreData));

                for (int i = 0; i < byteArray.Length; i++)
                    m_data[offset + i] = byteArray[i];
            }
            #endregion
        }

        public override void EmptyScores()
        {
            for (int i = 0; i < NumEntries; i++)
            {
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 5] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 6] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 7] = 0x00;
            }

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            for (int i = 0; i < m_numEntries; i++)
            {
                HiscoreData hiscoreData = new HiscoreData();
                hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreData));

                retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}",
                    i + 1,
                    HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score),
                    ByteArrayToString(hiscoreData.Name),
                    GetRally((int)hiscoreData.RallyEasy),
                    GetRally((int)hiscoreData.RallyMedium),
                    GetRally((int)hiscoreData.RallyHard),
                    GetRally((int)hiscoreData.RallyExpert),
                    GetRally((int)hiscoreData.RallyTotal)) + Environment.NewLine;
            }

            return retString;
        }
    }
}
