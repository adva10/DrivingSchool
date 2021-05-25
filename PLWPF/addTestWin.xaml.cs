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
    /// Interaction logic for addTestWin.xaml
    /// </summary>
    public partial class addTestWin : Window
    {

        Trainee trainee = new Trainee();
        Test test;
        List<int> IdList = new List<int>();
        DateTime t;
        List<string> availableTesters = new List<string>();

        public addTestWin(Trainee t)
        {
            trainee = t;
            InitializeComponent();
            setComboBox();
            setAddr();
            testers.ItemsSource = availableTesters;
            stackPanel.DataContext = trainee;
        }

        void setAddr()
        {
            street.Text = trainee.Residence.street;
            city.Text = trainee.Residence.city;
            numOfBuilding.Text = trainee.Residence.bulidingNum.ToString();
        }


        void setComboBox()
        {
            //set hours
            for (int i = 9; i <= 15; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                hour.Items.Add(item);
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                test = new Test()
                {
                    TesterID = IdList[testers.SelectedIndex],
                    TraineeID = trainee.ID,
                    Time = t,
                    Start = (Address)Address.ConvertFromString(street.Text + " " + numOfBuilding.Text + " "+ city.Text),
                    Car = trainee.Car,
                };
                MainWindow.mbl.addTest(test);
                changeSchedule(test);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "",
                      MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }


        void changeSchedule(Test t) // updating the schedule of the  currrent tester 
        {
            Tester tester = MainWindow.mbl.GetTester(t.TesterID);
            tester.Schedule[t.Time.Hour - 9, (int)t.Time.DayOfWeek] = true;
            tester.StringSchedule = MainWindow.ConvertSchedualToString(tester.Schedule);
            MainWindow.mbl.updatingTester(tester);
        }
        private void Hour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Date.SelectedDate == null)
                {
                    MessageBox.Show("you havent fill the date", "",
                       MessageBoxButton.OK, MessageBoxImage.Error);
                    hour.SelectedIndex = -1;
                    return;
                }
                t = new DateTime(Date.SelectedDate.Value.Year, Date.SelectedDate.Value.Month, Date.SelectedDate.Value.Day, 9 + hour.SelectedIndex, 00, 00);
                List<Tester> l = MainWindow.mbl.closeTester(MainWindow.mbl.availableTesters(t), (Address)Address.ConvertFromString(street.Text + " " + numOfBuilding.Text + " " + city.Text));
                for(int i=0;i<l.Count;i++)
                {   
                    availableTesters.Add(l[i].FirstName + " " + l[i].LastName);
                    IdList.Add(l[i].ID);
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message , "",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void street_TextChanged(object sender, TextChangedEventArgs e)
        {
             MainWindow.check_no_Space(street.Text);
        }

        private void city_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow.check_no_Space(city.Text);
        }
    }
}
