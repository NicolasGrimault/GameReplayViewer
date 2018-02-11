using GameReplayViewer.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;


namespace GameReplayViewer.Services
{
    public class GameReplaySeekerServices
    {
        public List<GameReplay> gameReplayList = new List<GameReplay>();

        public enum Format
        {
            mp4, webm
        }

        /// <summary>
        /// Look for all videos in  UserProfile & MyDocuments
        /// </summary>
        public void Search()
        {
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SearchInPath(userProfilePath);
            SearchInPath(DocumentsPath);
        }

        private void SearchInPath(string path)
        {
            foreach (string folder in Directory.GetDirectories(path))
            {
                try
                {
                    foreach (var supportedExtensions in GetSupportedExtensions())
                    {
                        var mp4Files = Directory.GetFiles(folder, supportedExtensions, SearchOption.AllDirectories);
                        foreach (var file in mp4Files)
                        {
                            gameReplayList.Add(new GameReplay(file));
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private static IReadOnlyCollection<string> GetSupportedExtensions()
        {
            Collection<string> extensions = new Collection<string>();
            foreach (var format in Enum.GetValues(typeof(Format)))
            {
                extensions.Add(
                    string.Format("*.{0}", format.ToString())
                    );
            }
            return extensions;
        }
    }
}
