using System;

namespace Frontend.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            GameStatus = new GameStatus();
            GameHints = new GameHints();
        }

        public GameStatus GameStatus { get; set; }
        public GameHints GameHints { get; set; }
    }

    public class GameStatus
    {
        public string Status { get; set; } = "Start a new game!";
        public string CssClass { get; set; } = "card-header card-header-success";
        public int LastUpdated { get; set; }
        public int FastestTime { get; set; }
        public int CompletedPercentage { get; set; }
    }

    public class GameHints
    {
        public int HintDelayInSeconds { get; set; } = 300;
        public int HintsLimit { get; set; } = 5;
        public string HintDescription { get; set; }
    }
}