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
using System.ComponentModel;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static IBL mbl = (BLFactory.GetBLFactory()).GetBl();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void initializeScedule(Tester t)
        {
            foreach (Test u in mbl.testerTests(t.ID))
            {
                if (DatesAreInTheSameWeek(DateTime.Now, u.Time))
                {
                    t.Schedule[u.Time.Hour - 9, (int)u.Time.DayOfWeek] = true;
                }
                else
                {
                    t.Schedule[u.Time.Hour - 9, (int)u.Time.DayOfWeek] = false;
                }
            }
            t.StringSchedule = ConvertSchedualToString(t.Schedule);
            mbl.updatingTester(t);
        }



        public static string ConvertSchedualToString(bool[,] schedule)
        {
            string strSchedule = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (schedule[j, i])
                    {
                        strSchedule += "T";
                    }
                    else
                    {
                        strSchedule += "F";
                    }
                    strSchedule += ",";
                }
                strSchedule = strSchedule.Remove(strSchedule.Length - 1, 1) + "\n";
            }
            return strSchedule;
        }

        public static bool[,] ConvertSchedualFromString(string s)
        {
            bool[,] schedule = new bool[6, 5];
            string[] days = s.Split('\n');
            for (int i = 0; i < 5; i++)
            {
                string[] hours = days[i].Split(',');
                for (int j = 0; j < 6; j++)
                {
                    if (hours[j] == "T")
                    {
                        schedule[j, i] = true;
                    }
                    if (hours[j] == "F")
                    {
                        schedule[j, i] = false;
                    }
                }

            }
            return schedule;
        }
        private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));
            return d1 == d2;
        }



        private void TraineeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (TraineeCheckBox.IsChecked == true)
            {
                TesterCheckBox.IsChecked = false;
            }
        }

        private void TesterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (TesterCheckBox.IsChecked == true)
            {
                TraineeCheckBox.IsChecked = false;
            }
        }

        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsDigitsOnly(IdTextBox.Text))
            {
                MessageBox.Show("The ID Should be a number", "",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                IdTextBox.Text = "";
            }
        }

        public static void check_no_Space(String s)
        {
            if (s.Contains(" "))
            {
                MessageBox.Show("The name cant contain spaces put '-' instead ", "",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                s = "";
            }
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                MessageBox.Show("Please enter your ID", "",
                      MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (TesterCheckBox.IsChecked == true)
            {
                Tester tester = mbl.GetTester(Int32.Parse(IdTextBox.Text));
                if (tester == null)
                {
                    MessageBox.Show("Tester ID doesnt exit in the system, try again", "",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    IdTextBox.Text = "";
                }
                else
                {
                    initializeScedule(tester);
                    TesterWindow testerWin = new TesterWindow(tester);
                    testerWin.Show();
                    this.Close();
                }
            }
            else if (TraineeCheckBox.IsChecked == true)
            {
                Trainee trainee = mbl.GetTrainee(Int32.Parse(IdTextBox.Text));
                if (trainee == null)
                {
                    MessageBox.Show("Trainee ID doesnt exit in the system, try again", "",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    TraineeWindow traineeWin = new TraineeWindow(trainee);
                    traineeWin.Show();
                    this.Close();
                }
                IdTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("One of the fields missing ", "",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow Win = new SignUpWindow();
            Win.Show();
            this.Close();
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                MessageBox.Show("Please enter the user id to remove", "",
                      MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (TesterCheckBox.IsChecked == true)
            {
                Tester tester = mbl.GetTester(Int32.Parse(IdTextBox.Text));
                if (tester == null)
                {
                    MessageBox.Show("Tester ID doesnt exit in the system, try again", "",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    IdTextBox.Text = "";
                }
                else
                {
                    TesterDeleteWin testerWin = new TesterDeleteWin(tester);
                    testerWin.Show();
                    this.Close();
                }
            }
            else if (TraineeCheckBox.IsChecked == true)
            {
                Trainee trainee = mbl.GetTrainee(Int32.Parse(IdTextBox.Text));
                if (trainee == null)
                {
                    MessageBox.Show("Trainee ID doesnt exit in the system, try again", "",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    TraineeDeleteWin traineeWin = new TraineeDeleteWin(trainee);
                    traineeWin.Show();
                    this.Close();
                }
                IdTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("One of the fields missing ", "",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
