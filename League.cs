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
}