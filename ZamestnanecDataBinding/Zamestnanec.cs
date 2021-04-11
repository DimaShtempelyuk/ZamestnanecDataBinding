using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZamestnanecDataBinding
{
    class Zamestnanecc : Osoba
    {
        public static List<Zamestnanecc> AllZamestameccs = new List<Zamestnanecc>(); 

        private double _mon;
        public string Edu { get; set; }
        public string PracPos { get; set; }
        public double Mon
        {
            get { return _mon; }
            set
            {
                if (value >= 0)
                {
                    _mon = value;
                }
                else
                {
                    throw new ArgumentException("error, enter double number");
                }
            }
        }
    }
}
