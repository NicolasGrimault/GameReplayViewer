using GameReplayViewer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using System.ComponentModel;
using GameReplayViewer.Services;
using System;

namespace GameReplayViewer.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel(IMediaService mediaService)
        {
            var gameseeker = new GameReplaySeekerServices();

            gameseeker.Search();

            gameReplayItems = gameseeker.gameReplayList;
            //selectedGameReplay = gameReplayItems.First();
            this.PlayCommand = new DelegateCommand(this.Play);
            this.PauseCommand = new DelegateCommand(this.Pause);
            this.StopCommand = new DelegateCommand(this.Stop);


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
        private void Stop()
        {
            mediaService.Stop();
            this.IsVideoPlaying = false;
        }


        public ICommand PlayCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }
        public ICommand StopCommand { get; private set; }


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
            set
            {
                selectedGameReplay = value;
                IsVideoPlaying = false;
                NotifyPropertyChanged("SelectedGameReplay");
            }
        }

        public List<GameReplay> GameReplayItems
        {
            get { return gameReplayItems; }
            set { gameReplayItems = value; }
        }
    }
}
