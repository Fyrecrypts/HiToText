using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class bloodbro : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] HiScore;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 160)]
            public byte[] EntryArray;
        }

        public bloodbro()
        {
            m_numEntries = 20;
            m_format = "RANK|SCORE|NAME|AREA";
            m_gamesSupported = "bloodbro,weststry,bloodbra";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x20)
                    sb.Append(' ');
                else if (data[i] == 0x21)
                    sb.Append('!');
                else if (data[i] == 0x2e)
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
                    data[i] = 0x20;
                else if (str[i] == '!')
                    data[i] = 0x21;
                else if (str[i] == '.')
                    data[i] = 0x2e;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public int GetArea(string area)
        {
            return Convert.ToInt32(area.Replace("-", ""));
        }

        public string GetArea(int area)
        {
            return (area / 10).ToString() + "-" + (area % 10).ToString();
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int area = GetArea(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            int rank = NumEntries;
            int offset;

            #region DETERMINE_RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * 8; //The size of each entry.
                byte[] tmp = { 
                    hiscoreData.EntryArray[offset], 
                    hiscoreData.EntryArray[offset + 1], 
                    hiscoreData.EntryArray[offset + 2],
                    hiscoreData.EntryArray[offset + 3]};

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

                int offsetOldLoc = i * 8; //The size of each entry.
                int offsetNewLoc = (i + 1) * 8; //The size of each entry.

                for (int j = 0; j < 8; j++) //The size of each entry.
                {
                    hiscoreData.EntryArray[offsetNewLoc + j] = hiscoreData.EntryArray[offsetOldLoc + j];
                }
            }
            #endregion

            #region REPLACE_NEW
            if (rank < NumEntries)
            {
                offset = rank * 8; //The size of each score, and each name.
                byte[] newScore = HiConvert.IntToByteArrayHex(score, 4);
                byte[] newName = StringToByteArray(name);

                for (int i = 0; i < 8; i++) //The size of each entry
                {
                    if (i >= 0 && i <= 3)
                        hiscoreData.EntryArray[offset + i] = newScore[i];
                    else if (i >= 4 && i <= 6)
                        hiscoreData.EntryArray[offset + i] = newName[i - 4];
                    else
                        hiscoreData.EntryArray[offset + i] = HiConvert.IntToByteArrayHex(area, 1)[0];
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
                offset = i * 8; //The size of each score, and name.
                byte[] score = { 
                    hiscoreData.EntryArray[offset], 
                    hiscoreData.EntryArray[offset + 1], 
                    hiscoreData.EntryArray[offset + 2], 
                    hiscoreData.EntryArray[offset + 3]};
                byte[] name = { 
                    hiscoreData.EntryArray[offset + 4], 
                    hiscoreData.EntryArray[offset + 5], 
                    hiscoreData.EntryArray[offset + 6] };

                retString += String.Format("{0}|{1}|{2}|{3}",
                    i + 1,
                    HiConvert.ByteArrayHexToInt(score),
                    ByteArrayToString(name),
                    GetArea(Int32.Parse(hiscoreData.EntryArray[offset + 7].ToString("X2")))) + Environment.NewLine;
            }

            return retString;
        }
    }
}