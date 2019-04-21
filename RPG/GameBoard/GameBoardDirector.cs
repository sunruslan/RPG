using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

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
            _builder.SetShape(50, 50);
            var walls = new Cell[10];
            var positions = new Cell[10];
            var random = new Random(123);
            for(int i = 0; i < 10 ; ++i)
            { 
                walls[i] = new Cell();
                walls[i].X = random.Next(0, 50);
                walls[i].Y = random.Next(0, 50);
                walls[i].Content = new Wall{Spirit = 0};
            }

            for (int i = 0; i < 10; ++i)
            {
                positions[i] = new Cell();
                positions[i].X = random.Next(0, 50);
                positions[i].Y = random.Next(0, 50);
                positions[i].Content = new Archer{Spirit = 1};
            }
            _builder.CreateWalls(walls);
            _builder.SetStartPositions(positions);
        }

        private IGameBoardBuilder _builder;
    }
}
