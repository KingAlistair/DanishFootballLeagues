class Team {

    private int id;
    private string name;
    private string teamAbbreviation;

    private char specialRanking;

    public Team()
    {
    }

    public static void ReadAllTeams(){

        string filePath = @"files/teams.csv";

        StreamReader reader = null;

      if (File.Exists(filePath)){
         reader = new StreamReader(File.OpenRead(filePath));

         List<string> listA = new List<string>();

         while (!reader.EndOfStream){
            var line = reader.ReadLine();
            var values = line.Split(',');
            foreach (var item in values){
               listA.Add(item);
            }
            foreach (var coloumn1 in listA){
               Console.WriteLine(coloumn1);
            }
         }
      } else {
         Console.WriteLine("File doesn't exist");
      }
      Console.ReadLine();
   }

}