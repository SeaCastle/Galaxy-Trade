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

        public Random rnd = new Random();
        private Player player = new Player();

        private Product[] products = new Product[12]
            {
                new Product("Copper", 10, 60),
                new Product("Titanium", 70, 250),
                new Product("Platinum", 100, 700),
                new Product("Palladium", 300, 900),
                new Product("Iridium", 450, 1500),
                new Product("Meteorite", 500, 1300),
                new Product("Stargems", 600, 1400),
                new Product("Plutonium", 1000, 3500),
                new Product("Ion Drive", 1000, 4500),
                new Product("Nanites", 1500, 4500),
                new Product("Galaxy Dust", 5000, 14000),
                new Product("Dark Matter", 15000, 30000)
            };

        public GameForm()
        {
            InitializeComponent();
            updateItemsInListView();
        }

        /* 
         * To be called once every new day, or at the start of a new game.
         * Updates the current price of an item and adds the Product to the Items list view.
         */
        public void updateItemsInListView()
        {
            for (int i = 0; i < products.Length; i++)
            {
                int val = rnd.Next(products[i].MinValue, (products[i].MaxValue + 1));
                products[i].CurrentValue = val;

                ListViewItem item = new ListViewItem(products[i].Name);
                item.SubItems.Add(products[i].CurrentValue.ToString());
                itemsListView.Items.Add(item);
            }
        }

        private void buyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
