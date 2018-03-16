using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
    class Product
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private int minValue;
        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        private int maxValue;
        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        private int currentValue;
        public int CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }

        public Product(string pName, int minVal, int maxVal)
        {
            name = pName;
            minValue = minVal;
            maxValue = maxVal;
            currentValue = 0;
        }
    }
}
