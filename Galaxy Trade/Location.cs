using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
    class Location
    {
        private string name;
        private List<Product> currentProducts;

        public string Name
        {
            get => name;
        }

        public List<Product> CurrentProducts
        {
            get => currentProducts;
        }

        public Location(string name)
        {

        }
    }
}
