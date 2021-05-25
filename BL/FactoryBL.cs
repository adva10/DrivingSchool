using System;
using System.Collections.Generic;
using System.Text;


namespace BL
{
    public class BLFactory
    {
        //Singelton
        protected BLFactory() { }
        static BLFactory instance = null;

        public static BLFactory GetBLFactory()
        {
            if (instance == null)
                instance = new BLFactory();
            return instance;
        }

        public IBL GetBl()
        {
            return new BL_imp();
        }
    }
}