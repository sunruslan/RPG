﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.GameBoard;

namespace RPG.Units
{
    public interface IArmy
    {
        void Initialize(int archers, int firemen, int icemen);

        void Add(Unit unit);

        void Remove(Unit unit);

        void Clear();

        void Attack();

        ICollection<IItem> Units { get; }
    }
}