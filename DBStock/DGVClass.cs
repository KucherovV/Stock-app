using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStock
{
    class DGVClass
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Measuring { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
        public string Sum { get; set; }


        public DGVClass(string id, string name, string category, string measuring, string price, string amount, string sum)
        {
            Id = id;
            Name = name;
            Category = category;
            Measuring = measuring;
            Price = price;
            Amount = amount;
            Sum = sum;
        }
    }
}
