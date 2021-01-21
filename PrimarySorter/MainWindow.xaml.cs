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
 private string Uloha1Sync()
        {
            //tb1Out.Clear();
            //int max = Convert.ToInt32(tb1Max.Text);
            //int min = Convert.ToInt32(tb1Min.Text);
            int max = 20;
            int min = 1;
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

                       
                        return item.ToString();

                    }

                }
            }
            return null;

        }
        private string Uloha2Sync()
        {
            //tb2Out.Clear();
            //int delka = Convert.ToInt32(tb2Max.Text);
            //char num = Convert.ToChar(tb2Num.Text);
            int delka = 20;
            char num = '1';
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
                        return item.ToString();


                    }


                }

            }
            return null;

        }

        private async void AsyncButt_Click(object sender, RoutedEventArgs e)
        {
            List<Task<string>> myTasks = new List<Task<string>>();
            Task<string> task1 = new Task<string>(Uloha1Sync);
            task1.Start();
            tb1Out.Text += await task1;
            Task<string> task2 = new Task<string>(Uloha2Sync);
            task2.Start();
            tb2Out.Text = await task2;

        }
    }
}