using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameBoard
{
    public class GameBoardDirector
    {
        public GameBoardDirector(IGameBoardBuilder builder)
        {
            _builder = builder;
        }

        public void Create(int level)
        {
            
        }

        private IGameBoardBuilder _builder;
    }
}
