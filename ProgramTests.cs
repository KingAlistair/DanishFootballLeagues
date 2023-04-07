//using NUnit.Framework;
public class ProgramTests
{
    public void testSDisplay()
    {
        //Path

        //League
        string leagueFilePath = "files/setup.csv";

        //SL teams and rounds
        string test_teams = "files/test/test_teams.csv";
        string[] test_roundsFiles = { "files/test/test_round.csv" };

        Console.WriteLine("SuperLiagen:");
        Console.WriteLine("=======================================================================================");
        Program.loadStanding(leagueFilePath, test_teams, test_roundsFiles);
        Console.WriteLine("=======================================================================================");

    }
}