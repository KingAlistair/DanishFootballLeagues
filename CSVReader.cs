public class CSVReader {

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
}