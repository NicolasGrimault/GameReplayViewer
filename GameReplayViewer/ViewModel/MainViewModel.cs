using GameReplayViewer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;

namespace GameReplayViewer.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Game Overwatch = new Game() { Name = "Overwatch", Path = "D:/Nicolas/Documents/Overwatch/videos/overwatch/" };
            gameReplayItems = new List<GameReplay>() { new GameReplay() { Path = "soldier rocket 3kills_17-08-24_20-41-07.mp4", Name = "soldier rocket 3kills", Game = Overwatch } };
            selectedGameReplay = gameReplayItems.First();
            this.PlayCommand = new DelegateCommand(this.Play, this.CanBeResumed);
            this.PauseCommand = new DelegateCommand(this.Pause, this.CanBePaused);

        }

        private GameReplay selectedGameReplay;
        private List<GameReplay> gameReplayItems;
        private bool isVideoPlaying = true;



        private void Play() {

        }
        private void Pause()
        {

        }

        public ICommand PlayCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }


        public bool IsVideoPlaying
        {
            get { return isVideoPlaying; }
        }
        public bool IsVideoPaused
        {
            get { return !isVideoPlaying; }
        }
        private bool CanBePaused() => IsVideoPaused;
        private bool CanBeResumed() => IsVideoPlaying;

        public GameReplay SelectedGameReplay
        {
            get { return selectedGameReplay; }
            set { selectedGameReplay = value; }
        }

        public List<GameReplay> GameReplayItems
        {
            get { return gameReplayItems; }
            set { gameReplayItems = value; }
        }
    }
}
