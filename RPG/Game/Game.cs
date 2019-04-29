using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Enums;
using RPG.GameBoard;

namespace RPG.Game
{
    public class Game
    {
        public Game(Level level, UnitType unit)
        {
            _level = level;
            _unit = unit;
        }

        public GameBoard.GameBoard GameBoard { get; set; }

        public void Start()
        {
            var builder = new GameBoardBuilder();
            var director = new LightGameBoardDirector(builder);
            director.Create();
            GameBoard = builder.GetGameBoard();
        }


        private Level _level;
        private UnitType _unit;
    }
}
