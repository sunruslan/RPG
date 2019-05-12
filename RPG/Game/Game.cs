using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Units;
using RPG.Goods;

namespace RPG.Game
{
    public class Game
    {
        public Game(Level level, UnitType unit)
        {
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
            _redArmy.Initialize(1, 1, 1);
            _blueArmy.Initialize(1, 1, 1);
            switch (_level)
            {
                case Level.EASY:
                    director = new LightGameBoardDirector(builder);
                    break;
                case Level.MEDIUM:
                    director = new MediumGameBoardDirector(builder);
                    break;
                case Level.HARD:
                    director = new HardGameBoardDirector(builder);
                    break;
                default:
                    throw new NotSupportedException();
            }
            director.Create(_redArmy.Units, _blueArmy.Units, _life, _weapon);
            GameBoard = builder.GetGameBoard();
            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(GameStep);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        public void GameStep(object sender, EventArgs e)
        {
            if (_redArmy.IsAlive() && _blueArmy.IsAlive())
            {
                _blueArmy.Act(GameBoard);
                _redArmy.Act(GameBoard);
            }
            else
            {

                MessageBox.Show("win kto-to");
            }
            //MessageBox.Show($"reds: {_redArmy.AliveCount()}\nblues:{_blueArmy.AliveCount()}");
        }

        private IItem _life;
        private IItem _weapon;

        private RedArmy _redArmy;
        private BlueArmy _blueArmy;
        private Level _level;
        private UnitType _unit;
    }
}
