using Bunit;
using ScoringStatus.Components.Pages;

namespace ScoringStatusTests
{
    public class ScoringStatusUnitTests : TestContext
    {
        [Fact]
        public void Table_ShouldRenderTable()
        {
            var scoringComponent = RenderComponent<ScoringTable>();

            scoringComponent.Find("table");
            scoringComponent.FindAll("tr");

        }

        [Fact]
        public void Table_ShouldAssignRowToEachPlayer()
        {
            var scoringComponent = RenderComponent<ScoringTable>();
            var rows = scoringComponent.FindAll("tr");

            Assert.Equal(157, rows.Count);
        }

        [Fact]
        public void SearchBar_ShouldProduceResults()
        {
            var scoringComponent = RenderComponent<ScoringTable>();
            var searchInput = scoringComponent.Find("input[type=text]");

            searchInput.Change("rose");

            var playerRows = scoringComponent.FindAll("tr");
            Assert.True(playerRows.Count > 0);
        }
    }
}