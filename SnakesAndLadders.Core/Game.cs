using SnakesAndLadders.Core.DTO;
using SnakesAndLadders.Core.Enum;
using SnakesAndLadders.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakesAndLadders.Core
{
    public class Game :IGame
    {
        private static int _defaultBoardSize;
        private int _currentPlayer;
        private IBoard _board;
        private List<Player> _players;
        private IDie _die;

        public GameStatus Status { get; set; }
        
        public Game(IDie die)
        {
            Status = GameStatus.NotStarted;
            _defaultBoardSize = 100;
            _board = new Board(_defaultBoardSize);
            _players = new List<Player>();
            _die = die;
        }

        public bool Start()
        {
            if (!_players.Any())
            {
                throw new ApplicationException("No players");
            }
            _currentPlayer = 1;
            SetPlayersReady();
            Status = GameStatus.Started;
            return true;
        }

        public void AddPlayer(Player player)
        {
            if(_players.Contains(player))
            {
                throw new ApplicationException("Player already added");
            }
            if (Status != GameStatus.NotStarted)
            {
                throw new ApplicationException("Game not started");
            }
            _players.Add(player);
        }

        public Player GetCurrentPlayer()
        {
            return _players[_currentPlayer - 1];
        }

        private void SetPlayersReady()
        {
            foreach(Player player in _players)
            {
                player.Token = new Token(_board.GetCell(0));
            }
        }

        public PlayResult PlayCurrentPlayer()
        {
            PlayResult playResult = new PlayResult();
            _die.Roll();
            var movements = _die.GetValue();
            var currentToken = GetCurrentPlayer().Token;
            playResult.CurrentPosition = currentToken.GetCurrentCell().GetCellNumber();
            playResult.Movements = movements;

            var nextCellMovement = _board.GetNextCell(currentToken.GetCurrentCell(), movements);
            Cell finalCell = GetFinalPosition(playResult, nextCellMovement);

            _players[_currentPlayer - 1].Token.SetCurrentCell(finalCell);

            if (finalCell.GetCellNumber() == _board.GetLastCell().GetCellNumber())
            {
                playResult.IsWinner = true;
                Status = GameStatus.Finished;
            }
            else
            {
                playResult.IsWinner = false;
                AdvancePlayerTurn();
            }

            return playResult;
        }

        private Cell GetFinalPosition(PlayResult playResult, Cell nextCellMovement)
        {
            var nextCellMovementCellType = nextCellMovement.GetCellType();
            var finalPosition = nextCellMovementCellType != null ? nextCellMovementCellType.GetNextPosition(nextCellMovement.GetCellNumber()) : nextCellMovement.GetCellNumber();
            var finalCell = _board.GetCell(finalPosition - 1);
            playResult.FinalPosition = finalCell.GetCellNumber();
            return finalCell;
        }

        private void AdvancePlayerTurn()
        {
            var nextCurrentPlayer = _currentPlayer + 1;
            if (nextCurrentPlayer > _players.Count)
            {
                nextCurrentPlayer = 1;
            }
            _currentPlayer = nextCurrentPlayer;
        }
    }
}
