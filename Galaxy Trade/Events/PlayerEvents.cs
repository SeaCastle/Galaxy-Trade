using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galaxy_Trade.Events
{
    public class PlayerEvents : IEvent
    {
        private Random rnd;
        private Player player;
        private Product[] products;
        private int eventChance;
        private List<string> message;

        public List<string> Message { get => message; }

        /**
         * Initial constructor
         * @param chance - The chance that a PlayerEvent has to trigger.
         * @param p - Reference to the Player object for access to their health, money, inventory.
         * @param prod - Reference to the main Product array for item names.
         */ 
        public PlayerEvents(int chance, ref Player p, ref Product[] prod)
        {
            rnd = new Random();
            message = new List<string>();
            player = p;
            products = prod;
            eventChance = chance;
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
         * Calculates whether a PlayerEvent is happening or not.
         * @return - Returns true if a PlayerEvent is calculated to happen.
         */ 
        public bool isActive()
        {
            int i = rnd.Next(100) + 1;
            return (i <= eventChance);
        }

        /**
         * Player Event for buying extra storage. This event allows the Player
         * to expand their inventory by 10 if they choose to pay the appropriate cost.
         */ 
        private void buyStorage()
        {            
            int cost = rnd.Next(200,351);

            string m = String.Format("**An Alien ship hails you on your way. For a small fee of ${0} " +
                "their expert engineers have agreed to increase your storage capacity by 10!\n", cost);

            if (MessageBox.Show(m, "Event!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                player.AdditionalInventory += 10;
                player.updateInventorySlots();
                player.Money -= cost;
            }
            //message.Add(m);
        }

        /**
         * Player Event for finding extra items. This event randomly chooses an item from all
         * items in the game (not weighted) and adds 1-13 of that item to their inventory if
         * they have space. If not, their remaining inventory is filled and the excess amount 
         * of the found item is discarded. If inventory is full, all found items are discarded.
         */
        private void findItems()
        {
            int freeInvSlots = player.InventorySlots;
            int itemQuantity = rnd.Next(1, 14);
            int idx = rnd.Next(products.Length);
            Product prod = products[idx];

            string m = String.Format("**Among your travels, you come across a tragic scene - A ship " +
                "had a head on collision with an asteroid! There were no survivors... But hey, they left " +
                "some free stuff for you!\nYou recieved: {0} {1}(s)!\n", itemQuantity, prod.Name);

            if (freeInvSlots == 0)
            {
                m += "Unfortunately, you have no extra storage space. All items were left behind. Feelsbadman\n";
            }
            // The Player doesn't have enough inventory slots to fit all the items. Fill their
            // inventory to the max and leave the rest behind.
            else if (freeInvSlots < itemQuantity)
            {
                player.addItemsToInventory(prod.Name, freeInvSlots);
                m += String.Format("\nUh-Oh, you only have {0} slots left. You fill your ship" +
                    " to the brim and leave {1} {2}(s) behind.\n", freeInvSlots, (itemQuantity-freeInvSlots), prod.Name);
            }
            else
            {
                player.addItemsToInventory(prod.Name, itemQuantity);
            }

            message.Add(m);
        }

        /**
         * Player event for the player getting mugged. This event randomly takes 3 - 10%
         * of the Player's total money and 5 - 17 health from the Player. Additionally, if
         * the Player has any items in their inventory, one item is selected at random and
         * 10% - 40% (randomly chosen, rounded up) of that items quantity is discarded. 
         */ 
        private void gotMugged()
        {
            // Anywhere between 3% - 10% of the Players total money, rounded up/down.
            int moneyTaken = rnd.Next((int)(player.Money * 0.03), (int)(player.Money * 0.1));
            int healthLost = rnd.Next(5,18);
            string m = String.Format("**While travelling through space, you encounter a huge ship of space pirates! " +
                "Not wanting to start any trouble, you comply with their demands. They take ${0} and hurt you for {1} " +
                "for good measure - they are pirates after all.\n", moneyTaken, healthLost);

            int itemsInInv = player.Inventory.Count;
            // Calculate what item and how much of that item was lost.
            if (itemsInInv > 0)
            {
                int idx = rnd.Next(itemsInInv); // This may need to be - 1

                string itemName = player.Inventory.ElementAt(idx).Key;
                int itemQuantity = player.Inventory.ElementAt(idx).Value;

                double i = rnd.Next((int)(itemQuantity * 0.1), (int)(itemQuantity * 0.4));
                int totalLost = (int)Math.Ceiling(i);

                player.removeItemsFromInventory(itemName, totalLost);

                m += String.Format("Before leaving the pirates take a look at your booty... er your items. " +
                    "They take {0} {1}!\n", totalLost, itemName);
            }

            player.Money -= moneyTaken;
            player.Health -= healthLost;

            message.Add(m);
        }

        /**
         * Randomly chooses which event to run.
         */ 
        public void chooseEvent()
        {
            int i = rnd.Next(100) + 1;

            if (i <= 30)
            {
                findItems();
            }
            else if (i <= 48)
            {
                gotMugged();
            }
            else
            {
                buyStorage();
            }
        }
    }
}
