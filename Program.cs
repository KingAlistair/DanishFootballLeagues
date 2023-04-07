class Program
{
    static void Main(string[] args)
    {
        //File paths

        //League
        string leagueFilePath = "files/setup.csv";

        //SL teams and rounds
        string SL_teamFilePath = "files/teams/SL_teams.csv";
        string[] SL_roundsFilePaths = { "files/rounds/SL/SL_round1.csv", "files/rounds/SL/SL_round2.csv", "files/rounds/SL/SL_round3.csv", "files/rounds/SL/SL_round4.csv", "files/rounds/SL/SL_round5.csv", "files/rounds/SL/SL_round6.csv", "files/rounds/SL/SL_round7.csv", "files/rounds/SL/SL_round8.csv", "files/rounds/SL/SL_round9.csv", "files/rounds/SL/SL_round10.csv", "files/rounds/SL/SL_round11.csv",
        "files/rounds/SL/SL_round12.csv", "files/rounds/SL/SL_round13.csv", "files/rounds/SL/SL_round14.csv", "files/rounds/SL/SL_round15.csv", "files/rounds/SL/SL_round16.csv", "files/rounds/SL/SL_round17.csv", "files/rounds/SL/SL_round18.csv", "files/rounds/SL/SL_round19.csv", "files/rounds/SL/SL_round20.csv", "files/rounds/SL/SL_round21.csv", "files/rounds/SL/SL_round22.csv" };

        //NBL teams and round
        string NBL_teamFilePath = "files/teams/NBL_teams.csv";
        string[] NBL_roundsFilePaths = { "files/rounds/NBL/NBL_round1.csv", "files/rounds/NBL/NBL_round2.csv", "files/rounds/NBL/NBL_round3.csv", "files/rounds/NBL/NBL_round4.csv", "files/rounds/NBL/NBL_round5.csv", "files/rounds/NBL/NBL_round6.csv", "files/rounds/NBL/NBL_round7.csv", "files/rounds/NBL/NBL_round8.csv", "files/rounds/NBL/NBL_round9.csv", "files/rounds/NBL/NBL_round10.csv", "files/rounds/NBL/NBL_round11.csv",
        "files/rounds/NBL/NBL_round12.csv", "files/rounds/NBL/NBL_round13.csv", "files/rounds/NBL/NBL_round14.csv", "files/rounds/NBL/NBL_round15.csv", "files/rounds/NBL/NBL_round16.csv", "files/rounds/NBL/NBL_round17.csv", "files/rounds/NBL/NBL_round18.csv", "files/rounds/NBL/NBL_round19.csv", "files/rounds/NBL/NBL_round20.csv", "files/rounds/NBL/NBL_round21.csv", "files/rounds/NBL/NBL_round22.csv" };

        //Main menu
        bool exitProgram = false;
        while (!exitProgram)
        {
            //Console.BackgroundColor = ConsoleColor.Blue;
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Main Menu");
            //Console.ResetColor();
            //Console.BackgroundColor = ConsoleColor.White;
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("1. SuperLiagen standings");
            Console.WriteLine("2. NordicBetLigaen standings");
            Console.WriteLine("3. Exit program");
            //Console.ResetColor();

            Console.Write("Please select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================");
                    Console.WriteLine("SuperLiagen:");
                    Console.WriteLine("=======================================================================================");
                    Program.loadStanding(leagueFilePath: leagueFilePath, teamFilePath: SL_teamFilePath, roundsFilePath: SL_roundsFilePaths);
                    Console.WriteLine("=======================================================================================");
                    break;

                case "2":
                    Console.WriteLine("");
                    Console.WriteLine("=======================================================================================");
                    Console.WriteLine("NordicBetLigaen:");
                    Console.WriteLine("=======================================================================================");
                    Program.loadStanding(leagueFilePath: leagueFilePath, teamFilePath: NBL_teamFilePath, roundsFilePath: NBL_roundsFilePaths);
                    Console.WriteLine("=======================================================================================");
                    break;
                case "3":
                    Console.WriteLine("Exiting program...");
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    //Loads standing depending on menu option chosen
    public static void loadStanding(string leagueFilePath, string teamFilePath, string[] roundsFilePath)
    {
        CSVReader cSVReader = new CSVReader();
        League league = cSVReader.ReadLeague(leagueFilePath);
        List<Team> teams = cSVReader.ReadTeams(teamFilePath);
        LeagueProcessor leagueProcessor = new LeagueProcessor(league, teams);
        List<Match> matches = cSVReader.ReadMatches(roundsFilePath, teams);

        foreach (var match in matches)
        {
            leagueProcessor.ProcessMatch(match);
        }
        leagueProcessor.DisplayStandings();
    }
}