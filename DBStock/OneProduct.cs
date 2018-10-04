using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStock
{
    public class OneProduct
    {
        private int id;
        private string name;
        private string category;
        private string measuring;
        private int price;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Measuring { get; set; }
        public int Price { get; set; }

        public OneProduct()
        {

        }

        public OneProduct(int id, string name, string category, string measuring, int price)
        {
            Id = id;
            Name = name;
            Category = category;
            Measuring = measuring;
            Price = price;
        }
    }
}
