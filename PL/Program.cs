using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace PL
{
    class Program
    {
        static IBL mbl = (BLFactory.GetBLFactory()).GetBl();

        static void Main(string[] args)
        {
            try
            {
                
                Tester tester = new Tester() { ID = 123, LastName = "cohen", FirstName = "sharon", Gender = Gender.female, BirthDate = new DateTime(1960, 2, 1), Car = CarType.privateCar, MaxTestsAWeek = 10 };
                // Console.WriteLine(tester);

                mbl.addTester(tester);
                Console.WriteLine("LOG: create a tester");
                Trainee trainee = new Trainee() { ID = 234, LastName = "shimoni", FirstName = "tal", BirthDate = new DateTime(2000, 2, 1), Car = CarType.privateCar, GearBox = GearBoxType.manual, School = "rashi", Teacher = "slomit", NumOfLessons = 30 };
                Trainee trainee2 = new Trainee() { ID = 134, LastName = "shimoni", FirstName = "tal", BirthDate = new DateTime(2000, 2, 1), Car = CarType.privateCar, GearBox = GearBoxType.manual, School = "rashi", Teacher = "slomit", NumOfLessons = 30 };
                Console.WriteLine("LOG: create a trainee");
                Test test = new Test() { TesterID = 123, TraineeID = 234, Time = new DateTime(2019, 01, 1, 13, 00, 00), Car = CarType.privateCar };
                Test same_date_test2 = new Test() { TesterID = 123, TraineeID = 134, Time = new DateTime(2019, 01, 1, 13, 00, 00), Car = CarType.privateCar };
                Console.WriteLine("LOG: create a test");
                mbl.addTester(tester);
                Console.WriteLine("LOG: add Tester");
                mbl.addTrainee(trainee);
                Console.WriteLine("LOG: add Trainnee");
                mbl.addTrainee(trainee2);
                mbl.addTest(test);
                Console.WriteLine("LOG: add Test");
                test.LookingTheMirrors = true;
                mbl.updatingTest(test);
                Console.WriteLine("***");
                //Console.WriteLine("LOG: updating Test");
                //mbl.deleteTester(tester);
                mbl.addTest(same_date_test2);
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
