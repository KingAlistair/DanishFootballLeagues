# DanishFootballLeagues
C# mandatory I. by Fernanda Cunha Bacelar and Daniel Szabo.

![s960_Football_gov uk](https://user-images.githubusercontent.com/60754393/235305636-ad2a034a-27ab-4a9f-b58c-39a0fc788cc5.jpg)

User Manual:

Run applicataion from Command Line - dotnet run Progam.cs

Main menu will be shown. If blue color do not line up, resize command line manually.
Choose 1 or 2 to see the league's standing.
Press 3 to test exceptions regarding errors in the csv files.
Press 4 to Exit program

Main Menu
1. SuperLiagen standings
2. NordicBetLigaen standings
3. Testing
3. Exit program


Error messages:

Missing team error: Missing team error: Team FCK and/or BIFFF was not found in files/rounds/SL/SL_round1.csv file.

Solution: Compare the given file with the team names in the teams.csv file.


Same team error: Team FCK cannot play against itself! There is an error in file: files/rounds/SL/SL_round1.csv

Solution: Check the given file if one of the team is playing against itself.
