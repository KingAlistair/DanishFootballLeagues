public class Match {
    internal Team HomeTeam { get; set; } 
    internal Team AwayTeam { get; set; } 
    internal int HomeTeamGoals { get; set; } 
    internal int AwayTeamGoals { get; set; } 

    public Match()
    {
    }

    public Match(Team homeTeam, Team awayTeam, int homeTeamGoals, int awayTeamGoals)
    {
        this.HomeTeam = homeTeam;
        this.AwayTeam = awayTeam;
        this.HomeTeamGoals = homeTeamGoals;
        this.AwayTeamGoals = awayTeamGoals;
    }
}