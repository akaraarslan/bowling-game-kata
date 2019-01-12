using System;

namespace bowling_game_kata
{
    public class Game
    {
        public RollInfo[] RollHistory = new RollInfo[21];
        private int RollIndex { get; set; }
        public int TotalScore
        {
            get
            {
                var result = 0;
                if (RollIndex == 0)
                {
                    return 0;
                }

                for (int i = 0; i < RollIndex; i++)
                {
                    result += RollHistory[i].KnockedPins;

                    //Spare Bonus
                    if (i >= 2
                    && (RollHistory[i - 1].KnockedPins + RollHistory[i - 2].KnockedPins) == 10
                    && RollHistory[i - 1].FrameIndex == RollHistory[i - 2].FrameIndex && i < 18)
                    {
                        result += RollHistory[i].KnockedPins;
                    }
                    //Strike Bonus
                    if (i >= 2 && RollHistory[i - 2].KnockedPins == 10 && i < 18)
                    {
                        if (i < 3 || RollHistory[i - 3].KnockedPins != 0)
                        {
                            result += RollHistory[i - 1].KnockedPins + RollHistory[i].KnockedPins;
                        }
                    }
                }

                return result;
            }
        }

        public void Roll(int knockedPins)
        {
            var roll = new RollInfo();
            roll.KnockedPins = knockedPins;
            if (RollIndex == 0)
            {
                roll.FrameIndex = 0;
            }
            else if (RollIndex >= 1 && RollHistory[RollIndex - 1].KnockedPins == 10)
            {
                roll.FrameIndex = RollHistory[RollIndex - 1].FrameIndex + 1;
            }
            else if (RollIndex >= 2 && RollHistory[RollIndex - 1].FrameIndex == RollHistory[RollIndex - 2].FrameIndex)
            {
                roll.FrameIndex = RollHistory[RollIndex - 1].FrameIndex + 1;
            }
            else
            {
                roll.FrameIndex = RollHistory[RollIndex - 1].FrameIndex;
            }

            if (RollIndex == 20)
            {
                if (RollHistory[18].KnockedPins == 10 || RollHistory[19].KnockedPins == 10 || (RollHistory[18].KnockedPins + RollHistory[19].KnockedPins) == 10)
                {
                    roll.FrameIndex = 9;
                }
                else
                {
                    return;
                }
            }

            RollHistory[RollIndex] = roll;
            Console.WriteLine(roll);
            RollIndex++;
        }
    }

    public class RollInfo
    {
        public int KnockedPins { get; set; }
        public int FrameIndex { get; set; }

        public override string ToString()
        {
            return $"FrameIndex: {FrameIndex}, KnockedPins: {KnockedPins}";
        }
    }
}
