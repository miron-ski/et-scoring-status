using Microsoft.VisualBasic.FileIO;
using ScoringStatus.Data;

namespace ScoringStatus
{
    public class PlayerService
    {
        public List<Player> GetPlayersForTournament()
        {
            List<Player> players = [];

            using (TextFieldParser parser = new("data.csv"))
            {
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                // Skip the header row
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields != null && fields.Length >= 10)
                    {
                        Player player = new Player
                        {
                            PositionDesc = int.Parse(fields[0]),
                            PlayerId = int.Parse(fields[1]),
                            FirstName = fields[2],
                            LastName = fields[3],
                            Score = int.Parse(fields[4]),
                            RoundNo = int.Parse(fields[5]),
                            Strokes = int.Parse(fields[6]),
                            HolesPlayed = int.Parse(fields[7]),
                            IncompleteHoles = int.Parse(fields[8]),
                            Match = int.Parse(fields[9])
                        };

                        players.Add(player);
                    }
                }
            }

            return players;
        }
    }
}
