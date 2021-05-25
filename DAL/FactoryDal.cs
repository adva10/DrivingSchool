using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class FactoryDal
    {
        protected FactoryDal() { } 

        protected static FactoryDal instance = null;

        //Singleton
        public static FactoryDal GetInstance()
        {
            if (instance == null)
            {
                instance = new FactoryDal();
            }
            return instance;
        }

        //Factory
        public Idal getDal()
        {
            return new Dal_XML_imp();
        }

       
    }
}
