using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Tester
    {
        public int ID{ get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; } //check how to return only the date
        public Gender Gender { get; set; }
        public int PhoneNumber { get; set; }
        public Address Residence { get; set; } //
        public int experience { get; set; }
        public int MaxTestsAWeek { get; set; }
        public CarType Car { get; set; }

        public string StringSchedule { get; set; } = "F,F,F,F,F,F\n" +
            "F,F,F,F,F,F\n" +
            "F,F,F,F,F,F\n" +
            "F,F,F,F,F,F\n" +
            "F,F,F,F,F,F\n";


        [System.Xml.Serialization.XmlIgnore]
        private bool[,] schedule = new bool[6, 5];
        [System.Xml.Serialization.XmlIgnore]
        public bool[,] Schedule { get { return schedule; } set { schedule = value; } }

        public override string ToString()
        {
            return "Tester:\nID:" + ID + "\nLastName:" + LastName + "\nFirstName:" + FirstName
                + "\nBirthDate:" + BirthDate + "\nGender:" + Gender + "\nPhoneNumber:" + PhoneNumber + "\nResidence:" + Residence  + "\n";
        }

    }
}
