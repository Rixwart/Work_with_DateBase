using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWorkApp.View
{
    public static class Singleton<T> where T:class,new ()
    {
        static T instance;

        public static T Instance()
        {
            if (instance == null) { instance = new T(); return instance; }
            else return instance;
        }
    }
}
