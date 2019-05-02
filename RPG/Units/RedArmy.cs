﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameBoard;
using RPG.Goods;

namespace RPG.Units
{
    public class RedArmy : IArmy
    {
        public RedArmy()
        {
            _units = new List<Unit>();
        }

        public void Initialize(int archers, int firemen, int icemen)
        {
            for (int i = 0; i < archers; i++)
            {
                Add(new Archer()
                {
                    Army = this,
                    Lives = new Life[] { new Life(), new Life(), new Life() },
                    Weapons = new Weapon[] { new Arrow(), new Arrow(), new Arrow() }
                });
            }

            for (int i = 0; i < firemen; i++)
            {
                Add(new FireMan()
                {
                    Army = this,
                    Lives = new Life[] { new Life(), new Life(), new Life() },
                    Weapons = new Weapon[] { new Fire(), new Fire(), new Fire() }
                });
            }

            for (int i = 0; i < icemen; i++)
            {
                Add(new IceMan()
                {
                    Army = this,
                    Lives = new Life[] { new Life(), new Life(), new Life() },
                    Weapons = new Weapon[] { new Ice(), new Ice(), new Ice() }
                });
            }
        }

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public void Remove(Unit unit)
        {
            _units.Remove(unit);
        }

        public void Clear()
        {
            _units.Clear();
        }

        public void Attack()
        {
            foreach (var unit in _units)
            {
                unit.Attack();
            }
        }

        public ICollection<IItem> Units
        {
            get { return _units.Select(u => (IItem)u).ToList(); }
        }

        private ICollection<Unit> _units;
    }
}