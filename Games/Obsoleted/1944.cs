using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using SetScore = HiToText.Formatting.ConvertValuesToBytes;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;
using TextParams = HiToText.Utils.TextDecodingParameters;
using HiToText.Utils;

namespace HiGames
{
    class _1944 : Hiscore
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
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] UnusedA;

            public byte Stage1;
            public byte StartStage1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB1;

            public byte Stage2;
            public byte StartStage2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB2;

            public byte Stage3;
            public byte StartStage3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB3;

            public byte Stage4;
            public byte StartStage4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB4;

            public byte Stage5;
            public byte StartStage5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB5;

            public byte Stage6;
            public byte StartStage6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB6;

            public byte Stage7;
            public byte StartStage7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB7;

            public byte Stage8;
            public byte StartStage8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB8;

            public byte Stage9;
            public byte StartStage9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] UnusedB9;

            public byte Stage10;
            public byte StartStage10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate1;
            public byte UnusedC1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate2;
            public byte UnusedC2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate3;
            public byte UnusedC3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate4;
            public byte UnusedC4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate5;
            public byte UnusedC5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate6;
            public byte UnusedC6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate7;
            public byte UnusedC7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate8;
            public byte UnusedC8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate9;
            public byte UnusedC9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] DestroyRate10;
            public byte UnusedC10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name1;
            public byte UnusedD1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name2;
            public byte UnusedD2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name3;
            public byte UnusedD3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name4;
            public byte UnusedD4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name5;
            public byte UnusedD5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name6;
            public byte UnusedD6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name7;
            public byte UnusedD7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name8;
            public byte UnusedD8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name9;
            public byte UnusedD9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Name10;
        }

        public TextParams tParams = new TextParams();

        public _1944()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|STAGE|START STAGE|DESTROY RATE";
            m_gamesSupported = "1944,1944j,1944d";
            m_extensionsRequired = ".hi";

            tParams.Format =
                StringFormatFlag.NeedsSpecialMapping |
                StringFormatFlag.ASCIIUpper;

            tParams.AddMapping('!', 0x34);
            tParams.AddMapping('&', 0x36);
            tParams.AddMapping('.', 0x38);
            tParams.AddMapping('@', 0x3a);
            tParams.AddMapping('♂', 0x3c);
            tParams.AddMapping('♀', 0x3e);
            tParams.AddMapping('♥', 0x40);
            tParams.AddMapping('☺', 0x42);
            tParams.AddMapping(' ', 0x44);

            tParams.AddOffset(new Offset(0x00, 2, Offset.FlagOffsets.Upper));

            tParams.ByteSkipAmount = 2;
        }

        public string ConvertName(byte[] name)
        {
            return HTTF.ByteToString(name, tParams);
        }

        public string ConvertStage(byte[] stage)
        {
            return ((int)stage[0] + 1).ToString();
        }

        public string ConvertDestroyRate(byte[] dRate)
        {
            return HiConvert.ByteArraySingleBCDToInt(dRate).ToString() + "%";
        }

        public byte[] ConvertName(string name)
        {
            return HTTF.StringToByte(name, tParams);
        }

        public byte[] ConvertScore(string score)
        {
            return HiConvert.IntToByteArrayHex(Convert.ToInt32(score), 4);
        }

        public byte[] ConvertDestroyRate(string dRate)
        {
            return HiConvert.IntToByteArraySingleBCD(Convert.ToInt32(dRate.Replace("%", String.Empty)), 3);
        }

        public override void SetHiScore(string[] args)
        {
            //int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int stage = System.Convert.ToInt32(args[3]) - 1;
            int startStage = System.Convert.ToInt32(args[4]) - 1;
            string destroyRate = args[5];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score.*$");
            Regex rxName = new Regex("^Name.*$");
            Regex rxStage = new Regex("^Stage.*$");
            Regex rxStartStage = new Regex("^StartStage.*$");
            Regex rxDestroyRate = new Regex("^DestroyRate.*$");

            //Determining rank.
            int rank = HTTF.DetermineRank(
                score, rxScore, hiscoreData, HTTF.ByteArrayToInt.Standard);

            //Adjusting lower scores.
            List<Regex> adjusters = 
                new List<Regex>(new Regex[] { rxScore, rxName, rxStage, rxStartStage, rxDestroyRate });
            hiscoreData = (HiscoreData)HTTF.AdjustScores(rank, hiscoreData, adjusters);

            //Replacing new scores.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, rxName, ConvertName));
            placements.Add(new Placement(score.ToString(), rxScore, ConvertScore));
            placements.Add(new Placement(score.ToString(), new Regex("^HiScore$"), true, ConvertScore));
            placements.Add(new Placement(stage.ToString(), rxStage, HTTF.ConvertValuesToBytes.ConvertByte));
            placements.Add(new Placement(startStage.ToString(), rxStartStage, HTTF.ConvertValuesToBytes.ConvertByte));
            placements.Add(new Placement(destroyRate, rxDestroyRate, ConvertDestroyRate));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public void ModifyName(int rank, string name)
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, new Regex("^Name.*$"), ConvertName));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank - 1, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^.*Score.*$"), ConvertScore);

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

            //Rank.
            formatting.Add(new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1));
            formatting.Add(new DisplayData(
                new Regex("^Score.*$"), HiToStr.Standard));
            formatting.Add(new DisplayData(new Regex("^Name.*$"), ConvertName));
            formatting.Add(new DisplayData(new Regex("^Stage.*$"), ConvertStage));
            formatting.Add(new DisplayData(new Regex("^StartStage.*$"), ConvertStage));
            formatting.Add(new DisplayData(new Regex("^DestroyRate.*$"), ConvertDestroyRate));

            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}