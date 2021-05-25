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
    /// Interaction logic for infoWin.xaml
    /// </summary>
    public partial class TraineeInfoWin : Window
    {
        Trainee trainee = new Trainee();
        public TraineeInfoWin(Trainee t)
        {
            trainee = t;
            InitializeComponent();
            initializeLists();
        }

        void initializeLists()
        {
            List<string> l1 = new List<string>();
            foreach (var i in MainWindow.mbl.TesterByCar())
            {
                l1.Add(i.Key.ToString() + ":");
                foreach (var t in i)
                {
                    l1.Add(t.FirstName + " " + t.LastName);
                }
            }
            TesterByCar.ItemsSource = l1;

            List<string> l2 = new List<string>();
            foreach (var i in MainWindow.mbl.traineeTests(trainee.ID))
            {
                l2.Add(i.Time.ToString());
            }
            Tests.ItemsSource = l2;

            AverageTest.Content = MainWindow.mbl.averageTraineeTests().ToString();
        }


        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
