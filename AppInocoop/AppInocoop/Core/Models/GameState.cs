namespace AppInocoop.Core.Models
{
    public class GameState
    {
        public int Time_A_Score { get; set; }
        public int Time_B_Score { get; set; }
        public bool IsTournamentMode { get; set; }

        public void ResetScores()
        {
            Time_A_Score = 0;
            Time_B_Score = 0;
        }
    }
}