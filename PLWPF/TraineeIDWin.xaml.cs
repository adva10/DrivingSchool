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
    /// Interaction logic for TraineeIDWin.xaml
    /// </summary>
    public partial class TraineeIDWin : Window
    {
        Tester tester = new Tester();

        public TraineeIDWin(Tester t)
        {
            tester = t;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TraineeID.Text == "")
            {
                MessageBox.Show("Please enter the Trainee ID", "",
                      MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Trainee trainee = MainWindow.mbl.GetTrainee(Int32.Parse(TraineeID.Text));
           
            if (trainee == null)
            {
                MessageBox.Show("Trainee ID doesnt exit in the system", "",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                TesterWindow Win = new TesterWindow(tester);
                Win.Show();
                this.Close();
                return;
            }


            Test testToUpdate = MainWindow.mbl.closestTest(trainee.ID);
            if (testToUpdate == null)
            {
                
                MessageBox.Show("There is no current test to this trainee", "",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                TesterWindow Win = new TesterWindow(tester);
                Win.Show();
                this.Close();
                return;
            }
            else
            {
                StartTestWin Win = new StartTestWin(testToUpdate,tester);
                Win.Show();
                this.Close();
            }
        }

        private void TraineeID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
