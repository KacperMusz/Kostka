using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Kostka
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();
        private int suma = 0;
        private int wynikGry = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Reset(object sender, EventArgs e)
        {
            GameResultLabel.Text = "Wynik gry: 0";
            RollResultLabel.Text = " Wynik tego Losowania: 0";
            Dice1.Source = "question.jpg";
            Dice2.Source = "question.jpg";
            Dice3.Source = "question.jpg";
            Dice4.Source = "question.jpg";
            Dice5.Source = "question.jpg";

        }

        private void RollDice(object sender, EventArgs e)
        {
            Dictionary<int, int> wynikKostek = new Dictionary<int, int>();
            int[] rols = new int[5];
            suma = 0;
            for(int i = 0; i < 5; i++)
            {
                rols[i] = random.Next(1, 6);
                suma += rols[i];

                if (wynikKostek.ContainsKey(rols[i]))
                {
                    wynikKostek[rols[i]]++;
                }
                else
                {
                    wynikKostek[rols[i]] = 1;
                }
            }

            Dice1.Source = "k" + rols[0] + ".jpg";
            Dice2.Source = "k" + rols[1] + ".jpg";
            Dice3.Source = "k" + rols[2] + ".jpg";
            Dice4.Source = "k" + rols[3] + ".jpg";
            Dice5.Source = "k" + rols[4] + ".jpg";

            RollResultLabel.Text = "Wynik tego losowania: " + suma;
            
            foreach(var entry in wynikKostek)
            {
                int oczka = entry.Key;
                int iloscPowtorzen = entry.Value;

                if(iloscPowtorzen > 1)
                {
                    wynikGry += oczka * iloscPowtorzen;
                }
            }
            GameResultLabel.Text = "Wynik gry: " + wynikGry;
            
        }
    }
}
