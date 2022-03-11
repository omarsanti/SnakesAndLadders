using SnakesAndLadders.Core;
using Xunit;
using Moq;
using SnakesAndLadders.Core.Interface;

namespace SnakesAndLadders.Test
{
    public class Domain_US1
    {
        [Fact]
        public void TokenIsOnSquare1_UAT1()
        {
            IDie die = new Die();
            IGame game = new Game(die);
            Board board = new Board(100);
            Player player = new Player("Test Player 1", 1);
            game.AddPlayer(player);
            //Given
            // When
            game.Start();
            //Then
            Assert.True(game.GetCurrentPlayer().Token.GetCurrentCell().GetCellNumber() == board.GetCell(0).GetCellNumber());
        }

        [Fact]
        public void TokenAdvanceToSquare4_UAT2()
        {            
            Mock<IDie> dieMock = new Mock<IDie>();
            Board board = new Board(100);
            Player player = new Player("Test Player 1", 1);

            
            dieMock.Setup(c => c.GetValue()).Returns(3);
            IGame game = new Game(dieMock.Object);            
            game.AddPlayer(player);
            
            // Given
            game.Start();
            //When
            game.PlayCurrentPlayer();

            //Then
            Assert.True(game.GetCurrentPlayer().Token.GetCurrentCell().GetCellNumber() == board.GetCell(3).GetCellNumber());
        }

        [Fact]
        public void TokenAdvanceToSquare8_UAT3()
        {
            Mock<IDie> dieMock = new Mock<IDie>();
            Mock<ICellType> cellTypeMock = new Mock<ICellType>();
            dieMock.Setup(c => c.GetValue()).Returns(3);
            IGame game = new Game(dieMock.Object);

            Board board = new Board(100);
            Player player = new Player("Test Player 1", 1);
            game.AddPlayer(player);
            // Given
            game.Start();
            // When
            game.PlayCurrentPlayer();
            dieMock.Setup(c => c.GetValue()).Returns(4);
            game.PlayCurrentPlayer();

            // Then
            // The Square 8 according to the board takes you to square 31 because of the ladder
            // Ladder and Snakes logic is already integrated
            Assert.True(game.GetCurrentPlayer().Token.GetCurrentCell().GetCellNumber() == board.GetCell(7).GetCellNumber());
        }
    }
}
