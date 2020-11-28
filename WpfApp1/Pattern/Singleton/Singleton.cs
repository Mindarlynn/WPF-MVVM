using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Pattern.Singleton
{
    class Singleton
    {
        private static Singleton _instance;

        protected Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if(_instance == null)
            {
                lock (_instance)
                {
                    _instance = new Singleton();
                }
            }

            return _instance;
        }
    }
}
