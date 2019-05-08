﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Units;

namespace RPG.Game
{
    public class Game
    {
        public Game(Level level, UnitType unit)
        {
            //TODo: крякнуть
            _level = level;
            _unit = unit;
            _redArmy = new RedArmy();
            _blueArmy = new BlueArmy();
        }

        public GameBoard.GameBoard GameBoard { get; set; }

        public void Start()
        {
            var builder = new GameBoardBuilder();
            IGameBoardDirector director;
            switch (_level)
            {
                case Level.EASY:
                    director = new LightGameBoardDirector(builder);
                    _redArmy.Initialize(1, 1, 1);
                    _blueArmy.Initialize(1, 1, 1);
                    break;
                case Level.MEDIUM:
                    director = new MediumGameBoardDirector(builder);
                    _redArmy.Initialize(2, 2, 2);
                    _blueArmy.Initialize(2, 2, 2);
                    break;
                case Level.HARD:
                    director = new HardGameBoardDirector(builder);
                    _redArmy.Initialize(3, 3, 3);
                    _blueArmy.Initialize(3, 3, 3);
                    break;
                default:
                    throw new NotSupportedException();
            }
            director.Create(_redArmy.Units, _blueArmy.Units);
            GameBoard = builder.GetGameBoard();
        }



        private RedArmy _redArmy;
        private BlueArmy _blueArmy;
        private Level _level;
        private UnitType _unit;
    }
}
