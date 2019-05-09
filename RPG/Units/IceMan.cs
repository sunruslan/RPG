using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Units
{
    public class IceMan : Unit
    {
        public override void Attack(GameBoard.GameBoard gameBoard)
        {
            if (Weapons == 0) return;
            if (X - 1 >= 0 && gameBoard.GameBoardItems[Y][X - 1] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y][X - 1]).Army != Army)
                ((Unit)gameBoard.GameBoardItems[Y][X - 1]).Health -= 30;
            if (Y - 1 >= 0 && gameBoard.GameBoardItems[Y - 1][X] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y - 1][X]).Army != Army)
                ((Unit)gameBoard.GameBoardItems[Y - 1][X]).Health -= 30;
            if (X + 1 < gameBoard.Width && gameBoard.GameBoardItems[Y][X + 1] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y][X + 1]).Army != Army)
                ((Unit)gameBoard.GameBoardItems[Y][X + 1]).Health -= 30;
            if (Y + 1 < gameBoard.Height && gameBoard.GameBoardItems[Y + 1][X] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y + 1][X]).Army != Army)
                ((Unit)gameBoard.GameBoardItems[Y + 1][X]).Health -= 30;
        }
    }
}
