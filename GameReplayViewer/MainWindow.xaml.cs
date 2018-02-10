using GameReplayViewer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameReplayViewer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMediaService
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }

        void IMediaService.FastForward()
        {
            this.GameReplayMediaElement.Position += TimeSpan.FromSeconds(10);
        }

        void IMediaService.Pause()
        {
            this.GameReplayMediaElement.Pause();
        }

        void IMediaService.Play()
        {
            this.GameReplayMediaElement.Play();
        }

        void IMediaService.Rewind()
        {
            this.GameReplayMediaElement.Position -= TimeSpan.FromSeconds(10);
        }

        void IMediaService.Stop()
        {
            this.GameReplayMediaElement.Stop();
        }
    }
}
