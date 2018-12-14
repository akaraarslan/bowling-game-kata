namespace bowling_game_kata
{
    public class Game
    {
        private int[] RollKnockedPinsCountList = new int[21];
        private int RollIndex { get; set; }
        public int TotalScore { get; set; }

        public void Roll(int knockedPins)
        {
            RollKnockedPinsCountList[RollIndex] = knockedPins;

            TotalScore += knockedPins;

            if (RollIndex >= 2 && (RollKnockedPinsCountList[RollIndex - 1] + RollKnockedPinsCountList[RollIndex - 2]) == 10)
            {
                TotalScore += RollKnockedPinsCountList[RollIndex];
            }

            RollIndex++;
        }
    }
}
