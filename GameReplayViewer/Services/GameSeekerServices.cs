using GameReplayViewer.Model;
using System.Collections.Generic;
using System.IO;


namespace GameReplayViewer.Services
{
    public class GameSeekerServices
    {
        public List<GameReplay> gameReplayList = new List<GameReplay>();

        public void Search(string[] args)
        {
            foreach (string path in args)
            {
                if (Directory.Exists(path))
                {
                    var mp4Files = Directory.GetFiles(path, "*.mp4", SearchOption.AllDirectories);
                    foreach (var file in mp4Files)
                    {
                        this.ProcessFile(file);
                    }
                    var webpmFiles = Directory.GetFiles(path, "*.webm", SearchOption.AllDirectories);
                    foreach (var file in webpmFiles)
                    {
                        this.ProcessFile(file);
                    }

                }
            }
        }


        public void ProcessFile(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            string fullName = Path.GetFileName(path);
            string GamePath = Path.GetDirectoryName(path);
            gameReplayList.Add(new GameReplay() { Name = name, Path = fullName, Game = new Game() { Path = GamePath, Name = "overwatch" } });
    }
}
}
