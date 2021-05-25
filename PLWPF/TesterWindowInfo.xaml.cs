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
using System.Threading;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TesterWindowInfo.xaml
    /// </summary>
    public partial class TesterWindowInfo : Window
    {
        Tester tester;

        public TesterWindowInfo(Tester t)
        {
            tester = t;
            InitializeComponent();
            initializeLists();
        }


        void initializeLists()
        {
            List<string> l1 = new List<string>();
            foreach (var i in MainWindow.mbl.testerTests(tester.ID))
            {
                l1.Add(i.Time + " \n" + i.Start);
            }
            AllTests.ItemsSource = l1;

            List<string> l2 = new List<string>();
            foreach (var i in MainWindow.mbl.testsByDay(DateTime.Now))
            {
                if (i.TesterID == tester.ID)
                {
                    l2.Add(i.Time + " \n" + i.Start);
                }
            }
            TestsToday.ItemsSource = l2;

            List<string> l3 = new List<string>();
            foreach (var i in MainWindow.mbl.testsByMonth(DateTime.Now))
            {
                if (i.TesterID == tester.ID)
                {
                    l3.Add(i.Time + " \n" + i.Start);
                }
            }
            TestsThisMonth.ItemsSource = l3;

            List<string> l4 = new List<string>();
            foreach (var i in MainWindow.mbl.TraineeBySchool())
            {
                l4.Add(i.Key.ToString() + ":");
                foreach (var t in i)
                {
                    l4.Add(t.FirstName + " " + t.LastName);
                }
            }
            TraineeBySchool.ItemsSource = l4;


            List<string> l5 = new List<string>();
            foreach (var i in MainWindow.mbl.TraineeByTeacher())
            {
                l5.Add(i.Key.ToString() + ":");
                foreach (var t in i)
                {
                    l5.Add(t.FirstName + " " + t.LastName);
                }
            }
            TraineeByTeacher.ItemsSource = l5;

            List<string> l6 = new List<string>();
            foreach (var i in MainWindow.mbl.TraineeByNumTests())
            {
                l6.Add(i.Key.ToString() + ":");
                foreach (var t in i)
                {
                    l6.Add(t.FirstName + " " + t.LastName);
                }
            }
            TraineeByNumTests.ItemsSource = l6;



        }
    }
}
