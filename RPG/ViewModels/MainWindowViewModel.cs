using System;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using Prism.Mvvm;
using RPG.GameBoard;

namespace RPG.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {

        }

        public ICommand StartCommand { get; }
        
        

        public bool IsStarted
        {
            get { return _isStarted; }
            set { SetProperty(ref _isStarted, value); }
        }


        public TimeSpan RoundTime
        {
            get { return _roundTime; }
            set { SetProperty(ref _roundTime, value); }
        }

        public GameBoard.GameBoard GameBoard { get; set; }
        

        private void Start()
        {
            var builder = new GameBoardBuilder();
            var director = new GameBoardDirector(builder);
            director.Create(1);
            GameBoard = builder.GetGameBoard();
            IsStarted = true;
        }
        
        private bool _isStarted = false;
        private TimeSpan _roundTime = TimeSpan.Zero;
    }
}
