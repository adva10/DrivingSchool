using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Test
    {
        public int Code { get; set; }//
        public int TesterID { get; set; }
        public int TraineeID { get; set; }
        public DateTime Time { get; set; }// date and time
        public Address Start { get; set; } // Address to start the test
        public CarType Car { get; set; } // new field: the car that the test on
        public bool SaveDistance { get; set; }
        public bool ReverseParking { get; set; }
        public bool LookingTheMirrors { get; set; }
        public bool Signaling { get; set; }
        public bool StayInPath { get; set; }
        public bool DrivingOnRight { get; set; }
        public bool WheelControl { get; set; }
        public bool RightUseOfGeer { get; set; } // only for a geerbox car
        public bool Grade { get; set; }
        public override string ToString()
        {
            return "Code:\nID:" + Code + "\nTesterID:" + TesterID + "\nTraineeID:" + TraineeID
                + "\nTime:" + Time + "\nStart Address:" + Start + "\nCarType:" + Car;
        }


    }
}
