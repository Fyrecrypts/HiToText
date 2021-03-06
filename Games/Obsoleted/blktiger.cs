using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class blktiger : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] AboveName1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte NextToName1;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] AboveName2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte NextToName2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] AboveName3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte NextToName3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] AboveName4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte NextToName4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] AboveName5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte NextToName5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] HiScore;
        }

        //TODO: Add alternate scores to allow adding the additional name info.
        public blktiger()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "blktiger,bktigrb1,bktigrb2";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x5c)
                    sb.Append('★');
                if (data[i] == 0x6d)
                    sb.Append('♥');
                if (data[i] == 0x6c)
                    sb.Append('♦');
                if (data[i] == 0x6a)
                    sb.Append('\'');
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
                if (str[i] == '★')
                    data[i] = 0x5c;
                if (str[i] == '♥')
                    data[i] = 0x6d;
                if (str[i] == '♦')
                    data[i] = 0x6c;
                if (str[i] == '\'')
                    data[i] = 0x6a;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score5))
                rank = 4;
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HiScore.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    break;
                default:
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(0, hiscoreData.Score5.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score1) * 10, ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score2) * 10, ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score3) * 10, ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score4) * 10, ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score5) * 10, ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            
            return retString;
        }
    }
}
