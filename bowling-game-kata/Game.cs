namespace bowling_game_kata
{
    public class Game
    {
        private int[] RollKnockedPinsCountList = new int[21];
        private int RollIndex { get; set; }
        public int TotalScore
        {
            get
            {
                var result = 0;
                for (int i = 0; i < RollKnockedPinsCountList.Length; i++)
                {
                    result += RollKnockedPinsCountList[i];

                    if (i >= 2 && (RollKnockedPinsCountList[i - 1] + RollKnockedPinsCountList[i - 2]) == 10)
                    {
                        result += RollKnockedPinsCountList[i];
                    }

                    if (i >= 2 && RollKnockedPinsCountList[i - 2] == 10)
                    {
                        result += RollKnockedPinsCountList[i] + RollKnockedPinsCountList[i - 1];
                    }

                }
                return result;
            }
            set { }
        }

        public void Roll(int knockedPins)
        {
            RollKnockedPinsCountList[RollIndex] = knockedPins;
            RollIndex++;
        }
    }
}
