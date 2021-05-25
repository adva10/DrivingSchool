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
    /// Interaction logic for UpdateTraineeWin.xaml
    /// </summary>
    public partial class UpdateTraineeWin : Window
    {
        Trainee trainee = new Trainee();

        public UpdateTraineeWin(Trainee t)
        {
            trainee = t;
            InitializeComponent();
            InitializeResidence();
            DataContext = trainee;
        }

        void InitializeResidence()
        {
            Street.Text = trainee.Residence.street;
            NumBuild.Text = trainee.Residence.bulidingNum.ToString();
            City.Text = trainee.Residence.city;
        }

        CarType carType()
        {
            if (Car.SelectedIndex == 3)
            {
                return BE.CarType.heavyTruck;
            }
            if (Car.SelectedIndex == 1)
            {
                return BE.CarType.twoWheeledVehicles;
            }
            if (Car.SelectedIndex == 2)
            {
                return BE.CarType.mediumTruck;
            }
            else //default would be private car
            {
                return BE.CarType.privateCar;
            }
        }

        public GearBoxType gearBoxChoice()
        {
            if (GearBox.SelectedIndex == 0)
            {
                return GearBoxType.automatic;
            }
            else
            {
                return GearBoxType.manual;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            trainee.School = School.Text;

            trainee.Teacher = Teacher.Text;

            if (MainWindow.IsDigitsOnly(numLessons.Text.ToString()))
            {
                trainee.NumOfLessons = Int32.Parse(numLessons.Text.ToString());
            }
            else
            {
                MessageBox.Show("number of lesson should be a number", "",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Car.SelectedIndex != -1)
            {
                trainee.Car = carType();
            }
            if (GearBox.SelectedIndex != -1)
            {
                trainee.GearBox = gearBoxChoice();
            }
            trainee.Residence.street = Street.Text;

            if (MainWindow.IsDigitsOnly(NumBuild.Text.ToString()))
            {
                trainee.Residence.bulidingNum = Int32.Parse(NumBuild.Text);
            }
            else
            {
                MessageBox.Show("number of building should be a number", "",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }


            trainee.Residence.city = City.Text;



            MainWindow.mbl.updatingTrainee(trainee);


            //now back to traineeWin
            this.Close();
        }

        private void School_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Teacher_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void numLessons_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Street_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.check_no_Space(Street.Text);
        }


        private void numBuild_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void City_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.check_no_Space(City.Text);
        }
    }
}
