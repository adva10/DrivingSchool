using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Trainee
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; } //check how to return only the date
        public Gender Gender { get; set; }
        public int PhoneNumber { get; set; }
        public Address Residence { get; set; }
        public CarType Car { get; set; }
        public GearBoxType GearBox { get; set; }
        public string School { get; set; }
        public string Teacher { get; set; }
        public int NumOfLessons { get; set; }

        public override string ToString()
        {
            return "Trainee:\nID:" + ID + "\nLastName:" + LastName + "\nFirstName:" + FirstName
                + "\nBirthDate:" + BirthDate + "\nGender:" + Gender + "\nPhoneNumber:" + PhoneNumber + "\nResidence:" + Residence + "\n" 
                + "CarType:" + Car + "\n";
        }

    }
}
