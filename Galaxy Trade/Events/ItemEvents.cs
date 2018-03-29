using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade.Events
{
    class ItemEvents : IEvent
    {
        Random rnd;
        private int eventChance;
        private List<string> message;
        private Product[] allProducts;                

        public List<string> Message { get; }


        public ItemEvents(int chance, Product[] p)
        {
            rnd = new Random();
            eventChance = chance;
            allProducts = p;
        }

        /**
         * Calculates whether an ItemEvent is happening or not.
         * @return - Returns true if a ItemEvent is calculated to happen.
         */
        public bool isActive()
        {
            int i = rnd.Next(100) + 1;

            return (i <= eventChance);
        }

        public void clearMessage()
        {
            message.Clear();
        }

        private void highDemand()
        {
            double multiplier = (rnd.NextDouble() * (5.0 - 3.37) + 1.74);
            int numProducts = ((rnd.Next(100) + 1) >= 90) ? 2 : 1;

            for (int i = 0; i < numProducts; i++)
            {
                int k = rnd.Next(allProducts.Length);
                allProducts[k].updateCurrentValue(multiplier);
            }

            string m = String.Format("");
        }
    }
}
