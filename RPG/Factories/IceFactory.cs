﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Goods;
using RPG.Units;

namespace RPG.Factories
{
    public class IceFactory : Factory
    {
        public override Unit CreateUnit(IArmy army)
        {
            var iceMan = new IceMan {Army = army, Hit = 10, Health = 100, Weapons = 20};
            return iceMan;
        }

        public override Weapon CreateWeapon()
        {
            return new Ice();
        }
    }
}
