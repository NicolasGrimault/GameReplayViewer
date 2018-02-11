using System;
using System.Collections.Generic;
using System.IO;

namespace GameReplayViewer.Model
{
    public class GameReplay
    {
        private string fullPath;

        public GameReplay(string fullPath)
        {
            this.fullPath = fullPath;
        }

        public string FullPath 
        {
            get { return fullPath; }
            set { fullPath = value; }
        }

        public string Name
        {
            get { return Path.GetFileNameWithoutExtension(fullPath); }
        }

        public string FileName
        {
            get { return Path.GetFileName(fullPath); }
        }
    }
}
