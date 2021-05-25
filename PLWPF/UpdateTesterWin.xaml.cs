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
    /// Interaction logic for UpdateTesterWin.xaml
    /// </summary>
    public partial class UpdateTesterWin : Window
    {
        Tester tester = new Tester();
        public UpdateTesterWin(Tester t)
        {
            tester = t;
            InitializeComponent();
            InitializeResidence();
            DataContext = tester;
        }

        void InitializeResidence()
        {
            Street.Text = tester.Residence.street;
            NumBuild.Text = tester.Residence.bulidingNum.ToString();
            City.Text = tester.Residence.city;
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            tester.MaxTestsAWeek = Int32.Parse(PhoneNumber.Text);
            tester.PhoneNumber = Int32.Parse(PhoneNumber.Text);
            tester.Residence.street = Street.Text;
            tester.Residence.city = City.Text;
            tester.Residence.bulidingNum = Int32.Parse(NumBuild.Text);
            tester.experience = Int32.Parse(experience.Text);


            try
            {
                MainWindow.mbl.updatingTester(tester);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "",
                      MessageBoxButton.OK, MessageBoxImage.Error);

            }
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

        private void Street_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.check_no_Space(Street.Text);
        }
        
        private void NumBuild_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void City_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.check_no_Space(City.Text);
        }

        private void experience_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void MaxTestAWeek_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
