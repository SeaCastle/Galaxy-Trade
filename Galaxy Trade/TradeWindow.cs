/**
 * TradeWindow is a Form used for buying or selling in Galaxy Trade. TradeWindow can 
 * either be a buy window or a sell window, but not both at the same time. This class
 * is to be instantiated by GameForm.cs - The main Form for Galaxy Trade.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Galaxy_Trade
{
    public partial class TradeWindow : Form
    {

        private string itemName;
        private int itemPrice;
        private Player player;
        private int total;
        private bool isBuying;

        /**
         * TradeWindow constructor
         * @param p - Reference to the Player object stored in Game.player
         * @param name - Name of the current item the Player is buying/selling.
         * @param price - Price of the current item the Player is buying/selling.
         * @param isBuy - Flag to know whether this is a buy or a sell window.
         */ 
        public TradeWindow(ref Player p, string name, int price, bool isBuy)
        {
            InitializeComponent();

            player = p;
            itemName = name;
            itemPrice = price;
            isBuying = isBuy;

            setState();    
        }


        /////// TODO: Setting the Max Items to buy / sell should probably have it's own function //////////////
        /**
         * Sets up the state of the TradeWindow as to whether it is a buy or sell window,
         * and how many items the player can buy / sell (based on money, inventory slots, or quantity
         * of the item the player is trying to sell). Also sets the data for the Labels used by the 
         * Form. This function to be called by the TradeWindow() constructor.
         */ 
        public void setState()
        {
            int maxItems = 100; ///< int The maximum number of items the player can sell / buy

            if (isBuying)
            {
                sellBtn.Hide();
                
                if (itemPrice * player.InventorySlots < player.Money)
                {
                    maxItems = player.InventorySlots;
                }
                else
                {
                    maxItems = player.Money / itemPrice;
                }
            }
            else
            {
                buyBtn.Hide();
                maxItems = player.Inventory[itemName]; // How many of the item the player has
            }

            productLabel.Text = itemName + "(" + itemPrice.ToString("C0") + ")";
            totalAmountLabel.Text = "0";

            cashValueLabel.Text = player.Money.ToString("C0");

            numericUpDown.Minimum = 1;
            numericUpDown.Maximum = maxItems;
            totalAmountLabel.ForeColor = System.Drawing.Color.Black;
        }

        /**
         * Updates the totalAmountLabel to show the player how much it will cost
         * them to buy a specific quantity of the item.
         */ 
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.Color.Black;

            int num = (int)numericUpDown.Value;
            total = num * itemPrice;

            totalAmountLabel.Text = total.ToString("C0");
            totalAmountLabel.ForeColor = color;
        }

        /**
         * Checks to see whether the Player has bought anything, and if so, add the item and quantity
         * to the Player's inventory and subtract the total cost of the transaction from the 
         * Player's money.
         */ 
        private void buyBtn_Click(object sender, EventArgs e)
        {
            // they didn't buy anything
            if (numericUpDown.Value == 0) 
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                // We don't do any checking for whether or not the player has enough
                // money because the numericUpDown won't let them select more items than
                // they can afford / carry.
                player.addItemsToInventory(itemName, (int)numericUpDown.Value);
                player.updateMoney(-total); ////////// I STILL DON'T LIKE THIS
                // player.Money -= total?????????????
                this.DialogResult = DialogResult.OK;
            }
        }
        /**
         * Checks to see whether the Player has sold anything, and if so, subtract the
         * total sold from the quantity of the item in the Player's Inventory. After that
         * add the the total gained from the transaction to the Player's money.
         */ 
        private void sellBtn_Click(object sender, EventArgs e)
        {
            if (numericUpDown.Value == 0)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                player.removeItemsFromInventory(itemName, (int)numericUpDown.Value);
                player.updateMoney(total);
                this.DialogResult = DialogResult.OK;
            }
        }

        /**
         * Function that lets the Parent Form know that the dialogue box was
         * cancelled.
         */ 
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /**
         * Sets the value of the numericUpDown to the maximum amount so the Player can
         * quickly buy / sell the maximum amount of a particular item.
         */ 
        private void maxBtn_Click(object sender, EventArgs e)
        {
            numericUpDown.Value = numericUpDown.Maximum;
        }
    }
}




// If the player doesn't have enough money, change the label to red
// and disable the buy button.
// NO LONGER RELEVENT, WE DON'T ALLOW THE NUMERIC UPDOWN TO PASS HOW MANY THEY HAVE MONEY FOR
/*
if (total > player.Money)
{
    color = System.Drawing.Color.Red;
    buyBtn.Enabled = false;
}
else
{
    buyBtn.Enabled = true;
}
*/
