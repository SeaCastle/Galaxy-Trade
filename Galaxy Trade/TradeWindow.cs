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

        private ListViewItem selectedItem;
        private Player player;
        private int total;

        public TradeWindow(ref Player p, ListViewItem lvi, bool isTrade)
        {
            InitializeComponent();

            player = p;
            selectedItem = lvi;

            setState(isTrade);    
        }

        // Gets a reference to variables in GameForm.cs that we need to 
        // set up the state of the buyWindow, and get the window ready to show.
        public void setState(bool isTrade)
        {
            int maxItems = 100; ///< int The maximum number of items the player can sell / buy

            if (isTrade)
            {
                sellBtn.Hide();
                maxItems = player.InventorySlots;
            }
            else
            {
                buyBtn.Hide();
                maxItems = Int32.Parse(selectedItem.SubItems[1].Text);
            }

            productLabel.Text = selectedItem.Text + "(" + selectedItem.SubItems[1].Text + ")";
            totalAmountLabel.Text = "0";

            cashValueLabel.Text = player.Money.ToString("C0");

            numericUpDown.Minimum = 1;
            numericUpDown.Maximum = maxItems;
            numericUpDown.Value = 1;
            totalAmountLabel.ForeColor = System.Drawing.Color.Black;
        }

        // This function changes the totalAmountLabel to reflect
        // the total cost of the items.
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var color = System.Drawing.Color.Black;

            int num = (int)numericUpDown.Value;
            int cost = Int32.Parse(selectedItem.SubItems[1].Text, NumberStyles.Currency);
            total = num * cost;

            // If the player doesn't have enough money, change the label to red
            // and disable the buy button.
            if (total > player.Money)
            {
                color = System.Drawing.Color.Red;
                buyBtn.Enabled = false;
            }
            else
            {
                buyBtn.Enabled = true;
            }
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
                player.addItemsToInventory(selectedItem.Text, (int)numericUpDown.Value);
                player.updateMoney(-total); ////////// I STILL DON'T LIKE THIS
                this.DialogResult = DialogResult.OK;
                //this.Hide();
            }
        }

        private void sellBtn_Click(object sender, EventArgs e)
        {
            player.removeItemsFromInventory(selectedItem.Text, (int)numericUpDown.Value);
            player.updateMoney(total);
            this.DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}