using System;
using System.Collections.Generic;

namespace bowling_game_kata
{
    public class Game
    {
        public Game()
        {
            FrameList = new List<Frame>();
        }
        public RollInfo[] RollHistory = new RollInfo[21];
        public List<Frame> FrameList { get; set; }
        public int RollIndex { get; set; }
        public int TotalScore()
        {
            var score = 0;

            foreach (var frame in FrameList)
            {
                Console.WriteLine(frame);
                score += frame.Score(this);
            }

            return score;
        }

        public void Roll(int knockedPins)
        {
            var lastFrame = GetLastFrame();

            //Frame first roll
            if (lastFrame.KnockedPins.Count == 0)
            {
                lastFrame.KnockedPins.Add(knockedPins);
                return;
            }

            //frame second roll
            if (lastFrame.FrameIndex == 9)
            {
                if (lastFrame.KnockedPins.Count < 2)
                {
                    lastFrame.KnockedPins.Add(knockedPins);
                    return;
                }
                else if (lastFrame.KnockedPins.Count == 2)
                {
                    if (lastFrame.KnockedPins[0] == 10
                    || lastFrame.KnockedPins[1] == 10
                    || (lastFrame.KnockedPins[0] + lastFrame.KnockedPins[1]) == 10)
                    {
                        lastFrame.KnockedPins.Add(knockedPins);
                        return;
                    }

                }
                else
                {
                    throw new Exception("Game Over");
                }
            }
            else
            {
                if (lastFrame.KnockedPins[0] == 10)
                {
                    var newFrame = new Frame();
                    newFrame.FrameIndex = lastFrame.FrameIndex + 1;
                    newFrame.KnockedPins.Add(knockedPins);
                    FrameList.Add(newFrame);
                }
                else if (lastFrame.KnockedPins.Count >= 2)
                {
                    var newFrame = new Frame();
                    newFrame.FrameIndex = lastFrame.FrameIndex + 1;
                    newFrame.KnockedPins.Add(knockedPins);
                    FrameList.Add(newFrame);
                }
                else
                {
                    lastFrame.KnockedPins.Add(knockedPins);
                }
            }
        }

        private Frame GetLastFrame()
        {
            if (FrameList.Count == 0)
                FrameList.Add(new Frame { FrameIndex = 0 });
            return FrameList[FrameList.Count - 1];
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

    public class Frame
    {
        public Frame()
        {
            Finalized = false;
            KnockedPins = new List<int>();
        }
        public int FrameIndex { get; set; }
        public List<int> KnockedPins { get; set; }
        public int Score(Game game)
        {

            var frameScore = 0;
            foreach (var pins in KnockedPins)
            {
                frameScore += pins;
            }

            if (FrameIndex != 9)
            {
                if (KnockedPins.Count == 1 && KnockedPins[0] == 10)
                {
                    frameScore += GetNextTwoRollKnockedPins(game, FrameIndex);
                }

                if (KnockedPins.Count == 2 && (KnockedPins[0] + KnockedPins[1]) == 10)
                {
                    frameScore += GetNextRollKnockedPins(game, FrameIndex);
                }
            }

            return frameScore;
        }

        private int GetNextRollKnockedPins(Game game, int frameIndex)
        {
            var result = 0;
            var nextFrameIndex = frameIndex + 1;
            if (game.FrameList[nextFrameIndex] != null)
            {
                if (game.FrameList[nextFrameIndex].KnockedPins.Count > 0)
                {
                    result = game.FrameList[nextFrameIndex].KnockedPins[0];
                }
            }
            return result;
        }

        private int GetNextTwoRollKnockedPins(Game game, int frameIndex)
        {
            var result = 0;
            var nextFrameIndex = frameIndex + 1;
            if (game.FrameList[nextFrameIndex] != null)
            {
                if (game.FrameList[nextFrameIndex].KnockedPins.Count > 0)
                {
                    if (game.FrameList[nextFrameIndex].KnockedPins.Count == 1)
                    {
                        result = game.FrameList[nextFrameIndex].KnockedPins[0] + GetNextRollKnockedPins(game, nextFrameIndex);
                    }
                    else
                    {
                        result = game.FrameList[nextFrameIndex].KnockedPins[0] + game.FrameList[nextFrameIndex].KnockedPins[1];
                    }
                }
            }
            return result;
        }

        public bool Finalized { get; set; }
        public override string ToString()
        {
            return $"FrameIndex: {FrameIndex}, KnockedPins: { string.Join(",", KnockedPins.ToArray())}";
        }
    }
}
