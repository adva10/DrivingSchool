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
    /// Interaction logic for StartTestWin.xaml
    /// </summary>
    public partial class StartTestWin : Window

    {
        Test testToUpdate = new Test();
        Tester testerObj = new Tester();

        public StartTestWin(Test test, Tester tester)
        {
            testerObj = tester;
            testToUpdate = test;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SaveDistance.IsChecked == true)
            {
                testToUpdate.SaveDistance = true;
            }
            if (ReverseParking.IsChecked == true)
            {
                testToUpdate.ReverseParking = true;
            }
            if (LookingTheMirror.IsChecked == true)
            {
                testToUpdate.LookingTheMirrors = true;
            }
            if (Signaling.IsChecked == true)
            {
                testToUpdate.Signaling = true;
            }
            if (StayInPath.IsChecked == true)
            {
                testToUpdate.StayInPath = true;
            }
            if (DrivingOnRight.IsChecked == true)
            {
                testToUpdate.DrivingOnRight = true;
            }
            if (WheelControl.IsChecked == true)
            {
                testToUpdate.WheelControl = true;
            }
            if (RightUseOfGeer.IsChecked == true)
            {
                testToUpdate.RightUseOfGeer = true;
            }
            try
            {
                MainWindow.mbl.updatingTest(testToUpdate);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "",
                      MessageBoxButton.OK, MessageBoxImage.Error);

            }
            TesterWindow Win = new TesterWindow(testerObj);
            Win.Show();
            this.Close();
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_4(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_5(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_6(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_7(object sender, RoutedEventArgs e)
        {

        }

        private void pass_Checked(object sender, RoutedEventArgs e)
        {
            if (pass.IsChecked == true)
            {
                notPass.IsChecked = false;
            }

            testToUpdate.Grade = true;
        }

        private void notPass_Checked(object sender, RoutedEventArgs e)
        {
            if (notPass.IsChecked == true)
            {
                pass.IsChecked = false;
            }
            testToUpdate.Grade = false;
        }
    }
}
