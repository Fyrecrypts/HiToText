using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class ddribble : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Month1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Day1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Month2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Day2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Month3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Day3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Month4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Day4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Month5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Day5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Month6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Day6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Month7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Day7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Month8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Day8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Points1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Points2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Points3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Points4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Points5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Points6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Points7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Points8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FG1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FG2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FG3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FG4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FG5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FG6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FG7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FG8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FT1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FT2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FT3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FT4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FT5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FT6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FT7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FT8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] REBS1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] REBS2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] REBS3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] REBS4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] REBS5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] REBS6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] REBS7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] REBS8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] ASST1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] ASST2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] ASST3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] ASST4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] ASST5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] ASST6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] ASST7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] ASST8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] PF1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] PF2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] PF3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] PF4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] PF5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] PF6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] PF7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] PF8;
        }

        public ddribble()
        {
            m_numEntries = 8;
            m_format = "RANK|NAME|MONTH|DAY|POINTS|FG%|FT%|REBS|ASST|PF";
            m_gamesSupported = "ddribble";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x11 && data[i] <= 0x2a)
                    sb.Append(((char)((((int)data[i])) + 65 - 0x11)));
                else if (data[i] == 0x0a)
                    sb.Append('.');
            }
                                     
            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int numBytes)
        {
            str = str.PadRight(numBytes, ' ');
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65 + 0x11));
                else if (str[i] == '.')
                    data[i] = 0x0a;
            }

            return data;
        }

        private string GetPercent(byte[] data, int numBytes)
        {
            StringBuilder str = new StringBuilder();
            if (data[0] == 0xaa)
                str.Append("Perfect");
            else
            {
                str.Append(".");
                str.Append(HiConvert.ByteArrayHexToInt(data));
            }
            
            return str.ToString();
        }

        private byte[] SetPercent(string str, int numBytes)
        {
            // if you have 100% in FG or FT the program set the AAAA bytes.
            int data;
            if (str == "1" || str == "Perfect")
            {
                data = 0xAAAA;
                return HiConvert.HexStringToByteArray(data.ToString("X4"));
            }
            else if (str.Substring(0, 1) == ".")
                data = System.Convert.ToInt16(str.Substring(1, str.Length - 1));
            else if (str.Substring(0, 2) == "0.")
                data = System.Convert.ToInt16(str.Substring(2, str.Length - 2));
            else
                data = System.Convert.ToInt16(str);

            return HiConvert.HexStringToByteArray(data.ToString("D"+(numBytes*2)));
        }


        public override void SetHiScore(string[] args)
        { 
            int rankGiven = Convert.ToInt32(args[0]);
            string name = args[1];
            int month = Convert.ToInt32(args[2]);
            int day = Convert.ToInt32(args[3]);
            int points = Convert.ToInt32(args[4]);
            string fg = args[5];
            string ft = args[6];            
            int rebs = Convert.ToInt32(args[7]);
            int asst = Convert.ToInt32(args[8]);
            int pf = Convert.ToInt32(args[9]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (points > HiConvert.ByteArrayHexToInt(hiscoreData.Points1))
                rank = 0;
            else if (points > HiConvert.ByteArrayHexToInt(hiscoreData.Points2))
                rank = 1;
            else if (points > HiConvert.ByteArrayHexToInt(hiscoreData.Points3))
                rank = 2;
            else if (points > HiConvert.ByteArrayHexToInt(hiscoreData.Points4))
                rank = 3;
            else if (points > HiConvert.ByteArrayHexToInt(hiscoreData.Points5))
                rank = 4;
            else if (points > HiConvert.ByteArrayHexToInt(hiscoreData.Points6))
                rank = 5;
            else if (points > HiConvert.ByteArrayHexToInt(hiscoreData.Points7))
                rank = 6;
            else if (points > HiConvert.ByteArrayHexToInt(hiscoreData.Points8))
                rank = 7;            
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:                    
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    HiConvert.ByteArrayCopy(hiscoreData.Month2, hiscoreData.Month1);
                    HiConvert.ByteArrayCopy(hiscoreData.Day2, hiscoreData.Day1);                    
                    HiConvert.ByteArrayCopy(hiscoreData.Points2, hiscoreData.Points1);
                    HiConvert.ByteArrayCopy(hiscoreData.FG2, hiscoreData.FG1);
                    HiConvert.ByteArrayCopy(hiscoreData.FT2, hiscoreData.FT1);
                    HiConvert.ByteArrayCopy(hiscoreData.REBS2, hiscoreData.REBS1);
                    HiConvert.ByteArrayCopy(hiscoreData.ASST2, hiscoreData.ASST1);
                    HiConvert.ByteArrayCopy(hiscoreData.PF2, hiscoreData.PF1);                    
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Month3, hiscoreData.Month2);
                    HiConvert.ByteArrayCopy(hiscoreData.Day3, hiscoreData.Day2);
                    HiConvert.ByteArrayCopy(hiscoreData.Points3, hiscoreData.Points2);
                    HiConvert.ByteArrayCopy(hiscoreData.FG3, hiscoreData.FG2);
                    HiConvert.ByteArrayCopy(hiscoreData.FT3, hiscoreData.FT2);
                    HiConvert.ByteArrayCopy(hiscoreData.REBS3, hiscoreData.REBS2);
                    HiConvert.ByteArrayCopy(hiscoreData.ASST3, hiscoreData.ASST2);
                    HiConvert.ByteArrayCopy(hiscoreData.PF3, hiscoreData.PF2);   
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Month4, hiscoreData.Month3);
                    HiConvert.ByteArrayCopy(hiscoreData.Day4, hiscoreData.Day3);
                    HiConvert.ByteArrayCopy(hiscoreData.Points4, hiscoreData.Points3);
                    HiConvert.ByteArrayCopy(hiscoreData.FG4, hiscoreData.FG3);
                    HiConvert.ByteArrayCopy(hiscoreData.FT4, hiscoreData.FT3);
                    HiConvert.ByteArrayCopy(hiscoreData.REBS4, hiscoreData.REBS3);
                    HiConvert.ByteArrayCopy(hiscoreData.ASST4, hiscoreData.ASST3);
                    HiConvert.ByteArrayCopy(hiscoreData.PF4, hiscoreData.PF3);   
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Month5, hiscoreData.Month4);
                    HiConvert.ByteArrayCopy(hiscoreData.Day5, hiscoreData.Day4);
                    HiConvert.ByteArrayCopy(hiscoreData.Points5, hiscoreData.Points4);
                    HiConvert.ByteArrayCopy(hiscoreData.FG5, hiscoreData.FG4);
                    HiConvert.ByteArrayCopy(hiscoreData.FT5, hiscoreData.FT4);
                    HiConvert.ByteArrayCopy(hiscoreData.REBS5, hiscoreData.REBS4);
                    HiConvert.ByteArrayCopy(hiscoreData.ASST5, hiscoreData.ASST4);
                    HiConvert.ByteArrayCopy(hiscoreData.PF5, hiscoreData.PF4);   
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Month6, hiscoreData.Month5);
                    HiConvert.ByteArrayCopy(hiscoreData.Day6, hiscoreData.Day5);
                    HiConvert.ByteArrayCopy(hiscoreData.Points6, hiscoreData.Points5);
                    HiConvert.ByteArrayCopy(hiscoreData.FG6, hiscoreData.FG5);
                    HiConvert.ByteArrayCopy(hiscoreData.FT6, hiscoreData.FT5);
                    HiConvert.ByteArrayCopy(hiscoreData.REBS6, hiscoreData.REBS5);
                    HiConvert.ByteArrayCopy(hiscoreData.ASST6, hiscoreData.ASST5);
                    HiConvert.ByteArrayCopy(hiscoreData.PF6, hiscoreData.PF5);   
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Month7, hiscoreData.Month6);
                    HiConvert.ByteArrayCopy(hiscoreData.Day7, hiscoreData.Day6);
                    HiConvert.ByteArrayCopy(hiscoreData.Points7, hiscoreData.Points6);
                    HiConvert.ByteArrayCopy(hiscoreData.FG7, hiscoreData.FG6);
                    HiConvert.ByteArrayCopy(hiscoreData.FT7, hiscoreData.FT6);
                    HiConvert.ByteArrayCopy(hiscoreData.REBS7, hiscoreData.REBS6);
                    HiConvert.ByteArrayCopy(hiscoreData.ASST7, hiscoreData.ASST6);
                    HiConvert.ByteArrayCopy(hiscoreData.PF7, hiscoreData.PF6);   
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Month8, hiscoreData.Month7);
                    HiConvert.ByteArrayCopy(hiscoreData.Day8, hiscoreData.Day7);
                    HiConvert.ByteArrayCopy(hiscoreData.Points8, hiscoreData.Points7);
                    HiConvert.ByteArrayCopy(hiscoreData.FG8, hiscoreData.FG7);
                    HiConvert.ByteArrayCopy(hiscoreData.FT8, hiscoreData.FT7);
                    HiConvert.ByteArrayCopy(hiscoreData.REBS8, hiscoreData.REBS7);
                    HiConvert.ByteArrayCopy(hiscoreData.ASST8, hiscoreData.ASST7);
                    HiConvert.ByteArrayCopy(hiscoreData.PF8, hiscoreData.PF7);   
                    if (rank < 6)
                        goto case 5;
                    break;               
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Month1, HiConvert.IntToByteArrayHex(month, hiscoreData.Month1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Day1, HiConvert.IntToByteArrayHex(day, hiscoreData.Day1.Length));               
                    HiConvert.ByteArrayCopy(hiscoreData.Points1, HiConvert.IntToByteArrayHex(points, hiscoreData.Points1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FG1, SetPercent(fg, hiscoreData.FG1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FT1, SetPercent(ft, hiscoreData.FT1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.REBS1, HiConvert.IntToByteArrayHex(rebs, hiscoreData.REBS1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ASST1, HiConvert.IntToByteArrayHex(asst, hiscoreData.ASST1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.PF1, HiConvert.IntToByteArrayHex(pf, hiscoreData.PF1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Month2, HiConvert.IntToByteArrayHex(month, hiscoreData.Month2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Day2, HiConvert.IntToByteArrayHex(day, hiscoreData.Day2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Points2, HiConvert.IntToByteArrayHex(points, hiscoreData.Points2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FG2, SetPercent(fg, hiscoreData.FG2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FT2, SetPercent(ft, hiscoreData.FT2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.REBS2, HiConvert.IntToByteArrayHex(rebs, hiscoreData.REBS2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ASST2, HiConvert.IntToByteArrayHex(asst, hiscoreData.ASST2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.PF2, HiConvert.IntToByteArrayHex(pf, hiscoreData.PF2.Length));                    
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Month3, HiConvert.IntToByteArrayHex(month, hiscoreData.Month3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Day3, HiConvert.IntToByteArrayHex(day, hiscoreData.Day3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Points3, HiConvert.IntToByteArrayHex(points, hiscoreData.Points3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FG3, SetPercent(fg, hiscoreData.FG3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FT3, SetPercent(ft, hiscoreData.FT3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.REBS3, HiConvert.IntToByteArrayHex(rebs, hiscoreData.REBS3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ASST3, HiConvert.IntToByteArrayHex(asst, hiscoreData.ASST3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.PF3, HiConvert.IntToByteArrayHex(pf, hiscoreData.PF3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, hiscoreData.Name4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Month4, HiConvert.IntToByteArrayHex(month, hiscoreData.Month4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Day4, HiConvert.IntToByteArrayHex(day, hiscoreData.Day4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Points4, HiConvert.IntToByteArrayHex(points, hiscoreData.Points4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FG4, SetPercent(fg, hiscoreData.FG4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FT4, SetPercent(ft, hiscoreData.FT4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.REBS4, HiConvert.IntToByteArrayHex(rebs, hiscoreData.REBS4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ASST4, HiConvert.IntToByteArrayHex(asst, hiscoreData.ASST4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.PF4, HiConvert.IntToByteArrayHex(pf, hiscoreData.PF4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, hiscoreData.Name5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Month5, HiConvert.IntToByteArrayHex(month, hiscoreData.Month5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Day5, HiConvert.IntToByteArrayHex(day, hiscoreData.Day5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Points5, HiConvert.IntToByteArrayHex(points, hiscoreData.Points5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FG5, SetPercent(fg, hiscoreData.FG5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FT5, SetPercent(ft, hiscoreData.FT5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.REBS5, HiConvert.IntToByteArrayHex(rebs, hiscoreData.REBS5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ASST5, HiConvert.IntToByteArrayHex(asst, hiscoreData.ASST5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.PF5, HiConvert.IntToByteArrayHex(pf, hiscoreData.PF5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name, hiscoreData.Name6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Month6, HiConvert.IntToByteArrayHex(month, hiscoreData.Month6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Day6, HiConvert.IntToByteArrayHex(day, hiscoreData.Day6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Points6, HiConvert.IntToByteArrayHex(points, hiscoreData.Points6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FG6, SetPercent(fg, hiscoreData.FG6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FT6, SetPercent(ft, hiscoreData.FT6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.REBS6, HiConvert.IntToByteArrayHex(rebs, hiscoreData.REBS6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ASST6, HiConvert.IntToByteArrayHex(asst, hiscoreData.ASST6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.PF6, HiConvert.IntToByteArrayHex(pf, hiscoreData.PF6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name, hiscoreData.Name7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Month7, HiConvert.IntToByteArrayHex(month, hiscoreData.Month7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Day7, HiConvert.IntToByteArrayHex(day, hiscoreData.Day7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Points7, HiConvert.IntToByteArrayHex(points, hiscoreData.Points7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FG7, SetPercent(fg, hiscoreData.FG7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FT7, SetPercent(ft, hiscoreData.FT7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.REBS7, HiConvert.IntToByteArrayHex(rebs, hiscoreData.REBS7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ASST7, HiConvert.IntToByteArrayHex(asst, hiscoreData.ASST7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.PF7, HiConvert.IntToByteArrayHex(pf, hiscoreData.PF7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name, hiscoreData.Name8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Month8, HiConvert.IntToByteArrayHex(month, hiscoreData.Month8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Day8, HiConvert.IntToByteArrayHex(day, hiscoreData.Day8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Points8, HiConvert.IntToByteArrayHex(points, hiscoreData.Points8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FG8, SetPercent(fg, hiscoreData.FG8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.FT8, SetPercent(ft, hiscoreData.FT8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.REBS8, HiConvert.IntToByteArrayHex(rebs, hiscoreData.REBS8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.ASST8, HiConvert.IntToByteArrayHex(asst, hiscoreData.ASST8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.PF8, HiConvert.IntToByteArrayHex(pf, hiscoreData.PF8.Length));
                    break;        
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        { 
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            HiConvert.ByteArrayCopy(hiscoreData.Points1, HiConvert.IntToByteArrayHex(0, hiscoreData.Points1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Points2, HiConvert.IntToByteArrayHex(0, hiscoreData.Points2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Points3, HiConvert.IntToByteArrayHex(0, hiscoreData.Points3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Points4, HiConvert.IntToByteArrayHex(0, hiscoreData.Points4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Points5, HiConvert.IntToByteArrayHex(0, hiscoreData.Points5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Points6, HiConvert.IntToByteArrayHex(0, hiscoreData.Points6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Points7, HiConvert.IntToByteArrayHex(0, hiscoreData.Points7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Points8, HiConvert.IntToByteArrayHex(0, hiscoreData.Points8.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = Format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}/{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                1,
                ByteArrayToString(hiscoreData.Name1),
                HiConvert.ByteArrayHexToInt(hiscoreData.Month1),
                HiConvert.ByteArrayHexToInt(hiscoreData.Day1),                
                HiConvert.ByteArrayHexToInt(hiscoreData.Points1),
                GetPercent(hiscoreData.FG1, hiscoreData.FG1.Length),
                GetPercent(hiscoreData.FT1, hiscoreData.FT1.Length),
                HiConvert.ByteArrayHexToInt(hiscoreData.REBS1),
                HiConvert.ByteArrayHexToInt(hiscoreData.ASST1),
                HiConvert.ByteArrayHexToInt(hiscoreData.PF1)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}/{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                2,
                ByteArrayToString(hiscoreData.Name2),
                HiConvert.ByteArrayHexToInt(hiscoreData.Month2),
                HiConvert.ByteArrayHexToInt(hiscoreData.Day2),                
                HiConvert.ByteArrayHexToInt(hiscoreData.Points2),
                GetPercent(hiscoreData.FG2, hiscoreData.FG2.Length),
                GetPercent(hiscoreData.FT2, hiscoreData.FT2.Length),
                HiConvert.ByteArrayHexToInt(hiscoreData.REBS2),
                HiConvert.ByteArrayHexToInt(hiscoreData.ASST2),
                HiConvert.ByteArrayHexToInt(hiscoreData.PF2)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}/{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                3,
                ByteArrayToString(hiscoreData.Name3),
                HiConvert.ByteArrayHexToInt(hiscoreData.Month3),
                HiConvert.ByteArrayHexToInt(hiscoreData.Day3),                
                HiConvert.ByteArrayHexToInt(hiscoreData.Points3),
                GetPercent(hiscoreData.FG3, hiscoreData.FG3.Length),
                GetPercent(hiscoreData.FT3, hiscoreData.FT3.Length),
                HiConvert.ByteArrayHexToInt(hiscoreData.REBS3),
                HiConvert.ByteArrayHexToInt(hiscoreData.ASST3),
                HiConvert.ByteArrayHexToInt(hiscoreData.PF3)) + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}/{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                4,
                ByteArrayToString(hiscoreData.Name4),
                HiConvert.ByteArrayHexToInt(hiscoreData.Month4),
                HiConvert.ByteArrayHexToInt(hiscoreData.Day4),                
                HiConvert.ByteArrayHexToInt(hiscoreData.Points4),
                GetPercent(hiscoreData.FG4, hiscoreData.FG4.Length),
                GetPercent(hiscoreData.FT4, hiscoreData.FT4.Length),
                HiConvert.ByteArrayHexToInt(hiscoreData.REBS4),
                HiConvert.ByteArrayHexToInt(hiscoreData.ASST4),
                HiConvert.ByteArrayHexToInt(hiscoreData.PF4)) + Environment.NewLine;

              retString += String.Format("{0}|{1}|{2}/{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                5,
                ByteArrayToString(hiscoreData.Name5),
                HiConvert.ByteArrayHexToInt(hiscoreData.Month5),
                HiConvert.ByteArrayHexToInt(hiscoreData.Day5),                
                HiConvert.ByteArrayHexToInt(hiscoreData.Points5),
                GetPercent(hiscoreData.FG5, hiscoreData.FG5.Length),
                GetPercent(hiscoreData.FT5, hiscoreData.FT5.Length),
                HiConvert.ByteArrayHexToInt(hiscoreData.REBS5),
                HiConvert.ByteArrayHexToInt(hiscoreData.ASST5),
                HiConvert.ByteArrayHexToInt(hiscoreData.PF5)) + Environment.NewLine;

              retString += String.Format("{0}|{1}|{2}/{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                6,
                ByteArrayToString(hiscoreData.Name6),
                HiConvert.ByteArrayHexToInt(hiscoreData.Month6),
                HiConvert.ByteArrayHexToInt(hiscoreData.Day6),
                HiConvert.ByteArrayHexToInt(hiscoreData.Points6),
                GetPercent(hiscoreData.FG6, hiscoreData.FG6.Length),
                GetPercent(hiscoreData.FT6, hiscoreData.FT6.Length),
                HiConvert.ByteArrayHexToInt(hiscoreData.REBS6),
                HiConvert.ByteArrayHexToInt(hiscoreData.ASST6),
                HiConvert.ByteArrayHexToInt(hiscoreData.PF6)) + Environment.NewLine;

              retString += String.Format("{0}|{1}|{2}/{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                7,
                ByteArrayToString(hiscoreData.Name7),
                HiConvert.ByteArrayHexToInt(hiscoreData.Month7),
                HiConvert.ByteArrayHexToInt(hiscoreData.Day7),
                HiConvert.ByteArrayHexToInt(hiscoreData.Points7),
                GetPercent(hiscoreData.FG7, hiscoreData.FG7.Length),
                GetPercent(hiscoreData.FT7, hiscoreData.FT7.Length),
                HiConvert.ByteArrayHexToInt(hiscoreData.REBS7),
                HiConvert.ByteArrayHexToInt(hiscoreData.ASST7),
                HiConvert.ByteArrayHexToInt(hiscoreData.PF7)) + Environment.NewLine;

              retString += String.Format("{0}|{1}|{2}/{3}|{4}|{5}|{6}|{7}|{8}|{9}",
                8,
                ByteArrayToString(hiscoreData.Name8),
                HiConvert.ByteArrayHexToInt(hiscoreData.Month8),
                HiConvert.ByteArrayHexToInt(hiscoreData.Day8),
                HiConvert.ByteArrayHexToInt(hiscoreData.Points8),
                GetPercent(hiscoreData.FG8, hiscoreData.FG8.Length),
                GetPercent(hiscoreData.FT8, hiscoreData.FT8.Length),
                HiConvert.ByteArrayHexToInt(hiscoreData.REBS8),
                HiConvert.ByteArrayHexToInt(hiscoreData.ASST8),
                HiConvert.ByteArrayHexToInt(hiscoreData.PF8)) + Environment.NewLine;
        
            return retString;
        }
    }
}

