using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.Factories
{
    public abstract class Factory
    {
        public abstract Weapon CreateWeapon();

        public abstract Unit CreateUnit();

        public Life CreateLife()
        {
            return new Life();
        }

        public Coin CreateCoin()
        {
            return new Coin();
        }
    }
}
