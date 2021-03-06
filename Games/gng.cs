using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class gng : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] Ranks;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameJ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public gng()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "gng,gnga,gngt,makaimur,makaimuc,makaimug,gngbl,gngblita";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x1d)
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
                if (str[i] == '.')
                    data[i] = 0x1d;
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

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE POINTERS
            List<byte[]> Scores = new List<byte[]>();
            List<byte[]> Names = new List<byte[]>();

            byte rankLast;

            for (int i = 0; i < 10; i++)
            {
                int rankPointer = Convert.ToInt32(hiscoreData.Ranks[(i * 2) + 1]);
                switch (rankPointer)
                {
                    case 0x6b:
                        Scores.Add(hiscoreData.ScoreJ);
                        Names.Add(hiscoreData.NameJ);
                        break;
                    case 0x64:
                        Scores.Add(hiscoreData.ScoreI);
                        Names.Add(hiscoreData.NameI);
                        break;
                    case 0x5d:
                        Scores.Add(hiscoreData.ScoreH);
                        Names.Add(hiscoreData.NameH);
                        break;
                    case 0x56:
                        Scores.Add(hiscoreData.ScoreG);
                        Names.Add(hiscoreData.NameG);
                        break;
                    case 0x4F:
                        Scores.Add(hiscoreData.ScoreF);
                        Names.Add(hiscoreData.NameF);
                        break;
                    case 0x48:
                        Scores.Add(hiscoreData.ScoreE);
                        Names.Add(hiscoreData.NameE);
                        break;
                    case 0x41:
                        Scores.Add(hiscoreData.ScoreD);
                        Names.Add(hiscoreData.NameD);
                        break;
                    case 0x3A:
                        Scores.Add(hiscoreData.ScoreC);
                        Names.Add(hiscoreData.NameC);
                        break;
                    case 0x33:
                        Scores.Add(hiscoreData.ScoreB);
                        Names.Add(hiscoreData.NameB);
                        break;
                    case 0x2C:
                        Scores.Add(hiscoreData.ScoreA);
                        Names.Add(hiscoreData.NameA);
                        break;
                    default:
                        break;
                }
            }

            #endregion

            #region DETERMINE RANK
            int rank = 10;
            for (int i = 0; i < 10; i++)
            {
                if (score > HiConvert.ByteArrayHexToInt(Scores[i]))
                {
                    rank = i;
                    break;
                }
            }
            rankLast = hiscoreData.Ranks[19];
            #endregion

            #region ADJUST
            int adjust = 9;
            if (rank < 9)
                adjust = 8;
            switch (adjust)
            {
                case 0:
                    hiscoreData.Ranks[3] = hiscoreData.Ranks[1];
                    break;
                case 1:
                    hiscoreData.Ranks[5] = hiscoreData.Ranks[3];
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    hiscoreData.Ranks[7] = hiscoreData.Ranks[5];
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    hiscoreData.Ranks[9] = hiscoreData.Ranks[7];
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    hiscoreData.Ranks[11] = hiscoreData.Ranks[9];
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    hiscoreData.Ranks[13] = hiscoreData.Ranks[11];
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    hiscoreData.Ranks[15] = hiscoreData.Ranks[13];
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    hiscoreData.Ranks[17] = hiscoreData.Ranks[15];
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    hiscoreData.Ranks[19] = hiscoreData.Ranks[17];
                    if (rank < 8)
                        goto case 7;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            if (rank < 10)
            {
                HiConvert.ByteArrayCopy(Names[9], StringToByteArray(name));
                HiConvert.ByteArrayCopy(Scores[9], HiConvert.IntToByteArrayHex(score, Scores[9].Length));

                hiscoreData.Ranks[(rank * 2) + 1] = rankLast;

                if (rank == 0)
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreA, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreA.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreB, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreB.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreE, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreE.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreF, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreF.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreG, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreG.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreH, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreH.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreI, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreI.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreJ.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            for (int i = 0; i < 10; i++)
            {
                int rankPointer = Convert.ToInt32(hiscoreData.Ranks[(i * 2) + 1]);
                switch (rankPointer)
                {
                    case 0x6b:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreJ), 
                            ByteArrayToString(hiscoreData.NameJ)) + Environment.NewLine;
                        break;
                    case 0x64:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreI),
                            ByteArrayToString(hiscoreData.NameI)) + Environment.NewLine;
                        break;
                    case 0x5d:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreH),
                            ByteArrayToString(hiscoreData.NameH)) + Environment.NewLine;
                        break;
                    case 0x56:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreG),
                            ByteArrayToString(hiscoreData.NameG)) + Environment.NewLine;
                        break;
                    case 0x4F:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreF),
                            ByteArrayToString(hiscoreData.NameF)) + Environment.NewLine;
                        break;
                    case 0x48:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreE),
                            ByteArrayToString(hiscoreData.NameE)) + Environment.NewLine;
                        break;
                    case 0x41:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD),
                            ByteArrayToString(hiscoreData.NameD)) + Environment.NewLine;
                        break;
                    case 0x3A:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC),
                            ByteArrayToString(hiscoreData.NameC)) + Environment.NewLine;
                        break;
                    case 0x33:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreB),
                            ByteArrayToString(hiscoreData.NameB)) + Environment.NewLine;
                        break;
                    case 0x2C:
                        retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArrayHexToInt(hiscoreData.ScoreA),
                            ByteArrayToString(hiscoreData.NameA)) + Environment.NewLine;
                        break;
                    default:
                        break;
                }
            }

            return retString;
        }
    }
}

