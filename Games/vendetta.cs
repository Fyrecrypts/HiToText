using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class vendetta : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name;
        }

        public vendetta()
        {
            m_numEntries = 8;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "vendetta,vendettar,vendetta2p,vendetta2pu,vendetta2pd,vendettaj";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x40)
                    sb.Append(' ');
                else if (data[i] == 0x5b)
                    sb.Append('.');
                else
                    sb.Append((char)(int)data[i]);
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    data[i] = 0x40;
                else if (str[i] == '.')
                    data[i] = 0x5b;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

            int rank = NumEntries;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            //Do not change the below.
            hiscoreData.Score = HiConvert.IntToByteArrayHex(score, 2);
            hiscoreData.Name = new byte[3];
            HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name));
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            #region DETERMINE RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * Marshal.SizeOf(typeof(HiscoreData));
                byte[] tmp = { m_data[offset], m_data[offset + 1] };

                int scoreToCompare = HiConvert.ByteArrayHexToInt(tmp);
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
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData)))] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 1] = 0x00;
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

                retString += String.Format("{0}|{1}|{2}",
                    i + 1,
                    HiConvert.ByteArrayHexToInt(hiscoreData.Score),
                    ByteArrayToString(hiscoreData.Name)) + Environment.NewLine;
            }

            return retString;
        }
    }
}
