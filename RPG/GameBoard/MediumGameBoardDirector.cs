using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.GameBoard
{
    public class MediumGameBoardDirector : IGameBoardDirector
    {
        public MediumGameBoardDirector(IGameBoardBuilder builder)
        {
            _builder = builder;
        }

        public void Create(ICollection<IItem> reds, ICollection<IItem> blues)
        {
            _builder.SetShape(15, 15);
        }

        private IGameBoardBuilder _builder;
    }
}
