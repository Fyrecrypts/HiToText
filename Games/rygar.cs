using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class rygar : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 459)]
            public byte[] EntryArray;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScoreShort;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] HiScoreLong;
        }

        public rygar()
        {
            m_numEntries = 50;
            m_format = "RANK|SCORE|NAME|ROUND|RANK DISPLAY";
            m_gamesSupported = "rygar,rygar2,rygarj,rygar3";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x5b)
                    sb.Append('.');
                else if (data[i] == 0x5c)
                    sb.Append('◉');
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
                    data[i] = 0x5b;
                else if (str[i] == '◉')
                    data[i] = 0x5c;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        private byte[] GetHiScoreLong(int score)
        {
            int numDigitsInScore = 8;

            StringBuilder sb = new StringBuilder();
            String strScore = score.ToString();
            strScore = strScore.PadLeft(numDigitsInScore, 'F');

            for (int i = 0; i < numDigitsInScore; i++)
            {
                if (strScore[i].Equals('F'))
                    sb.Append("01");
                else
                    sb.Append("6" + strScore[i].ToString());
            }

            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int round = System.Convert.ToInt32(args[3]);
            int rankDisplay = System.Convert.ToInt32(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            int rank = NumEntries;
            int offset;

            #region DETERMINE_RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * 9; //The size of each entry.
                byte[] tmp = { 
                    hiscoreData.EntryArray[offset + 1], 
                    hiscoreData.EntryArray[offset + 2], 
                    hiscoreData.EntryArray[offset + 3],
                    hiscoreData.EntryArray[offset + 4]};

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

                int offsetOldLoc = i * 9; //The size of each entry.
                int offsetNewLoc = (i + 1) * 9; //The size of each entry.

                for (int j = 0; j < 9; j++) //The size of each score.
                {
                    hiscoreData.EntryArray[offsetNewLoc + j] = hiscoreData.EntryArray[offsetOldLoc + j];
                }
            }
            #endregion

            #region REPLACE_NEW
            if (rank < NumEntries)
            {
                offset = rank * 9; //The size of each score, and each name.
                byte[] newScore = HiConvert.IntToByteArrayHex(score, 4);
                byte[] newName = StringToByteArray(name);
                byte bRound = (byte)round;
                byte bRank = (byte)rankDisplay;

                for (int i = 0; i < 9; i++) //The size of each entry
                {
                    if (i == 0)
                        hiscoreData.EntryArray[offset + i] = bRank;
                    else if (i >= 1 && i <= 4)
                        hiscoreData.EntryArray[offset + i] = newScore[i - 1];
                    else if (i >= 5 && i <= 7)
                        hiscoreData.EntryArray[offset + i] = newName[i - 5];
                    else
                        hiscoreData.EntryArray[offset + i] = bRound;
                }

                if (rank == 0)
                {
                    hiscoreData.HiScoreShort = HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScoreShort.Length));
                    hiscoreData.HiScoreLong = GetHiScoreLong(score);
                }
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            int offset;

            for (int i = 0; i < m_numEntries; i++)
            {
                offset = i * 9; //The size of each score, and name.
                byte[] score = { 
                    hiscoreData.EntryArray[offset + 1], 
                    hiscoreData.EntryArray[offset + 2], 
                    hiscoreData.EntryArray[offset + 3], 
                    hiscoreData.EntryArray[offset + 4]};
                byte[] name = { 
                    hiscoreData.EntryArray[offset + 5], 
                    hiscoreData.EntryArray[offset + 6], 
                    hiscoreData.EntryArray[offset + 7] };

                retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                    i + 1,
                    HiConvert.ByteArrayHexToInt(score),
                    ByteArrayToString(name),
                    Int32.Parse(hiscoreData.EntryArray[offset + 8].ToString("X2")),
                    Int32.Parse(hiscoreData.EntryArray[offset].ToString("X2"))) + Environment.NewLine;
            }

            return retString;
        }
    }
}