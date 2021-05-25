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
    /// Interaction logic for TraineeWindow.xaml
    /// </summary>
    public partial class TraineeWindow : Window
    {
        Trainee trainee = new Trainee();
        Test test;

        public TraineeWindow(Trainee t)
        {
            trainee = t;
            test = MainWindow.mbl.closestTest(trainee.ID);
            InitializeComponent();
            StatusUpdate();
            DataContext = trainee;
        }

        void StatusUpdate()
        {
            bool s = MainWindow.mbl.pass(trainee);
            if(s)
            {

                Status.Content = "Pass";
            }
            else if(test != null)
            {
                Status.Content = "The closest test:\n" + test.Time;
            }
            else
            {
                Status.Content = "Didnt pass";
            }
        }


        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateTraineeWin testerWin = new UpdateTraineeWin(trainee);
            testerWin.Show();
        }

        private void Statistics_Button_Click(object sender, RoutedEventArgs e)
        {
            TraineeInfoWin Win = new TraineeInfoWin(trainee);
            Win.Show();
        }

        private void deleteTest_Button_Click(object sender, RoutedEventArgs e)
        {
            deleteTestWin Win = new deleteTestWin(test,trainee);
            Win.Show();
            Status.Content = "Didnt pass";
        }

        private void addTest_Button_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.mbl.pass(trainee))
            {
                MessageBox.Show("you already pass the test :)", "",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            addTestWin Win = new addTestWin(trainee);
            Win.Show();
        }

        private void SignOut_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Win = new MainWindow();
            Win.Show();
            this.Close();
        }
    }
}
