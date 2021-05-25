using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public class Dal_XML_imp : Idal
    {
        XElement traineeRoot;
        string traineePath = @"traineesXml.xml";

        XElement ConfigRoot;
        string ConfigPath = @"ConfigXml.xml";

        List<Tester> testerList;
        string testerPath = @"testersXml.xml";


        List<Test> testList;
        string testPath = @"testsXml.xml";

        public Dal_XML_imp()
        {
            if (!File.Exists(testerPath))
                CreateTesterFile();
            else
                LoadTesterData();

            if (!File.Exists(traineePath))
                CreateTraineeFile();
            else
                LoadTraineeData();

            if (!File.Exists(testPath))
                CreateTestFile();
            else
                LoadTestData();

            if (!File.Exists(ConfigPath))
                CreateConfigFile();
            else
                LoadConfigData();

        }

        private void CreateTraineeFile()
        {
            traineeRoot = new XElement("trainee");
            traineeRoot.Save(traineePath);
        }

        private void LoadTraineeData()
        {
            try
            {
                traineeRoot = XElement.Load(traineePath);
            }
            catch
            {
                throw new Exception("DAL_xml : Trainee file upload problem");
            }
        }


        private void CreateTesterFile()
        {
            testerList = new List<Tester>();
            saveTesterListToXML(testerList, testerPath);
        }


        private void LoadTesterData()
        {
            try
            {
                testerList = loadTesterListFromXML(testerPath);
            }
            catch
            {
                throw new Exception("DAL_xml : tester file upload problem");
            }
        }

        private void CreateTestFile()
        {
            testList = new List<Test>();
            saveTestListToXML(testList, testPath);
        }


        private void LoadTestData()
        {
            try
            {
                testList = loadTestListFromXML(testPath);
            }
            catch
            {
                throw new Exception("DAL_xml : test file upload problem");
            }
        }


        private void CreateConfigFile()
        {
            ConfigRoot = new XElement("configuration");
            ConfigRoot.Add(new XElement("minLesson", 20));
            ConfigRoot.Add(new XElement("maxTesterAge", 70));
            ConfigRoot.Add(new XElement("minTesterAge", 40));
            ConfigRoot.Add(new XElement("minTraineeAge", 18));
            ConfigRoot.Add(new XElement("breakTime", 30));
            ConfigRoot.Add(new XElement("minDistance", 20));
            ConfigRoot.Add(new XElement("runCode", 11111111));
            ConfigRoot.Add(new XElement("MaxDistanceFromAddress", 25));
            ConfigRoot.Add(new XElement("numOfCriteria", 8));
            ConfigRoot.Save(ConfigPath);
            LoadConfigData();
        }

        private void LoadConfigData()
        {
            try
            {
                ConfigRoot = XElement.Load(ConfigPath);
                Configuration.minLesson = int.Parse(ConfigRoot.Element("minLesson").Value);
                Configuration.maxTesterAge = int.Parse(ConfigRoot.Element("maxTesterAge").Value);
                Configuration.minTesterAge = int.Parse(ConfigRoot.Element("minTesterAge").Value);
                Configuration.minTraineeAge = int.Parse(ConfigRoot.Element("minTraineeAge").Value);
                Configuration.breakTime = int.Parse(ConfigRoot.Element("breakTime").Value);
                Configuration.minDistance = int.Parse(ConfigRoot.Element("minDistance").Value);
                Configuration.runCode = int.Parse(ConfigRoot.Element("runCode").Value);
                Configuration.MaxDistanceFromAddress = int.Parse(ConfigRoot.Element("MaxDistanceFromAddress").Value);
                Configuration.numOfCriteria = int.Parse(ConfigRoot.Element("numOfCriteria").Value);
            }
            catch
            {
                throw new Exception("DAL_xml : Config file upload problem");
            }
        }


        XElement ConvertTester(Tester tester)
        {
            XElement testerElement = new XElement("tester");
            foreach (PropertyInfo item in typeof(Tester).GetProperties())
            {
                testerElement.Add(new XElement(item.Name, item.GetValue(tester, null).ToString()));
            }
            return testerElement;
        }


        XElement ConvertTraineeToXml(Trainee trainee)
        {
            XElement traineeElement = new XElement("trainee");
            foreach (PropertyInfo item in typeof(Trainee).GetProperties())
            {
                traineeElement.Add(new XElement(item.Name, item.GetValue(trainee, null).ToString()));
            }
            return traineeElement;
        }


        Trainee ConvertTraineeFromXml(XElement element)
        {
            Trainee trainee = new Trainee();

            foreach (PropertyInfo item in typeof(Trainee).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue;
                if (item.PropertyType.Name == "Address")
                {
                    convertValue = Address.ConvertFromString(element.Element(item.Name).Value);
                }
                else
                {
                    convertValue = (object)typeConverter.ConvertFromString(element.Element(item.Name).Value);
                }

                if (item.CanWrite)
                    item.SetValue(trainee, convertValue);
            }

            return trainee;
        }

        public void addTester(Tester t)
        {
            if (testerList.Exists(s => s.ID == t.ID))
            {
                throw new Exception("DAL_xml: The tester already exits in the system");
            }
            testerList.Add(t);
            saveTesterListToXML(testerList, testerPath);
        }

        public void deleteTester(Tester t)
        {
            List<Tester> l = testerList.Where(u => u.ID == t.ID).ToList();
            if (!l.Any())
            {
                throw new Exception("DAL_xml: The tester is not exits in the system");
            }
            testerList.Remove(l[0]);
            saveTesterListToXML(testerList, testerPath);
        }


        public void updatingTester(Tester t)
        {
            if (!testerList.Exists(item => t.ID == item.ID))
            {
                throw new Exception("DAL_xml : tester dosent exists");
            }
            var index = testerList.FindIndex(c => c.ID == t.ID);
            testerList[index] = t;
            saveTesterListToXML(testerList, testerPath);
        }

        public void addTrainee(Trainee t)
        {
            Trainee trainee = GetTrainee(t.ID);
            if (trainee != null)
            {
                throw new Exception("DAL_xml : trainee with the same id already exists...");
            }
            traineeRoot.Add(ConvertTraineeToXml(t));

            traineeRoot.Save(traineePath);
        }



        public Trainee GetTrainee(int id)
        {
            XElement trainee = new XElement(traineePath);

            try
            {
                trainee = (from item in traineeRoot.Elements()
                           where int.Parse(item.Element("ID").Value) == id
                           select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (trainee == null)
                return null;

            return ConvertTraineeFromXml(trainee);
        }//


        public void deleteTrainee(Trainee t)
        {
            XElement traineeToDelete = (from item in traineeRoot.Elements()
                                        where int.Parse(item.Element("ID").Value) == t.ID
                                        select item).FirstOrDefault();

            if (traineeToDelete == null)
            {
                throw new Exception("DAL_xml : there doesnt exists trainee with this id");
            }
            traineeToDelete.Remove();

            traineeRoot.Save(traineePath);
        }



        public void updatingTrainee(Trainee t)
        {
            XElement traineeToUpdate = (from item in traineeRoot.Elements()
                                        where int.Parse(item.Element("ID").Value) == t.ID
                                        select item).FirstOrDefault();

            if (traineeToUpdate == null)
            {
                throw new Exception("DAL_xml : Trainee with the same id not found...");
            }

            foreach (PropertyInfo item in typeof(BE.Trainee).GetProperties())
            {
                traineeToUpdate.Element(item.Name).SetValue(item.GetValue(t).ToString());
            }
            traineeRoot.Save(traineePath);
        }

        private void updateRunCode()
        {
            ConfigRoot = XElement.Load(ConfigPath);
            ConfigRoot.Element("runCode").SetValue(int.Parse(ConfigRoot.Element("runCode").Value) + 1);
            Configuration.runCode = int.Parse(ConfigRoot.Element("runCode").Value);
            ConfigRoot.Save(ConfigPath);
        }

        public void addTest(Test t)
        {
            t.Code = Configuration.runCode;
            updateRunCode();
            testList.Add(t);
            saveTestListToXML(testList, testPath);
        }

        public void deleteTest(Test t)
        {
            List<Test> l = testsList().Where(u => u.Code == t.Code).ToList();
            if (!l.Any())
            {
                throw new Exception("DAL: The test is not exits in the system");
            }
            testList.Remove(l[0]);
            saveTestListToXML(testList, testPath);
        }
        public void updatingTest(Test t)
        {
            if (!testList.Exists(item => t.Code == item.Code))
            {
                throw new Exception("DAL_xml : tester dosent exists");
            }
            var index = testList.FindIndex(c => c.Code == t.Code);
            testList[index] = t;
            saveTestListToXML(testList, testPath);
        }

        public Tester GetTester(int id)
        {
            List<Tester> l = testerList.Where(u => u.ID == id).ToList();
            if (l.Any())
            {
                return l[0];
            }
            return null;
        }

        public IEnumerable<Tester> testersList()
        {
            return testerList;

        }

        public IEnumerable<Trainee> traineesList()
        {
            return from item in traineeRoot.Elements()
                   let s = ConvertTraineeFromXml(item)
                   select s;
        }


        public IEnumerable<Test> testsList()
        {
            return testList;
        }

        private static void saveTestListToXML(List<Test> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }

        private static List<Test> loadTestListFromXML(string path)
        {
            List<Test> list;
            XmlSerializer x = new XmlSerializer(typeof(List<Test>));
            FileStream fs = new FileStream(path, FileMode.Open);
            list = (List<Test>)x.Deserialize(fs);
            fs.Close();
            return list;
        }


        private static void saveTesterListToXML(List<Tester> list, string path)
        {
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Create);
            x.Serialize(fs, list);
            fs.Close();
        }

        private static List<Tester> loadTesterListFromXML(string path)
        {
            List<Tester> list = new List<Tester>();
            XmlSerializer x = new XmlSerializer(list.GetType());
            FileStream fs = new FileStream(path, FileMode.Open);
            list = (List<Tester>)x.Deserialize(fs);
            fs.Close();
            return list;
        }



      
    }
}
