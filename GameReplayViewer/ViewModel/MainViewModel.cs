using GameReplayViewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReplayViewer.ViewModel
{
    public class MainViewModel
    {
        private GameReplay selectedGameReplay;
        private List<GameReplay> gameReplayItems;


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
