using Microsoft.VisualBasic.FileIO;
class Program
{
    static void Main(string[] args)
    {
    //     using (TextFieldParser parser = new TextFieldParser("files/teams.csv")) {
    //         parser.TextFieldType = FieldType.Delimited;
    //         parser.SetDelimiters(",");
            
    //         // Read the CSV file row by row
    //         while (!parser.EndOfData) {
    //             // Parse the current row
    //             string[] fields = parser.ReadFields();
                
    //             // Process the fields as needed
    //             foreach (string field in fields) {
    //                 Console.Write(field + " ");
    //             }
    //             Console.WriteLine();
    //         }
    //     }

    Team.ReadAllTeams();
    }
}
