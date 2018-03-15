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
        string[] items = new string[10] {"test1", "test2", "test3", "test4", "test5", "test6", "test7", "test8", "test9", "test10"};

        public void addItems()
        {
            int k = 1000;
            for (int i = 0; i < items.Length; i++)
            {
                ListViewItem item = new ListViewItem(items[i]);
                item.SubItems.Add(k.ToString());
                itemsListView.Items.Add(item);

                k += 1000;
            }
        }
        */
        public GameForm()
        {
            InitializeComponent();
        }
    }
}
