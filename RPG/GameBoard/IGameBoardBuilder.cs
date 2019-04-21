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

        void CreateWalls(params Cell[] walls);

        void SetStartPositions(params Cell[] positions);

        void Reset();

        GameBoard GetGameBoard();
    }
}
