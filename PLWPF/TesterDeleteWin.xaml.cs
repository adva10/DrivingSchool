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
using System.Windows.Shapes;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TesterDeleteWin.xaml
    /// </summary>
    public partial class TesterDeleteWin : Window
    {
        Tester testerToDelete = new Tester();
        public TesterDeleteWin(Tester t)
        {
            testerToDelete = t;
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (testerToDelete != null)
                {
                    MainWindow.mbl.deleteTester(testerToDelete);
                }
                else
                {
                    MessageBox.Show("There is no tester to delete", "",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "",
                      MessageBoxButton.OK, MessageBoxImage.Error);

            }
            returnToMainWin();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            returnToMainWin();
        }

        private void returnToMainWin()
        {
            MainWindow Win = new MainWindow();
            Win.Show();
            this.Close();
        }

    }
}
