using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;

namespace Jtm
{
    public class Player:Property
    {
        //Uri uri = new Uri(@"C:\Users\Gorky\Documents\Visual Studio 2015\Projects\Jtm\Jtm\bin\Debug\myfile.mp3");
        Uri uri; 
        MediaPlayer player = new MediaPlayer();
        private int _alert;
        private String[] files;
        private String[] allFiles;
        private String[] names;
        private int numberclicked;
        public int NumberClicked
        {
            get { return numberclicked; }
            set { numberclicked = value; }
        }
        public String[] Names
        {
            get
            {
                return names;
            }
            set
            {
                names = value;
                //OnPropertyChanged("Names");

            }

        }
       
        public int Alert
        {
            get
            {
                return _alert;
            }
            set
            {
                _alert = value;
                OnPropertyChanged("Alert");

            }

        }

        //public object DataContext { get; private set; }
        

        public void PlayerInit()
        {

            if (NumberClicked != -1)
            {
                uri = new Uri(allFiles[NumberClicked]);
                player.Open(uri);
            }

        }

        public  void PlaySong() {
            
            player.Play();

        }
        public void StopSong()
        {

            player.Stop();

        }
        public void ClosePlayer()
        {

            player.Close();

        }
        public void PauseSong()
        {

            player.Pause();

        }
        public static string Odwroc(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }




        public virtual void Browse()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                
                allFiles = Directory.GetFiles(fbd.SelectedPath);
                files = Directory.GetFiles(fbd.SelectedPath);
                for (int i = 0; i < files.Length; i++)
                {
                    
                    

                        files[i] = files[i].Substring(0, files[i].LastIndexOf('.'));

                    
                }
               
                names = files;

                Alert = files.Length;

            }
            if (files != null && names!=null)
            {
                MakeNames();
            }


        }

        private void MakeNames()
        {
            
            for (int j = 0; j < files.Length; j++)
            {
                String strink = Odwroc(files[j]);
                for (int i = 0; i < strink.Length; i++)
                {
                    if (strink[i] == '\\')
                    {
                        Names[j] = strink.Remove(i);
                        break;
                    }

                }


            }

            for (int j = 0; j < Names.Length; j++)
            {
                Names[j] = Odwroc(Names[j]);

            }
        }

        


    }
}
