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
        /*
        public struct BoughtITem
        {
            public readonly string name;
            public readonly int val;

            public BoughtITem(string name, int val)
            {
                this.name = name;
                this.val = val;
            }
        }

        private BoughtITem boughtItem;
        public BoughtITem BoughtItem
        {
            get { return boughtItem; }
            set { boughtItem = value; }
        }
        */

        private string itemName;
        private int itemPrice;
        private Player player;
        private int total;
        private bool isBuying;

        public TradeWindow(ref Player p, string name, int price, bool isBuy)
        {
            InitializeComponent();

            player = p;
            itemName = name;
            itemPrice = price;
            isBuying = isBuy;

            setState();    
        }

        // Gets a reference to variables in GameForm.cs that we need to 
        // set up the state of the buyWindow, and get the window ready to show.
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

        // This function changes the totalAmountLabel to reflect
        // the total cost of the items.
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.Color.Black;

            int num = (int)numericUpDown.Value;
            total = num * itemPrice;

            totalAmountLabel.Text = total.ToString("C0");
            totalAmountLabel.ForeColor = color;
        }

        private void buyBtn_Click(object sender, EventArgs e)
        {
            // they didn't buy anything
            if (numericUpDown.Value == 0) 
            {
                this.Hide();
            }
            else
            {
                // We don't do any checking for whether or not the player has enough
                // money because we automatically disable the buy button in the 
                // numeric updown box if they don't have enough money to buy the item(s).
                player.addItemsToInventory(itemName, (int)numericUpDown.Value);
                player.updateMoney(-total); ////////// I STILL DON'T LIKE THIS
                this.DialogResult = DialogResult.OK;
                //this.Hide();
            }
        }

        private void sellBtn_Click(object sender, EventArgs e)
        {
            player.removeItemsFromInventory(itemName, (int)numericUpDown.Value);
            player.updateMoney(total);
            this.DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void maxBtn_Click(object sender, EventArgs e)
        {
            if (isBuying)
            {
                if (itemPrice * player.InventorySlots < player.Money)
                {
                    numericUpDown.Value = player.InventorySlots;
                }
                else
                {
                    numericUpDown.Value = player.Money / itemPrice;
                }
                
            }
            else
            {
                numericUpDown.Value = player.Inventory[itemName];
            }
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
