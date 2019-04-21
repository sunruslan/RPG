using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameBoard
{
    public class GameBoardBuilder : IGameBoardBuilder
    {
        public GameBoardBuilder()
        {
            Reset();
        }

        public void SetShape(int height, int width)
        {
            _gameBoard.GameBoardCells = new Cell[height][];
            for (int i = 0; i < height; i++)
            {
                _gameBoard.GameBoardCells[i] = new Cell[width];
            }
        }
        
        public void CreateWalls(params Cell[] walls)
        {
            foreach (var wall in walls)
            {
                _gameBoard.GameBoardCells[wall.Y][wall.X] = wall;
            }
        }

        public void SetStartPositions(params Cell[] positions)
        {
            foreach (var position in positions)
            {
                _gameBoard.GameBoardCells[position.Y][position.X] = position;
            }
        }

        public void Reset()
        {
            _gameBoard = new GameBoard();
        }

        public GameBoard GetGameBoard()
        {
            var result = _gameBoard;
            Reset();
            return result;
        }

        private GameBoard _gameBoard;
    }
}
