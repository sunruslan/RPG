using System;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
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
        }

        public ICommand StartCommand { get; }

        public ICommand SetPlayerCommand { get; }

        public ICommand SetLevelCommand { get; }
        
        

        public bool IsStarted
        {
            get { return _isStarted; }
            set { SetProperty(ref _isStarted, value); }
        }

        public int Level { get; private set; }

        public string PlayerName { get; set; }

        public TimeSpan RoundTime
        {
            get { return _roundTime; }
            set { SetProperty(ref _roundTime, value); }
        }

        public Cell[][] GameBoard { get; set; }
        
        private void Start()
        {
            if (Level != 0 && String.IsNullOrEmpty(PlayerName)) return;
            var builder = new GameBoardBuilder();
            var director = new GameBoardDirector(builder);
            director.Create(1);
            GameBoard = builder.GetGameBoard().GameBoardCells;
            IsStarted = true;
        }

        private void SetLevel(string level)
        {
            Level = level == null ? 0 : Int32.Parse(level);
        }

        private void SetPlayer(string name)
        {
            PlayerName = name;
        }
        
        private bool _isStarted = false;
        private TimeSpan _roundTime = TimeSpan.Zero;
    }
}
