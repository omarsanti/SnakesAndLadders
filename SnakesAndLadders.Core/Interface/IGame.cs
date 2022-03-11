using SnakesAndLadders.Core.DTO;
using SnakesAndLadders.Core.Enum;

namespace SnakesAndLadders.Core.Interface
{
    public interface IGame
    {
        GameStatus Status { get; set; }
        bool Start();
        void AddPlayer(Player player);
        Player GetCurrentPlayer();
        PlayResult PlayCurrentPlayer();
    }
}
