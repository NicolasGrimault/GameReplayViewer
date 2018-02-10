using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReplayViewer.Model
{
    public class GameReplay
    {
        private string name;
        private string path;
        private Game game;

        public string FullPath => string.Format("{0}{1}", game.Path, this.Path);

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }



    }
}
