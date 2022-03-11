using Moq;
using SnakesAndLadders.Core;
using SnakesAndLadders.Core.Interface;
using Xunit;

namespace SnakesAndLadders.Test
{
    public class Domain_US3
    {
        [Fact]
        public void DieBetween1To6_UAT1()
        {
            IDie die = new Die();
            IGame game = new Game(die);
            Board board = new Board(100);
            Player player = new Player("Test Player 1", 1);
            game.AddPlayer(player);
            // Given
            game.Start();
            // When
            game.PlayCurrentPlayer();
            // Then
            Assert.InRange<int>(die.GetValue(), 1, 6);
        }

        [Fact]
        public void DieMove4Spaces_UAT2()
        {
            Mock<IDie> dieMock = new Mock<IDie>();
            dieMock.Setup(c => c.GetValue()).Returns(4);
            IGame game = new Game(dieMock.Object);
            Board board = new Board(100);
            Player player = new Player("Test Player 1", 1);
            game.AddPlayer(player);
            // Given
            game.Start();
            // When
            game.PlayCurrentPlayer();
            // Then
            Assert.True(game.GetCurrentPlayer().Token.GetCurrentCell().GetCellNumber() - 1 == 4);
        }
    }
}
