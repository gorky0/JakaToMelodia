using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jtm
{
    public class Points:Property
    {
        public int StatusOne = 3;
        private int playerOne=0;
        public int PlayerOne
        {   get
            {
                return playerOne;
            }
            set
            {
                playerOne = value;
                OnPropertyChanged("PlayerOne");
            }
        }
        public int StatusTwo = 3;
        private int playerTwo=0;
        public int PlayerTwo
        {
            get
            {
                return playerTwo;
            }
            set
            {
                playerTwo = value;
                OnPropertyChanged("PlayerTwo");
            }
        }
        public int StatusThree = 3;
        private int playerThree=0;
        public int PlayerThree
        {
            get
            {
                return playerThree;
            }
            set
            {
                playerThree = value;
                OnPropertyChanged("PlayerThree");
            }
        }

        private int round = 1;
        public int Round
        {
            get
            {
                return Round;
            }
            set
            {
                Round = value;
                OnPropertyChanged("Round");
            }
        }


        public void ResetStatus() {
            StatusOne = 3;
            StatusTwo = 3;
            StatusThree = 3;
        }

    }
}
