/**
 * Product is a class to store the information of a given Product (or item) in 
 * Galaxy Trade. This class is to be used by Game.cs to hold the current state of
 * all the Products in the game.
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
    public class Product
    {
        private Random rnd = new Random();
        private string name;
        private int minValue;
        private int maxValue;
        private int currentValue;

        public string Name
        {
            get => name; 
        }

        public int MinValue
        {
            get => minValue;
            set => minValue = value;
        }

        public int MaxValue
        {
            get => maxValue;
            set => maxValue = value;
        }

        public int CurrentValue
        {
            get => currentValue;
            set => currentValue = value;
        }

        /** 
         * Product constructor.
         * Used to instantiate a new Product in Galaxy Trade.
         * @param pName - Name of the product.
         * @param minVal - The minimum value a product can have.
         * @param maxVal - The maximum value a product can have.
         */ 
        public Product(string pName, int minVal, int maxVal)
        {
            currentValue = 0; // Is this really needed?
            name = pName;
            minValue = minVal;
            maxValue = maxVal;
            updateCurrentValue();
        }

        /**
         * Sets the currentValue of a Product to be somewhere randomly
         * between the Products minimum and maximum values.
         */ 
        public void updateCurrentValue()
        {
            currentValue = rnd.Next(minValue, (maxValue + 1));
        }

        /**
         * Takes the current value of a Product and multiplies it by a certain amount.
         * @param multiplier - The amount by which we multiply the current value.
         */ 
        public void multiplyCurrentValue(double multiplier)
        {
            currentValue = (int)(currentValue * multiplier);
        }
    }
}
