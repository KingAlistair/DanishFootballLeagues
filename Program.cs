using Microsoft.VisualBasic.FileIO;
class Program
{
    static void Main(string[] args)
    { 

    string teamFilePath = "files/teams.csv";
    string matchFilePath = "files/rounds/SL_round1.csv";
    string leagueFilePath = "files/setup.csv";

    CSVReader cSVReader = new CSVReader();

   List<Team> teams = cSVReader.ReadTeams(teamFilePath);

    foreach(var team in teams){

        Console.WriteLine(team.TeamAbbreviation + "Team list ");
    }

    League league = League.FromCsvFile(leagueFilePath);

      LeagueProcessor leagueProcessor = new LeagueProcessor(league, teams);
    
    Console.WriteLine(leagueProcessor.teams[0].Name + "teams");
    List<Match> matches = leagueProcessor.ReadMatches(matchFilePath, teams);

    foreach(var match in matches){

        Console.WriteLine(match.HomeTeam.TeamAbbreviation);
    }

    Console.WriteLine(matches[0].HomeTeam.Name + "hellloooooo");
 
    foreach(var match in matches) {
    leagueProcessor.ProcessMatch(match);
    }

    leagueProcessor.DisplayStandings();

    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Write on red");
}
}
