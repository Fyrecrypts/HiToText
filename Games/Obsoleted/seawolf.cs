using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class seawolf : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Score;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Dummy1;           
        }

        public seawolf()
        {
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "seawolf";
            m_extensionsRequired = ".hi";
        }

       public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0]) / 100;
            
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
           
            HiConvert.ByteArrayCopy(hiscoreData.Score, HiConvert.IntToByteArrayHex(score, hiscoreData.Score.Length));
              
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            HiConvert.ByteArrayCopy(hiscoreData.Score, HiConvert.IntToByteArrayHex(0, hiscoreData.Score.Length));
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = Format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", HiConvert.ByteArrayHexToInt(hiscoreData.Score) * 100) + Environment.NewLine;
         
            return retString;
        }
    }
}

