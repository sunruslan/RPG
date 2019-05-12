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
    class Context
    {
        private IAction _action;
        public Context()
        { }
        
        public Context(IAction action)
        {
            this._action = action;
        }
        
        public void SetAction(IAction action)
        {
            this._action = action;
        }

        public void DoAction(Unit fighter, IItem element, GameBoard.GameBoard gameBoard)
        {
            _action.Act(fighter, element, gameBoard);
        }
    }
}
