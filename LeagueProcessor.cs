public class LeagueProcessor
{
    public League league;
    public List<Team> teams;
    public List<Match> matches;
    public Dictionary<string, Standing> standings;
    
    public LeagueProcessor(League league, List<Team> teams)
    {
        this.league = league;
        this.teams = teams;
        matches = new List<Match>();
        standings = new Dictionary<string, Standing>();
        foreach (var team in teams)
        {
            standings[team.teamAbbreviation] = new Standing(team);
        }
    }

    public void ProcessMatch(Match match)
    {
        // Process the match and update the standings accordingly
        var homeStanding = standings[match.homeTeam.teamAbbreviation];
        var awayStanding = standings[match.awayTeam.teamAbbreviation];

        homeStanding.GamesPlayed++;
        awayStanding.GamesPlayed++;

        homeStanding.GoalsFor += match.homeTeamGoals;
        awayStanding.GoalsFor += match.awayTeamGoals;

        homeStanding.GoalsAgainst += match.awayTeamGoals;
        awayStanding.GoalsAgainst += match.homeTeamGoals;

        if (match.homeTeamGoals > match.awayTeamGoals)
        {
            homeStanding.Wins++;
            awayStanding.Losses++;
            UpdateStreak(homeStanding, "W");
            UpdateStreak(awayStanding, "L");
        }
        else if (match.homeTeamGoals < match.awayTeamGoals)
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
        var sortedStandings = standings.Values
            .OrderByDescending(s => s.Points)
            .ThenByDescending(s => s.GoalDifference)
            .ThenByDescending(s => s.GoalsFor)
            .ThenBy(s => s.GoalsAgainst)
            .ThenBy(s => s.Team.name)
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
                              $"{standing.Team.teamAbbreviation}\t" +
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