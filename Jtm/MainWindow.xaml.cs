using System.Windows;
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
        public MainWindow()
        {
            
            //lol.PlayerInit();
            newContext = new ContextObject();
            newContext.NewGame = new Player();
            newContext.GamePoints = new Points();
            InitializeComponent();
            DataContext = newContext;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            isPlaying = true;
            newContext.NewGame.PlaySong();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            newContext.NewGame.StopSong();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.Items.Count > 0)
            {

                newContext.NewGame.StopSong();
                newContext.NewGame.ClosePlayer();
                listBox.Items.Clear();
                newContext.NewGame.Names = null;
            }
            
            newContext.NewGame.Browse();
            if (newContext.NewGame.Names != null)
            {
                for (int j = 0; j < newContext.NewGame.Names.Length; j++)
                {
                    listBox.Items.Add(newContext.NewGame.Names[j]);

                }
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            newContext.NewGame.Alert = 4;
            

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            newContext.NewGame.PauseSong();
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            newContext.NewGame.NumberClicked = listBox.SelectedIndex;
            newContext.NewGame.PlayerInit();

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)//kto pierwszy naciśnie
        {
            if (isPlaying == true)
            {
                
                if (e.Key == Key.A)
                {
                    newContext.NewGame.StopSong();
                    isPlaying = false;
                    button5.Visibility = Visibility.Visible;
                    button6.Visibility = Visibility.Hidden;
                    button7.Visibility = Visibility.Hidden;
                    button8.Visibility = Visibility.Visible;
                    button9.Visibility = Visibility.Hidden;
                    button10.Visibility = Visibility.Hidden;
                
                }
                else if (e.Key == Key.S)
                {
                    newContext.NewGame.StopSong();
                    isPlaying = false;
                    button5.Visibility = Visibility.Hidden;
                    button6.Visibility = Visibility.Visible;
                    button7.Visibility = Visibility.Hidden;
                    button8.Visibility = Visibility.Hidden;
                    button9.Visibility = Visibility.Visible;
                    button10.Visibility = Visibility.Hidden;
                }
                else if (e.Key == Key.D)
                {
                    newContext.NewGame.StopSong();
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

        private void UkryjPrzyciski() {
            button5.Visibility = Visibility.Hidden;
            button6.Visibility = Visibility.Hidden;
            button7.Visibility = Visibility.Hidden;
            button8.Visibility = Visibility.Hidden;
            button9.Visibility = Visibility.Hidden;
            button10.Visibility = Visibility.Hidden;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            newContext.GamePoints.PlayerOne++;
            UkryjPrzyciski();
        }

    }
}
