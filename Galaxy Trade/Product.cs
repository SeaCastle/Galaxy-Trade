using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
    public class Product
    {
        private string name;
        private int minValue;
        private int maxValue;
        private int currentValue;

        public string Name
        {
            get { return name; }
        }

        public int MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        public int MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

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
