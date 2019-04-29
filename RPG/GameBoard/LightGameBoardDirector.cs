using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;

namespace RPG.GameBoard
{
    public class LightGameBoardDirector : IGameBoardDirector
    {
        public LightGameBoardDirector(IGameBoardBuilder builder)
        {
            _builder = builder;
        }

        public void Create()
        {
            _builder.SetShape(20, 20);
            var walls = new Cell[]
            {
                new Cell{Y = 0, X = 18, Good = new Wall(), Unit = null},
                new Cell{Y = 1, X = 4, Good = new Wall(), Unit = null},
                new Cell{Y = 1, X = 18, Good = new Wall(), Unit = null},
                new Cell{Y = 2, X = 3, Good = new Wall(), Unit = null},
                new Cell{Y = 2, X = 4, Good = new Wall(), Unit = null},
                new Cell{Y = 2, X = 5, Good = new Wall(), Unit = null},
                new Cell{Y = 3, X = 5, Good = new Wall(), Unit = null},
                new Cell{Y = 4, X = 5, Good = new Wall(), Unit = null},
                new Cell{Y = 5, X = 10, Good = new Wall(), Unit = null},
                new Cell{Y = 5, X = 11, Good = new Wall(), Unit = null},
                new Cell{Y = 5, X = 12, Good = new Wall(), Unit = null},
                new Cell{Y = 5, X = 13, Good = new Wall(), Unit = null},
                new Cell{Y = 9, X = 15, Good = new Wall(), Unit = null},
                new Cell{Y = 10, X = 12, Good = new Wall(), Unit = null},
                new Cell{Y = 10, X = 13, Good = new Wall(), Unit = null},
                new Cell{Y = 10, X = 15, Good = new Wall(), Unit = null},
                new Cell{Y = 11, X = 13, Good = new Wall(), Unit = null},
                new Cell{Y = 11, X = 14, Good = new Wall(), Unit = null},
                new Cell{Y = 11, X = 15, Good = new Wall(), Unit = null},
                new Cell{Y = 11, X = 16, Good = new Wall(), Unit = null},
                new Cell{Y = 11, X = 17, Good = new Wall(), Unit = null},
                new Cell{Y = 12, X = 15, Good = new Wall(), Unit = null},
                new Cell{Y = 13, X = 4, Good = new Wall(), Unit = null},
                new Cell{Y = 14, X = 4, Good = new Wall(), Unit = null},
                new Cell{Y = 14, X = 3, Good = new Wall(), Unit = null},
                new Cell{Y = 14, X = 4, Good = new Wall(), Unit = null},
                new Cell{Y = 14, X = 5, Good = new Wall(), Unit = null},
                new Cell{Y = 14, X = 6, Good = new Wall(), Unit = null},
                new Cell{Y = 15, X = 3, Good = new Wall(), Unit = null},
                new Cell{Y = 16, X = 3, Good = new Wall(), Unit = null},
                new Cell{Y = 15, X = 14, Good = new Wall(), Unit = null},
                new Cell{Y = 16, X = 14, Good = new Wall(), Unit = null},
                new Cell{Y = 17, X = 13, Good = new Wall(), Unit = null},
                new Cell{Y = 17, X = 14, Good = new Wall(), Unit = null},
                new Cell{Y = 18, X = 13, Good = new Wall(), Unit = null},
                new Cell{Y = 18, X = 14, Good = new Wall(), Unit = null},
                new Cell{Y = 19, X = 13, Good = new Wall(), Unit = null},
                new Cell{Y = 19, X = 14, Good = new Wall(), Unit = null},
            };
            _builder.CreateWalls(walls);
        }

        private IGameBoardBuilder _builder;
    }
}
