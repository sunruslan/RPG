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
    interface IAction
    {
        void Act(Unit fighter, IItem element, GameBoard.GameBoard gameBoard);
    }
}
