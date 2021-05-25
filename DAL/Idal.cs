using System;
using System.Collections.Generic;
using System.Text;
using BE;

namespace DAL
{
    public interface Idal
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

        Trainee GetTrainee(int id);
        Tester GetTester(int id);

       IEnumerable<Tester> testersList();
       IEnumerable<Trainee> traineesList();
       IEnumerable<Test> testsList();
    }
}