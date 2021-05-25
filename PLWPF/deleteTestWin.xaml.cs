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
    /// Interaction logic for deleteTestWin.xaml
    /// </summary>
    public partial class deleteTestWin : Window
    {
        Trainee trainee ;
        Test test;

        public deleteTestWin(Test t, Trainee train)
        {
            trainee = train;
            test = t;
            InitializeComponent();
           
        }
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (test != null)
                {
                    MainWindow.mbl.deleteTest(test);
                }
                else
                {
                    MessageBox.Show("There is no test to delete", "",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "",
                      MessageBoxButton.OK, MessageBoxImage.Error);

            }
           
        }

    }
}
