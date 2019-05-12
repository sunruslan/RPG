using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Units;
using RPG.GameBoard;
using RPG.Goods;


namespace RPG.Action
{
    class Attack : IAction
    {
        void Act(Unit fighter, IItem element, GameBoard.GameBoard gameBoard);
        {
            if (Weapons == 0) return;
            if (X - 1 >= 0 && gameBoard.GameBoardItems[Y][X - 1] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y][X - 1]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y][X - 1]).Health -= Hit;
            }
            if (Y - 1 >= 0 && gameBoard.GameBoardItems[Y - 1][X] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y - 1][X]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y - 1][X]).Health -= Hit;
            }
            if (X + 1 < gameBoard.Width && gameBoard.GameBoardItems[Y][X + 1] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y][X + 1]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y][X + 1]).Health -= Hit;
            }
            if (Y + 1 < gameBoard.Height && gameBoard.GameBoardItems[Y + 1][X] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y + 1][X]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y + 1][X]).Health -= Hit;
            }
        }
    }
}
