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

namespace PrimarySorter
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static bool chkprime(int num)
        {
            for (int i = 2; i < num; i++)
                if (num % i == 0)
                    return false;
            return true;
        }
        public int[] CreatePole(int min, int max)
        {

            int delka = max - min;
            int[] pole = new int[delka];
            for (int i = 0; i < delka; i++)
            {
                pole[i] = min + 1;
            }
            return pole;
  
        }
        //public async static Task<int> ShowPrimes()
        //{

        //}
        private  void Uloha1_Click(object sender, RoutedEventArgs e)
        {
            tb1Out.Clear();
            int max = Convert.ToInt32(tb1Max.Text);
            int min = Convert.ToInt32(tb1Min.Text);
            if (min > max)
            {
                MessageBox.Show("Minimální hodnota je větší než maximální", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int delka = max - min;
                int[] prim = new int[delka + 1];
                for (int i = 0; i < delka + 1; i++)
                {
                    prim[i] = min + i;
                }
                foreach (int item in prim)
                {

                    if (chkprime(item))
                    {
                        tb1Out.Text += (" ");
                        tb1Out.Text += item.ToString();
                    }

                }
            }


        }

        private void Uloha2_Click(object sender, RoutedEventArgs e)
        {
            tb2Out.Clear();
            int delka = Convert.ToInt32(tb2Max.Text);
            int Num = Convert.ToInt32(tb2Num.Text);
            int[] poleU2 = new int[delka + 1];
            for (int i = 0; i < delka + 1; i++)
            {
                poleU2[i] = i;
            }
            foreach (int item in poleU2)
            {
                if (chkprime(item))
                {
                    char[] test = new char[5];
                    test[0] = (char)item;
                    for (int i = 0; i < 5; i++)
                    {
                        if (test[i] == Num)
                        {
                            tb2Out.Text += item.ToString();
                            //test[]
                        }
                    }


                }
            }

        }
    }
}