using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade.Events
{
    class PlayerEvents : IEvent
    {
        private Random rnd;
        private Player player;
        private int eventChance;
        private List<string> message;

        public List<string> Message { get; }

        /**
         * Initial constructor
         * @param chance - The chance that a PlayerEvent has to trigger.
         */ 
        public PlayerEvents(int chance, ref Player p)
        {
            rnd = new Random();
            player = p;
            eventChance = chance;
        }

        /**
         * Clears the message that was stored from the previous event.
         */ 
        public void clearMessage()
        {
            message.Clear();
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

            string m = String.Format("An Alien ship hails you on your way. For a small fee of {0} " +
                "their expert engineers have agreed to increase your storage capacity by 10!", cost);
            Message.Add(m);
        }

        /**
         * Player Event for finding extra items. This event randomly chooses an item from all
         * items in the game (not weighted) and adds 1-13 of that item to their inventory if
         * they have space. If not, their remaining inventory is filled and the excess amount 
         * of the found item is discarded. If inventory is full, all found items are discarded.
         */
        private void findItems(Product[] p, int freeInvSlots)
        {
            int itemQuantity = rnd.Next(1, 14);
            int idx = rnd.Next(p.Length);
            Product prod = p[idx];

            string m = String.Format("Among your travels, you come across a tragic scene - A ship " +
                "had a head on collision with an asteroid! There were no survivors... But hey, they left" +
                "some free stuff for you!\n You recieved: {0} {1}(s)!", itemQuantity, prod.Name);

            if (freeInvSlots == 0)
            {
                m += "\nUnfortunately, you have no extra storage space. All items were left behind. Feelsbadman";
            }
            // The Player doesn't have enough inventory slots to fit all the items. Fill their
            // inventory to the max and leave the rest behind.
            else if (freeInvSlots < itemQuantity)
            {
                player.addItemsToInventory(prod.Name, freeInvSlots);
                m += String.Format("\nUh-Oh, you only have {0} slots left. You fill your ship" +
                    " to the brim and leave {1} {2}(s) behind.", freeInvSlots, (itemQuantity-freeInvSlots), prod.Name);
            }
            else
            {
                player.addItemsToInventory(prod.Name, itemQuantity);
            }

            Message.Add(m);
        }

        /**
         * Player event for the player getting mugged. This event randomly takes 3 - 10%
         * of the Player's total money and 5 - 17 health from the Player. Additionally, if
         * the Player has any items in their inventory, one item is selected at random and
         * 10% - 40% (randomly chosen, rounded) of that items quantity is discarded. 
         */ 
        private void gotMugged()
        {
            // Anywhere between 3% - 10% of the Players total money, rounded up/down.
            int moneyTaken = rnd.Next((int)(player.Money * 0.03), (int)(player.Money * 0.1));
            int healthLost = rnd.Next(5,18);

            int itemsInInv = player.Inventory.Count;
            // Calculate what item and how much of that item was lost.
            if (itemsInInv > 0)
            {
                int idx = rnd.Next(itemsInInv); // This may need to be - 1

                string itemName = player.Inventory.ElementAt(idx).Key;
                int itemQuantity = player.Inventory.ElementAt(idx).Value;

                int totalLost = rnd.Next((int)(itemQuantity * 0.1), (int)(itemQuantity * 0.4));

                player.removeItemsFromInventory(itemName, totalLost);
            }

            player.Money -= moneyTaken;
            player.Health -= healthLost;
        }
    }
}
