public class Team
{
        internal string Name { get; set; } 
        internal string TeamAbbreviation { get; set; } 

    private string SpecialRanking { get; set; } 

    internal Team()
    {
    }

    public Team(string name, string teamAbbreviation, string specialRanking)
    {
        this.Name = name;
        this.TeamAbbreviation = teamAbbreviation;
        this.SpecialRanking = specialRanking;
    }
}