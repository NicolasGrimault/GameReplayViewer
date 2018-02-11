using GameReplayViewer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Prism.Commands;
using System.ComponentModel;
using GameReplayViewer.Services;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GameReplayViewer.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private GameReplaySeekerServices gameSeeker = new GameReplaySeekerServices();

        public MainViewModel(PlayerServicesInterface mediaService)
        {
            LoadGamesCommand = new DelegateCommand(this.LoadGamesReplay);
            this.mediaService = mediaService;

        }

        private GameReplay selectedGameReplay;
        private ObservableCollection<GameReplay> gameReplayItems;


        public async void LoadGamesReplay()
        {
           await Task.Run(() => this.gameSeeker.Search());
            GameReplayItems = new ObservableCollection<GameReplay>(this.gameSeeker.gameReplayList);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public PlayerServicesInterface mediaService { get; private set; }

        public ICommand LoadGamesCommand { get; private set; }

        public GameReplay SelectedGameReplay
        {
            get { return selectedGameReplay; }
            set
            {
                selectedGameReplay = value;
                mediaService.LoadVideo(value.FullPath);
                NotifyPropertyChanged("SelectedGameReplay");
            }
        }

        public ObservableCollection<GameReplay> GameReplayItems
        {
            get { return gameReplayItems; }
            set
            {
                gameReplayItems = value;
                NotifyPropertyChanged("GameReplayItems");
            }
        }
    }
}
