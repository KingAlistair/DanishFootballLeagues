public class CSVReader
{

    public List<Team> ReadTeams(string filePath)
    {
        List<Team> teams = new List<Team>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            sr.ReadLine();
            string line;
            while ((line = sr.ReadLine()) != null)
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
                            throw new Exception("One or both teams not found in the teams list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
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