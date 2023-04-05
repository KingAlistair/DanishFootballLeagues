public class Standing
{
    public Team Team { get; set; }
    public int Position { get; set; }
    public int GamesPlayed { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference => GoalsFor - GoalsAgainst;
    public int Points => Wins * 3 + Draws;
    public string Streak { get; set; }

    public Standing(Team team)
    {
        Team = team;
        Streak = "-";
    }
}