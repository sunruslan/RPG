using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Threading;
using Prism.Commands;
using Prism.Mvvm;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Units;

namespace RPG.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            StartCommand = new DelegateCommand(Start);
            SetPlayerCommand = new DelegateCommand<string>(SetPlayer);
            SetLevelCommand = new DelegateCommand<string>(SetLevel);


            _redArmy = new RedArmy();
            _blueArmy = new BlueArmy();
        }

        public ICommand StartCommand { get; }

        public ICommand SetPlayerCommand { get; }

        public ICommand SetLevelCommand { get; }
        
        public bool IsStarted
        {
            get { return _isStarted; }
            set { SetProperty(ref _isStarted, value); }
        }

        public Level Level { get; private set; } = Level.UNKHOWN;

        public UnitType Player { get; set; } = UnitType.UNKNOWN;

        public Game.Game Game { get; set; }

        public GameBoard.GameBoard GameBoard
        {
            get { return _gameBoard; }
            set { SetProperty(ref _gameBoard, value); }
        }

        private void Start()
        {
            if (Level == Level.UNKHOWN || Player == UnitType.UNKNOWN) return;
            Game = new Game.Game(Level, Player);
            Game.Start();
            GameBoard = Game.GameBoard;
            IsStarted = true;
            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(GameStep);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        public void GameStep(object sender, EventArgs e)
        {
            GameBoard = null;
            GameBoard = Game.GameBoard;
        }

        private void SetLevel(string level)
        {
            Level = (Level)int.Parse(level);
        }

        private void SetPlayer(string type)
        {
            Player = (UnitType) int.Parse(type);
        }
        
        private bool _isStarted;
        private GameBoard.GameBoard _gameBoard;
        private IArmy _blueArmy;
        private IArmy _redArmy;
        private IItem _life;
        private IItem _weapon;
    }
}
