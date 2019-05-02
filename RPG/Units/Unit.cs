using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameBoard;
using RPG.Goods;
using RPG.Units.States;

namespace RPG.Units
{
    public abstract class Unit : IItem
    {
        public State State { get; set; }

        public IArmy Army { get; set; }
        
        public ICollection<Weapon> Weapons { get; set; }

        public ICollection<Life> Lives { get; set; }

        public int Health
        {
            get { return Lives.Count; }
        }

        public int WeaponsCount
        {
            get { return Weapons.Count; }
        }

        public bool IsAlive
        {
            get { return Health > 0; }
        }

        public abstract void Attack();

        public int X { get; set; }

        public int Y { get; set; }
    }
}
