using GameReplayViewer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using System.ComponentModel;

namespace GameReplayViewer.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel(IMediaService mediaService)
        {
            Game Overwatch = new Game() { Name = "Overwatch", Path = "D:/Nicolas/Documents/Overwatch/videos/overwatch/" };
            gameReplayItems = new List<GameReplay>() { new GameReplay() { Path = "soldier rocket 3kills_17-08-24_20-41-07.mp4", Name = "soldier rocket 3kills", Game = Overwatch } };
            selectedGameReplay = gameReplayItems.First();
            this.PlayCommand = new DelegateCommand(this.Play);
            this.PauseCommand = new DelegateCommand(this.Pause);
            this.mediaService = mediaService;

        }


        private GameReplay selectedGameReplay;
        private List<GameReplay> gameReplayItems;
        private bool isVideoPlaying = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public IMediaService mediaService { get; private set; }


        private void Play()
        {
            mediaService.Play();
            this.IsVideoPlaying = true;

        }
        private void Pause()
        {
            mediaService.Pause();
            this.IsVideoPlaying = false;

        }

        public ICommand PlayCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }


        public bool IsVideoPlaying
        {
            get { return isVideoPlaying; }
            set
            {
                isVideoPlaying = value;
                NotifyPropertyChanged("IsVideoPlaying");
            }
        }

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
