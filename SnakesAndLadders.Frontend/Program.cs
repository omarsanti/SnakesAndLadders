using SnakesAndLadders.Core;
using SnakesAndLadders.Core.Interface;
using System;

namespace SnakesAndLadders.Frontend
{
    class Program
    {
        private static IGame _game;
        private static int _numberOfPlayers;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Snakes And Ladders");
                IDie die = new Die();
                _game = new Game(die);

                Console.WriteLine("¿How many players?");
                var numberOfPlayersIn = Console.ReadLine();
                if (!int.TryParse(numberOfPlayersIn, out _numberOfPlayers))
                {
                    throw new ApplicationException("Wrong Number of Players");
                }

                for (int i = 0; i < _numberOfPlayers; i++)
                {
                    Console.WriteLine("Name of Player {0}: ", i + 1);
                    var name = Console.ReadLine();
                    if (name == null || name.Length == 0)
                    {
                        throw new ApplicationException("Name not valid");
                    }
                    _game.AddPlayer(new Player(name, i + 1));
                }

                Console.WriteLine("Match Started");
                _game.Start();
                do
                {
                    var player = _game.GetCurrentPlayer();
                    Console.WriteLine("");
                    Console.WriteLine("Player {0}. Type any key to play.", player.GetName());
                    Console.ReadKey(false);
                    var result = _game.PlayCurrentPlayer();

                    Console.WriteLine("Current position: {0}. Advance {1} cell(s). Final position: {2}.", result.CurrentPosition, result.Movements, result.FinalPosition);
                    if(result.IsWinner)
                    {
                        Console.WriteLine("You have won. Congratulations!");
                    }
                }
                while (_game.Status != Core.Enum.GameStatus.Finished);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("Error: {0}. Restart game please.", ex.Message);
            }
        }
    }
}
