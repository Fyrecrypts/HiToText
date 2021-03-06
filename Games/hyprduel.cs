using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class hyprduel : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name1;
            public byte Stage1;
            public byte Class1;
            public byte Type1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name2;
            public byte Stage2;
            public byte Class2;
            public byte Type2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name3;
            public byte Stage3;
            public byte Class3;
            public byte Type3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name4;
            public byte Stage4;
            public byte Class4;
            public byte Type4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name5;
            public byte Stage5;
            public byte Class5;
            public byte Type5;

            public byte Footer;
        }

        public hyprduel()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|STAGE|CLASS|TYPE";
            m_gamesSupported = "hyprduel,hyprdelj";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x11 && data[i] <= 0x2a)
                    sb.Append(((char)((((int)data[i])) + 65 - 0x11)));
                else if (data[i] == 0x00)
                    sb.Append('0');
                else if (data[i] == 0x01)
                    sb.Append('1');
                else if (data[i] == 0x02)
                    sb.Append('2');
                else if (data[i] == 0x03)
                    sb.Append('3');
                else if (data[i] == 0x04)
                    sb.Append('4');
                else if (data[i] == 0x05)
                    sb.Append('5');
                else if (data[i] == 0x06)
                    sb.Append('6');
                else if (data[i] == 0x07)
                    sb.Append('7');
                else if (data[i] == 0x08)
                    sb.Append('8');
                else if (data[i] == 0x09)
                    sb.Append('9');
                else if (data[i] == 0x2c)
                    sb.Append('♥');
                else if (data[i] == 0x2b)
                    sb.Append('!');
                else if (data[i] == 0x0b)
                    sb.Append(',');
                else if (data[i] == 0x0a)
                    sb.Append('.');
                else if (data[i] == 0x10) //whale, actually uses U+297E ('UP FISH TAIL')
                    sb.Append('⥾');
                else if (data[i] == 0x0f)
                    sb.Append('?');
                else if (data[i] == 0x0e)
                    sb.Append(']');
                else if (data[i] == 0x0d)
                    sb.Append('-');
                else if (data[i] == 0x0c)
                    sb.Append('[');
                else if (data[i] == 0xd0)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                int tmp = (int)str[i];
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65 + 0x11));
                else if (str[i] == '0')
                    data[i] = 0x00;
                else if (str[i] == '1')
                    data[i] = 0x01;
                else if (str[i] == '2')
                    data[i] = 0x02;
                else if (str[i] == '3')
                    data[i] = 0x03;
                else if (str[i] == '4')
                    data[i] = 0x04;
                else if (str[i] == '5')
                    data[i] = 0x05;
                else if (str[i] == '6')
                    data[i] = 0x06;
                else if (str[i] == '7')
                    data[i] = 0x07;
                else if (str[i] == '8')
                    data[i] = 0x08;
                else if (str[i] == '9')
                    data[i] = 0x09;
                else if (str[i] == '♥')
                    data[i] = 0x2c;
                else if (str[i] == '!')
                    data[i] = 0x2b;
                else if (str[i] == ',')
                    data[i] = 0x0b;
                else if (str[i] == '.')
                    data[i] = 0x0a;
                else if (str[i] == '⥾')
                    data[i] = 0x10;
                else if (str[i] == '?')
                    data[i] = 0x0f;
                else if (str[i] == ']')
                    data[i] = 0x0e;
                else if (str[i] == '-')
                    data[i] = 0x0d;
                else if (str[i] == '[')
                    data[i] = 0x0c;
                else if (str[i] == ' ')
                    data[i] = 0xd0;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int stage = System.Convert.ToInt32(args[3]);
            int classGiven = System.Convert.ToInt32(args[4]);
            int type = GetGameType(args[5]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 5;
            if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5))
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
                    hiscoreData.Stage2 = hiscoreData.Stage1;
                    hiscoreData.Class2 = hiscoreData.Class1;
                    hiscoreData.Type2 = hiscoreData.Type1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Stage3 = hiscoreData.Stage2;
                    hiscoreData.Class3 = hiscoreData.Class2;
                    hiscoreData.Type3 = hiscoreData.Type2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Stage4 = hiscoreData.Stage3;
                    hiscoreData.Class4 = hiscoreData.Class3;
                    hiscoreData.Type4 = hiscoreData.Type3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Stage5 = hiscoreData.Stage4;
                    hiscoreData.Class5 = hiscoreData.Class4;
                    hiscoreData.Type5 = hiscoreData.Type4;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length));
                    hiscoreData.Stage1 = (byte)stage;
                    hiscoreData.Class1 = (byte)classGiven;
                    hiscoreData.Type1 = (byte)type;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length));
                    hiscoreData.Stage2 = (byte)stage;
                    hiscoreData.Class2 = (byte)classGiven;
                    hiscoreData.Type2 = (byte)type;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length));
                    hiscoreData.Stage3 = (byte)stage;
                    hiscoreData.Class3 = (byte)classGiven;
                    hiscoreData.Type3 = (byte)type;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length));
                    hiscoreData.Stage4 = (byte)stage;
                    hiscoreData.Class4 = (byte)classGiven;
                    hiscoreData.Type4 = (byte)type;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length));
                    hiscoreData.Stage5 = (byte)stage;
                    hiscoreData.Class5 = (byte)classGiven;
                    hiscoreData.Type5 = (byte)type;
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public int GetGameType(String typeAsStr)
        {
            switch (typeAsStr.ToUpper())
            {
                case "S.FORGEL":
                    return 0;
                case "H.MUSTANG":
                    return 1;
                case "P.SMASHER":
                    return 2;
            }

            return -1;
        }

        public String GetGameType(int typeAsInt)
        {
            switch (typeAsInt)
            {
                case 0:
                    return "S.FORGEL";
                case 1:
                    return "H.MUSTANG";
                case 2:
                    return "P.SMASHER";
            }

            return "";
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score5.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 
                1,
                HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1), 
                ByteArrayToString(hiscoreData.Name1), 
                hiscoreData.Stage1,
                hiscoreData.Class1,
                GetGameType((int)hiscoreData.Type1)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                2,
                HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2),
                ByteArrayToString(hiscoreData.Name2),
                hiscoreData.Stage2,
                hiscoreData.Class2,
                GetGameType((int)hiscoreData.Type2)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                3,
                HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3),
                ByteArrayToString(hiscoreData.Name3),
                hiscoreData.Stage3,
                hiscoreData.Class3,
                GetGameType((int)hiscoreData.Type3)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                4,
                HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4),
                ByteArrayToString(hiscoreData.Name4),
                hiscoreData.Stage4,
                hiscoreData.Class4,
                GetGameType((int)hiscoreData.Type4)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}|{5}",
                5,
                HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5),
                ByteArrayToString(hiscoreData.Name5),
                hiscoreData.Stage5,
                hiscoreData.Class5,
                GetGameType((int)hiscoreData.Type5)) + Environment.NewLine;
            
            return retString;
        }
    }
}

