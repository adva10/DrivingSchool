using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BE
{
    public enum CarType
    {
        privateCar,
        twoWheeledVehicles,
        mediumTruck,
        heavyTruck
    }

    public enum GearBoxType
    {
        automatic,
        manual
    }

    public enum Gender
    {
        female,
        male,
        SelectedIndex
    }

 
    public class Address
    {
        public string street;
        public int bulidingNum;
        public string city;
        public override string ToString()
        {
            return street + " " + bulidingNum + " " + city;
        }
        static public Object ConvertFromString(string value)
        {
            Address addr = new Address();
            string[] size = value.Split(' ');
            addr.street = size[0];
            addr.bulidingNum = Int32.Parse(size[1]);
            addr.city = size[2];
            return addr;
        }
    }


}
