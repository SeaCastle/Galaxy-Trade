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
        BuyWindow buyWindow;

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
            /*
            for (int i = 0; i < game.products.Length; i++)
            {
                ListViewItem item = new ListViewItem(game.products[i].Name);
                item.SubItems.Add(game.products[i].CurrentValue.ToString("C0"));
                itemsListView.Items.Add(item);
            }
            */
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
            if (game.player.Inventory.Count() > 0)
            {
                foreach (string key in game.player.Inventory.Keys)
                {
                    // Make sure the item doesn't already exist in the list view.
                    if (inventoryListView.FindItemWithText(key) == null)
                    {
                        ListViewItem item = new ListViewItem(key, key);
                        item.SubItems.Add(game.player.Inventory[key].ToString());
                        inventoryListView.Items.Add(item);
                    }
                }
            }
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            // Only instantiate one buy window per session,
            // we will just hide it until we need it again
            if (buyWindow == null || buyWindow.IsDisposed)
            {
                buyWindow = new BuyWindow(ref game.player);
            }

            ListViewItem selectedItem = getSelectedItem();
            
            buyWindow.setState(selectedItem);
            buyWindow.ShowDialog();

        }

        // TODO: NEEDS ERROR CHECKING (IF STATEMENT)!
        private ListViewItem getSelectedItem()
        {
            if (itemsListView.SelectedItems.Count != 1)
            {
                return null;
                //MessageBox.Show("Please select an item you would wish you buy", "No Item Selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return itemsListView.SelectedItems[0];
        }

        private void setState()
        {
            // Update the text labels
            dayCounterLabel.Text = "Day " + game.day.ToString() + "/" + game.gameLength.ToString();
            debtValLabel.Text = game.player.Debt.ToString("C0");
            cashValLabel.Text = game.player.Money.ToString("C0");

            // Update the list views
            updateItemsInListView();
            updateItemsInInventory();
        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            setState();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            buyWindow.Close();
            Application.Exit();
        }
    }
}
