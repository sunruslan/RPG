﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameBoard;
using RPG.Goods;
using RPG.Factories;

namespace RPG.Units
{
    public class BlueArmy : IArmy, IActionable
    {
        public BlueArmy()
        {
            _units = new List<Unit>();
        }

        public void Initialize(int archers, int firemen, int icemen)
        {
            var archerFactory = new ArcherFactory();
            var fireFactory = new FireFactory();
            var iceFactory = new IceFactory();

            for (int i = 0; i < archers; i++)
            {
                Add(archerFactory.CreateUnit(this));
            }

            for (int i = 0; i < firemen; i++)
            {
                Add(fireFactory.CreateUnit(this));
            }

            for (int i = 0; i < icemen; i++)
            {
                Add(iceFactory.CreateUnit(this));
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

        public Archer Archer
        {
            get { return Units.FirstOrDefault(t => t is Archer) as Archer; }
        }

        public FireMan FireMan
        {
            get { return Units.FirstOrDefault(t => t is FireMan) as FireMan; }
        }

        public IceMan IceMan
        {
            get { return Units.FirstOrDefault(t => t is IceMan) as IceMan; }
        }

        public bool IsAlive()
        {
            return Units.Any(u => ((Unit) u).IsAlive);
        }

        public int Count()
        {
            return Units.Count;
        }

        public int AliveCount()
        {
            return Units.Count(u => ((Unit) u).IsAlive);
        }

        public void Act(GameBoard.GameBoard gameBoard)
        {
            foreach (var unit in _units)
            {
                unit.Act(gameBoard);
            }
        }

        public ICollection<IItem> Units
        {
            get { return _units.Select(u => (IItem)u).ToList(); }
        }

        public void ActWithout(GameBoard.GameBoard gameBoard, Unit unit)
        {
            foreach (var u in _units)
            {
                if (u == unit) continue;
                u.Act(gameBoard);
            }
        }

        public void UpdateAliveUnits()
        {
            var died = Units.Where(u => ((Unit)u).IsAlive).ToList();
            foreach (var d in died)
            {
                Units.Remove(d);
            }
        }

        private ICollection<Unit> _units;
    }
}
