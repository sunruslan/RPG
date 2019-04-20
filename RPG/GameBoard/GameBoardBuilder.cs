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
            _gameBoard = new Cell.Cell[height, width];
        }

        public void CreateWalls(params Cell.Cell[] walls)
        {
            foreach (var wall in walls)
            {
                
            }
        }

        public void SetStartPositions(params Cell.Cell[] positions)
        {
            foreach (var position in positions)
            {

            }
        }

        public void Reset()
        {
            _gameBoard = null;
        }

        public Cell.Cell[,] GetGameBoard()
        {
            var result = _gameBoard;
            Reset();
            return result;
        }

        private Cell.Cell[,] _gameBoard;
    }
}
