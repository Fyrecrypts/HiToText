using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class outzone : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameFirst1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameMid1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameLast1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SeparatorA1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameFirst2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameMid2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameLast2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SeparatorA2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameFirst3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameMid3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameLast3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SeparatorA3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameFirst4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameMid4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameLast4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SeparatorA4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameFirst5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameMid5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] NameLast5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SeparatorA5;

            public byte Area1;
            public byte AreaSeparator1;
            public byte Area2;
            public byte AreaSeparator2;
            public byte Area3;
            public byte AreaSeparator3;
            public byte Area4;
            public byte AreaSeparator4;
            public byte Area5;
        }

        public outzone()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|AREA";
            m_gamesSupported = "outzone,outzonep,outzonea,outzoneb,outzonec";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x00)
                    sb.Append(' ');
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
                    data[i] = 0x00;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        private byte[] GetFour(byte p)
        {
            byte[] toReturn = new byte[4];
            toReturn[0] = p;
            if (p == 0x3f)
                toReturn[2] = p;

            return toReturn;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int area = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
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
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst2, hiscoreData.NameFirst1);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid2, hiscoreData.NameMid1);
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast2, hiscoreData.NameLast1);
                    hiscoreData.Area2 = hiscoreData.Area1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst3, hiscoreData.NameFirst2);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid3, hiscoreData.NameMid2);
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast3, hiscoreData.NameLast2);
                    hiscoreData.Area3 = hiscoreData.Area2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst4, hiscoreData.NameFirst3);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid4, hiscoreData.NameMid3);
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast4, hiscoreData.NameLast3);
                    hiscoreData.Area4 = hiscoreData.Area3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst5, hiscoreData.NameFirst4);
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid5, hiscoreData.NameMid4);
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast5, hiscoreData.NameLast4);
                    hiscoreData.Area5 = hiscoreData.Area4;
                    if (rank < 3)
                        goto case 2;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            byte[] nameArray = StringToByteArray(name);
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst1, GetFour(nameArray[0]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid1, GetFour(nameArray[1]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast1, GetFour(nameArray[2]));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
                    hiscoreData.Area1 = (byte)area;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst2, GetFour(nameArray[0]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid2, GetFour(nameArray[1]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast2, GetFour(nameArray[2]));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    hiscoreData.Area2 = (byte)area;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst3, GetFour(nameArray[0]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid3, GetFour(nameArray[1]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast3, GetFour(nameArray[2]));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    hiscoreData.Area3 = (byte)area;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst4, GetFour(nameArray[0]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid4, GetFour(nameArray[1]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast4, GetFour(nameArray[2]));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    hiscoreData.Area4 = (byte)area;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.NameFirst5, GetFour(nameArray[0]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameMid5, GetFour(nameArray[1]));
                    HiConvert.ByteArrayCopy(hiscoreData.NameLast5, GetFour(nameArray[2]));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    hiscoreData.Area5 = (byte)area;
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

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(new byte[] { hiscoreData.NameFirst1[0], hiscoreData.NameMid1[0], hiscoreData.NameLast1[0] }), (int)hiscoreData.Area1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(new byte[] { hiscoreData.NameFirst2[0], hiscoreData.NameMid2[0], hiscoreData.NameLast2[0] }), (int)hiscoreData.Area2) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(new byte[] { hiscoreData.NameFirst3[0], hiscoreData.NameMid3[0], hiscoreData.NameLast3[0] }), (int)hiscoreData.Area3) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(new byte[] { hiscoreData.NameFirst4[0], hiscoreData.NameMid4[0], hiscoreData.NameLast4[0] }), (int)hiscoreData.Area4) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(new byte[] { hiscoreData.NameFirst5[0], hiscoreData.NameMid5[0], hiscoreData.NameLast5[0] }), (int)hiscoreData.Area5) + Environment.NewLine;

            return retString;
        }
    }
}