/**
 * Player is used to hold all the variables and functionality to make a Player
 * in Galaxy Trade. Key functionality includes updating the Player's inventory,
 * and updating / storing the Player's total money, debt and health.
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
     public class Player
    {
        private const int STARTINGINVENTORY = 100;
        private Dictionary<string, int> inventory; //<key, val>
        private int money;
        private int debt;
        private int health;
        private int additionalInventory;
        private int inventorySlots;

        public Dictionary<string, int> Inventory
        {
            get { return inventory; }
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

        public int InventorySlots
        {
            get { return inventorySlots; }
        }

        public int AdditionalInventory
        {
            get { return additionalInventory; }
            set { additionalInventory += value; }
        }

        /**
         * Initial Player constructor
         * This is used to be used when starting a new game.
         */ 
        public Player()
        {
            money = 50000;
            debt = 5500;
            health = 100;
            inventorySlots = STARTINGINVENTORY;
            additionalInventory = 0;
            inventory = new Dictionary<string, int>();
        }

        /**
         * Adds items to the Player's Inventory if they do not already have that
         * particular item, otherwise it adds the new amount to the old amount.
         * @param product - The key used for lookup in the Player's Inventory.
         * @param amount - How many items we are adding to the Player's Inventory.
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

            updateInventorySlots();
        }

        // TODO: Error Checking
        /**
         * Removes the quantity of an item from the Player's Inventory. If the 
         * quantity to be removed is equal to the total number of an item the Player
         * has, we remove the full item (name, val) from the Player's inventory entirely.
         * @param product - The key used for lookup in the Player's Inventory.
         * @param amount - Quantity to remove from a particular item in the Player's Inventory.
         */ 
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

            updateInventorySlots();
        }

        /**
         * Updates how many open inventory slots the Player has
         */ 
        public void updateInventorySlots()
        {
            int totalItems = 0;
            foreach (string key in inventory.Keys)
            {
                totalItems += inventory[key];
            }

            inventorySlots = (STARTINGINVENTORY + additionalInventory - totalItems);
        }

        //// THIS PROBABLY NEEDS TO GO ////
        public void updateMoney(int val)
        {
            money += val;
        }
    }
}
