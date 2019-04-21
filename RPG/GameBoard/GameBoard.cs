using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.GameBoard
{
    public class GameBoard
    {
        public int Height
        {
            get { return GameBoardCells.Length; }
        }

        public int Width
        {
            get { return GameBoardCells[0].Length; }
        }

        public Cell[][] GameBoardCells { get; set; }
    }
}
