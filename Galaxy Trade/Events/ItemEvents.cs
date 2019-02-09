/**
 * ItemEvents.cs is a class containing all the functionality to run Item specific events
 * in Galaxy Trade. These events are specific to the Items of Galaxy Trade because they 
 * either multiply their value greatly or reduce their value to a degree.
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade.Events
{
    public class ItemEvents : IEvent
    {
        private int eventChance;
        private List<string> message;
        private Product[] products;                

        public List<string> Message { get => message; }

        /**
         * Initial constructor
         * @param chance - The chance for an ItemEvent to happen.
         * @param p - A reference to the main Product array in case we need to
         * multiply a product value due to an event.
         */ 
        public ItemEvents(int chance, ref Product[] p)
        {
            message = new List<string>();
            eventChance = chance;
            products = p;
        }

        /**
         * Calculates whether an ItemEvent is happening or not.
         * @return - Returns true if a ItemEvent is calculated to happen.
         */
        public bool isActive()
        {
            int i = Globals.rnd.Next(100) + 1;

            return (i <= eventChance);
        }

        /**
         * Clears the message that was stored from the previous event.
         */
        public void clearMessage()
        {
            if (message.Count > 0)
            {
                message.Clear();
            }
        }

        /**
         * Randomly chooses which event to run.
         */
        public void chooseEvent()
        {
            int i = Globals.rnd.Next(100) + 1;

            if (i <= 50)
            {
                highDemand();
            }
            else
            {
                lowDemand();
            }
        }

        /**
         * Randomly chooses 1 or 2 items and multiplies their value by 3.37 - 5.         
         */ 
        private void highDemand()
        {
            string[] s = new string[2]
            {
                "**Companies are buying {0} at rediculous prices!\n",
                "**{0} is in short supply. Prices are sky rocketing!\n"
            };
            
            double multiplier = (Globals.rnd.NextDouble() * (5.0 - 4.0) + 4.0);
            int numProducts = ((Globals.rnd.Next(100) + 1) >= 90) ? 2 : 1;

            for (int i = 0; i < numProducts; i++)
            {
                int k = Globals.rnd.Next(products.Length);
                products[k].multiplyCurrentValue(multiplier);

                string m = k % 2 == 0 ? String.Format(s[0], products[k].Name) : String.Format(s[1], products[k].Name);
                message.Add(m);
            }            
        }

        /**
         * Randomly chooses an item and multiplies it's value by 0.33.
         */ 
        private void lowDemand()
        {                    
            int i = Globals.rnd.Next(products.Length);
            products[i].multiplyCurrentValue(0.33);

            string m = String.Format("**The market is flooded with {0}. Prices are plummeting!\n", products[i].Name);
            message.Add(m);
        }
    }
}
