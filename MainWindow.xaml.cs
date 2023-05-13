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
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace Djeyjey
{


    public partial class MainWindow : Window
    {

        bool pause;
        int queue;
        bool drag = false;
       

        public MainWindow()
        {
            InitializeComponent();
        }


        string FileName;

        private void picker_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog { IsFolderPicker = true };
            var dialog = fileDialog.ShowDialog();
            if (dialog == CommonFileDialogResult.Ok)
            {
                string[] mp3 = Directory.GetFiles(fileDialog.FileName, "*mp3");
                string[] mav = Directory.GetFiles(fileDialog.FileName, "*mav");
                string[] m4a = Directory.GetFiles(fileDialog.FileName, "*m4a");
                List<string> directs = new List<string>();
                directs.AddRange(mp3);
                directs.AddRange(mav);
                directs.AddRange(m4a);
                listbox.ItemsSource = directs;
                queue = 0;
                Media.Source = new Uri(directs[queue].ToString());
                Media.Play();
                Media.Volume = 0.00000001;
                Thread potok = new Thread(_ =>
                {
                    mover.Value = Media.Position.Ticks;
        });

            }


        }

        private void paustart_Click(object sender, RoutedEventArgs e)
        {

            Media.Play();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (queue > 0)
            {
                for (int i = 0; i < listbox.Items.Count; i++)
                {
                    queue--;
                }
            }
            else
            {
                MessageBox.Show("Назад уже некуда");
            }

        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            if (queue <= listbox.Items.Count)
            {
                for (int i = 0; i < listbox.Items.Count; i++)
                {
                    queue++;
                }
            }
            else
            {
                MessageBox.Show("Дальше уже некуда");
            }

        }

        private void repeat_Click(object sender, RoutedEventArgs e)
        {

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

        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            Media.Pause();
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }


}
