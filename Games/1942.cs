using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using SetScore = HiToText.Formatting.ConvertValuesToBytes;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;
using TextParams = HiToText.Utils.TextDecodingParameters;

namespace HiGames
{
    class _1942 : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte Rank;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name;

            public byte Stage;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Unknown;
        }

        public TextParams tParams = new TextParams();

        public _1942()
        {
            m_numEntries = 25;
            m_format = "RANK|SCORE|NAME|STAGE";
            m_gamesSupported = "1942,1942a,1942b,1942w";
            m_extensionsRequired = ".hi";

            tParams.Format =
                StringFormatFlag.NeedsSpecialMapping |
                StringFormatFlag.ASCIIUpper;

            tParams.AddMapping('.', 0x24);
            tParams.AddMapping('-', 0x25);
            tParams.AddMapping('&', 0x26);
            tParams.AddMapping('?', 0x27);
            tParams.AddMapping('!', 0x28);
            tParams.AddMapping('%', 0x29);
            tParams.AddMapping('(', 0x2a);
            tParams.AddMapping(')', 0x2b);
            tParams.AddMapping('♂', 0x2c);
            tParams.AddMapping('♀', 0x2d);
            tParams.AddMapping('♥', 0x2e);
            tParams.AddMapping(' ', 0x30);
            tParams.AddMapping('©', 0x38);

            tParams.AddOffset(new Offset(0x0a, Offset.FlagOffsets.Upper));
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = System.Convert.ToInt32(args[0]) - 1;
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int stage = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData.Score = HiConvert.IntToByteArrayHex(score, 4);
            hiscoreData.Name = new byte[8];
            hiscoreData.Stage = (byte)stage;

            HiConvert.ByteArrayCopy(hiscoreData.Name, HTTF.StringToByte(name, tParams));

            #region ORGANIZE EXISTING SCORES
            List<HiscoreData> scores = new List<HiscoreData>();
            for (int i = 0; i < m_numEntries; i++)
            {
                HiscoreData hsd = new HiscoreData();
                hsd = (HiscoreData)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreData));

                scores.Add(hsd);
            }

            scores.Sort(new _1942Comparator());
            #endregion

            #region DETERMINE RANK
            int rank = NumEntries;
            int counter = 0;
            foreach (HiscoreData hiscore in scores)
            {
                if (score > HiConvert.ByteArrayHexToInt(hiscore.Score))
                {
                    rank = counter;
                    break;
                }
                counter++;
            }
            //No need to adjust anything, or write any scores, the rank is not high enough
            //to be written.
            if (rank == NumEntries)
                return;

            hiscoreData.Rank = (byte)rank;
            #endregion

            #region ADJUST
            for (int i = 0; i < NumEntries; i++)
            {
                int rankToAdjust =
                    HiConvert.ByteArrayHexAsHexToInt(new byte[] { m_data[i * Marshal.SizeOf(typeof(HiscoreData))] });

                //Even adjust the 24th to 25, we will replace 25 with a correct rank later.
                if (rank <= rankToAdjust)
                    m_data[i * Marshal.SizeOf(typeof(HiscoreData))] = HiConvert.IntToByteArrayHexAsHex(rankToAdjust + 1, 1)[0];
            }
            #endregion

            #region REPLACE NEW
            for (int i = 0; i < NumEntries; i++)
            {
                int rankToReplace =
                    HiConvert.ByteArrayHexAsHexToInt(new byte[] { m_data[i * Marshal.SizeOf(typeof(HiscoreData))] });

                //The one we want to replace will be 25.
                if (rankToReplace == NumEntries)
                {
                    byte[] byteArray = HiConvert.RawSerialize(hiscoreData);
                    for (int j = 0; j < byteArray.Length; j++)
                        m_data[i * Marshal.SizeOf(typeof(HiscoreData)) + j] = byteArray[j];
                }
            }
            //Must change "Top Score" section as well.
            if (rank == 0)
                SetTopScore(score, stage);
            #endregion
        }

        public override void ModifyName(int rank, string name)
        {
            #region ORGANIZE EXISTING SCORES
            List<HiscoreData> scores = new List<HiscoreData>();
            for (int i = 0; i < m_numEntries; i++)
            {
                HiscoreData hsd = new HiscoreData();
                hsd = (HiscoreData)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreData));

                scores.Add(hsd);
            }

            scores.Sort(new _1942Comparator());
            #endregion

            HiscoreData hiscoreData = scores[rank - 1];
            hiscoreData.Name = HTTF.StringToByte(name, tParams); 

            for (int i = 0; i < NumEntries; i++)
            {
                int rankToReplace =
                    HiConvert.ByteArrayHexAsHexToInt(new byte[] { m_data[i * Marshal.SizeOf(typeof(HiscoreData))] });

                if (rankToReplace == Convert.ToInt32(hiscoreData.Rank.ToString("X2")))
                {
                    byte[] byteArray = HiConvert.RawSerialize(hiscoreData);
                    for (int j = 0; j < byteArray.Length; j++)
                        m_data[i * Marshal.SizeOf(typeof(HiscoreData)) + j] = byteArray[j];
                }
            }
        }

        public override void EmptyScores()
        {
            for (int i = 0; i < NumEntries; i++)
            {
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 1] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 2] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 3] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 4] = 0x00;
            }
            SetTopScore(0, 0);
            SaveData();
        }

        private void SetTopScore(int score, int stage)
        {
            int bytesInTopScore = 8;
            int topScoreOffset = m_numEntries * Marshal.SizeOf(typeof(HiscoreData)) + 1; //+1 because we ignore the completed % for now.
            byte[] scoreAsBytes = IntToByteArrayTopScore(score, bytesInTopScore);

            for (int i = 0; i < bytesInTopScore; i++)
                m_data[topScoreOffset + i] = scoreAsBytes[i];
            
            m_data[topScoreOffset + scoreAsBytes.Length] = (byte) stage;
        }

        public static byte[] IntToByteArrayTopScore(int value, int lenOfByteArray)
        {
            string valueAsString = value.ToString();
            byte[] byteToRet = new byte[lenOfByteArray];

            for (int i = 0; i < lenOfByteArray; i++)
            {
                if (i < lenOfByteArray - valueAsString.Length)
                    byteToRet[i] = 0;
                else
                    byteToRet[i] = System.Convert.ToByte(valueAsString.Substring(i - (lenOfByteArray - valueAsString.Length), 1));
            }
            return byteToRet;
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            List<HiscoreData> scores = new List<HiscoreData>();

            for (int i = 0; i < m_numEntries; i++)
            {
                HiscoreData hiscoreData = new HiscoreData();
                hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreData));
                
                scores.Add(hiscoreData);
            }

            scores.Sort(new _1942Comparator());

            for (int i = 0; i < m_numEntries; i++)
            {
                HiscoreData hiscoreData = scores[i];
                retString += String.Format("{0}|{1}|{2}|{3}", 
                    i + 1,
                    HiConvert.ByteArrayHexToInt(hiscoreData.Score),
                    HTTF.ByteToString(hiscoreData.Name, tParams), 
                    (int) hiscoreData.Stage) + Environment.NewLine;
            }

            return retString;
        }
    }

    class _1942Comparator : IComparer<_1942.HiscoreData>
    {
        #region IComparer<HiscoreData> Members

        public int Compare(_1942.HiscoreData x, _1942.HiscoreData y)
        {
            return HiConvert.ByteArrayHexToInt(y.Score).CompareTo(HiConvert.ByteArrayHexToInt(x.Score));
        }

        #endregion
    }
}
