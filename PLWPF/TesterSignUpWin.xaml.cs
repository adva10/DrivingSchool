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
    /// Interaction logic for testerSignUpWin.xaml
    /// </summary>
    public partial class TesterSignUpWin : Window
    {
        public TesterSignUpWin()
        {
            InitializeComponent();
            set_date();
        }

        void set_date()
        {
            //set years
            int currentYear = 2019;
            for (int i = 1920; i <= currentYear; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                year.Items.Add(item);
            }

            //set months
            for (int i = 1; i < 13; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                month.Items.Add(item);
            }

            //set days
            for (int i = 1; i < 32; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                day.Items.Add(item);
            }

        }

        Gender genderType()
        {
            if (Gender.SelectedIndex == 0)
            {
                return BE.Gender.female;
            }
            else
            {
                return BE.Gender.male;
            }
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

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            Tester tester = new Tester()
            {
                ID = Int32.Parse(Id.Text.ToString()),
                FirstName = FirstName.Text.ToString(),
                LastName = LastName.Text.ToString(),
                BirthDate = new DateTime(Int32.Parse(year.Text), Int32.Parse(month.Text), Int32.Parse(day.Text)),
                Gender = genderType(),
                PhoneNumber = Int32.Parse(PhoneNumber.Text),
                Residence = new Address() { street = Street.Text.ToString(), bulidingNum = Int32.Parse(NumBuild.Text), city = City.Text.ToString() },
                Car = carType(),
                experience = Int32.Parse(experience.Text.ToString()),
                MaxTestsAWeek = Int32.Parse(MaxTestAWeek.Text.ToString()),
            };
            try
            {
                MainWindow.mbl.addTester(tester);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "",
                      MessageBoxButton.OK, MessageBoxImage.Error);

            }
            MainWindow Win = new MainWindow();
            Win.Show();
            this.Close();

        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MaxTestAWeek_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!MainWindow.IsDigitsOnly(experience.Text.ToString()))
            {
                MessageBox.Show("please enter a number", "",
                      MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

     

        private void experience_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!MainWindow.IsDigitsOnly(experience.Text.ToString()))
            {
                MessageBox.Show("please enter a number", "",
                      MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow Win = new SignUpWindow();
            Win.Show();
            this.Close();
        }

        private void Street_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.check_no_Space(Street.Text);
        }

        private void City_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.check_no_Space(City.Text);
        }

        private void NumBuild_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
