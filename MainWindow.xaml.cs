using Microsoft.Win32;
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


namespace Djeyjey
{


public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }
        bool drag = false;
        MediaPlayer mediaPlayer = new MediaPlayer();
        string FileName;

        private void picker_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Multiselect = false,
                DefaultExt = ".mp3"
            };
            bool? dialogWin = fileDialog.ShowDialog();
            if (dialogWin == true)
            {
                FileName = fileDialog.FileName;
                TBFileName.Text = fileDialog.SafeFileName;
                mediaPlayer.Open(new Uri(FileName));
            }
        }

        private void paustart_Click(object sender, RoutedEventArgs e)
        {

            mediaPlayer.Play();



        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void repeat_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            mediaPlayer.Play();
        }

        private void random_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /* Slider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            mediaPlayer.Pause();
            mediaPlayer.Position = TimeSpan.FromSeconds(Slider.Value);
            mediaPlayer.Play();*/
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }
    }


}

