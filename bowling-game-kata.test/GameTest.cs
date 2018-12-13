using Xunit;

namespace bowling_game_kata.test
{
    public class GameTest
    {
        [Fact]
        public void Should_calculate20_when_allRolls1()
        { 
            Game game = new Game();
             
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);    
            }

          Assert.True(game.TotalScore == 20);   
        } 
    }
}
