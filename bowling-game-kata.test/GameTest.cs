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

            Assert.True(game.TotalScore == 1);

        }

        [Fact]
        public void Should_Calculate20_When_AllRolls1()
        {
            Game game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }

            Assert.True(game.TotalScore == 20);
        }

        [Fact]
        public void Should_Calculate80_When_AllRolls4()
        {
            Game game = new Game();

            for (int i = 0; i < 20; i++)
            {
                game.Roll(4);
            }

            Assert.True(game.TotalScore == 80);
        }

        [Fact]
        public void Should_CalculateSpareBonus_When_NextRolled()
        {
            Game game = new Game();

            game.Roll(5);
            game.Roll(5);
            game.Roll(4);

            Assert.Equal(18, game.TotalScore);
        }

        [Fact]
        public void Should_CalculateStrikeBonus_When_NextTwoRolled()
        {
            Game game = new Game();

            game.Roll(10);
            game.Roll(5);
            game.Roll(4);

            Assert.Equal(28, game.TotalScore);
        }

        [Fact]
        public void Should_NotCalculateSpareBonus_When_NotRolledSameFrame()
        {
            Game game = new Game();

            game.Roll(3);
            game.Roll(5);
            game.Roll(5);
            game.Roll(2);

            Assert.Equal(15, game.TotalScore);
        }

        [Fact]
        public void Should_NotCalculateStrikeBonus_When_FrameSecondRoleKnockedDown10Pins()
        {
            Game game = new Game();

            game.Roll(0);
            game.Roll(10);
            game.Roll(5);
            game.Roll(2);

            Assert.Equal(22, game.TotalScore);
        }

        [Fact]
        public void Should_CalculateScore21stRoll_When_LastFrameHasSpare()
        {
            Game game = new Game();
            for (int i = 0; i < 18; i++)
            {
                game.Roll(1);
            }
            game.Roll(7);
            game.Roll(3);
            game.Roll(5);

            Assert.Equal(33, game.TotalScore);
        }

        [Fact]
        public void Should_CalculateScore21stRoll_When_LastFrameHas2Strike()
        {
            Game game = new Game();
            for (int i = 0; i < 18; i++)
            {
                game.Roll(1);
            }
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);

            Assert.Equal(43, game.TotalScore);
        }

        [Fact]
        public void Should_NotCalculateBonus_When_LastFrame()
        {
            Game game = new Game();
            for (int i = 0; i < 18; i++)
            {
                game.Roll(1);
            }
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            Assert.Equal(48, game.TotalScore);
        }

        [Fact]
        public void Should_FrameIndexCorrect_WhenLastFrameHasSpare()
        {
            Game game = new Game();
            for (int i = 0; i < 18; i++)
            {
                game.Roll(1);
            }
            game.Roll(6);
            game.Roll(4);
            game.Roll(10);

            Assert.Equal(9, game.RollHistory[game.RollIndex - 1].FrameIndex);
        }

        [Fact]
        public void Should_FrameIndexCorrect_WhenLastFrameHasStrike()
        {
            Game game = new Game();
            for (int i = 0; i < 18; i++)
            {
                game.Roll(1);
            }
            game.Roll(10);
            game.Roll(10);
            game.Roll(5);

            Assert.Equal(9, game.RollHistory[game.RollIndex - 1].FrameIndex);
            Assert.Equal(9, game.RollHistory[game.RollIndex - 2].FrameIndex);
        }

        [Fact]
        public void Should_CalculateScoreSheetExampleCorrect()
        {
            Game game = new Game();
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
            Assert.Equal(187, game.TotalScore);
        }

        [Fact]
        public void Should_ThrowException_WhenGameisOver()
        {
            Game game = new Game();


            Action act = () =>
            {
                for (int i = 0; i < 26; i++)
                {
                    game.Roll(10);
                }
            };
            //assert
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void PerfectGame()
        {
            var game = new Game();
            for (int i = 0; i < 12; i++)
            {
                game.Roll(10);
            }

            Assert.Equal(300, game.TotalScore);
        }
    }
}
