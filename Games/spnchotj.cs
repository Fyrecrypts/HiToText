using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;
using System.IO;

namespace HiGames
{   // This is a clone of spnchout. The only difference is the checksum.
    class spnchotj : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] UnusedA;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NoName0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NoScore0;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NoName1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NoScore1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score11;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score12;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score13;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score14;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score15;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score16;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score17;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score18;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score19;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score20;

            // And now the hi file with records 21 to 50
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank21;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name21;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score21;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank22;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name22;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score22;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank23;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name23;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score23;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank24;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name24;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score24;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank25;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name25;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score25;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank26;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name26;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score26;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank27;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name27;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score27;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank28;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name28;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score28;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank29;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name29;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score29;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank30;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name30;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score30;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank31;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name31;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score31;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank32;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name32;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score32;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank33;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name33;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score33;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank34;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name34;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score34;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank35;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name35;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score35;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank36;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name36;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score36;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank37;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name37;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score37;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank38;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name38;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score38;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank39;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name39;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score39;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank40;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name40;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score40;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank41;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name41;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score41;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank42;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name42;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score42;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank43;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name43;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score43;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank44;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name44;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score44;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank45;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name45;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score45;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank46;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name46;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score46;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank47;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name47;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score47;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank48;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name48;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score48;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank49;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name49;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score49;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank50;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name50;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score50; 
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct AlternateData
        {
            // BEST 5 HIT AVERAGE
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameAverage1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentAverage1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameAverage2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentAverage2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameAverage3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentAverage3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameAverage4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentAverage4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameAverage5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentAverage5;

            // BEST 3 K.O. TIMES - BEAR HUGGER
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOBH1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOBH1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOBH2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOBH2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOBH3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOBH3;

            // BEST 3 K.O. TIMES - DRAGON CHAN
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKODC1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKODC1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKODC2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKODC2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKODC3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKODC3;

            // BEST 3 K.O. TIMES - VODKA DRUNKENSKI
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOVD1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOVD1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOVD2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOVD2;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOVD3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOVD3;

            // BEST 3 K.O. TIMES - GREAT TIGER
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOGT1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOGT1;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOGT2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOGT2;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOGT3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOGT3;

            // BEST 3 K.O. TIMES - SUPER MACHO MAN
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOSM1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOSM1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOSM2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOSM2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameKOSM3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] TimeKOSM3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] UnusedB;       
        }

        public spnchotj()
        {
            m_numEntries = 50;
            m_format = "RANK|SCORE|NAME";
            m_altFormat = new string[6];
            m_altFormat[0] = "HIT AVERAGE" + Environment.NewLine + "RANK|PERCENT|NAME";
            m_altFormat[1] = "KO TIME BEAR HUGGER" + Environment.NewLine + "RANK|TIME|NAME";
            m_altFormat[2] = "KO TIME DRAGON CHAN" + Environment.NewLine + "RANK|TIME|NAME";
            m_altFormat[3] = "KO TIME VODKA DRUNKENSKI" + Environment.NewLine + "RANK|TIME|NAME";
            m_altFormat[4] = "KO TIME GREAT TIGER" + Environment.NewLine + "RANK|TIME|NAME";
            m_altFormat[5] = "KO TIME SUPER MACHO MAN" + Environment.NewLine + "RANK|TIME|NAME";
            m_numAltEntries = new int[] { 5, 3, 3, 3, 3, 3 };
            m_gamesSupported = "spnchotj";
            m_extensionsRequired = ".nv,.hi";
        }

        public byte[] EncryptArray(byte[] data1, byte[]data2)
        {
            byte[] temp = new byte[(data1.Length - 240 + data2.Length) * 4 + 240];
            int j = 0;
            for (int i = 0; i < data1.Length - 240; i++)
            {
                temp[j] = Convert.ToByte(data1[i].ToString("X2").Substring(1, 1),16);
                temp[j+512] = Convert.ToByte(data1[i].ToString("X2").Substring(1, 1), 16);
                j++;
                temp[j]= Convert.ToByte(data1[i].ToString("X2").Substring(0, 1), 16);
                temp[j+512] = Convert.ToByte(data1[i].ToString("X2").Substring(0, 1), 16); 
                j++;
            }
            for (int i = 0; i < data2.Length; i++)
            {
                temp[j] = Convert.ToByte(data2[i].ToString("X2").Substring(1, 1), 16);
                temp[j + 512] = Convert.ToByte(data2[i].ToString("X2").Substring(1, 1), 16);
                j++;
                temp[j] = Convert.ToByte(data2[i].ToString("X2").Substring(0, 1), 16);
                temp[j + 512] = Convert.ToByte(data2[i].ToString("X2").Substring(0, 1), 16);
                j++;
            }
            j = j + 512;
            for (int i = data1.Length - 240; i < data1.Length; i++)
            {
                temp[j] = data1[i];
                j++;
            }

            // The program makes a checksum from 0xd512 memory position.
            // The subrutine is allocated in 0x0e4e. Is called from 0x03cf position
            // at the start of the program. Makes a 'complement to 1' (0xff-byte) with
            // name and score/times/percent bytes (only those).
            // The rutine below adapt this rule to the data stored in the nvram file.
            // The data of the nvram is stored in 0xc002 and 0xc202 positions. Both have
            // the same data. 
            int Checksum = 0x0000;
            int checkstart = 6; // First byte to consider
            int checkend = 509; // Last byte included in the checksum is data[509]           

            for (int i = checkstart; i < checkend; i = i + 2)
            {
                // Be aware that the data is swapped.
                Checksum += 0xff - (int)(temp[i + 1] * 0x10 + temp[i] * 0x01);
                if (Checksum > 0x10000) Checksum = Checksum - 0x10000;// Checksum is stored in a 16 bits register

            }
            string strcheck = Checksum.ToString("X2");
            temp[2] = Convert.ToByte(strcheck.Substring(3, 1), 0x10); //0x10 -> Convert from hex number
            temp[2 + 512] = temp[2];
            temp[3] = Convert.ToByte(strcheck.Substring(2, 1), 0x10);
            temp[3 + 512] = temp[3];
            temp[4] = Convert.ToByte(strcheck.Substring(1, 1), 0x10);
            temp[4 + 512] = temp[4];
            temp[5] = Convert.ToByte(strcheck.Substring(0, 1), 0x10);
            temp[5 + 512] = temp[5];

            return temp;
        }

        public byte[] DecryptArray(byte[] data)
        {
            byte[] temp = new byte[data.Length-512]; //We don't need the duplicate bytes
            int j = 0;
            for (int i = 0; i < 270; i++) // First, the Scores from nvram (1 to 20)
            {
               temp[j] = Convert.ToByte(data[i+1].ToString("X2").Substring(1, 1) + data[i].ToString("X2").Substring(1, 1), 16);
               i++;
               j++;
            }
            for (int i = 1024; i < data.Length; i++) // Next, the .hi file data (scores 21-50)
            {
                temp[j] = data[i];
                j++;
            }
            for (int i= 270; i < 512; i++) // Finally, the AlternateData
            {
                temp[j] = Convert.ToByte(data[i + 1].ToString("X2").Substring(1, 1) + data[i].ToString("X2").Substring(1, 1), 16);
                i++;
                j++;
            }

            return temp;
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
        
            for (int i = 0; i < data.Length; i++)
            {
                int correction = 0x41 - 0x0a;
                if (data[i] == 0x24) 
                    sb.Append('-');
                else if (data[i] == 0x25)
                    sb.Append(':');
                else if (data[i] == 0x26)
                    sb.Append('♥');
                else if (data[i] == 0x27)
                    sb.Append('.');
                else
                    sb.Append((char)(data[i]+ correction));
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];
            int correction = 0x41 - 0x0a;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - correction));
                else if (str[i] == '-') 
                    data[i] = 0x24;
                else if (str[i] == ':')
                    data[i] = 0x25;
                else if (str[i] == '♥')
                    data[i] = 0x26;
                else if (str[i] == '.')
                    data[i] = 0x27;               
            }

            return data;
        }

        private int GetAlternateName(string altName)
        {
            switch (altName)
            {
                case "HIT AVERAGE":
                    return 0;
                case "KO TIME BEAR HUGGER":
                    return 1;
                case "KO TIME DRAGON CHAN":
                    return 2;
                case "KO TIME VODKA DRUNKENSKI":
                    return 3;
                case "KO TIME GREAT TIGER":
                    return 4;
                case "KO TIME SUPER MACHO MAN":
                    return 5;
            }
            return -1;
        }

        private string FormatAsTime(int score)
        {
            if (score == 0)
                return "0'00''00";
            string stscore = score.ToString().PadLeft(5, '0');
            string millseconds = stscore.Substring(3,2);
            string seconds = stscore.Substring(1,2);
            return stscore.Substring(0, 1) + "'" + seconds + "''" + millseconds;
        }

        private string FormatAsPercent(int score)
        {
            return (score.ToString().Substring(0, 2) + "." + score.ToString().Substring(2, 2) + "%");
        }
        
        private int FormatFromTime(string score)
        {
            return Convert.ToInt32(score.Replace("'", "").Replace(Convert.ToString((char)34),"")); // char(34) = "
        }

        private int FormatFromPercent(string score)
        {
            return Convert.ToInt32(score.Replace(".", "").Replace("%", ""));
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

            HiscoreData hiscoreData = new HiscoreData();
            AlternateData altData = new AlternateData();

            byte[] data_converted = DecryptArray(m_data);

            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(data_converted, 0, typeof(HiscoreData));
            altData = (AlternateData)HiConvert.RawDeserialize(data_converted, Marshal.SizeOf(typeof(HiscoreData)), typeof(AlternateData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6)))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7)))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8)))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9)))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10)))
                rank = 9;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score11)))
                rank = 10;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score12)))
                rank = 11;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score13)))
                rank = 12;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score14)))
                rank = 13;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score15)))
                rank = 14;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score16)))
                rank = 15;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score17)))
                rank = 16;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score18)))
                rank = 17;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score19)))
                rank = 18;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score20)))
                rank = 19;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score21)))
                rank = 20;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score22)))
                rank = 21;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score23)))
                rank = 22;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score24)))
                rank = 23;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score25)))
                rank = 24;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score26)))
                rank = 25;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score27)))
                rank = 26;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score28)))
                rank = 27;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score29)))
                rank = 28;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score30)))
                rank = 29;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score31)))
                rank = 30;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score32)))
                rank = 31;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score33)))
                rank = 32;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score34)))
                rank = 33;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score35)))
                rank = 34;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score36)))
                rank = 35;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score37)))
                rank = 36;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score38)))
                rank = 37;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score39)))
                rank = 38;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score40)))
                rank = 39;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score41)))
                rank = 40;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score42)))
                rank = 41;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score43)))
                rank = 42;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score44)))
                rank = 43;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score45)))
                rank = 44;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score46)))
                rank = 45;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score47)))
                rank = 46;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score48)))
                rank = 47;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score49)))
                rank = 48;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score50)))
                rank = 49;
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
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;                
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    if (rank < 8)
                        goto case 7;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, hiscoreData.Score10);
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, hiscoreData.Name10);
                    if (rank < 9)
                        goto case 8;
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, hiscoreData.Score11);
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, hiscoreData.Name11);
                    if (rank < 10)
                        goto case 9;
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, hiscoreData.Score12);
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, hiscoreData.Name12);
                    if (rank < 11)
                        goto case 10;
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, hiscoreData.Score13);
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, hiscoreData.Name13);
                    if (rank < 12)
                        goto case 11;
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, hiscoreData.Score14);
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, hiscoreData.Name14);
                    if (rank < 13)
                        goto case 12;
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, hiscoreData.Score15);
                    HiConvert.ByteArrayCopy(hiscoreData.Name16, hiscoreData.Name15);
                    if (rank < 14)
                        goto case 13;
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, hiscoreData.Score16);
                    HiConvert.ByteArrayCopy(hiscoreData.Name17, hiscoreData.Name16);
                    if (rank < 15)
                        goto case 14;
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, hiscoreData.Score17);
                    HiConvert.ByteArrayCopy(hiscoreData.Name18, hiscoreData.Name17);
                    if (rank < 16)
                        goto case 15;
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, hiscoreData.Score18);
                    HiConvert.ByteArrayCopy(hiscoreData.Name19, hiscoreData.Name18);
                    if (rank < 17)
                        goto case 16;
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, hiscoreData.Score19);
                    HiConvert.ByteArrayCopy(hiscoreData.Name20, hiscoreData.Name19);
                    if (rank < 18)
                        goto case 17;
                    break;
                case 19:
                    HiConvert.ByteArrayCopy(hiscoreData.Score21, hiscoreData.Score20);
                    HiConvert.ByteArrayCopy(hiscoreData.Name21, hiscoreData.Name20);
                    if (rank < 19)
                        goto case 18;
                    break;
                case 20:
                    HiConvert.ByteArrayCopy(hiscoreData.Score22, hiscoreData.Score21);
                    HiConvert.ByteArrayCopy(hiscoreData.Name22, hiscoreData.Name21);
                    if (rank < 20)
                        goto case 19;
                    break;
                case 21:
                    HiConvert.ByteArrayCopy(hiscoreData.Score23, hiscoreData.Score22);
                    HiConvert.ByteArrayCopy(hiscoreData.Name23, hiscoreData.Name22);
                    if (rank < 21)
                        goto case 20;
                    break;
                case 22:
                    HiConvert.ByteArrayCopy(hiscoreData.Score24, hiscoreData.Score23);
                    HiConvert.ByteArrayCopy(hiscoreData.Name24, hiscoreData.Name23);
                    if (rank < 22)
                        goto case 21;
                    break;
                case 23:
                    HiConvert.ByteArrayCopy(hiscoreData.Score25, hiscoreData.Score24);
                    HiConvert.ByteArrayCopy(hiscoreData.Name25, hiscoreData.Name24);
                    if (rank < 23)
                        goto case 22;
                    break;
                case 24:
                    HiConvert.ByteArrayCopy(hiscoreData.Score26, hiscoreData.Score25);
                    HiConvert.ByteArrayCopy(hiscoreData.Name26, hiscoreData.Name25);
                    if (rank < 24)
                        goto case 23;
                    break;
                case 25:
                    HiConvert.ByteArrayCopy(hiscoreData.Score27, hiscoreData.Score26);
                    HiConvert.ByteArrayCopy(hiscoreData.Name27, hiscoreData.Name26);
                    if (rank < 25)
                        goto case 24;
                    break;
                case 26:
                    HiConvert.ByteArrayCopy(hiscoreData.Score28, hiscoreData.Score27);
                    HiConvert.ByteArrayCopy(hiscoreData.Name28, hiscoreData.Name27);
                    if (rank < 26)
                        goto case 25;
                    break;
                case 27:
                    HiConvert.ByteArrayCopy(hiscoreData.Score29, hiscoreData.Score28);
                    HiConvert.ByteArrayCopy(hiscoreData.Name29, hiscoreData.Name28);
                    if (rank < 27)
                        goto case 26;
                    break;
                case 28:
                    HiConvert.ByteArrayCopy(hiscoreData.Score30, hiscoreData.Score29);
                    HiConvert.ByteArrayCopy(hiscoreData.Name30, hiscoreData.Name29);
                    if (rank < 28)
                        goto case 27;
                    break;
                case 29:
                    HiConvert.ByteArrayCopy(hiscoreData.Score31, hiscoreData.Score30);
                    HiConvert.ByteArrayCopy(hiscoreData.Name31, hiscoreData.Name30);
                    if (rank < 29)
                        goto case 28;
                    break;
                case 30:
                    HiConvert.ByteArrayCopy(hiscoreData.Score32, hiscoreData.Score31);
                    HiConvert.ByteArrayCopy(hiscoreData.Name32, hiscoreData.Name31);
                    if (rank < 30)
                        goto case 29;
                    break;
                case 31:
                    HiConvert.ByteArrayCopy(hiscoreData.Score33, hiscoreData.Score32);
                    HiConvert.ByteArrayCopy(hiscoreData.Name33, hiscoreData.Name32);
                    if (rank < 31)
                        goto case 30;
                    break;
                case 32:
                    HiConvert.ByteArrayCopy(hiscoreData.Score34, hiscoreData.Score33);
                    HiConvert.ByteArrayCopy(hiscoreData.Name34, hiscoreData.Name33);
                    if (rank < 32)
                        goto case 31;
                    break;
                case 33:
                    HiConvert.ByteArrayCopy(hiscoreData.Score35, hiscoreData.Score34);
                    HiConvert.ByteArrayCopy(hiscoreData.Name35, hiscoreData.Name34);
                    if (rank < 33)
                        goto case 32;
                    break;
                case 34:
                    HiConvert.ByteArrayCopy(hiscoreData.Score36, hiscoreData.Score35);
                    HiConvert.ByteArrayCopy(hiscoreData.Name36, hiscoreData.Name35);
                    if (rank < 34)
                        goto case 33;
                    break;
                case 35:
                    HiConvert.ByteArrayCopy(hiscoreData.Score37, hiscoreData.Score36);
                    HiConvert.ByteArrayCopy(hiscoreData.Name37, hiscoreData.Name36);
                    if (rank < 35)
                        goto case 34;
                    break;
                case 36:
                    HiConvert.ByteArrayCopy(hiscoreData.Score38, hiscoreData.Score37);
                    HiConvert.ByteArrayCopy(hiscoreData.Name38, hiscoreData.Name37);
                    if (rank < 36)
                        goto case 35;
                    break;
                case 37:
                    HiConvert.ByteArrayCopy(hiscoreData.Score39, hiscoreData.Score38);
                    HiConvert.ByteArrayCopy(hiscoreData.Name39, hiscoreData.Name38);
                    if (rank < 37)
                        goto case 36;
                    break;
                case 38:
                    HiConvert.ByteArrayCopy(hiscoreData.Score40, hiscoreData.Score39);
                    HiConvert.ByteArrayCopy(hiscoreData.Name40, hiscoreData.Name39);
                    if (rank < 38)
                        goto case 37;
                    break;
                case 39:
                    HiConvert.ByteArrayCopy(hiscoreData.Score41, hiscoreData.Score40);
                    HiConvert.ByteArrayCopy(hiscoreData.Name41, hiscoreData.Name40);
                    if (rank < 39)
                        goto case 38;
                    break;
                case 40:
                    HiConvert.ByteArrayCopy(hiscoreData.Score42, hiscoreData.Score41);
                    HiConvert.ByteArrayCopy(hiscoreData.Name42, hiscoreData.Name41);
                    if (rank < 40)
                        goto case 39;
                    break;
                case 41:
                    HiConvert.ByteArrayCopy(hiscoreData.Score43, hiscoreData.Score42);
                    HiConvert.ByteArrayCopy(hiscoreData.Name43, hiscoreData.Name42);
                    if (rank < 41)
                        goto case 40;
                    break;
                case 42:
                    HiConvert.ByteArrayCopy(hiscoreData.Score44, hiscoreData.Score43);
                    HiConvert.ByteArrayCopy(hiscoreData.Name44, hiscoreData.Name43);
                    if (rank < 42)
                        goto case 41;
                    break;
                case 43:
                    HiConvert.ByteArrayCopy(hiscoreData.Score45, hiscoreData.Score44);
                    HiConvert.ByteArrayCopy(hiscoreData.Name45, hiscoreData.Name44);
                    if (rank < 43)
                        goto case 42;
                    break;
                case 44:
                    HiConvert.ByteArrayCopy(hiscoreData.Score46, hiscoreData.Score45);
                    HiConvert.ByteArrayCopy(hiscoreData.Name46, hiscoreData.Name45);
                    if (rank < 44)
                        goto case 43;
                    break;
                case 45:
                    HiConvert.ByteArrayCopy(hiscoreData.Score47, hiscoreData.Score46);
                    HiConvert.ByteArrayCopy(hiscoreData.Name47, hiscoreData.Name46);
                    if (rank < 45)
                        goto case 44;
                    break;
                case 46:
                    HiConvert.ByteArrayCopy(hiscoreData.Score48, hiscoreData.Score47);
                    HiConvert.ByteArrayCopy(hiscoreData.Name48, hiscoreData.Name47);
                    if (rank < 46)
                        goto case 45;
                    break;
                case 47:
                    HiConvert.ByteArrayCopy(hiscoreData.Score49, hiscoreData.Score48);
                    HiConvert.ByteArrayCopy(hiscoreData.Name49, hiscoreData.Name48);
                    if (rank < 47)
                        goto case 46;
                    break;
                case 48:
                    HiConvert.ByteArrayCopy(hiscoreData.Score50, hiscoreData.Score49);
                    HiConvert.ByteArrayCopy(hiscoreData.Name50, hiscoreData.Name49);
                    if (rank < 48)
                        goto case 47;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length)));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length)));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length)));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length)));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length)));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length)));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length)));
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score11.Length)));
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score12.Length)));
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score13.Length)));
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score14.Length)));
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score15.Length)));
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Name16, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score16.Length)));
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Name17, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score17.Length)));
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Name18, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score18.Length)));
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Name19, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score19.Length)));
                    break;
                case 19:
                    HiConvert.ByteArrayCopy(hiscoreData.Name20, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score20.Length)));
                    break;
                case 20:
                    HiConvert.ByteArrayCopy(hiscoreData.Name21, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score21, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score21.Length)));
                    break;
                case 21:
                    HiConvert.ByteArrayCopy(hiscoreData.Name22, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score22, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score22.Length)));
                    break;
                case 22:
                    HiConvert.ByteArrayCopy(hiscoreData.Name23, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score23, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score23.Length)));
                    break;
                case 23:
                    HiConvert.ByteArrayCopy(hiscoreData.Name24, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score24, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score24.Length)));
                    break;
                case 24:
                    HiConvert.ByteArrayCopy(hiscoreData.Name25, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score25, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score25.Length)));
                    break;
                case 25:
                    HiConvert.ByteArrayCopy(hiscoreData.Name26, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score26, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score26.Length)));
                    break;
                case 26:
                    HiConvert.ByteArrayCopy(hiscoreData.Name27, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score27, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score27.Length)));
                    break;
                case 27:
                    HiConvert.ByteArrayCopy(hiscoreData.Name28, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score28, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score28.Length)));
                    break;
                case 28:
                    HiConvert.ByteArrayCopy(hiscoreData.Name29, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score29, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score29.Length)));
                    break;
                case 29:
                    HiConvert.ByteArrayCopy(hiscoreData.Name30, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score30, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score30.Length)));
                    break;
                case 30:
                    HiConvert.ByteArrayCopy(hiscoreData.Name31, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score31, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score31.Length)));
                    break;
                case 31:
                    HiConvert.ByteArrayCopy(hiscoreData.Name32, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score32, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score32.Length)));
                    break;
                case 32:
                    HiConvert.ByteArrayCopy(hiscoreData.Name33, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score33, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score33.Length)));
                    break;
                case 33:
                    HiConvert.ByteArrayCopy(hiscoreData.Name34, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score34, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score34.Length)));
                    break;
                case 34:
                    HiConvert.ByteArrayCopy(hiscoreData.Name35, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score35, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score35.Length)));
                    break;
                case 35:
                    HiConvert.ByteArrayCopy(hiscoreData.Name36, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score36, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score36.Length)));
                    break;
                case 36:
                    HiConvert.ByteArrayCopy(hiscoreData.Name37, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score37, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score37.Length)));
                    break;
                case 37:
                    HiConvert.ByteArrayCopy(hiscoreData.Name38, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score38, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score38.Length)));
                    break;
                case 38:
                    HiConvert.ByteArrayCopy(hiscoreData.Name39, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score39, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score39.Length)));
                    break;
                case 39:
                    HiConvert.ByteArrayCopy(hiscoreData.Name40, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score40, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score40.Length)));
                    break;
                case 40:
                    HiConvert.ByteArrayCopy(hiscoreData.Name41, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score41, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score41.Length)));
                    break;
                case 41:
                    HiConvert.ByteArrayCopy(hiscoreData.Name42, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score42, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score42.Length)));
                    break;
                case 42:
                    HiConvert.ByteArrayCopy(hiscoreData.Name43, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score43, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score43.Length)));
                    break;
                case 43:
                    HiConvert.ByteArrayCopy(hiscoreData.Name44, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score44, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score44.Length)));
                    break;
                case 44:
                    HiConvert.ByteArrayCopy(hiscoreData.Name45, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score45, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score45.Length)));
                    break;
                case 45:
                    HiConvert.ByteArrayCopy(hiscoreData.Name46, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score46, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score46.Length)));
                    break;
                case 46:
                    HiConvert.ByteArrayCopy(hiscoreData.Name47, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score47, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score47.Length)));
                    break;
                case 47:
                    HiConvert.ByteArrayCopy(hiscoreData.Name48, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score48, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score48.Length)));
                    break;
                case 48:
                    HiConvert.ByteArrayCopy(hiscoreData.Name49, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score49, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score49.Length)));
                    break;
                case 49:
                    HiConvert.ByteArrayCopy(hiscoreData.Name50, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score50, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score50.Length)));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);
            byte[] byteArrayAlt = HiConvert.RawSerialize(altData);

            // Generate the Checksum, sort the data and                       
            // Duplicate records 1 to 20, Best 3 K.O. times and Best 5 Hit Average(nvram)
            m_data = EncryptArray(byteArray,byteArrayAlt);
        }

        public override void SetAlternateScore(string[] args)
        {
            int alternateName = GetAlternateName(args[0]);
            int rankGiven = Convert.ToInt32(args[1]);
            string name = args[3];
            int score = 0;
            switch (alternateName)
            {
                case 0:
                    score = FormatFromPercent(args[2]);
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    score = FormatFromTime(args[2]);
                    break;
            }

            HiscoreData hiscoreData = new HiscoreData();
            AlternateData altData = new AlternateData();

            byte[] data_converted = DecryptArray(m_data);

            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(data_converted, 0, typeof(HiscoreData));
            altData = (AlternateData)HiConvert.RawDeserialize(data_converted, Marshal.SizeOf(typeof(HiscoreData)), typeof(AlternateData));

            #region DETERMINE_RANK
            int rank = NumAltEntries[alternateName];
            switch (alternateName)
            {
                case 0:
                    if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage1)))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage2)))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage3)))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage4)))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage5)))
                        rank = 4;
                    break;
                case 1:
                    if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOBH1)))
                        rank = 0;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOBH2)))
                        rank = 1;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOBH3)))
                        rank = 2;
                    break;
                case 2:
                    if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKODC1)))
                        rank = 0;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKODC2)))
                        rank = 1;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKODC3)))
                        rank = 2;
                    break;
                case 3:
                    if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOVD1)))
                        rank = 0;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOVD2)))
                        rank = 1;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOVD3)))
                        rank = 2;
                    break;
                case 4:
                    if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOGT1)))
                        rank = 0;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOGT2)))
                        rank = 1;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOGT3)))
                        rank = 2;
                    break;
                case 5:
                    if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOSM1)))
                        rank = 0;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOSM2)))
                        rank = 1;
                    else if (score < HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOSM3)))
                        rank = 2;
                    break;
            }
            #endregion

            #region ADJUST
            int adjust = NumAltEntries[alternateName] - 1;
            if (rank < NumAltEntries[alternateName] - 1)
                adjust = NumAltEntries[alternateName] - 2;
            switch (alternateName)
            {
                case 0:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.PercentAverage2, altData.PercentAverage1);
                            HiConvert.ByteArrayCopy(altData.NameAverage2, altData.NameAverage1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.PercentAverage3, altData.PercentAverage2);
                            HiConvert.ByteArrayCopy(altData.NameAverage3, altData.NameAverage2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(altData.PercentAverage4, altData.PercentAverage3);
                            HiConvert.ByteArrayCopy(altData.NameAverage4, altData.NameAverage3);
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(altData.PercentAverage5, altData.PercentAverage4);
                            HiConvert.ByteArrayCopy(altData.NameAverage5, altData.NameAverage4);
                            if (rank < 3)
                                goto case 2;
                            break;
                    }
                    break;
                case 1:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.TimeKOBH2, altData.TimeKOBH1);
                            HiConvert.ByteArrayCopy(altData.NameKOBH2, altData.NameKOBH1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.TimeKOBH3, altData.TimeKOBH2);
                            HiConvert.ByteArrayCopy(altData.NameKOBH3, altData.NameKOBH2);
                            if (rank < 1)
                                goto case 0;
                            break;
                    }
                    break;
                case 2:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.TimeKODC2, altData.TimeKODC1);
                            HiConvert.ByteArrayCopy(altData.NameKODC2, altData.NameKODC1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.TimeKODC3, altData.TimeKODC2);
                            HiConvert.ByteArrayCopy(altData.NameKODC3, altData.NameKODC2);
                            if (rank < 1)
                                goto case 0;
                            break;
                    }
                    break;
                case 3:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.TimeKOVD2, altData.TimeKOVD1);
                            HiConvert.ByteArrayCopy(altData.NameKOVD2, altData.NameKOVD1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.TimeKOVD3, altData.TimeKOVD2);
                            HiConvert.ByteArrayCopy(altData.NameKOVD3, altData.NameKOVD2);
                            if (rank < 1)
                                goto case 0;
                            break;
                    }
                    break;
                case 4:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.TimeKOGT2, altData.TimeKOGT1);
                            HiConvert.ByteArrayCopy(altData.NameKOGT2, altData.NameKOGT1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.TimeKOGT3, altData.TimeKOGT2);
                            HiConvert.ByteArrayCopy(altData.NameKOGT3, altData.NameKOGT2);
                            if (rank < 1)
                                goto case 0;
                            break;
                    }
                    break;
                case 5:
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.TimeKOSM2, altData.TimeKOSM1);
                            HiConvert.ByteArrayCopy(altData.NameKOSM2, altData.NameKOSM1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.TimeKOSM3, altData.TimeKOSM2);
                            HiConvert.ByteArrayCopy(altData.NameKOSM3, altData.NameKOSM2);
                            if (rank < 1)
                                goto case 0;
                            break;
                    }
                    break;
            }                
            #endregion

            #region REPLACE_NEW
            switch (alternateName)
            { 
                case 0:
                    switch (rank)
                    { 
                        case 0:
                            HiConvert.ByteArrayCopy(altData.NameAverage1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.PercentAverage1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.PercentAverage1.Length)));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.NameAverage2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.PercentAverage2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.PercentAverage2.Length)));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(altData.NameAverage3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.PercentAverage3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.PercentAverage3.Length)));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(altData.NameAverage4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.PercentAverage4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.PercentAverage4.Length)));
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(altData.NameAverage5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.PercentAverage5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.PercentAverage5.Length)));
                            break;
                    }
                    break;
                case 1:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.NameKOBH1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOBH1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOBH1.Length)));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.NameKOBH2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOBH2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOBH2.Length)));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(altData.NameKOBH3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOBH3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOBH3.Length)));
                            break;
                    }
                    break;
                case 2:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.NameKODC1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKODC1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKODC1.Length)));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.NameKODC2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKODC2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKODC2.Length)));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(altData.NameKODC3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKODC3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKODC3.Length)));
                            break;
                    }
                    break;
                case 3:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.NameKOVD1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOVD1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOVD1.Length)));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.NameKOVD2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOVD2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOVD2.Length)));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(altData.NameKOVD3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOVD3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOVD3.Length)));
                            break;
                    }
                    break;
                case 4:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.NameKOGT1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOGT1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOGT1.Length)));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.NameKOGT2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOGT2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOGT2.Length)));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(altData.NameKOGT3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOGT3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOGT3.Length)));
                            break;
                    }
                    break;
                case 5:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(altData.NameKOSM1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOSM1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOSM1.Length)));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(altData.NameKOSM2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOSM2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOSM2.Length)));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(altData.NameKOSM3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(altData.TimeKOSM3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, altData.TimeKOSM3.Length)));
                            break;
                    }
               break;
            }
            #endregion
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);
            byte[] byteArrayAlt = HiConvert.RawSerialize(altData);

            // Generate the Checksum, sort the data and                       
            // Duplicate records 1 to 20, Best 3 K.O. times and Best 5 Hit Average(nvram)
            m_data = EncryptArray(byteArray, byteArrayAlt);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = new HiscoreData();
            AlternateData altData = new AlternateData();

            byte[] data_converted = DecryptArray(m_data);

            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(data_converted, 0, typeof(HiscoreData));
            altData = (AlternateData)HiConvert.RawDeserialize(data_converted, Marshal.SizeOf(typeof(HiscoreData)), typeof(AlternateData));

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
            HiConvert.ByteArrayCopy(hiscoreData.Score11, HiConvert.IntToByteArrayHex(0, hiscoreData.Score11.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score12, HiConvert.IntToByteArrayHex(0, hiscoreData.Score12.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score13, HiConvert.IntToByteArrayHex(0, hiscoreData.Score13.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score14, HiConvert.IntToByteArrayHex(0, hiscoreData.Score14.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score15, HiConvert.IntToByteArrayHex(0, hiscoreData.Score15.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score16, HiConvert.IntToByteArrayHex(0, hiscoreData.Score16.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score17, HiConvert.IntToByteArrayHex(0, hiscoreData.Score17.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score18, HiConvert.IntToByteArrayHex(0, hiscoreData.Score18.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score19, HiConvert.IntToByteArrayHex(0, hiscoreData.Score19.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score20, HiConvert.IntToByteArrayHex(0, hiscoreData.Score20.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score21, HiConvert.IntToByteArrayHex(0, hiscoreData.Score21.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score22, HiConvert.IntToByteArrayHex(0, hiscoreData.Score22.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score23, HiConvert.IntToByteArrayHex(0, hiscoreData.Score23.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score24, HiConvert.IntToByteArrayHex(0, hiscoreData.Score24.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score25, HiConvert.IntToByteArrayHex(0, hiscoreData.Score25.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score26, HiConvert.IntToByteArrayHex(0, hiscoreData.Score26.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score27, HiConvert.IntToByteArrayHex(0, hiscoreData.Score27.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score28, HiConvert.IntToByteArrayHex(0, hiscoreData.Score28.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score29, HiConvert.IntToByteArrayHex(0, hiscoreData.Score29.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score30, HiConvert.IntToByteArrayHex(0, hiscoreData.Score30.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score31, HiConvert.IntToByteArrayHex(0, hiscoreData.Score31.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score32, HiConvert.IntToByteArrayHex(0, hiscoreData.Score32.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score33, HiConvert.IntToByteArrayHex(0, hiscoreData.Score33.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score34, HiConvert.IntToByteArrayHex(0, hiscoreData.Score34.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score35, HiConvert.IntToByteArrayHex(0, hiscoreData.Score35.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score36, HiConvert.IntToByteArrayHex(0, hiscoreData.Score36.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score37, HiConvert.IntToByteArrayHex(0, hiscoreData.Score37.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score38, HiConvert.IntToByteArrayHex(0, hiscoreData.Score38.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score39, HiConvert.IntToByteArrayHex(0, hiscoreData.Score39.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score40, HiConvert.IntToByteArrayHex(0, hiscoreData.Score40.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score41, HiConvert.IntToByteArrayHex(0, hiscoreData.Score41.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score42, HiConvert.IntToByteArrayHex(0, hiscoreData.Score42.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score43, HiConvert.IntToByteArrayHex(0, hiscoreData.Score43.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score44, HiConvert.IntToByteArrayHex(0, hiscoreData.Score44.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score45, HiConvert.IntToByteArrayHex(0, hiscoreData.Score45.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score46, HiConvert.IntToByteArrayHex(0, hiscoreData.Score46.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score47, HiConvert.IntToByteArrayHex(0, hiscoreData.Score47.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score48, HiConvert.IntToByteArrayHex(0, hiscoreData.Score48.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score49, HiConvert.IntToByteArrayHex(0, hiscoreData.Score49.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score50, HiConvert.IntToByteArrayHex(0, hiscoreData.Score50.Length));

            HiConvert.ByteArrayCopy(altData.PercentAverage1, HiConvert.IntToByteArrayHex(0, altData.PercentAverage1.Length));
            HiConvert.ByteArrayCopy(altData.PercentAverage2, HiConvert.IntToByteArrayHex(0, altData.PercentAverage2.Length));
            HiConvert.ByteArrayCopy(altData.PercentAverage3, HiConvert.IntToByteArrayHex(0, altData.PercentAverage3.Length));
            HiConvert.ByteArrayCopy(altData.PercentAverage4, HiConvert.IntToByteArrayHex(0, altData.PercentAverage4.Length));
            HiConvert.ByteArrayCopy(altData.PercentAverage5, HiConvert.IntToByteArrayHex(0, altData.PercentAverage5.Length));

            HiConvert.ByteArrayCopy(altData.TimeKOBH1, HiConvert.IntToByteArrayHex(0, altData.TimeKOBH1.Length));
            HiConvert.ByteArrayCopy(altData.TimeKOBH2, HiConvert.IntToByteArrayHex(0, altData.TimeKOBH2.Length));
            HiConvert.ByteArrayCopy(altData.TimeKOBH3, HiConvert.IntToByteArrayHex(0, altData.TimeKOBH3.Length));

            HiConvert.ByteArrayCopy(altData.TimeKODC1, HiConvert.IntToByteArrayHex(0, altData.TimeKODC1.Length));
            HiConvert.ByteArrayCopy(altData.TimeKODC2, HiConvert.IntToByteArrayHex(0, altData.TimeKODC2.Length));
            HiConvert.ByteArrayCopy(altData.TimeKODC3, HiConvert.IntToByteArrayHex(0, altData.TimeKODC3.Length));

            HiConvert.ByteArrayCopy(altData.TimeKOVD1, HiConvert.IntToByteArrayHex(0, altData.TimeKOVD1.Length));
            HiConvert.ByteArrayCopy(altData.TimeKOVD2, HiConvert.IntToByteArrayHex(0, altData.TimeKOVD2.Length));
            HiConvert.ByteArrayCopy(altData.TimeKOVD3, HiConvert.IntToByteArrayHex(0, altData.TimeKOVD3.Length));

            HiConvert.ByteArrayCopy(altData.TimeKOGT1, HiConvert.IntToByteArrayHex(0, altData.TimeKOGT1.Length));
            HiConvert.ByteArrayCopy(altData.TimeKOGT2, HiConvert.IntToByteArrayHex(0, altData.TimeKOGT2.Length));
            HiConvert.ByteArrayCopy(altData.TimeKOGT3, HiConvert.IntToByteArrayHex(0, altData.TimeKOGT3.Length));

            HiConvert.ByteArrayCopy(altData.TimeKOSM1, HiConvert.IntToByteArrayHex(0, altData.TimeKOSM1.Length));
            HiConvert.ByteArrayCopy(altData.TimeKOSM2, HiConvert.IntToByteArrayHex(0, altData.TimeKOSM2.Length));
            HiConvert.ByteArrayCopy(altData.TimeKOSM3, HiConvert.IntToByteArrayHex(0, altData.TimeKOSM3.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);
            byte[] byteArrayAlt = HiConvert.RawSerialize(altData);

            // Generate the Checksum, sort the data and                       
            // Duplicate records 1 to 20, Best 3 K.O. times and Best 5 Hit Average(nvram)
            m_data = EncryptArray(byteArray, byteArrayAlt);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            AlternateData altData = new AlternateData();

            byte[] data_converted = DecryptArray(m_data);

            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(data_converted, 0, typeof(HiscoreData));
            altData = (AlternateData)HiConvert.RawDeserialize(data_converted, Marshal.SizeOf(typeof(HiscoreData)), typeof(AlternateData));

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)), ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)), ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)), ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)), ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)), ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6)), ByteArrayToString(hiscoreData.Name6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 7, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7)), ByteArrayToString(hiscoreData.Name7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 8, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8)), ByteArrayToString(hiscoreData.Name8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 9, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9)), ByteArrayToString(hiscoreData.Name9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 10, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10)), ByteArrayToString(hiscoreData.Name10)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 11, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score11)), ByteArrayToString(hiscoreData.Name11)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 12, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score12)), ByteArrayToString(hiscoreData.Name12)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 13, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score13)), ByteArrayToString(hiscoreData.Name13)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 14, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score14)), ByteArrayToString(hiscoreData.Name14)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 15, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score15)), ByteArrayToString(hiscoreData.Name15)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 16, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score16)), ByteArrayToString(hiscoreData.Name16)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 17, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score17)), ByteArrayToString(hiscoreData.Name17)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 18, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score18)), ByteArrayToString(hiscoreData.Name18)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 19, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score19)), ByteArrayToString(hiscoreData.Name19)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 20, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score20)), ByteArrayToString(hiscoreData.Name20)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 21, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score21)), ByteArrayToString(hiscoreData.Name21)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 22, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score22)), ByteArrayToString(hiscoreData.Name22)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 23, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score23)), ByteArrayToString(hiscoreData.Name23)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 24, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score24)), ByteArrayToString(hiscoreData.Name24)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 25, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score25)), ByteArrayToString(hiscoreData.Name25)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 26, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score26)), ByteArrayToString(hiscoreData.Name26)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 27, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score27)), ByteArrayToString(hiscoreData.Name27)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 28, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score28)), ByteArrayToString(hiscoreData.Name28)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 29, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score29)), ByteArrayToString(hiscoreData.Name29)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 30, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score30)), ByteArrayToString(hiscoreData.Name30)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 31, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score31)), ByteArrayToString(hiscoreData.Name31)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 32, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score32)), ByteArrayToString(hiscoreData.Name32)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 33, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score33)), ByteArrayToString(hiscoreData.Name33)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 34, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score34)), ByteArrayToString(hiscoreData.Name34)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 35, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score35)), ByteArrayToString(hiscoreData.Name35)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 36, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score36)), ByteArrayToString(hiscoreData.Name36)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 37, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score37)), ByteArrayToString(hiscoreData.Name37)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 38, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score38)), ByteArrayToString(hiscoreData.Name38)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 39, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score39)), ByteArrayToString(hiscoreData.Name39)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 40, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score40)), ByteArrayToString(hiscoreData.Name40)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 41, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score41)), ByteArrayToString(hiscoreData.Name41)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 42, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score42)), ByteArrayToString(hiscoreData.Name42)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 43, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score43)), ByteArrayToString(hiscoreData.Name43)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 44, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score44)), ByteArrayToString(hiscoreData.Name44)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 45, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score45)), ByteArrayToString(hiscoreData.Name45)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 46, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score46)), ByteArrayToString(hiscoreData.Name46)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 47, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score47)), ByteArrayToString(hiscoreData.Name47)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 48, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score48)), ByteArrayToString(hiscoreData.Name48)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 49, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score49)), ByteArrayToString(hiscoreData.Name49)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 50, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score50)), ByteArrayToString(hiscoreData.Name50)) + Environment.NewLine;

            retString += Environment.NewLine + Environment.NewLine + AltFormat[0] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsPercent(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage1))), ByteArrayToString(altData.NameAverage1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsPercent(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage2))), ByteArrayToString(altData.NameAverage2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsPercent(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage3))), ByteArrayToString(altData.NameAverage3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, FormatAsPercent(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage4))), ByteArrayToString(altData.NameAverage4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, FormatAsPercent(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.PercentAverage5))), ByteArrayToString(altData.NameAverage5)) + Environment.NewLine;
            retString += AltFormat[1] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOBH1))), ByteArrayToString(altData.NameKOBH1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOBH2))), ByteArrayToString(altData.NameKOBH2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOBH3))), ByteArrayToString(altData.NameKOBH3)) + Environment.NewLine;
            retString += AltFormat[2] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKODC1))), ByteArrayToString(altData.NameKODC1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKODC2))), ByteArrayToString(altData.NameKODC2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKODC3))), ByteArrayToString(altData.NameKODC3)) + Environment.NewLine;
            retString += AltFormat[3] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOVD1))), ByteArrayToString(altData.NameKOVD1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOVD2))), ByteArrayToString(altData.NameKOVD2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOVD3))), ByteArrayToString(altData.NameKOVD3)) + Environment.NewLine;
            retString += AltFormat[4] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOGT1))), ByteArrayToString(altData.NameKOGT1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOGT2))), ByteArrayToString(altData.NameKOGT2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOGT3))), ByteArrayToString(altData.NameKOGT3)) + Environment.NewLine;
            retString += AltFormat[5] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOSM1))), ByteArrayToString(altData.NameKOSM1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOSM2))), ByteArrayToString(altData.NameKOSM2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, FormatAsTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(altData.TimeKOSM3))), ByteArrayToString(altData.NameKOSM3)) + Environment.NewLine;

            return retString;
        }

        public override void SaveData()
        {
            byte[] nvRam = new byte[1024];
            byte[] hiFile = new byte[240];
            for (int i = 0; i < m_data.Length; i++)
            {
                if (i < nvRam.Length)
                    nvRam[i] = m_data[i];
                else
                    hiFile[i - nvRam.Length] = m_data[i];
            }
            File.WriteAllBytes(m_fileNames[0], nvRam);
            File.WriteAllBytes(m_fileNames[1], hiFile);
        }
    }
}