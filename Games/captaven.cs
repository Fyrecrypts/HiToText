using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class captaven : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameA1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameB1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownB1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameC1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownC1;
            public byte Coin1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
            public byte[] UnknownD1;
            public byte Character1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] UnknownE1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameA2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameB2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownB2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameC2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownC2;
            public byte Coin2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
            public byte[] UnknownD2;
            public byte Character2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] UnknownE2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameA3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameB3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownB3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameC3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownC3;
            public byte Coin3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
            public byte[] UnknownD3;
            public byte Character3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] UnknownE3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameA4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameB4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownB4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameC4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownC4;
            public byte Coin4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
            public byte[] UnknownD4;
            public byte Character4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] UnknownE4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameA5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownA5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameB5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownB5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameC5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnknownC5;
            public byte Coin5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
            public byte[] UnknownD5;
            public byte Character5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] UnknownE5;
        }

        public captaven()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|CREDITS USED|CHARACTER";
            m_gamesSupported = "captaven,captavnj,captavna,captavne,captavua,captavuu,captavnu";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i = i + 2)
            {
                if (data[i + 1] == 0xbf)
                {
                    if (data[i] >= 0x58 && data[i] <= 0xbc)
                        sb.Append(((char)((((int)data[i]) / 4) + 65 - 0x16)));
                    else if (data[i] >= 0x00 && data[i] <= 0x24)
                        sb.Append(((char)((((int)data[i]) / 4) + 65 + 0x30)));
                    else if (data[i] == 0x30)
                        sb.Append('.');
                    else if (data[i] == 0x50)
                        sb.Append('&');
                    else if (data[i] == 0x4c)
                        sb.Append('?');
                    else if (data[i] == 0x48)
                        sb.Append('❢');
                    else if (data[i] == 0x44)
                        sb.Append(')');
                    else if (data[i] == 0x40)
                        sb.Append('(');
                    else if (data[i] == 0x3c)
                        sb.Append('_');
                    else if (data[i] == 0x38)
                        sb.Append('-');
                    else if (data[i] == 0x34)
                        sb.Append(',');
                    else if (data[i] == 0x2c)
                        sb.Append(':');
                    else if (data[i] == 0x28)
                        sb.Append('•');
                }
                else if (data[i + 1] == 0xbe)
                {
                    if (data[i] >= 0xc0 && data[i] <= 0xfc)
                        sb.Append(((char)((((int)data[i]) / 4) + 65 - 0x10)));
                }
                else if (data[i + 1] == 0x00)
                {
                    if (data[i] == 0x00)
                        sb.Append(' ');
                }
                else if (data[i + 1] == 0xb2)
                {
                    if (data[i] == 0xfc)
                        sb.Append('`');
                    else if (data[i] == 0xf4)
                        sb.Append('´');
                    else if (data[i] == 0xf8)
                        sb.Append('‼');
                    else if (data[i] == 0xec)
                        sb.Append('[');
                    else if (data[i] == 0xf0)
                        sb.Append(']');
                    else if (data[i] == 0xe8)
                        sb.Append('!');
                    else if (data[i] == 0xe4)
                        sb.Append('؟');
                    else if (data[i] == 0xdc)
                        sb.Append('։');
                    else if (data[i] == 0xc8)
                        sb.Append('·');
                }
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length * 2];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    data[(i * 2)] = (byte)((((int)str[i]) - 65 + 0x16) * 4);
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] >= 'p' && str[i] <= 'z')
                {
                    data[(i * 2)] = (byte)((((int)str[i]) - 65 - 0x30) * 4);
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] >= 'a' && str[i] <= 'o')
                {
                    data[(i * 2)] = (byte)((((int)str[i]) - 65 + 0x10) * 4);
                    data[(i * 2) + 1] = 0xbe;
                }
                else if (str[i] == '.')
                {
                    data[(i * 2)] = 0x30;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == '&')
                {
                    data[(i * 2)] = 0x50;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == '?')
                {
                    data[(i * 2)] = 0x4c;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == '❢')
                {
                    data[(i * 2)] = 0x48;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == ')')
                {
                    data[(i * 2)] = 0x44;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == '(')
                {
                    data[(i * 2)] = 0x40;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == '_')
                {
                    data[(i * 2)] = 0x3c;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == '-')
                {
                    data[(i * 2)] = 0x38;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == ',')
                {
                    data[(i * 2)] = 0x34;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == ':')
                {
                    data[(i * 2)] = 0x2c;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == '•')
                {
                    data[(i * 2)] = 0x28;
                    data[(i * 2) + 1] = 0xbf;
                }
                else if (str[i] == ' ')
                {
                    data[(i * 2)] = 0x00;
                    data[(i * 2) + 1] = 0x00;
                }
                else if (str[i] == '`')
                {
                    data[(i * 2)] = 0xfc;
                    data[(i * 2) + 1] = 0xb2;
                }
                else if (str[i] == '´')
                {
                    data[(i * 2)] = 0xf4;
                    data[(i * 2) + 1] = 0xb2;
                }
                else if (str[i] == '‼')
                {
                    data[(i * 2)] = 0xf8;
                    data[(i * 2) + 1] = 0xb2;
                }
                else if (str[i] == '[')
                {
                    data[(i * 2)] = 0xec;
                    data[(i * 2) + 1] = 0xb2;
                }
                else if (str[i] == ']')
                {
                    data[(i * 2)] = 0xf0;
                    data[(i * 2) + 1] = 0xb2;
                }
                else if (str[i] == '!')
                {
                    data[(i * 2)] = 0xe8;
                    data[(i * 2) + 1] = 0xb2;
                }
                else if (str[i] == '؟')
                {
                    data[(i * 2)] = 0xe4;
                    data[(i * 2) + 1] = 0xb2;
                }
                else if (str[i] == '։')
                {
                    data[(i * 2)] = 0xdc;
                    data[(i * 2) + 1] = 0xb2;
                }
                else if (str[i] == '·')
                {
                    data[(i * 2)] = 0xc8;
                    data[(i * 2) + 1] = 0xb2;
                }
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int coin = System.Convert.ToInt32(args[3]);
            int character = GetCharacter(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 5;
            if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)))
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
                    HiConvert.ByteArrayCopy(hiscoreData.NameA2, hiscoreData.NameA1);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB2, hiscoreData.NameB1);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC2, hiscoreData.NameC1);
                    hiscoreData.Coin2 = hiscoreData.Coin1;
                    hiscoreData.Character2 = hiscoreData.Character1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.NameA3, hiscoreData.NameA2);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB3, hiscoreData.NameB2);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC3, hiscoreData.NameC2);
                    hiscoreData.Coin3 = hiscoreData.Coin2;
                    hiscoreData.Character3 = hiscoreData.Character2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.NameA4, hiscoreData.NameA3);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB4, hiscoreData.NameB3);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC4, hiscoreData.NameC3);
                    hiscoreData.Coin4 = hiscoreData.Coin3;
                    hiscoreData.Character4 = hiscoreData.Character3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.NameA5, hiscoreData.NameA4);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB5, hiscoreData.NameB4);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC5, hiscoreData.NameC4);
                    hiscoreData.Coin5 = hiscoreData.Coin4;
                    hiscoreData.Character5 = hiscoreData.Character4;
                    if (rank < 3)
                        goto case 2;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            byte[] first = new byte[] { StringToByteArray(name)[0], StringToByteArray(name)[1] };
            byte[] second = new byte[] { StringToByteArray(name)[2], StringToByteArray(name)[3] };
            byte[] third = new byte[] { StringToByteArray(name)[4], StringToByteArray(name)[5] };
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.NameA1, first);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB1, second);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC1, third);
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length)));
                    hiscoreData.Character1 = (byte)character;
                    hiscoreData.Coin1 = (byte)coin;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.NameA2, first);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB2, second);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC2, third);
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length)));
                    hiscoreData.Character2 = (byte)character;
                    hiscoreData.Coin2 = (byte)coin;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.NameA3, first);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB3, second);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC3, third);
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length)));
                    hiscoreData.Character3 = (byte)character;
                    hiscoreData.Coin3 = (byte)coin;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.NameA4, first);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB4, second);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC4, third);
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length)));
                    hiscoreData.Character4 = (byte)character;
                    hiscoreData.Coin4 = (byte)coin;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.NameA5, first);
                    HiConvert.ByteArrayCopy(hiscoreData.NameB5, second);
                    HiConvert.ByteArrayCopy(hiscoreData.NameC5, third);
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length)));
                    hiscoreData.Character5 = (byte)character;
                    hiscoreData.Coin5 = (byte)coin;
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        private int GetCharacter(string characterName)
        {
            switch (characterName.ToUpper())
            {
                case "CAPTAIN AMERICA":
                    return 0;
                case "IRONMAN":
                    return 1;
                case "ANDROID":
                    return 2;
                case "HAWKEYE":
                    return 3;
            }
            return -1;
        }

        private String GetCharacter(int characterID)
        {
            switch (characterID)
            {
                case 0:
                    return "CAPTAIN AMERICA";
                case 1:
                    return "IRONMAN";
                case 2:
                    return "ANDROID";
                case 3:
                    return "HAWKEYE";
            }
            return "";
        }

        private String AppendName(byte[] first, byte[] second, byte[] third)
        {
            return ByteArrayToString(first) + ByteArrayToString(second) + ByteArrayToString(third);
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

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)), AppendName(hiscoreData.NameA1, hiscoreData.NameB1, hiscoreData.NameC1), hiscoreData.Coin1, GetCharacter((int)hiscoreData.Character1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)), AppendName(hiscoreData.NameA2, hiscoreData.NameB2, hiscoreData.NameC2), hiscoreData.Coin2, GetCharacter((int)hiscoreData.Character2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)), AppendName(hiscoreData.NameA3, hiscoreData.NameB3, hiscoreData.NameC3), hiscoreData.Coin3, GetCharacter((int)hiscoreData.Character3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)), AppendName(hiscoreData.NameA4, hiscoreData.NameB4, hiscoreData.NameC4), hiscoreData.Coin4, GetCharacter((int)hiscoreData.Character4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)), AppendName(hiscoreData.NameA5, hiscoreData.NameB5, hiscoreData.NameC5), hiscoreData.Coin5, GetCharacter((int)hiscoreData.Character5)) + Environment.NewLine;

            return retString;
        }
    }
}