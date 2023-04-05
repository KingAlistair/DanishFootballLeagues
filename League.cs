public class League
{
    public string Name { get; set; }
    public int ChampionsLeagueSpots { get; set; }
    public int EuropaLeagueSpots { get; set; }
    public int ConferenceLeagueSpots { get; set; }
    public int UpperLeaguePromotionSpots { get; set; }
    public int RelegationSpots { get; set; }

    public League(string name, int championsLeagueSpots, int europaLeagueSpots,
                  int conferenceLeagueSpots, int upperLeaguePromotionSpots, int relegationSpots)
    {
        Name = name;
        ChampionsLeagueSpots = championsLeagueSpots;
        EuropaLeagueSpots = europaLeagueSpots;
        ConferenceLeagueSpots = conferenceLeagueSpots;
        UpperLeaguePromotionSpots = upperLeaguePromotionSpots;
        RelegationSpots = relegationSpots;
    }

    
    public static League FromCsvFile(string filePath)
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
}
