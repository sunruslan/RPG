using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.GameBoard
{
    public class Cell
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Unit Unit { get; set; }

        public Good Good { get; set; } = new Ground();
    }
}
