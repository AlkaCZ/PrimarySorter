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
            if (num == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
          
        }


        private void Uloha1_Click(object sender, RoutedEventArgs e)
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
            char num = Convert.ToChar(tb2Num.Text);
            int[] poleU2 = new int[delka + 1];
            for (int i = 0; i < delka + 1; i++)
            {
                poleU2[i] = i;
            }
            foreach (int item in poleU2)
            {
                if (chkprime(item))
                {
                    char[] itemArray2 = item.ToString().ToCharArray();

                    if (itemArray2.Contains(num))
                    {
                            tb2Out.Text += item.ToString();
                            tb2Out.Text += " ";

                    }
                    

                }
               
            }
            

        }
 private string Uloha1Sync(string max, string min)
        {
            int maxI = Convert.ToInt32(max);
            int minI = Convert.ToInt32(max);
            if (minI > maxI)
            {
                MessageBox.Show("Minimální hodnota je větší než maximální", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int delka = maxI - minI;
                int[] prim = new int[delka + 1];
                for (int i = 0; i < delka + 1; i++)
                {
                    prim[i] = minI + i;
                }
                foreach (int item in prim)
                {

                    if (chkprime(item))
                    {

                       
                        return item.ToString();


                    }


                }
                return null;
            }
            return null;
        }

        private async void AsyncButt_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => Uloha1Sync(tb1Max.Text, tb1Min.Text));
        }
    }
}