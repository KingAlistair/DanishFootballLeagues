 using Xunit;
 using System.IO;
 public class ProgramTests2
{
    [Fact]
   public void WhenILoadMyFiles_ThenMyFileIsLoadedCorrectly()
    {
        // Arrange
        string filePath = "files/test/test_teams.csv";
        string expectedContents = "Write this to my file";

        File.WriteAllText(filePath, expectedContents);

        // Act
        string actualContents = File.ReadAllText(filePath);

        // Assert
        Assert.Equal(expectedContents, actualContents);
    }
   
}