using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DS;

namespace DAL
{

    class Dal_imp : Idal
    {
        
        public void addTest(Test t)
        { 
            t.Code = Configuration.runCode;
            Configuration.runCode++;
            DataSource.Tests.Add(t); 
        }

        public void addTester(Tester t)
        {
            if (DataSource.Testers.Exists(s => s.ID == t.ID))
            {
                throw new Exception("DAL: The tester already exits in the system");
            }

            DataSource.Testers.Add(t);
        }

        public void addTrainee(Trainee t)
        {
            if (DataSource.Trainees.Exists(s => s.ID == t.ID))
            {
                throw new Exception("DAL: The trainee already exits in the system");
            }
            DataSource.Trainees.Add(t);
        }


        public void deleteTest(Test t)
        {
            if (!DataSource.Tests.Remove(t))
            {
                throw new Exception("DAL: The test is not exits in the system");
            }
        }



        public void deleteTester(Tester t)
        {
            if (!DataSource.Testers.Remove(t))
            {
                throw new Exception("DAL: The tester is not exits in the system");
            }
        }

        public void deleteTrainee(Trainee t)
        {
            if (!DataSource.Trainees.Remove(t))
            {
                throw new Exception("DAL: The trainee is not exits in the system");
            }
        }

        public IEnumerable<Tester> testersList()
        {
            List<Tester> copyTesters = new List<Tester>(DataSource.Testers);
            return copyTesters;
        }

        public IEnumerable<Test> testsList()
        {
            List<Test> copyTests = new List<Test>(DataSource.Tests);
            return copyTests;
        }

        public IEnumerable<Trainee> traineesList()
        {
           List<Trainee> copyTrainees = new List<Trainee>(DataSource.Trainees);
            return copyTrainees;
        }

        public void updatingTest(Test t)
        {
            if (!DataSource.Tests.Exists(item => t.Code == item.Code))
            {
                throw new Exception("DAL : test dosent exists");
            }
            var index = DataSource.Tests.FindIndex(c => c.Code == t.Code);
            DataSource.Tests[index] = t;
        }

        public void updatingTester(Tester t)
        {
            if(! DataSource.Testers.Exists(item => t.ID == item.ID))
            {
                throw new Exception("DAL : tester dosent exists");
            }
            var index = DataSource.Testers.FindIndex(c => c.ID == t.ID);
            DataSource.Testers[index] = t;
        }

        public void updatingTrainee(Trainee t)
        {
            if (!DataSource.Trainees.Exists(item => t.ID == item.ID))
            {
                throw new Exception("DAL : trainee dosent exists");
            }
            var index = DataSource.Trainees.FindIndex(c => c.ID == t.ID);
            DataSource.Trainees[index] = t;
        }

        //adding
        public Trainee GetTrainee(int id)
        {
            foreach (Trainee item in traineesList())
            {
                if (id == item.ID)
                {
                    return item;
                }
            }
            return null;
        }

        //adding
        public Tester GetTester(int id)
        {
            foreach (Tester item in testersList())
            {
                if (id == item.ID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
