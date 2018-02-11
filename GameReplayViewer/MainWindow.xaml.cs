using GameReplayViewer.Services;
using GameReplayViewer.ViewModel;
using Meta.Vlc.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameReplayViewer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, PlayerServicesInterface
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Player.Dispose();
            ApiManager.ReleaseAll();
            base.OnClosing(e);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Player.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Player.PauseOrResume();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }

        private void ProgressBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var value = (float)(e.GetPosition(ProgressBar).X / ProgressBar.ActualWidth);
            ProgressBar.Value = value;
        }

        public void LoadVideo(string path)
        {
            Player.Stop();
            Player.LoadMedia(path);
            Player.Play();
        }

    }
}
