using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class bankp : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Level10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unused10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] HiScore;
        }

        public bankp()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|TIME|LEVEL";
            m_gamesSupported = "bankp";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x3d)
                    sb.Append('.');
                else if (data[i] == 0x00)
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
                if (str[i] == '.')
                    data[i] = 0x3d;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public int GetTime(string time)
        {
            //Format mmm:ss
            string[] saTime = time.Split(new char[] { ':' });
            return (Convert.ToInt32(saTime[0]) * 60) + Convert.ToInt32(saTime[1]);
        }

        public string GetTime(int time)
        {
            //Format mmm:ss
            int mins = time / 60;
            int secs = time % 60;
            return mins.ToString() + ":" + secs.ToString().PadLeft(2, '0');
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int time = GetTime(args[3]);
            int level = System.Convert.ToInt32(args[4]);

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
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score9))
                rank = 8;
            else if (score > HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score10))
                rank = 9;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Time2, hiscoreData.Time1);
                    HiConvert.ByteArrayCopy(hiscoreData.Level2, hiscoreData.Level1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Time3, hiscoreData.Time2);
                    HiConvert.ByteArrayCopy(hiscoreData.Level3, hiscoreData.Level2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Time4, hiscoreData.Time3);
                    HiConvert.ByteArrayCopy(hiscoreData.Level4, hiscoreData.Level3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Time5, hiscoreData.Time4);
                    HiConvert.ByteArrayCopy(hiscoreData.Level5, hiscoreData.Level4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Time6, hiscoreData.Time5);
                    HiConvert.ByteArrayCopy(hiscoreData.Level6, hiscoreData.Level5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Time7, hiscoreData.Time6);
                    HiConvert.ByteArrayCopy(hiscoreData.Level7, hiscoreData.Level6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Time8, hiscoreData.Time7);
                    HiConvert.ByteArrayCopy(hiscoreData.Level8, hiscoreData.Level7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Time9, hiscoreData.Time8);
                    HiConvert.ByteArrayCopy(hiscoreData.Level9, hiscoreData.Level8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    HiConvert.ByteArrayCopy(hiscoreData.Time10, hiscoreData.Time9);
                    HiConvert.ByteArrayCopy(hiscoreData.Level10, hiscoreData.Level9);
                    if (rank < 8)
                        goto case 7;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Time1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time1.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level1, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time2.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level2, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time3.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level3, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time4.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level4, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time5.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level5, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time6, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time6.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level6, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time7, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time7.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level7, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time8, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time8.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level8, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time9, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time9.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level9, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level9.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time10, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(time, hiscoreData.Time10.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Level10, HiConvert.IntToByteArraySingleBCD(level, hiscoreData.Level10.Length));
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
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(0, hiscoreData.Score10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time1))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time2))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time3))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time4))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time5))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time6))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time7))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time8))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time9))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArraySingleBCDToInt(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), GetTime(HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Time10))), HiConvert.ByteArraySingleBCDToInt(hiscoreData.Level10)) + Environment.NewLine;

            return retString;
        }
    }
}
