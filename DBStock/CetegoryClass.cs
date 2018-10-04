using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStock
{
     public class CetegoryClass
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public CetegoryClass(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }
}
