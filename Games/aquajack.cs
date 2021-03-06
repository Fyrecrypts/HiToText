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
    class aquajack : Hiscore
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

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Round10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte Separator1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte Separator2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte Separator3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte Separator4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte Separator5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte Separator6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            public byte Separator7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            public byte Separator8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            public byte Separator9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            public byte Separator10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Play10;
        }

        public TextParams tParams = new TextParams();

        public aquajack()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|ROUND|PLAY";
            m_gamesSupported = "aquajack,aquajckj";
            m_extensionsRequired = ".hi";

            tParams.Format =
                StringFormatFlag.NeedsSpecialMapping |
                StringFormatFlag.ASCIIStandard;

            tParams.AddMapping('←', 0x5e);
        }

        private int GetPlacement(int score, int round, HiscoreData hiscoreData)
        {
            int rank = NumEntries;
            List<int> rounds = new List<int>();
            List<int> scores = new List<int>();

            #region ADD TO LIST
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round1));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round2));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round3));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round4));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round5));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round6));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round7));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round8));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round9));
            rounds.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Round10));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score1));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score2));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score3));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score4));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score5));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score6));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score7));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score8));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score9));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score10));
            #endregion

            for (int i = 0; i < NumEntries; i++)
            {
                if (round >= rounds[i])
                {
                    if (score > scores[i])
                        return i;
                }
            }

            return rank;
        }

        private bool IsHighestScore(int score, HiscoreData hiscoreData)
        {
            List<int> scores = new List<int>();
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score1));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score2));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score3));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score4));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score5));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score6));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score7));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score8));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score9));
            scores.Add(HiConvert.ByteArrayHexToInt(hiscoreData.Score10));

            scores.Sort();

            if (score > scores[9])
                return true;

            return false;
        }

        public override void SetHiScore(string[] args)
        {
            //int rankGiven = Convert.ToInt32(args[0]);
            int score = Convert.ToInt32(args[1]);
            string name = args[2].PadRight(3, ' ').Substring(0, 3);
            int round = Convert.ToInt32(args[3]) - 1;
            int play = Convert.ToInt32(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            Regex rxScore = new Regex("^Score.*$");
            Regex rxName = new Regex("^Name.*$");
            Regex rxRound = new Regex("^Round.*$");
            Regex rxPlay = new Regex("^Play.*$");

            int rank = GetPlacement(score, round, hiscoreData);

            //Since the high score area is for the highest score, we can't just trust rank.
            if (IsHighestScore(score, hiscoreData))
                HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));

            //Adjusting lower scores.
            List<Regex> adjusters = new List<Regex>(new Regex[] { rxScore, rxName, rxRound, rxPlay });
            hiscoreData = (HiscoreData)HTTF.AdjustScores(rank, hiscoreData, adjusters);

            //Replacing new scores.
            //Delegate creation.
            VBA dScore = SetScore.ConvertData(score, hiscoreData.Score1.Length, HiConvert.IntToByteArrayHex);
            VBA dRound = SetScore.ConvertData(round, hiscoreData.Round1.Length, HiConvert.IntToByteArrayHex);
            VBA dPlays = SetScore.ConvertData(play, hiscoreData.Play1.Length, HiConvert.IntToByteArrayHex);

            //Placement creation.
            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, rxName, SetScore.ConvertName(tParams)));
            placements.Add(new Placement(score.ToString(), rxScore, dScore));
            placements.Add(new Placement(round.ToString(), rxRound, dRound));
            placements.Add(new Placement(play.ToString(), rxPlay, dPlays));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void ModifyName(int rank, string name)
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            List<Placement> placements = new List<Placement>();
            placements.Add(new Placement(name, new Regex("^Name.*$"), SetScore.ConvertName(tParams)));

            hiscoreData = (HiscoreData)HTTF.ReplaceNew(rank - 1, hiscoreData, placements);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            VBA dScore = SetScore.ConvertData(0, hiscoreData.Score1.Length, HiConvert.IntToByteArrayHex);
            VBA dRound = SetScore.ConvertData(0, hiscoreData.Round1.Length, HiConvert.IntToByteArrayHex);

            //We also want to get the top score and empty that.
            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^.*Score.*$"), dScore);
            //Round is also a determining factor for determining scores.
            hiscoreData = (HiscoreData)HTTF.EmptyScores(hiscoreData, new Regex("^Round.*$"), dRound);

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
            formatting.Add(new DisplayData(new Regex("^Score.*$"), HiToStr.Standard));
            formatting.Add(new DisplayData(new Regex("^Name.*$"), HiToStr.ConvertName(tParams)));
            formatting.Add(new DisplayData(new Regex("^Round.*$"), HiToStr.AddToDisplayed(HiToStr.Standard, 1)));
            formatting.Add(new DisplayData(new Regex("^Play.*$"), HiToStr.Standard));

            retString += HTTF.HiToString(hiscoreData, formatting);

            return retString;
        }
    }
}
