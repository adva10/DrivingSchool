using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using System.Linq;

namespace BL
{
    public interface IBL
    {
        void addTester(Tester t);
        void deleteTester(Tester t);
        void updatingTester(Tester t);

        void addTrainee(Trainee t);
        void deleteTrainee(Trainee t);
        void updatingTrainee(Trainee t);

        void addTest(Test t);
        void deleteTest(Test t);
        void updatingTest(Test t);

        IEnumerable<Tester> testersList();
        IEnumerable<Trainee> traineesList();
        IEnumerable<Test> testsList();

        List<IGrouping<CarType, Tester>> TesterByCar(bool flag = false);
        List<IGrouping<string, Trainee>> TraineeBySchool(bool flag = false);
        List<IGrouping<string, Trainee>> TraineeByTeacher(bool flag = false);
        List<IGrouping<int, Trainee>> TraineeByNumTests(bool flag = false);

        int numTesterTests(Tester t); //number of tests that the trainee did - addition
        int numTraineeTests(Trainee t); //number of tests that the trainee did

        bool pass(Trainee t); //there is a test that the trainee passed - he can get a licence

        List<Tester> closeTester(List<Tester> testersToCheck, Address adr);//return a list of all the teseters that live x kilometers from adr
        List<Tester> availableTesters(DateTime t);
        List<Test> testsByRequest(Func<Test,bool> condition);
        List<Test> testsByDay(DateTime day);
        List<Test> testsByMonth(DateTime month);

        int numOfPassedcCriteria(Test t);//counting the number of criteria that the trainee passed - addinition

        List<Test> testerTests(int id); //return a list of all tests of a specific tester - addition
        List<Test> traineeTests(int id); //return a list of all tests of a specific trainee - addition
        List<Trainee> testerTrainees(Tester t); //return a list of all trainees of a specific tester - addition
        int averageTraineeTests(); //calculate the average of trainee tests - addition

        Trainee GetTrainee(int id);
        Tester GetTester(int id);

       //return the current trainee test
        Test closestTest(int id);
    }
}
