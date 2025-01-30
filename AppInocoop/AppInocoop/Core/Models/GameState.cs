namespace AppInocoop.Core.Models
{
    public class GameState
    {
        public int Time_A { get; set; }
        public int Time_B { get; set; }
        public bool IsTournamentMode { get; set; }

        public void ResetScores()
        {
            Time_A = 0;
            Time_B = 0;
        }
    }
}