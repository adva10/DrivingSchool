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
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TesterWindow.xaml
    /// </summary>
    public partial class TesterWindow : Window
    {
        Tester t = new Tester();

        public TesterWindow(Tester tester)
        {
            t = tester;
            InitializeComponent();
            stackPanel.DataContext = t;
            buildSchedule(t);
        }

        void buildSchedule(Tester t)
        {
            a00.Text = checkFree(t.Schedule[0, 0]);
            a01.Text = checkFree(t.Schedule[0, 1]);
            a02.Text = checkFree(t.Schedule[0, 2]);
            a03.Text = checkFree(t.Schedule[0, 3]);
            a04.Text = checkFree(t.Schedule[0, 4]);
            a10.Text = checkFree(t.Schedule[1, 0]);
            a11.Text = checkFree(t.Schedule[1, 1]);
            a12.Text = checkFree(t.Schedule[1, 2]);
            a13.Text = checkFree(t.Schedule[1, 3]);
            a14.Text = checkFree(t.Schedule[1, 4]);
            a20.Text = checkFree(t.Schedule[2, 0]);
            a21.Text = checkFree(t.Schedule[2, 1]);
            a22.Text = checkFree(t.Schedule[2, 2]);
            a23.Text = checkFree(t.Schedule[2, 3]);
            a24.Text = checkFree(t.Schedule[2, 4]);
            a30.Text = checkFree(t.Schedule[3, 0]);
            a31.Text = checkFree(t.Schedule[3, 1]);
            a32.Text = checkFree(t.Schedule[3, 2]);
            a33.Text = checkFree(t.Schedule[3, 3]);
            a34.Text = checkFree(t.Schedule[3, 4]);
            a40.Text = checkFree(t.Schedule[4, 0]);
            a41.Text = checkFree(t.Schedule[4, 1]);
            a42.Text = checkFree(t.Schedule[4, 2]);
            a43.Text = checkFree(t.Schedule[4, 3]);
            a44.Text = checkFree(t.Schedule[4, 4]);
            a50.Text = checkFree(t.Schedule[5, 0]);
            a51.Text = checkFree(t.Schedule[5, 1]);
            a52.Text = checkFree(t.Schedule[5, 2]);
            a53.Text = checkFree(t.Schedule[5, 3]);
            a54.Text = checkFree(t.Schedule[5, 4]);
        }

        string checkFree(bool b)
        {
            if(b)
            {
                return "Taken";
            }
            return "Free";
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateTesterWin Win = new UpdateTesterWin(t);
            Win.Show();
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            TesterWindowInfo Win = new TesterWindowInfo(t);
            Win.Show();
        }

        private void Start_Test_Click(object sender, RoutedEventArgs e)
        {
            TraineeIDWin Win = new TraineeIDWin(t);
            Win.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Win = new MainWindow();
            Win.Show();
            this.Close();
        }
    }
}
