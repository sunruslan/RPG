using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameBoard;
using RPG.Units.States;

namespace RPG.Units
{
    public abstract class Unit : Item
    {
        public State State { get; set; }

        public int Spirit { get; set; }
    }
}
