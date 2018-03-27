using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galaxy_Trade
{
    public partial class GameForm : Form
    {
        /*
         * This code adds items into the itemsListView
         * Saving this code for when we have our Item class ready so we can just
         * change out a few things and everything will hopefully work
         * 
         * if (itemsListView.SelectedItems.Count == 0) return;
         * Get item from listView == **something = itemsListView.SelectedItems[0].SubItems[0].Text
         * 
         * remove item from list view == **itemsListView.SelectedItems[0].Remove();
         * 
        */

        public Game game;
        TradeWindow tradeWindow;
        LocationWindow locationWindow;

        public GameForm()
        {
            InitializeComponent();
            game = new Game();
            setState();
        }

        /* 
         * To be called once every new day, or at the start of a new game.
         * Updates the current price of an item and adds the Product to the Items list view.
         */
        public void updateItemsInListView()
        {
            foreach (Product p in game.products)
            {
                if (itemsListView.FindItemWithText(p.Name) == null)
                {
                    ListViewItem item = new ListViewItem(p.Name);
                    item.SubItems.Add(p.CurrentValue.ToString("C0"));
                    itemsListView.Items.Add(item);
                }
            }
        }

        public void updateItemsInInventory()
        {
            // SHOULD PROBABLY THINK OF SOMETHING BETTER HERE -----
            inventoryListView.Items.Clear();
            //////////////////////////////////////////////////////

            foreach (string key in game.player.Inventory.Keys)
            {
                //ListViewItem currentItem = null;
                ListViewItem currentItem = inventoryListView.FindItemWithText(key);
                // Make sure the item doesn't already exist in the list view.
                if (currentItem == null)
                {
                    ListViewItem item = new ListViewItem(key, key);
                    item.SubItems.Add(game.player.Inventory[key].ToString());
                    inventoryListView.Items.Add(item);
                }
                else
                {
                    currentItem.SubItems[1].Text = game.player.Inventory[key].ToString();
                }
            }
        }

        // CAN WE MESH THESE TWO (buyButton / sellButton) CLICK FUNCTIONS TOGETHER?
        private void buyButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = getSelectedItemFromListView(itemsListView); ///< ListViewItem Will be set to null if none/more than 1 item selected.
      
            if (selectedItem != null)
            {
                string name;
                int price;

                getItemInfo(selectedItem, out name, out price);
                createTradeWindow(name, price, true);
                inventoryListView.SelectedIndices.Clear();
            }
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = getSelectedItemFromListView(inventoryListView);

            if (selectedItem != null)
            {
                string name;
                int price;

                getItemInfo(selectedItem, out name, out price);
                createTradeWindow(name, price, false);
                inventoryListView.SelectedIndices.Clear();
            }
        }

        private void createTradeWindow(string name, int price, bool isTrade)
        {
            using (tradeWindow = new TradeWindow(ref game.player, name, price, isTrade))
            {
                tradeWindow.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);

                DialogResult result = tradeWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    setState();
                }
            }
        }

        // IS THIS REALLY WHAT WE WANT TO DO??
        /// //////////////////////////////////
        private void getItemInfo(ListViewItem lvi, out string name, out int price)
        {
            name = "ERROR NAME NOT FOUND";
            price = -1;

            foreach (Product p in game.products)
            {
                if (lvi.SubItems[0].Text == p.Name)
                {
                    name = p.Name;
                    price = p.CurrentValue;
                }
            }           
        }

        // TODO: NEEDS ERROR CHECKING (IF STATEMENT)!
        private ListViewItem getSelectedItemFromListView(ListView view)
        {
            if (view.SelectedItems.Count != 1)
            {
                return null;
            }
            return view.SelectedItems[0];
        }

        private void dropButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = getSelectedItemFromListView(inventoryListView);

            if (selectedItem != null)
            {
                string name = selectedItem.SubItems[0].Text;
                string count = selectedItem.SubItems[1].Text;

                game.player.removeItemsFromInventory(name, Int32.Parse(count));
                eventTextBox.AppendText("You dropped " + count + " " + name + "!\n");
                updateItemsInInventory();
            }            
        }

        private void travelButton_Click(object sender, EventArgs e)
        {
            using (locationWindow = new LocationWindow())
            {
                DialogResult result = locationWindow.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Change the day here
                }
            }
        }

        private void setState()
        {
            // Update the text labels
            dayCounterLabel.Text = "Day " + game.day.ToString() + "/" + game.gameLength.ToString();

            debtValLabel.Text = game.player.Debt.ToString("C0");
            cashValLabel.Text = game.player.Money.ToString("C0");

            spaceValLabel.Text = game.player.InventorySlots.ToString();

            // Update the list views
            updateItemsInListView();
            updateItemsInInventory();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tradeWindow.Close();
            Application.Exit();
        }
    }
}


// MessageBox.Show("Text Here", "Something", MessageBoxButtons.OK, MessageBoxIcon.None);