using System.Windows;
namespace Jtm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player lol = new Player();
      
        public MainWindow()
        {
            //lol.PlayerInit();
            
          
           
            InitializeComponent();
            this.DataContext = lol;
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            lol.PlaySong();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            lol.StopSong();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.Items.Count > 0)
            {

                lol.StopSong();
                lol.ClosePlayer();
            }
            listBox.Items.Clear();
            lol.Browse();
            if (lol.Names != null)
            {
                for (int j = 0; j < lol.Names.Length; j++)
                {
                    listBox.Items.Add(lol.Names[j]);

                }
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            lol.Alert = +1;
            

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            lol.PauseSong();
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
            lol.NumberClicked = listBox.SelectedIndex;
           // lol.PlayerInit();

        }
    }
}
