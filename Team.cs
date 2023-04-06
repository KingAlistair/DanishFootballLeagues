public class Team
{
    internal string name { get; set; }
    internal string teamAbbreviation { get; set; }

    private string specialRanking { get; set; }

    internal Team()
    {
    }

    public Team(string name, string teamAbbreviation, string specialRanking)
    {
        this.name = name;
        this.teamAbbreviation = teamAbbreviation;
        this.specialRanking = specialRanking;
    }
}