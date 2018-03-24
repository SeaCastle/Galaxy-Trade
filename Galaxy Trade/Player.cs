using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
     public class Player
    {
        private Dictionary<string, int> inventory; //<key, val>
        private int money;
        private int debt;
        private int health;

        public Dictionary<string, int> Inventory
        {
            get => inventory;
        }

        public int Money
        {
            get { return money; }
        }

        public int Debt
        {
            get { return debt; }
            set { debt = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        // Use this constructor if starting a new game
        public Player()
        {
            money = 20000;
            debt = 5500;
            health = 100;
            inventory = new Dictionary<string, int>();
        }

        /**
         * Adds items to the players inventory if they do not already have that
         * particular item, otherwise it adds the new amount to the old amount.
         * @param p - Product<key> we are updating, or adding to the players inventory
         * @param amount - how many items we are adding to the inventory
         */
        public void addItemsToInventory(string product, int amount)
        {
            int val = 0;
            if (inventory.TryGetValue(product, out val))
            {
                inventory[product] = val + amount;
            }
            else
            {
                inventory.Add(product, amount);
            }
        }

        // TODO: Error Checking
        public void removeItemsFromInventory(string product, int amount)
        {
            int val = 0;
            if (inventory.TryGetValue(product, out val))
            {
                inventory[product] = val - amount;

                // If they have no more of that item, remove it from the dictionary
                if (inventory[product] <= 0)
                {
                    inventory.Remove(product);
                }
            }
        }

        public void updateMoney(int val)
        {
            money += val;
        }
    }
}
