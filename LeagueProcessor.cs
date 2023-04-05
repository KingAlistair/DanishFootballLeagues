public class LeagueProcessor
{
    public League league;
    public List<Team> teams;
    public List<Match> matches;
    public Dictionary<string, Standing> standings;

    public LeagueProcessor() {}
    public LeagueProcessor(League league, List<Team> teams)
    {
        this.league = league;
        this.teams = teams;
        matches = new List<Match>();
        standings = new Dictionary<string, Standing>();
    foreach (var team in teams)
    {
        standings[team.TeamAbbreviation] = new Standing(team);
    }
    }

    public List<Match> ReadMatches(string filePath, List<Team> teams)
{
    var matches = new List<Match>();

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

            var homeTeam = teams.FirstOrDefault(t => t.TeamAbbreviation == homeTeamAbbr);
            var awayTeam = teams.FirstOrDefault(t => t.TeamAbbreviation == awayTeamAbbr);

            if (homeTeam == null || awayTeam == null)
            {
                // Handle the case where a team is not found in the teams list
                continue;
            }

            int homeTeamGoalsInt = int.Parse(homeTeamGoals);
            int awayTeamGoalsInt = int.Parse(awayTeamGoals);

            var match = new Match(homeTeam, awayTeam, homeTeamGoalsInt, awayTeamGoalsInt);

            matches.Add(match);
        
        }
    }

    return matches;
}

public void ProcessMatch(Match match)
    {
        // Process the match and update the standings accordingly
        var homeStanding = standings[match.HomeTeam.TeamAbbreviation];
        var awayStanding = standings[match.AwayTeam.TeamAbbreviation];

        homeStanding.GamesPlayed++;
        awayStanding.GamesPlayed++;

        homeStanding.GoalsFor += match.HomeTeamGoals;
        awayStanding.GoalsFor += match.AwayTeamGoals;

        homeStanding.GoalsAgainst += match.AwayTeamGoals;
        awayStanding.GoalsAgainst += match.HomeTeamGoals;

        if (match.HomeTeamGoals > match.AwayTeamGoals)
        {
            homeStanding.Wins++;
            awayStanding.Losses++;
            UpdateStreak(homeStanding, "W");
            UpdateStreak(awayStanding, "L");
        }
        else if (match.HomeTeamGoals < match.AwayTeamGoals)
        {
            homeStanding.Losses++;
            awayStanding.Wins++;
            UpdateStreak(homeStanding, "L");
            UpdateStreak(awayStanding, "W");
        }
        else
        {
            homeStanding.Draws++;
            awayStanding.Draws++;
            UpdateStreak(homeStanding, "D");
            UpdateStreak(awayStanding, "D");
        }
    }

    public void UpdateStreak(Standing standing, string result)
    {
        if (standing.Streak.Length < 5)
        {
            standing.Streak = result + standing.Streak;
        }
        else
        {
            standing.Streak = result + standing.Streak.Substring(0, 4);
        }
    }

    public void DisplayStandings()
{
    // Sort the standings

    Console.WriteLine($"standings: {standings}");
if (standings != null)
{
    Console.WriteLine($"standings.Values: {standings.Values}");
}
    var sortedStandings = standings.Values
        .OrderByDescending(s => s.Points)
        .ThenByDescending(s => s.GoalDifference)
        .ThenByDescending(s => s.GoalsFor)
        .ThenBy(s => s.GoalsAgainst)
        .ThenBy(s => s.Team.Name)
        .ToList();

    // Display the sorted standings on the console
    Console.WriteLine("Pos\tTeam\tM\tW\tD\tL\tGF\tGA\tGD\tP\tStreak");
    int position = 1;
    int currentPosition = 1;
    Standing previousStanding = null;
    foreach (var standing in sortedStandings)
    {
        string positionString;
        if (previousStanding == null || standing.Points != previousStanding.Points ||
            standing.GoalDifference != previousStanding.GoalDifference ||
            standing.GoalsFor != previousStanding.GoalsFor)
        {
            positionString = position.ToString();
            currentPosition = position;
        }
        else
        {
            positionString = "-";
        }

        Console.WriteLine($"{positionString}\t" +
                          $"{standing.Team.TeamAbbreviation}\t" +
                          $"{standing.GamesPlayed}\t" +
                          $"{standing.Wins}\t" +
                          $"{standing.Draws}\t" +
                          $"{standing.Losses}\t" +
                          $"{standing.GoalsFor}\t" +
                          $"{standing.GoalsAgainst}\t" +
                          $"{standing.GoalDifference}\t" +
                          $"{standing.Points}\t" +
                          $"{standing.Streak}");

        position++;
        previousStanding = standing;
    }
}

}