public class Match {
    internal Team homeTeam { get; set; } 
    internal Team awayTeam { get; set; } 
    internal int homeTeamGoals { get; set; } 
    internal int awayTeamGoals { get; set; } 

    public Match(Team homeTeam, Team awayTeam, int homeTeamGoals, int awayTeamGoals)
    {
        this.homeTeam = homeTeam;
        this.awayTeam = awayTeam;
        this.homeTeamGoals = homeTeamGoals;
        this.awayTeamGoals = awayTeamGoals;
    }
}