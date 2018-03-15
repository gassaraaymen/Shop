using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    public class Product
    {
        public String Image { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
        public String Price { get; set; }
        public String Category { get; set; }
        public bool IsVisible { get; set; }
    }
}
