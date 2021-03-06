using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using HiGames;
using System.Net;
using System.Diagnostics;
using HiToText.Utils;
using HiToText.HXML;
using HiToText.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Specialized;
using System.Xml.XPath;

namespace HiToText
{
    class Program
    {
        public static List<string> supportedGames = new List<string>();
        public static HXMLReader r = new HXMLReader();

#if DEBUG
        public const string HTT_XML = @"E:\Stuff\Nick Test\SVN\hitotext\HiToText.xml";
#else
        public const string HTT_XML = "HiToText.xml";
#endif

        #region SERVER PATHS
        private static string updatePath = "http://www.hitotext.com/HiToText/update.txt";
        private static string versionPath = "http://www.hitotext.com/HiToText/version.txt";
        #endregion

        #region LEGACY DRIVERS
        private static Hiscore[] m_games =
        {
            new _1942(),
            //new galaga(),
            new msword(),
            //new dkong(),
            new puckman(),
            new mrdo(),
            new mappy(),
            //new asterix(),
            //new digdug2(),
            new jackal(),
            new pulstar(),
            new ddonpach(),
            //new contra(),
            new suprmrio(),
            //new galaxian(),
            new zaxxon(),
            new mhavoc(),
            //new ckong(),
            //new dkongjr(),
            new raiden(),
            new marble(),
            new wb3(),
            //new digdug(),
            //new btime(),
            new gigawing(),
            //new dkong3(),
            new sf2(),
            //new frogger(),
            new gng(),
            new mario(),
            //new altbeast(),
            new simpsons(),
            new roadrunn(),
            //new daioh(),
            new xmen(),
            //new bublbobl(),
            new captaven(), 
            new knights(), //Added in version 11/26/08
            new rtype(),
            new spdodgeb(),
            //new bombjack(), //Added in version 12/1/2008
            new hyprduel(),
            new metrocrs(),
            new hyperpac(), 
            //new bnzabros(), //Added in version 20081212
            new gijoe(),
            new nitd(),
            new defender(), //Added in version 20081218
            new jjsquawk(),
            new ccastles(),
            new gunsmoke(),
            //new elevator(),
            new junglek(),
            new tempest(), //Added in version 20081222
            new sci(),
            new upndown(),
            //new dowild(),
            //new alibaba(),
            //new _1943(), //Added in version 20090106
            /*new invaders(),*/ new searthin(), //new darthvdr(),
            new slapfigh(),
            new phoenix(),
            //new dino(),
            //new columns(),
            //new djboy(), //Added in version 2009.1.17
            new tmnt2(),
            new dragnblz(),
            new mrdrillr(),
            //new asteroid(),
            new tmnt(),
            new pacmania(),
            //new dorunrun(),
            //new commando(),
            //new dariusg(), //Added in version 2009.2.5
            new outzone(),
            new trackfld_090410(),
            //new centiped(),
            new xmvsf(),
            //new cclimber(),
            new milliped(),
            new mooncrst(),
            new mpatrol(),
            //new arkanoid(),
            new tetris(), //Added in version 2009.2.11 
            new zookeep(),
            //new _005(), //Added in version 2009.2.20
            //new _8ballact(),
            //new aliensyn(),
            new spf2t(),
            new gauntlet(),
            new paperboy(),
            new junofrst(), //Added in version 2009.3.25
            new pbaction(),
            new rtype2(),
            new s1945ii(),
            new aquajack(),
            //new balonfgt(),
            //new _4dwarrio(),
            //new extrmatn(),
            new hvysmsh(),
            new imgfight(),
            //new _10yard(),
            //new bullfgt(),
            //new explorer(),
            //new eyes(),
            new kchamp(),
            new scramble(),
            //new viofight(), 
            //new amidar(), //Added in version 2009.4.15
            //new arknoid2(),
            //new arkretrn(),
            //new astdelux(),
            //new baddudes(),
            //new bagman(),
            //new bzone(),
            //new carnival(),
            //new ddribble(),
            //new frogs(),
            //new gberet(),
            new robotron(),
            new sdtennis(),
            //new seawolf(),
            new seawolf2(),
            new kungfum(), //Added in version 2009.5.29
            //new circusc(),
            //new ddragon(),
            new pacland(),
            new matmania(),
            //new bankp(),
            new punchout(),
            new spnchout(), new spnchotj(),
            new kamikcab(),
            new rastan(),
            new robocop(),
            //new blktiger(),
            new wrally(),
            new vigilant(),
            new srumbler(),
            new wboy(),
            new yiear(),
            new vendetta(),
            new twincobr(),
            new popeye(), //Added in version 2009.6.19
            new silkworm(),
            new esprade(),
            //new gyruss(),
            new timeplt(),
            new jungler(),
            new ladybug(),
            //new brubber(),
            new shadoww(),
            new trackfld(), //Added in version 2009.6.29
            new rygar(),
            //new bloodbro(),
            //new blueprnt(),
            //new crush(),
            //new bjtwin(),
            new steelwkr(),
            //new _1941(),
            new klax(),
            new terracre(),
            new rthunder(),
            new astyanax(),
            new turfmast(),
            new kangaroo(), //Added in version 2009.7.1
            new swimmer(),
            //new _1944(),
            new troangel(),
            //new exprraid(), new exprrada(),
            new pooyan(), //Added in version 2009.7.14
            new rpatrol(),
            new joust(),
            new joust2(),
            new headon(), new headon2(), new headoni(),
            //new crzrally(),
            //new cabal(),
            //new dotron(), new dotrone(),
            new toki(),
            new tron(),
            new narc(), //Added in version 2009.8.4
            new unsquad(),
            //new ajax(),
            new qbert(),
            new mk(), new mkla1(),
            new armora(),
            new boxingb(),
            new ripoff(),
            new speedfrk(),
            new starcas(),
            new tailg(),
            //new barrier(), //Added in version 2009.8.5
            //new batsugun(),
            //new battlcry(),
            //new chasehq(),
            new demon(),
            new pengo(),
            new qb3(),
            new solarq(),
            new sundance(),
            new wotw(),
            new woodpeck(), //Added in version 2009.9.1
            new nmouse(),
            new journey(),
            new tapper(),
            new timber(),
            new domino(),
            new mk2(),
            new berzerk(),
            new _19xx(),
            //new blockout(), //Added in version 2009.9.16
            //new brkthru(),
            //new cleopatr(),
            new dazzler(),
            //new deadeye(),
            //new dynagear(),
            new lrescue(),
            new madalien(),
            new megadon(),
            new mimonkey(),
            new missile(), new missile2(),
            new mslug(),
            new mslug2(),
            new mslug3(), new mslug4(), new mslug5(),
            new mslugx(),
            new mtlchamp(),
            new mwalk(),
            new naughtyb(),
            new nemesis(),
            new nova2001(),
            new olibochu(),
            new omegaf(), new omegafs(),
            new qbertqub(),
            new starwars(),
            new streakng(),
            new subroc3d(),
            //new boomrang(),
            //new evilston(),
            new pirates(),
            new redbaron(),
            new sprint1(),
            new hyperspt() //Added in version 2010.1.26
        };
        #endregion

        private static void Initialize(ConsoleFlags flag, string romName)
        {
            //Do a fast initalize for a legacy read.
            if (flag.Equals(ConsoleFlags.ReadAll) || flag.Equals(ConsoleFlags.Read))
            {
                XPathDocument docNav = new XPathDocument(HTT_XML);
                XPathNavigator nav = docNav.CreateNavigator();
                string strExpression =
                    string.Format("/HiToText/Entry[Header/Games/Name=\"{0}\"]", romName);
                XPathNodeIterator NodeIter = nav.Select(strExpression);
                NodeIter.MoveNext();

                r = new HXMLReader(NodeIter.Current);
            }
            else
            {
                //Load up XML file
#if DEBUG
                r = new HXMLReader(HTT_XML);
#else
                if (File.Exists(HTT_XML))
                    r = new HXMLReader(HTT_XML);
#endif
            }
            supportedGames = r.GetSupportedGames();
        }

        static void Main(string[] args)
        {
#if DEBUG_TIME
            //TimingTest();
            TimingTestCompare();
            return;
#endif
#if DEBUG
            DateTime tStart = DateTime.Now;
            string dRom = "4dwarrio";
#endif
            bool isLegacyStart = false;
            string cmdLine = string.Empty;
            CsvParser parser = new CsvParser();
            parser.separator = ' ';

#if DEBUG_READ
            cmdLine = string.Format(@"-ra ""E:\Stuff\Nick Test\hi\{0}.hi""", dRom);
#elif DEBUG_LIST
            cmdLine = string.Format(@"-lp ""E:\Stuff\Nick Test\mame.exe""");
#elif DEBUG_WRITE
            string dToWrite = "1 62000 NLA";
            cmdLine = string.Format(@"-w ""E:\Stuff\Nick Test\hi\{0}.hi"" {1}", dRom, dToWrite);
#endif

            if (args.Length > 0)
                isLegacyStart = true;

            if (isLegacyStart)
            {
#if !DEBUG
                cmdLine = "\"" + string.Join("\" \"", args) + "\"";
#endif
                StringCollection commands = parser.ParseCsv(cmdLine);

                //Put anything that would only need to be run once in the initialize function.
#if DEBUG_READ
                Initialize(ConsoleFlags.ReadAll, dRom);
#else
                if (commands.Count > 1)
                    Initialize(GetFlagFromString(commands[0].ToLower()), Path.GetFileNameWithoutExtension(commands[1]));
                else
                    Initialize(ConsoleFlags.None, string.Empty);
            
                PerformCommand(commands);
                return;
                
#endif
            }
            else
                Initialize(ConsoleFlags.None, string.Empty);
            
#if DEBUG
            DateTime tAIStart = DateTime.Now;
#endif

            Console.WriteLine("HiToText initialized, please enter command. (-h for help)");
            Console.Write(">");
#if DEBUG
            if (true)
            {
#else
            while (!(cmdLine = Console.ReadLine()).Equals("-q"))
            {
#endif
                PerformCommand(parser.ParseCsv(cmdLine));

#if DEBUG
                DateTime tAIEnd = DateTime.Now;
                double totalAITimems = tAIEnd.Subtract(tAIStart).TotalMilliseconds;
                Console.WriteLine(string.Format("Inner operation took {0}ms to complete.", totalAITimems.ToString("#.00#")));
#else
                Console.Write(">");
#endif
            }

            Console.WriteLine("Exitting HiToText.");

#if DEBUG
            DateTime tEnd = DateTime.Now;
            double totalTimems = tEnd.Subtract(tStart).TotalMilliseconds;
            Console.WriteLine(string.Format("Operation took {0}ms to complete.", totalTimems.ToString("#.00#")));
#endif
        }

        private static void PerformCommand(StringCollection cmdLineArgs)
        {
            ConsoleFlags flag = ConsoleFlags.None;
            string fileName = null;
            string romName = null;
            string mameFolder = String.Empty;
            List<string> scoreData = new List<string>();
            Hiscore game = null;

            if (cmdLineArgs.Count == 0)
            {
                WriteUsage();
                return;
            }

            flag = GetFlagFromString(cmdLineArgs[0].ToLower());

            if (cmdLineArgs.Count >= 2 &&
                !flag.Equals(ConsoleFlags.Update) &&
                !flag.Equals(ConsoleFlags.ListParents) &&
                !flag.Equals(ConsoleFlags.Version))
            {
                fileName = Path.GetFullPath(
                    Path.GetExtension(cmdLineArgs[1]) == String.Empty ? cmdLineArgs[1] + ".hi" : cmdLineArgs[1]).Replace('/', '\\');
                try
                {
                    mameFolder = GetMAMEFolderFromFileName(fileName);
                }
                catch
                {
                    Console.WriteLine(String.Format("Error: MAME directory could not be inferred from '{0}'", fileName));
                }

                romName = Path.GetFileNameWithoutExtension(fileName);

                List<string> possibleFileNames = GetPossibleFileNames(mameFolder, romName);

                bool isVersionSpecified = false;
                
                DateTime dVersion = DateTime.Now;
                int argCounter = 0;
                foreach (string argument in cmdLineArgs)
                {
                    if (argument.Equals("-v"))
                    {
                        if (cmdLineArgs.Count >= argCounter + 1)
                        {
                            Console.WriteLine("Error: Version flag found without version date.");
                            return;
                        }
                        try
                        {
                            dVersion = Convert.ToDateTime(cmdLineArgs[argCounter + 1]);
                        }
#if DEBUG
                        catch (Exception ex)
#else
                        catch
#endif
                        {
                            Console.WriteLine("Error: Could not format version date, please use MMDDYYYY format.");
#if DEBUG
                            Console.WriteLine(Environment.NewLine + ex.Message);
#endif
                            return;
                        }
                        isVersionSpecified = true;
                    }
                    argCounter++;
                }

                if (!isVersionSpecified && IsVersionRequired(romName))
                    dVersion = GetMAMEVersionAsDate(mameFolder);

                if (DoesAFileNameExist(possibleFileNames) && !File.Exists(fileName))
                {
                    Console.WriteLine(String.Format("Error: File Not Found '{0}'", fileName));
                    return;
                }

                if (supportedGames.Contains(romName))
                {
                    game = new General(r.GetEntry(romName));
                    game.FileNames = GetFileNamesFromGame(mameFolder, romName, game);
                }
                else
                {
                    if (!TryGetGame(romName, mameFolder, dVersion, out game))
                    {
                        Console.WriteLine(String.Format("Error: ROM Not Supported '{0}'", romName));
                        return;
                    }
                }
            }

            switch (flag)
            {
                #region READ
                case ConsoleFlags.Read:
                    if (game != null)
                    {
                        try
                        {
                            Console.WriteLine(RemoveAlternates(game.HiToString()));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                    else
                        Console.WriteLine("Error: No ROM Specified");
                    break;
                #endregion

                #region READ ALL
                case ConsoleFlags.ReadAll:
                    if (game != null)
                        try
                        {
                            Console.WriteLine(game.HiToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    else
                        Console.WriteLine("Error: No ROM Specified");
                    break;
                #endregion

                #region WRITE
                case ConsoleFlags.Write:
                    if (game != null)
                    {
                        for (int i = 2; i < cmdLineArgs.Count; i++)
                            scoreData.Add(cmdLineArgs[i]);
#if DEBUG
                        if (true)
#else
                        if (scoreData.Count == game.FieldCount)
#endif
                        {
                            try
                            {
                                game.SetHiScore(scoreData.ToArray());
                                game.SaveData();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
#if DEBUG
#else
                        else
                            Console.WriteLine(String.Format("Error: Expecting {0} Entries", game.FieldCount));
#endif
                    }
                    else
                        Console.WriteLine("Error: No ROM Specified");
                    break;
                #endregion

                #region WRITE ALTERNATE
                case ConsoleFlags.WriteAlternate:
                    if (game != null)
                    {
                        if (game.NumAltScores == 0)
                            Console.WriteLine(String.Format("Error: {0} Does Not Contain Any Alternate Scores", romName));
                        else
                        {
                            int gameLoc = -1;
                            for (int i = 2; i < cmdLineArgs.Count; i++)
                                scoreData.Add(cmdLineArgs[i]);

                            for (int i = 0; i < game.NumAltScores; i++)
                            {
                                if (cmdLineArgs[2].ToUpper().Equals(game.AltFormat[i].Substring(0, game.AltFormat[i].IndexOf(Environment.NewLine))))
                                {
                                    gameLoc = i;
                                    break;
                                }
                            }

                            if (gameLoc == -1)
                                Console.WriteLine(String.Format("Error: \"{0}\" Does Not Match Any Known Alternate Score Names", cmdLineArgs[2]));
                            else
                            {
                                if ((scoreData.Count - 1) == game.AltFieldCount[gameLoc])
                                {
                                    try
                                    {
                                        game.SetAlternateScore(scoreData.ToArray());
                                        game.SaveData();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Error: " + ex.Message);
                                    }
                                }
                                else
                                    Console.WriteLine(String.Format("Error: Expecting {0} Entries For Alternate Score \"{1}\"", game.AltFieldCount[gameLoc], game.AltScoreName[gameLoc]));
                            }
                        }
                    }
                    else
                        Console.WriteLine("Error: No ROM Specified");
                    break;
                #endregion

                #region FORMAT
                case ConsoleFlags.Format:
                    if (game != null)
                        Console.WriteLine(game.Format);
                    else
                        Console.WriteLine("Error: No ROM Specified");
                    break;
                #endregion

                #region FORMAT ALTERNATE
                case ConsoleFlags.FormatAlternate:
                    if (game != null)
                    {
                        if (game.NumAltScores == 0)
                            Console.WriteLine(String.Format("Error: {0} Does Not Contain Any Alternate Scores", romName));
                        else
                        {
                            for (int i = 0; i < game.AltFormat.Length; i++)
                                Console.WriteLine(game.AltFormat[i].Replace(Environment.NewLine, "|"));
                        }
                    }
                    else
                        Console.WriteLine("Error: No ROM Specified");
                    break;
                #endregion

                #region LIST
                case ConsoleFlags.List:
                    try
                    {
                        ListGamesSupported();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("Error: {0}", ex.Message));
                    }
                    break;
                #endregion

                #region LIST PARENTS
                case ConsoleFlags.ListParents:
                    try
                    {
                        ListParentGamesSupported(cmdLineArgs[1]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("Error: {0}", ex.Message));
                    }
                    break;
                #endregion

                #region UPDATE
                case ConsoleFlags.Update:
                    try
                    {
                        Version latestVersion = new Version(ReadTxtFrom(versionPath, cmdLineArgs[1]));
                        if (GetVersion().CompareTo(latestVersion) < 0)
                            Console.WriteLine(ReadTxtFrom(updatePath, cmdLineArgs[1]));
                        else
                            Console.WriteLine("No newer version available.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                    break;
                #endregion

                #region VERSION
                case ConsoleFlags.Version:
                    if (cmdLineArgs.Count < 2)
                    {
                        Console.WriteLine("Error: Not enough command line arguments. (-h for help)");
                        return;
                    }
                    try
                    {
                        Console.WriteLine(GetMAMEVersionAsDate(cmdLineArgs[1]).ToString("MMddyyyy"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;
                #endregion

                #region ERASE
                case ConsoleFlags.Erase:
                    try
                    {
                        if (game != null)
                        {
                            game.EmptyScores();
                            //SaveData is now done in the general hiscoreData.
                            //game.SaveData();
                        }
                        else
                            Console.WriteLine("Error: No ROM Specified");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;
                #endregion

                #region MODIFY
                case ConsoleFlags.Modify:
                    try
                    {
                        if (game != null)
                        {
                            game.ModifyName(Convert.ToInt32(cmdLineArgs[3]), cmdLineArgs[4]);
                            game.SaveData();
                        }
                        else
                            Console.WriteLine("Error: No ROM Specified");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;
                #endregion

                #region HELP
                case ConsoleFlags.Help:
                    WriteUsage();
                    break;
                #endregion
            }
        }

        private static bool DoesAFileNameExist(List<string> possibleFileNames)
        {
            foreach (string fileName in possibleFileNames)
            {
                if (File.Exists(fileName))
                    return true;
            }

            return false;
        }

        //TODO: Find a smarter way to contain this information rather than hardcoding.
        //TODO: Add save state file names, and locations.
        private static List<string> GetPossibleFileNames(string mameFolder, string romName)
        {
            List<string> toReturn = new List<string>();

            toReturn.Add(Path.Combine(Path.Combine(mameFolder, "hi"), romName + ".hi"));
            toReturn.Add(Path.Combine(Path.Combine(mameFolder, "nvram"), romName + ".nv"));

            return toReturn;
        }

        private static bool IsVersionRequired(string romName)
        {
            foreach (Hiscore h in m_games)
            {
                foreach (string gName in h.GamesSupported)
                {
                    if (romName.Equals(gName))
                    {
                        if (h.GetVersionDate.Equals(DateTime.MaxValue))
                            return false;
                        else
                            return true;
                    }
                }
            }

            return false;
        }

        private static string[] GetFileNamesFromGame(string mameFolder, string romName, Hiscore game)
        {
            List<string> possibleFileNames = GetPossibleFileNames(mameFolder, romName);

            string[] extReq = game.ExtensionsRequired;
            string[] fileNameArray = new String[extReq.Length];
            for (int x = 0; x < extReq.Length; x++)
            {
                foreach (string pfn in possibleFileNames)
                {
                    if (extReq[x].Equals(Path.GetExtension(pfn)))
                    {
                        if (File.Exists(pfn))
                            fileNameArray[x] = pfn;
                        else
                            fileNameArray[x] = romName + extReq[x];

                        break;
                    }
                }
            }

            return fileNameArray;
        }

        //TODO: Throw save states in here.
        private static string GetMAMEFolderFromFileName(string fileName)
        {
            string mameFolder = string.Empty;

            if (fileName.IndexOf("\\hi\\") == -1)
            {
                //No longer throw an exception due to not finding the MAME directory.
                if (fileName.IndexOf("\\nvram\\") == -1)
                    //throw new Exception(String.Format("Error: MAME directory could not be inferred from '{0}'", fileName));
                    return mameFolder;
                else
                    mameFolder = Path.GetDirectoryName(fileName).Substring(0, fileName.IndexOf("\\nvram\\"));
            }
            else
                mameFolder = Path.GetDirectoryName(fileName).Substring(0, fileName.IndexOf("\\hi\\"));

            return mameFolder;
        }

        private static ConsoleFlags GetFlagFromString(string flag)
        {
            switch (flag.ToLower())
            {
                case "-r":
                    return ConsoleFlags.Read;
                case "-ra":
                    return ConsoleFlags.ReadAll;
                case "-w":
                    return ConsoleFlags.Write;
                case "-wa":
                    return ConsoleFlags.WriteAlternate;
                case "-f":
                    return ConsoleFlags.Format;
                case "-fa":
                    return ConsoleFlags.FormatAlternate;
                case "-l":
                    return ConsoleFlags.List;
                case "-lp":
                    return ConsoleFlags.ListParents;
                case "-u":
                    return ConsoleFlags.Update;
                case "-v":
                    return ConsoleFlags.Version;
                case "-e":
                    return ConsoleFlags.Erase;
                case "-m":
                    return ConsoleFlags.Modify;
                case "-h":
                default:
                    return ConsoleFlags.Help;
            }
        }

        private static bool TryGetGame(string romName, string mameFolder, DateTime versionAllowed, out Hiscore game)
        {
            game = null;
            List<Hiscore> validGames = new List<Hiscore>();

            for (int i = 0; i < m_games.Length; i++)
            {
                string[] gamesSupported = m_games[i].GamesSupported;

                for (int j = 0; j < gamesSupported.Length; j++)
                {
                    if (gamesSupported[j] == romName)
                        validGames.Add(m_games[i]);
                }
            }

            DateTime oldestValid = DateTime.Now;
            foreach (Hiscore gm in validGames)
            {
                if ((gm.GetVersionDate.CompareTo(oldestValid) <= 0 && 
                    gm.GetVersionDate.CompareTo(versionAllowed) >= 0) ||
                    gm.GetVersionDate.Equals(DateTime.MaxValue))
                {
                    game = gm;
                    oldestValid = gm.GetVersionDate;
                }
            }

            if (game != null)
            {
                game.FileNames = GetFileNamesFromGame(mameFolder, romName, game);
                return true;
            }

            return false;
        }

        private static List<string> GetSupportedGames()
        {
            List<string> gameArray = new List<string>();

            for (int i = 0; i < m_games.Length; i++)
                gameArray.AddRange(m_games[i].GamesSupported);

            gameArray.AddRange(supportedGames);

            gameArray.Sort();

            return gameArray;
        }

        private static void ListGamesSupported()
        {
            List<string> gameArray = GetSupportedGames();

            for (int i = 0; i < gameArray.Count; i++)
                Console.WriteLine(gameArray[i]);
        }

        private static void ListParentGamesSupported(string mameExe)
        {
            List<string> gameArray = GetSupportedGames();

            mame xMAME = new mame();

            XmlSerializer xSerial = new XmlSerializer(typeof(mame));
#if DEBUG_CHILLIN
            Console.WriteLine("DEBUG: MAME serializer initialized.");
#endif
            byte[] bytes = Encoding.ASCII.GetBytes(String.Join(Environment.NewLine, GetMAMEFullXML(mameExe).ToArray()));
            MemoryStream ms = new MemoryStream(bytes);

#if DEBUG_CHILLIN
            Console.WriteLine(string.Format("DEBUG: {0} bytes long.", bytes.Length));
#endif

            if (ms == null)
            {
                Console.WriteLine(string.Format("{0} is not a valid mame.exe file. HiToText cannot list parents supported without a valid mame.exe.", mameExe));
                return;
            }

            using (XmlReader reader = XmlReader.Create(ms))
            {
                xMAME = (mame)xSerial.Deserialize(reader);
                reader.Close();
                bytes = new byte[0];
                ms.Close();
            }

#if DEBUG_CHILLIN
            Console.WriteLine("DEBUG: MAME serializer utilized successfully.");
#endif

            List<string> supportedParents = new List<string>();
            foreach (string game in gameArray)
            {
                foreach (mameGame mg in xMAME.game)
                {
                    if (mg.name.Equals(game))
                    {
                        if (mg.cloneof == null)
                            supportedParents.Add(game);
                        break;
                    }
                }
            }

            supportedParents.Sort();
            for (int i = 0; i < supportedParents.Count; i++)
                Console.WriteLine(supportedParents[i]);
        }

        private static List<string> GetMAMEFullXML(string mameExe)
        {
            string info = ShellMAME(mameExe, "-listxml");

            string[] lines = info.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            List<string> XMLLines = new List<string>(lines);
            for (int i = 0; i < XMLLines.Count; i++)
            {
                if (XMLLines[i].Length < 5)
                {
#if DEBUG_CHILLIN
                    Console.WriteLine(string.Format("DEBUG: Line \"{0}\" removed.", XMLLines[i]));
#endif
                    XMLLines.RemoveAt(i);
                    i--;
                }
                else
                {
                    if (XMLLines[i].Substring(0, 5).Equals("<mame"))
                    {
#if DEBUG_CHILLIN
                        Console.WriteLine(string.Format("DEBUG: Line \"{0}\" found.", XMLLines[i]));
#endif
                        break;
                    }
                    else
                    {
#if DEBUG_CHILLIN
                        Console.WriteLine(string.Format("DEBUG: Line \"{0}\" removed.", XMLLines[i]));
#endif
                        XMLLines.RemoveAt(i);
                        i--;
                    }
                }
            }

            for (int i = XMLLines.Count - 1; i > 0; i--)
            {
                if (XMLLines[i].Length < 6)
                {
#if DEBUG_CHILLIN
                    Console.WriteLine(string.Format("DEBUG: Line \"{0}\" removed.", XMLLines[i]));
#endif
                    XMLLines.RemoveAt(i);
                }
                else
                {
                    if (XMLLines[i].Substring(0, 6).Equals("</mame"))
                    {
#if DEBUG_CHILLIN
                        Console.WriteLine(string.Format("DEBUG: Line \"{0}\" found.", XMLLines[i]));
#endif
                        break;
                    }
                    else
                    {
#if DEBUG_CHILLIN
                        Console.WriteLine(string.Format("DEBUG: Line \"{0}\" removed.", XMLLines[i]));
#endif
                        XMLLines.RemoveAt(i);
                    }
                }
            }

            lines = new string[0];
#if DEBUG_CHILLIN
            Console.WriteLine(string.Format("DEBUG: First line \"{0}\".", XMLLines[0]));
            Console.WriteLine(string.Format("DEBUG: Last line \"{0}\".", XMLLines[XMLLines.Count - 1]));
#endif
            return XMLLines;
        }

        private static string RemoveAlternates(string hiTable)
        {
            //Search for three new lines, remove up to that.
            int newLines = hiTable.IndexOf(Environment.NewLine + Environment.NewLine + Environment.NewLine);
            if (newLines != -1)
                return hiTable.Substring(0, newLines);
            else
                return hiTable;
        }

        private static void WriteUsage()
        {
            Console.WriteLine("USAGE: [-r|-ra|-w|-wa|-m|-f|-fa|-e|-l|-lp|-u|-v|-h|-q] [FILENAME|REFERRER] [SCORE DATA SEPARATED BY SPACES] (-v [DATE IN MMDDYYYY FORMAT])");
            Console.WriteLine();
            Console.WriteLine("-r  : Read             e.g. -r  trackfld.nv");
            Console.WriteLine("-ra : Read All         e.g. -ra trackfld.nv");
            Console.WriteLine("-ra : Read All         e.g. -ra trackfld.nv -v 06222009");
            Console.WriteLine("-w  : Write            e.g. -w  trackfld.nv 1 100000 FOO");
            Console.WriteLine("-wa : Write Alternate  e.g. -wa trackfld.nv \"LONG JUMP WORLD RECORD\" 1 9.12m FOO");
            Console.WriteLine("-m  : Modify           e.g. -m  trackfld.nv 1 FOO");
            Console.WriteLine("-f  : Format           e.g. -f  trackfld.nv");
            Console.WriteLine("-fa : Format Alternate e.g. -fa trackfld.nv");
            Console.WriteLine("-e  : Erase All Scores e.g. -e  trackfld.nv");
            Console.WriteLine("-l  : List Games       e.g. -l");
            Console.WriteLine("-lp : List Parents     e.g. -lp [FULL PATH TO MAME]");
            Console.WriteLine("-u  : Update           e.g. -u  [REFERRER]");
            Console.WriteLine("-v  : Version          e.g. -v  [FULL PATH TO MAME FOLDER]");
            Console.WriteLine("-h  : Help             e.g. -h");
            Console.WriteLine("-q  : Quit             e.g. -q");
            Console.WriteLine();
            Console.WriteLine("NOTES: To write a hiscore entry, view the format first to get the score or alternate data format.");
            Console.WriteLine("       Ensure that you use quotation marks around fields that contain spaces.");
            Console.WriteLine("       If the update command sees a newer version it will return a URL to download a newer version.");
            Console.WriteLine("       If it's determined that there is no new version, it will return \"No newer version available.\"");
            Console.WriteLine("       REFERRER should be something simple so some statistics can be tracked.");
            Console.WriteLine();
            Console.WriteLine("       The version command will show you what version of MAME HiToText thinks you are using.");
            Console.WriteLine("       This is done by date. HiToText will use today's date if it cannot find the version ");
            Console.WriteLine("       information automatically.");
            Console.WriteLine();
            Console.WriteLine("       You can specify your own version (by date) of HiToText if it is not ");
            Console.WriteLine("       determining your version correctly. You can only do this with the -r, -ra, -w, and -wa flags.");
            Console.WriteLine("       You can see your mame version by running mame with the -help command. (e.g. mame -help).");
            Console.WriteLine();
            Console.WriteLine("       Different versions of MAME will read .hi or nvram files differently so be sure HiToText is");
            Console.WriteLine("       using the correct version for your files.");
            Console.WriteLine();
            Console.WriteLine("       The modify command only takes a score rank and a name field, and instead of inserting a score");
            Console.WriteLine("       will use the data provided to modify the name of the score given by the rank provided.");
            Console.WriteLine();
        }

        private static Version GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        }

        public static string GetMAMEExeFromFolder(string mameFolder)
        {
#if DEBUG_CHILLIN
            Console.WriteLine(string.Format("DEBUG: MAME folder: {0}", mameFolder));
#endif
            if (mameFolder.Equals(string.Empty))
                return string.Empty;

            string mameExe = String.Empty;
            string[] exes = Directory.GetFiles(mameFolder, "*mame*.exe");
#if DEBUG_CHILLIN
            Console.WriteLine("DEBUG: MAME.exes found: " + exes.Length);
            foreach (string s in exes)
                Console.WriteLine("DEBUG: " + s);
#endif
            if (exes.Length > 0)
                return exes[0];
            else
                return string.Empty;
        }

        private static string ShellMAME(string mamePath, string commandLineArguments)
        {
            string mameExe = mamePath;
            if (!Path.GetExtension(mamePath).Equals(".exe"))
                mameExe = GetMAMEExeFromFolder(mamePath);

            ProcessStartInfo cmd = new ProcessStartInfo("cmd.exe");
            cmd.CreateNoWindow = true;
            cmd.RedirectStandardInput = true;
            cmd.RedirectStandardOutput = true;
            cmd.UseShellExecute = false;
            Process verify = Process.Start(cmd);
            StreamWriter sw = verify.StandardInput;
            StreamReader sr = verify.StandardOutput;
            sw.WriteLine(Directory.GetDirectoryRoot(mameExe).Substring(0, 2));
#if DEBUG_CHILLIN
            Console.WriteLine(string.Format("DEBUG: Command written: {0}", Directory.GetDirectoryRoot(mameExe).Substring(0, 2)));
#endif
            sw.WriteLine("cd \"" + Path.GetDirectoryName(mameExe) + "\"");
#if DEBUG_CHILLIN
            Console.WriteLine(string.Format("DEBUG: Command written: {0}", "cd \"" + Path.GetDirectoryName(mameExe) + "\""));
#endif
            sw.WriteLine("\"" + Path.GetFileNameWithoutExtension(mameExe) + "\" " + commandLineArguments);
#if DEBUG_CHILLIN
            Console.WriteLine(string.Format("DEBUG: Command written: {0}", "\"" + Path.GetFileNameWithoutExtension(mameExe) + "\" " + commandLineArguments));
#endif
            sw.Close();

            string info = "";

            while (!sr.EndOfStream)
                info += sr.ReadToEnd();

            sr.Close();
            verify.Close();

            return info;
        }

        private static DateTime GetMAMEVersionAsDate(string mameFolder)
        {
            string info = ShellMAME(mameFolder, "-help");
            if (info.Equals(string.Empty))
                return DateTime.Now;

            bool foundDate = false;
            DateTime dVersion = DateTime.Now;
            string restOfInfo = info;
            while (!foundDate)
            {
                try
                {
                    int leftParens = restOfInfo.IndexOf('(');
                    if (leftParens != -1)
                    {
                        string afterLeftParens = restOfInfo.Substring(leftParens + 1);
                        int rightParens = afterLeftParens.IndexOf(')');
                        if (rightParens != -1)
                        {
                            string version = afterLeftParens.Substring(0, rightParens);
                            restOfInfo = afterLeftParens.Substring(rightParens + 1);
                            dVersion = Convert.ToDateTime(version);
                            foundDate = true;
                        }
                        else
                            foundDate = true;
                    }
                    else
                        foundDate = true;
                }
#if DEBUG
                catch (Exception ex)
#else
                catch
#endif
                {
                    foundDate = false;
#if DEBUG
                    Console.WriteLine(Environment.NewLine + ex.Message);
#endif
                }
            }

            return dVersion;
        }

        private static string ReadTxtFrom(string remoteURL, string referrer)
        {
            string toReturn = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(remoteURL);
                request.UserAgent = "HiToText v" + GetVersion();
                request.Referer = "http://www.hitotext.com/" + referrer;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream());
                toReturn = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return toReturn;
        }

        [Conditional("DEBUG_TIME")]
        private static void TimingTest()
        {
            List<string> toWrite = new List<string>();
            List<double> cTimes = new List<double>();
            DateTime iStart = DateTime.Now;
            Initialize(ConsoleFlags.None, string.Empty);
            DateTime iEnd = DateTime.Now;
            double iTimems = iEnd.Subtract(iStart).TotalMilliseconds;
            toWrite.Add(string.Format("Initialize() took {0}ms to complete.", iTimems.ToString("#.00#")));

            List<string> hiFiles = new List<string>(Directory.GetFiles(@"E:\Stuff\Nick Test\hi\"));

            for (int i = 0; i < 50; i++)
            {
                string dRom = 
                    Path.GetFileName(hiFiles[new Random(DateTime.Now.Millisecond).Next(0, hiFiles.Count)]);
                DateTime cStart = DateTime.Now;
                CsvParser parser = new CsvParser();
                parser.separator = ' ';
                string cmdLine = string.Format(@"-ra ""E:\Stuff\Nick Test\hi\{0}""", dRom);
                PerformCommand(parser.ParseCsv(cmdLine));
                DateTime cEnd = DateTime.Now;

                double cTimems = cEnd.Subtract(cStart).TotalMilliseconds;
                toWrite.Add(string.Format("Reading {0} took {1}ms to complete.", dRom, cTimems.ToString("#.00#")));
                cTimes.Add(cTimems);
            }

            foreach (string w in toWrite)
                Console.WriteLine(w);

            double cTotal = 0.00;
            foreach (double d in cTimes)
                cTotal += d;

            Console.WriteLine(
                string.Format(
                    "Average time for {0} reads: {1}ms",
                        cTimes.Count.ToString(),
                        (cTotal / ((double)cTimes.Count)).ToString()));
        }

        [Conditional("DEBUG_TIME")]
        private static void TimingTestCompare()
        {
            List<string> toWrite = new List<string>();
            List<double> cTimes = new List<double>();
            
            List<string> hiFiles = new List<string>(Directory.GetFiles(@"E:\Stuff\Nick Test\hi\strict\"));

            for (int i = 0; i < 50; i++)
            {
                string dRom =
                    Path.GetFileName(hiFiles[new Random(DateTime.Now.Millisecond).Next(0, hiFiles.Count)]);
                DateTime cStart = DateTime.Now;
                CsvParser parser = new CsvParser();
                parser.separator = ' ';
                string cmdLine = string.Format(@"-ra ""E:\Stuff\Nick Test\hi\{0}""", dRom);
                Initialize(ConsoleFlags.ReadAll, Path.GetFileNameWithoutExtension(dRom));
                PerformCommand(parser.ParseCsv(cmdLine));
                DateTime cEnd = DateTime.Now;

                double cTimems = cEnd.Subtract(cStart).TotalMilliseconds;
                toWrite.Add(string.Format("Reading {0} took {1}ms to complete.", dRom, cTimems.ToString("#.00#")));
                cTimes.Add(cTimems);
            }

            foreach (string w in toWrite)
                Console.WriteLine(w);

            double cTotal = 0.00;
            foreach (double d in cTimes)
                cTotal += d;

            Console.WriteLine(
                string.Format(
                    "Average time for {0} reads: {1}ms",
                        cTimes.Count.ToString(),
                        (cTotal / ((double)cTimes.Count)).ToString()));
        }
    }
}
