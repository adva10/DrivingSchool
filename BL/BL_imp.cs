using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Net;
using System.Xml;
using BE;
using DAL;
using System.Threading;

namespace BL
{
    class BL_imp : IBL
    {
        public void addTester(Tester t)
        {
            if (t.ID == 0)
            {
                throw new Exception("BL: the tester id is missing");
            }
            if (t.LastName == null || t.FirstName == null)
            {
                throw new Exception("BL: the tester Last or First Name is missing");
            }
            if (DateTime.Now.Year - t.BirthDate.Year < Configuration.minTesterAge)
            {
                throw new Exception("BL: the tester age got to be 40 and above");
            }
            if (t.BirthDate == default(DateTime))
            {
                throw new Exception("BL: the tester Birthdate is missing");
            }
            FactoryDal.GetInstance().getDal().addTester(t);
        }
        public void deleteTester(Tester t)
        {
            FactoryDal.GetInstance().getDal().deleteTester(t);
        }
        public void updatingTester(Tester t)
        {
            if (!testersList().ToList().Exists(item => t.ID == item.ID && item.BirthDate == t.BirthDate))
            {
                throw new Exception("DAL : tester dosent exists");
            }
            FactoryDal.GetInstance().getDal().updatingTester(t);
        }

        public void updatingTest(Test t)
        {
            if (!testsList().ToList().Exists(item => t.Code == item.Code && t.TesterID == item.TesterID && t.TraineeID == item.TraineeID && t.Car == item.Car && t.Time == item.Time))
            {
                throw new Exception("BL: the test does not exist");
            }
            if ((float)(numOfPassedcCriteria(t) / (float)Configuration.numOfCriteria) < 0.5 && t.Grade)
            {
                throw new Exception(" BL: The trainee cant pass - more than half of criteria didnt pass");
            }
            FactoryDal.GetInstance().getDal().updatingTest(t);
        }

        public void addTrainee(Trainee t)
        {
            if (t.ID == 0)
            {
                throw new Exception("BL: the trainne id is missing");
            }
            if (t.LastName == null || t.FirstName == null)
            {
                throw new Exception("BL: the trainee Last or First Name is missing");
            }
            if (t.BirthDate == default(DateTime))
            {
                throw new Exception("BL: the trainee Last or First Name is missing");
            }
            if (DateTime.Now.Year - t.BirthDate.Year < Configuration.minTraineeAge)
            {
                throw new Exception(" BL: the trainee age got to be 18 and above");
            }
            FactoryDal.GetInstance().getDal().addTrainee(t);
        }
        public void deleteTrainee(Trainee t)
        {
            FactoryDal.GetInstance().getDal().deleteTrainee(t);
        }
        public void updatingTrainee(Trainee t)
        {
            if (!traineesList().ToList().Exists(item => t.ID == item.ID && t.BirthDate == item.BirthDate))
            {
                throw new Exception("The trainee does not exist");
            }
            FactoryDal.GetInstance().getDal().updatingTrainee(t);
        }


        public void addTest(Test t)
        {
            Trainee trainee = FactoryDal.GetInstance().getDal().GetTrainee(t.TraineeID);
            if ((DateTime.Now.Date - t.Time.Date).Days > 0)
            {
                throw new Exception(" BL: this date is in the past");
            }
            if (trainee == null)
            {
                throw new Exception(" BL: this trainee doesnt exist");
            }
            Tester tester = FactoryDal.GetInstance().getDal().GetTester(t.TesterID);
            if (tester == null)
            {
                throw new Exception("BL: this trainee doesnt exist");
            }


            if (t.Time.DayOfWeek == DayOfWeek.Friday || t.Time.DayOfWeek == DayOfWeek.Saturday || t.Time.Hour > 15 || t.Time.Hour < 9)
            {
                throw new Exception("BL: wrong time");
            }

            foreach (Test item in traineeTests(t.TraineeID))
            {
                TimeSpan distance = t.Time.Date - item.Time.Date;
                TimeSpan distance_now = DateTime.Now.Date - item.Time.Date;
                if (distance_now.Days <= 0)
                {
                    throw new Exception(" BL: You already have a test that you havent done");
                }
                if (distance.Days <= Configuration.minDistance)//
                {
                    throw new Exception(" BL: it hasn't been a week since the last test");
                }
                if (t.Car == item.Car && item.Grade)
                {
                    throw new Exception(" BL: The trainee is already passed the test");

                }
                if (item.Time == t.Time)//
                {
                    throw new Exception(" BL: the trainee isnt free that time");
                }
            }




            if (testerTests(t.TesterID).Exists(item => item.Time == t.Time))
            {
                throw new Exception(" BL: the tester isnt free that time");
            }


            if (trainee.NumOfLessons < Configuration.minLesson)//
            {
                throw new Exception(" BL: you havent done enought lessons");
            }

            if (numTesterTests(tester) == tester.MaxTestsAWeek)//
            {
                throw new Exception(" BL: The tester has no free time in this week");
            }

            if (trainee.Car != tester.Car)
            {
                throw new Exception(" BL: The trainee car doent math to the tester car");
            }
            else
            {
                t.Car = trainee.Car;
            }
            FactoryDal.GetInstance().getDal().addTest(t);
        }


        public void deleteTest(Test t)
        {
            FactoryDal.GetInstance().getDal().deleteTest(t);
        }

        public IEnumerable<Tester> testersList()
        {
            return FactoryDal.GetInstance().getDal().testersList();
        }

        public IEnumerable<Trainee> traineesList()
        {
            return FactoryDal.GetInstance().getDal().traineesList();
        }

        public IEnumerable<Test> testsList()
        {
            return FactoryDal.GetInstance().getDal().testsList();
        }
        public int numTesterTests(Tester t)//in a week
        {
            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (t.Schedule[i, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int numTraineeTests(Trainee t)
        {
            return testsList().Where(u => (u.TraineeID == t.ID)).Count();
        }

        public bool pass(Trainee t)
        {
            return (testsList().Where(u => (u.TraineeID == t.ID && u.Grade)).Count() > 0);
        }


        /*gets a list of testers and address and retun all the testers that live close*/
        public List<Tester> closeTester(List<Tester> testersToCheck, Address adr)
        {
            List<Tester> t = new List<Tester>();
            double value = 0;
            foreach (Tester u in testersToCheck)
            {
                Thread thread = new Thread(() => { value = calculateDistance(u.Residence, adr); });
                thread.Start();
                thread.Join();
                if (value <= Configuration.MaxDistanceFromAddress)
                {
                    t.Add(u);
                }
            }
            return t;
            //return testersToCheck.Where(u => calculateDistance(u.Residence, adr) <= Configuration.MaxDistanceFromAddress).ToList();
        }



        double calculateDistance(Address adr1, Address adr2)
        {

            string origin = adr1.street + " " + adr1.bulidingNum + " st. " + adr1.city; //or "תקווה פתח 100 העם אחד "etc.
            string destination = adr2.street + " " + adr2.bulidingNum + " st. " + adr2.city; ;//or "גן רמת 10 בוטינסקי'ז "etc.
            string KEY = @"Wt2QQ6mp5MugkXPvPVK6AQPSNkasiLk7";
            string url = @"https://www.mapquestapi.com/directions/v2/route" +
             @"?key=" + KEY +
             @"&from=" + origin +
             @"&to=" + destination +
             @"&outFormat=xml" +
             @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
             @"&enhancedNarrative=false&avoidTimedConditions=false";
            double distInMiles = 0;
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);

                XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                string fTime = formattedTime[0].ChildNodes[0].InnerText;
                //throw new Exception("Driving Time: " + fTime);
            }
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                throw new Exception("an error occurred, one of the addresses is not found. try again.");
            }
            else //busy network or other error...
            {
                throw new Exception("We have'nt got an answer, maybe the net is busy...");
            }
            return distInMiles;
        }

        public List<Tester> availableTesters(DateTime t)
        {
            List<Tester> freeT = testersList().ToList();

            foreach (Tester item in testersList())
            {
                foreach (Test u in testsList())
                {
                    if (u.TesterID == item.ID && u.Time == t)
                    {
                        freeT.Remove(item);
                    }
                }
            }
            return freeT;
        }
        public List<Test> testsByRequest(Func<Test, bool> condition)
        {
            return testsList().Where(u => condition(u)).ToList();
        }
        public List<Test> testsByDay(DateTime day)
        {
            return (from p in testsList() where (p.Time.Date == day) select p).ToList();
        }
        public List<Test> testsByMonth(DateTime month)
        {
            return testsList().Where(u => u.Time.Date.Year == month.Year && u.Time.Date.Month == month.Month).ToList();
        }


        public List<IGrouping<CarType, Tester>> TesterByCar(bool flag = false)
        {
            var result = (from t in testersList()
                          group t by t.Car into g
                          select g);
            if (flag)
            {
                result = (from g in result
                          orderby g.Key
                          select g);

            }

            return result.ToList();
        }
        public List<IGrouping<string, Trainee>> TraineeBySchool(bool flag = false)
        {
            var result = (from t in traineesList()
                          group t by t.School into g
                          select g);
            if (flag)
            {
                result = (from g in result
                          orderby g.Key
                          select g);

            }

            return result.ToList();
        }
        public List<IGrouping<string, Trainee>> TraineeByTeacher(bool flag = false)
        {
            var result = (from t in traineesList()
                          group t by t.Teacher into g
                          select g);
            if (flag)
            {
                result = (from g in result
                          orderby g.Key
                          select g);

            }

            return result.ToList();
        }
        public List<IGrouping<int, Trainee>> TraineeByNumTests(bool flag = false)
        {
            var result = (from t in traineesList()
                          group t by numTraineeTests(t) into g
                          select g);
            if (flag)
            {
                result = (from g in result
                          orderby g.Key
                          select g);

            }

            return result.ToList();
        }

        public int numOfPassedcCriteria(Test t)
        {
            int count = 0;
            if (t.SaveDistance)
            {
                count++;
            }
            if (t.ReverseParking)
            {
                count++;
            }
            if (t.LookingTheMirrors)
            {
                count++;
            }
            if (t.Signaling)
            {
                count++;
            }
            if (t.StayInPath)
            {
                count++;
            }
            if (t.DrivingOnRight)
            {
                count++;
            }
            if (t.WheelControl)
            {
                count++;
            }
            if (t.RightUseOfGeer)
            {
                count++;
            }
            return count;
        }

        public List<Test> testerTests(int id)
        {
            return testsList().Where(u => u.TesterID == id).ToList();
        }
        public List<Test> traineeTests(int id)
        {
            return testsList().Where(u => u.TraineeID == id).ToList();
        }
        public List<Trainee> testerTrainees(Tester t)
        {
            List<Test> l = testerTests(t.ID);
            List<Trainee> newList = new List<Trainee>();
            foreach (Test item in l)
            {
                newList.Add(GetTrainee(item.TraineeID));
            }
            return newList;
        }

        public int averageTraineeTests()
        {
            return (int)traineesList().Average(u => numTraineeTests(u));
        }

        public Trainee GetTrainee(int id)
        {
            return FactoryDal.GetInstance().getDal().GetTrainee(id);
        }
        public Tester GetTester(int id)
        {
            return FactoryDal.GetInstance().getDal().GetTester(id);
        }

        public Test closestTest(int id)
        {
            List<Test> l = traineeTests(id).Where(u => (DateTime.Now.Date - u.Time.Date).Days <= 0).ToList();
            if (l.Any())
            {
                return l[0];
            }
            return null;
        }

    }

}
