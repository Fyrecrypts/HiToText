using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class mappy : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiFillerA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiHundreds;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HiFillerB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiThousands;
        }

        public mappy()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|ROUND";
            m_gamesSupported = "mappy,mappyj";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x41 && data[i] <= 0x5a)
                    sb.Append((char)(int)data[i]);
                else if (data[i] == 0x5f)
                    sb.Append('.');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i]);
                else if (str[i] == '.')
                    data[i] = 0x5f;
            }

            return data;
        }

        public byte[] SmallScoreToByteArray(int score)
        {
            byte[] scoreConverted = HiConvert.IntToByteArraySingleBCD(score, score.ToString().PadLeft(3, '0').Length);
            byte[] toReturn = HiConvert.ReverseByteArray(scoreConverted);

            return toReturn;
        }

        public byte[] ReOrderForThousands(byte[] unordered)
        {
            //Ordered will have bytes in this order: (thousands, ten thousands, hundred thousands)
            //We want: (hundred thousands, thousands, ten thousands)
            byte[] ordered = new byte[unordered.Length];
            ordered[0] = unordered[2];
            ordered[1] = unordered[0];
            ordered[2] = unordered[1];
            if (ordered[0] == 0x00)
            {
                ordered[0] = 0x20;
                if (ordered[1] == 0x00)
                {
                    ordered[1] = 0x20;
                    if (ordered[2] == 0x00)
                        ordered[2] = 0x20;
                }
            }
            return ordered;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            string name = args[2];
            int round = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 5;
            if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score5))
                rank = 4;
            #endregion

            #region ADJUST
            int adjust = 4;
            if (rank < 4)
                adjust = 3;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    HiConvert.ByteArrayCopy(hiscoreData.Round2, hiscoreData.Round1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Round3, hiscoreData.Round2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Round4, hiscoreData.Round3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Round5, hiscoreData.Round4);
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.HexStringToByteArray(score.ToString("D6")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Round1, HiConvert.HexStringToByteArray(round.ToString("D4")));
                    HiConvert.ByteArrayCopy(hiscoreData.HiHundreds, SmallScoreToByteArray((score * 10) % 1000));
                    HiConvert.ByteArrayCopy(hiscoreData.HiThousands, ReOrderForThousands(SmallScoreToByteArray((score * 10) / 1000)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.HexStringToByteArray(score.ToString("D6")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Round2, HiConvert.HexStringToByteArray(round.ToString("D4")));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.HexStringToByteArray(score.ToString("D6")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Round3, HiConvert.HexStringToByteArray(round.ToString("D4")));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.HexStringToByteArray(score.ToString("D6")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Round4, HiConvert.HexStringToByteArray(round.ToString("D4")));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.HexStringToByteArray(score.ToString("D6")));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Round5, HiConvert.HexStringToByteArray(round.ToString("D4")));
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

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1) * 10, ByteArrayToString(hiscoreData.Name1), HiConvert.ByteArrayHexToInt(hiscoreData.Round1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2) * 10, ByteArrayToString(hiscoreData.Name2), HiConvert.ByteArrayHexToInt(hiscoreData.Round2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3) * 10, ByteArrayToString(hiscoreData.Name3), HiConvert.ByteArrayHexToInt(hiscoreData.Round3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4) * 10, ByteArrayToString(hiscoreData.Name4), HiConvert.ByteArrayHexToInt(hiscoreData.Round4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5) * 10, ByteArrayToString(hiscoreData.Name5), HiConvert.ByteArrayHexToInt(hiscoreData.Round5)) + Environment.NewLine;
            
            return retString;
        }
    }
}
