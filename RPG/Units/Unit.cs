﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Units.States;

namespace RPG.Units
{
    public abstract class Unit
    {
        public State State { get; set; }
    }
}
