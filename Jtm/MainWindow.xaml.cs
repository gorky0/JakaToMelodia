﻿using System.Windows;
using System.Windows.Input;

namespace Jtm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContextObject newContext;
        bool isPlaying = false;
        enum Status { Failed=2, Ok=3 }
        public MainWindow()
        {
            
         
            newContext = new ContextObject();
            newContext.NewPlayer = new Player();
            newContext.GamePoints = new Points();
            InitializeComponent();
            DataContext = newContext;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)//play/start
        {
            HideX();
            isPlaying = true;
            newContext.NewPlayer.PlaySong();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)//Stop
        {
            isPlaying = false;
            newContext.NewPlayer.StopSong();
        }

        private void button2_Click(object sender, RoutedEventArgs e)//Wczytaj
        {
            if (listBox.Items.Count > 0)
            {

                newContext.NewPlayer.StopSong();
                newContext.NewPlayer.ClosePlayer();
                listBox.Items.Clear();
                newContext.NewPlayer.Names = null;
            }
            
            newContext.NewPlayer.Browse();
            if (newContext.NewPlayer.Names != null)
            {
                for (int j = 0; j < newContext.NewPlayer.Names.Length; j++)
                {
                    listBox.Items.Add(newContext.NewPlayer.Names[j]);

                }
            }

        }

        //private void button3_Click(object sender, RoutedEventArgs e)//Testowy button
        //{
        //    newContext.NewPlayer.Alert = 4;
            

        //}

        private void button4_Click(object sender, RoutedEventArgs e)//Pauza
        {
            isPlaying = false;
            newContext.NewPlayer.PauseSong();
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            HideX();
            HidePointButtons();
            isPlaying = false;
            newContext.NewPlayer.NumberClicked = listBox.SelectedIndex;
            newContext.GamePoints.ResetStatus();
            newContext.NewPlayer.PlayerInit();

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)//gracz naciska przycisk
        {
            if (isPlaying == true)
            {
                
                if (e.Key == Key.A && newContext.GamePoints.StatusOne ==(int) Status.Ok)
                {
                    newContext.NewPlayer.PauseSong();
                    isPlaying = false;
                    button5.Visibility = Visibility.Visible;
                    button6.Visibility = Visibility.Hidden;
                    button7.Visibility = Visibility.Hidden;
                    button8.Visibility = Visibility.Visible;
                    button9.Visibility = Visibility.Hidden;
                    button10.Visibility = Visibility.Hidden;
                
                }
                else if (e.Key == Key.S && newContext.GamePoints.StatusTwo == (int)Status.Ok)
                {
                    newContext.NewPlayer.PauseSong();
                    isPlaying = false;
                    button5.Visibility = Visibility.Hidden;
                    button6.Visibility = Visibility.Visible;
                    button7.Visibility = Visibility.Hidden;
                    button8.Visibility = Visibility.Hidden;
                    button9.Visibility = Visibility.Visible;
                    button10.Visibility = Visibility.Hidden;
                }
                else if (e.Key == Key.D && newContext.GamePoints.StatusThree == (int)Status.Ok)
                {
                    newContext.NewPlayer.PauseSong();
                    isPlaying = false;
                    button5.Visibility = Visibility.Hidden;
                    button6.Visibility = Visibility.Hidden;
                    button7.Visibility = Visibility.Visible;
                    button8.Visibility = Visibility.Hidden;
                    button9.Visibility = Visibility.Hidden;
                    button10.Visibility = Visibility.Visible;
                }
                else { }
            }
        }

        private void HidePointButtons() {
            button5.Visibility = Visibility.Hidden;
            button6.Visibility = Visibility.Hidden;
            button7.Visibility = Visibility.Hidden;
            button8.Visibility = Visibility.Hidden;
            button9.Visibility = Visibility.Hidden;
            button10.Visibility = Visibility.Hidden;
        }

        private void HideX()
        {
            label10.Visibility = Visibility.Hidden;
            label11.Visibility = Visibility.Hidden;
            label12.Visibility = Visibility.Hidden;

        }

        private void button5_Click(object sender, RoutedEventArgs e)//+1 1szy gracz
        {
            HideX();
            newContext.GamePoints.PlayerOne++;

            newContext.GamePoints.ResetStatus();

            HidePointButtons();
            newContext.NewPlayer.StopSong();
        }

        private void button8_Click(object sender, RoutedEventArgs e)//0
        {
            label10.Visibility = Visibility.Visible;
            HidePointButtons();
            newContext.GamePoints.StatusOne = (int)Status.Failed;
            newContext.NewPlayer.PlaySong();
            isPlaying = true;
        }

        private void button6_Click(object sender, RoutedEventArgs e)//+1 2gi gracz
        {
            HideX();
            newContext.GamePoints.PlayerTwo++;
            newContext.GamePoints.ResetStatus();
            HidePointButtons();
            newContext.NewPlayer.StopSong();
        }

        private void button9_Click(object sender, RoutedEventArgs e)//0
        {
            label11.Visibility = Visibility.Visible;
            HidePointButtons();
            newContext.GamePoints.StatusTwo = (int)Status.Failed;
            newContext.NewPlayer.PlaySong();
            isPlaying = true;
        }

        private void button7_Click(object sender, RoutedEventArgs e)//+1 3ci gracz
        {
            HideX();
            newContext.GamePoints.PlayerThree++;
            newContext.GamePoints.ResetStatus();
            HidePointButtons();
            newContext.NewPlayer.StopSong();
        }

        private void button10_Click(object sender, RoutedEventArgs e)//0
        {
            label12.Visibility = Visibility.Visible;
            HidePointButtons();
            newContext.GamePoints.StatusThree = (int)Status.Failed;
            newContext.NewPlayer.PlaySong();
            isPlaying = true;
        }
    }
}
