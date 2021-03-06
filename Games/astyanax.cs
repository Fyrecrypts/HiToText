using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using SetScore = HiToText.Formatting.ConvertValuesToBytes;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;
using TextParams = HiToText.Utils.TextDecodingParameters;

namespace HiGames
{
    class astyanax : Hiscore
    {
        // The Top Score is 99999990
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Colours1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Rank1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Colours2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Rank2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Colours3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Rank3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Colours4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Rank4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Colours5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Rank5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] HiScore;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] HiScoreText;
        }

        public TextParams tParams = new TextParams();

        public astyanax()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|STAGE";
            m_gamesSupported = "astyanax,lordofk";
            m_extensionsRequired = ".hi";

            tParams.Format = StringFormatFlag.ASCIIStandard;
        }

        public byte[] ShorterByteArray(byte[] byteArray)
        {
            byte[] newData = new byte[byteArray.Length / 2];
            int count = 0;

            for (int i = 1; i < byteArray.Length; i = i + 2)
            {
                newData[count] = byteArray[i];
                count++;
            }
            return newData;
        }

        public byte[] LongerByteArray(byte[] byteArray)
        {
            byte[] newData = new byte[byteArray.Length * 2];
            int count = 0;

            for (int i = 0; i < newData.Length; i = i + 2)
            {
                newData[i] = 0x00;
                newData[i + 1] = byteArray[count];
                count++;
            }
            return newData;
        }

        public byte[] IntToByteArrayAsChar(int value, int numBytes)
        {
            byte[] data = new byte[numBytes];
            String str = value.ToString().PadLeft(numBytes,(char)0x00);

            for (int i = 0 ; i < numBytes ; i++)
                data[i] = (byte)((int)str[i]);

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            //int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper().PadRight(3, ' ').Substring(0, 3);
            int stage = System.Convert.ToInt32(args[3]);
            if (stage > 9) 
                stage = 9;

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score.*$");
            Regex rxName = new Regex("^Name.*$");
            Regex rxStage = new Regex("^Stage.*$");
            Regex rxHiScore = new Regex("^HiScore$");
            Regex rxHiScoreText = new Regex("^HiScoreText$");

            //Determining rank.
            int rank = HTTF.DetermineRank(score, rxScore, hiscoreData,
                HTTF.ByteArrayToInt.CustomInternal(HiConvert.ByteArraySingleBCDToInt, ShorterByteArray));

            //Adjusting lower scores.
            List<Regex> adjusters = new List<Regex>(new Regex[] { rxScore, rxName, rxStage });
            hiscoreData = (HiscoreData)HTTF.AdjustScores(rank, hiscoreData, adjusters);

            //Replacing new scores.
            //Delegate creation.
            VBA dName = SetScore.ConvertName(tParams, LongerByteArray);
            VBA dScore = SetScore.ConvertData(score, 8, HiConvert.IntToByteArraySingleBCD, LongerByteArray);
            VBA dStage = SetScore.ConvertData(stage, hiscoreData.Stage1.Length, IntToByteArrayAsChar);
            VBA dHiTxt = SetScore.ConvertData(score, hiscoreData.HiScoreText.Length, IntToByteArrayAsChar);

            //Placement creation.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, rxName, dName));
            placements.Add(new Placement(score.ToString(), rxScore, dScore));
            placements.Add(new Placement(score.ToString(), rxHiScore, true, dScore));
            placements.Add(new Placement(score.ToString(), rxHiScoreText, true, dHiTxt));
            placements.Add(new Placement(stage.ToString(), rxStage, dStage));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void ModifyName(int rank, string name)
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            //Delegate creation.
            VBA dName = SetScore.ConvertName(tParams, LongerByteArray);
            
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, new Regex("^Name.*$"), dName));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank - 1, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            //Delegate creation.
            VBA dScore = SetScore.ConvertData(0, 8, HiConvert.IntToByteArraySingleBCD, LongerByteArray);
            VBA dHiTxt = SetScore.ConvertData(0, 8, IntToByteArrayAsChar);

            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^Score.*$"), dScore);
            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^HiScore$"), dScore);
            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^HiScoreText$"), dHiTxt);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            List<DisplayData> formatting = new List<DisplayData>();
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(new Regex("^Score.*$"),
                HiToStr.CustomInternal(HiToStr.BCD, ShorterByteArray)));
            formatting.Add(new DisplayData(new Regex("^Name.*$"),
                HiToStr.ConvertName(tParams, ShorterByteArray)));
            formatting.Add(new DisplayData(new Regex("^Stage.*$"),
                HiToStr.CustomInternal(HiConvert.ByteArrayToString, ShorterByteArray)));

            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}