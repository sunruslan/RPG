using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameBoard
{
    public interface IGameBoardBuilder
    {
        void SetShape(int height, int width);

        void CreateWalls(params Cell.Cell[] walls);

        void SetStartPositions(params Cell.Cell[] positions);

        void Reset();

        Cell.Cell[,] GetGameBoard();
    }
}
