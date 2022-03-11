using SnakesAndLadders.Core;
using Xunit;
using Moq;
using SnakesAndLadders.Core.Interface;

namespace SnakesAndLadders.Test
{
    public class Domain_US2
    {
        [Fact]
        public void PlayerWonTheGame_UAT1()
        {
            Mock<IDie> dieMock = new Mock<IDie>();
            // Given
            dieMock.Setup(c => c.GetValue()).Returns(96);
            IGame game = new Game(dieMock.Object);

            Board board = new Board(100);
            Player player = new Player("Test Player 1", 1);
            game.AddPlayer(player);
            game.Start();
            game.PlayCurrentPlayer();

            // When
            dieMock.Setup(c => c.GetValue()).Returns(3);
            game.PlayCurrentPlayer();

            // Then
            Assert.True(game.GetCurrentPlayer().Token.GetCurrentCell().GetCellNumber() == board.GetCell(99).GetCellNumber());
            Assert.True(game.Status == Core.Enum.GameStatus.Finished);
        }

        [Fact]
        public void PlayerHasNotWonTheGame_UAT2()
        {
            Mock<IDie> dieMock = new Mock<IDie>();
            // Given
            dieMock.Setup(c => c.GetValue()).Returns(96);
            IGame game = new Game(dieMock.Object);

            Board board = new Board(100);
            Player player = new Player("Test Player 1", 1);
            game.AddPlayer(player);
            game.Start();
            game.PlayCurrentPlayer();

            //When
            dieMock.Setup(c => c.GetValue()).Returns(4);
            game.PlayCurrentPlayer();

            // Then
            Assert.True(game.GetCurrentPlayer().Token.GetCurrentCell().GetCellNumber() == board.GetCell(96).GetCellNumber());
            Assert.True(game.Status == Core.Enum.GameStatus.Started);
        }
    }
}
