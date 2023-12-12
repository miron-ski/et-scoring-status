using ScoringStatus.Data;

namespace ScoringStatus.Components.Pages
{
    public partial class ScoringTable
    {
        private List<Player> players = [];
        private List<Player> filteredPlayers = [];
        private List<int> distinctRounds = [];
        private string searchLastName = string.Empty;
        private bool sortDescending = false;
        private string sortByColumn = "Match";


        protected override void OnInitialized()
        {
            var service = new PlayerService();
            players = service.GetPlayersForTournament();
            filteredPlayers = players.ToList();

            distinctRounds = players.Select(player => player.RoundNo)
                                   .Distinct()
                                   .OrderBy(round => round)
                                   .ToList();
        }

        private void Sort(string column)
        {
            if (sortByColumn == column)
            {
                sortDescending = !sortDescending;
            }
            else
            {
                sortByColumn = column;
                sortDescending = false;
            }

            if (sortDescending)
            {
                filteredPlayers = filteredPlayers.OrderByDescending(player => GetPropertyValue(player, column)).ToList();
            }
            else
            {
                filteredPlayers = filteredPlayers.OrderBy(player => GetPropertyValue(player, column)).ToList();
            }
        }

        // Helper method to get property value 
        private object GetPropertyValue(Player player, string propertyName)
        {
            return player.GetType().GetProperty(propertyName)?.GetValue(player, null);
        }

        private string GetColour(int holesPlayed, int incompleteHoles)
        {
            if (holesPlayed < 18)
            {
                return "orange";
            }
            else if (holesPlayed == 18 && incompleteHoles == 0)
            {
                return "green";
            }
            else
            {
                return "red";
            }
        }

        private void UpdateSearchResults()
        {
            filteredPlayers = players.Where(player =>
                string.IsNullOrWhiteSpace(searchLastName) || player.LastName.Contains(searchLastName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private void ResetSeachResults()
        {
            filteredPlayers = players;
            searchLastName = string.Empty;
        }
    }
}
