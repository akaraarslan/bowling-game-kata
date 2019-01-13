using Xunit;
using System;

namespace bowling_game_kata.test
{
    public class GameTest
    {
        [Fact]
        public void Should_FirstRollX_TotalScoreX()
        {
            Game game = new Game();

            game.Roll(1);

            Assert.Equal(1, game.TotalScore());

        }

        [Fact]
        public void Should_Calculate20_When_AllRolls1()
        {
            Game game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            Assert.Equal(20, game.TotalScore());
        }

        [Fact]
        public void Should_Calculate80_When_AllRolls4()
        {
            Game game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(4);
            }

            Assert.Equal(80, game.TotalScore());
        }

        [Fact]
        public void Should_CalculateSpareBonus_When_NextRolled()
        {
            Game game = new Game();

            game.Roll(5);
            game.Roll(5);
            game.Roll(4);

            Assert.Equal(18, game.TotalScore());
        }

        [Fact]
        public void Should_CalculateStrikeBonus_When_NextTwoRolled()
        {
            Game game = new Game();

            game.Roll(10);
            game.Roll(5);
            game.Roll(4);

            Assert.Equal(28, game.TotalScore());
        }

        [Fact]
        public void Should_NotCalculateSpareBonus_When_NotRolledSameFrame()
        {
            var game = new Game();

            game.Roll(3);
            game.Roll(5);
            game.Roll(5);
            game.Roll(2);

            Assert.Equal(15, game.TotalScore());
        }

        [Fact]
        public void Should_NotCalculateStrikeBonus_When_FrameSecondRoleKnockedDown10Pins()
        {
            var game = new Game();

            game.Roll(0);
            game.Roll(10);
            game.Roll(5);
            game.Roll(2);

            Assert.Equal(22, game.TotalScore());
        }

        [Fact]
        public void Should_CalculateScore21stRoll_When_LastFrameHasSpare()
        {
            var game = new Game();
            RollMany(game, 18, 1);
            game.Roll(7);
            game.Roll(3);
            game.Roll(5);

            Assert.Equal(33, game.TotalScore());
        }

        [Fact]
        public void Should_CalculateScore21stRoll_When_LastFrameHas2Strike()
        {
            var game = new Game();
            RollMany(game, 18, 1);
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);

            Assert.Equal(43, game.TotalScore());
        }

        [Fact]
        public void Should_NotCalculateBonus_When_LastFrame()
        {
            var game = new Game();
            RollMany(game, 18, 1);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            Assert.Equal(48, game.TotalScore());
        }

        [Fact]
        public void Should_Be10Frame_WhenLastFrameHasSpare()
        {
            var game = new Game();
            RollMany(game, 18, 1);
            game.Roll(6);
            game.Roll(4);
            game.Roll(10);

            Assert.Equal(10, game.FrameList.Count);
        }

        [Fact]
        public void Should_Be10Frame__WhenLastFrameHasStrike()
        {
            var game = new Game();
            RollMany(game, 18, 1);
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);

            Assert.Equal(10, game.FrameList.Count);
        }

        [Fact]
        public void Should_CalculateScoreSheetExampleCorrect()
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(9);
            game.Roll(1);
            game.Roll(5);
            game.Roll(5);
            game.Roll(7);
            game.Roll(2);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(9);
            game.Roll(0);
            game.Roll(8);
            game.Roll(2);
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);
            Assert.Equal(187, game.TotalScore());
        }

        [Fact]
        public void Should_ThrowException_WhenGameisOver()
        {
            var game = new Game();
            Action act = () =>
            {
                RollMany(game, 26, 10);
            };

            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void PerfectGame()
        {
            var game = new Game();
            RollMany(game, 12, 10);

            Assert.Equal(300, game.TotalScore());
        }

        private void RollMany(Game game, int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
