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
    /// Interaction logic for TraineeDeleteWin.xaml
    /// </summary>
    public partial class TraineeDeleteWin : Window
    {
        Trainee traineeToDelete = new Trainee();
        public TraineeDeleteWin(Trainee t)
        {
            traineeToDelete = t;
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (traineeToDelete != null)
                {
                    MainWindow.mbl.deleteTrainee(traineeToDelete);
                }
                else
                {
                    MessageBox.Show("There is no trainee to delete", "",
                           MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
