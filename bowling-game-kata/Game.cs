namespace bowling_game_kata
{
    public class Game
    {
        public int TotalScore { get; set; } 

        public void Roll(int knockedPins)
        {
            TotalScore += knockedPins;
        }
    }
}
