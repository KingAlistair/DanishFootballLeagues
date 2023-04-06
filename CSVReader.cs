public class CSVReader
{

    public League ReadLeague(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();
            string line = reader.ReadLine();
            var values = line.Split(';');

            string leagueName = values[0];
            int promoteToChampionsLeague = int.Parse(values[1]);
            int promoteToEuropeLeague = int.Parse(values[2]);
            int promoteToConferenceLeague = int.Parse(values[3]);
            int promoteToUpperLeague = int.Parse(values[4]);
            int relegateToLowerLeague = int.Parse(values[5]);

            return new League(
                leagueName,
                promoteToChampionsLeague,
                promoteToEuropeLeague,
                promoteToConferenceLeague,
                promoteToUpperLeague,
                relegateToLowerLeague);
        }
    }

    public List<Team> ReadTeams(string filePath)
    {
        List<Team> teams = new List<Team>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            reader.ReadLine();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');

                string abbreviation = tokens[0].Trim();
                string name = tokens[1].Trim();
                string specialRanking = tokens[2].Trim();

                Team team = new Team(abbreviation, name, specialRanking);
                teams.Add(team);
            }
        }

        return teams;
    }

    public List<Match> ReadMatches(string[] filePaths, List<Team> teams)
    {
        var matches = new List<Match>();

        foreach (string filePath in filePaths)
        {

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    // Assuming the CSV is structured as follows:
                    // Home team abbreviation, Away team abbreviation, Score (x-y)
                    var homeTeamAbbr = values[0].Trim();
                    var awayTeamAbbr = values[1].Trim();
                    var homeTeamGoals = values[2].Trim();
                    var awayTeamGoals = values[3].Trim();

                    var homeTeam = teams.FirstOrDefault(t => t.teamAbbreviation == homeTeamAbbr);
                    var awayTeam = teams.FirstOrDefault(t => t.teamAbbreviation == awayTeamAbbr);

                    try
                    {
                        if (homeTeam == null || awayTeam == null)
                        {
                            throw new Exception($"Team {homeTeamAbbr} and/or {awayTeamAbbr} was not found in the teams list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Missing team: {ex.Message}");
                    }

                    int homeTeamGoalsInt = int.Parse(homeTeamGoals);
                    int awayTeamGoalsInt = int.Parse(awayTeamGoals);

                    var match = new Match(homeTeam, awayTeam, homeTeamGoalsInt, awayTeamGoalsInt);

                    matches.Add(match);

                }
            }
        }

        return matches;
    }
}