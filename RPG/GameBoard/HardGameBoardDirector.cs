using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Units;

namespace RPG.GameBoard
{
    public class HardGameBoardDirector : IGameBoardDirector
    {
        public HardGameBoardDirector(IGameBoardBuilder builder)
        {
            _builder = builder;
        }

        public void Create(ICollection<IItem> reds, ICollection<IItem> blues)
        {
            _builder.SetShape(18, 18);
        }

        private IGameBoardBuilder _builder;
    }
}
