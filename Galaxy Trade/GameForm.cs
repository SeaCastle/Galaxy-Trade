/**
 * GameForm is the Main Form for Galaxy Trade. This Form manages all other subforms
 * needed to make the complete game. This Form includes key functionality such as
 * advancing the day counter which progresses the game forward and setting the new location
 * of the Player when the Player chooses to leave their current location.
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

namespace Galaxy_Trade
{
    public partial class GameForm : Form
    {

        public Game game;
        public TradeWindow tradeWindow;
        public LocationWindow locationWindow;

        private Point dialogOpenLocation;
        private string nextLocation;

        /**
         * Initial constructor. To be called on a new game.
         */ 
        public GameForm()
        {
            InitializeComponent();
            game = new Game();

            setGameFormSize();

            // Set the location where all dialogue boxes will open at.
            //dialogOpenLocation = buyButton.PointToScreen(Point.Empty); 
            //dialogOpenLocation = buyButton.FindForm().PointToClient(buyButton.Parent.PointToScreen(buyButton.Location));
            //dialogOpenLocation.X -= 200;
            //dialogOpenLocation.Y -= 200;

            setState();
            
        }

        /**
         * To be called once every new day, or at the start of a new game.
         * Adds the Product to the Items list view.
         */
        public void updateItemsInListView()
        {
            itemsListView.Items.Clear();

            foreach (Product p in game.CurrentLocation.CurrentProducts)
            {
                if (itemsListView.FindItemWithText(p.Name) == null)
                {
                    ListViewItem item = new ListViewItem(p.Name);
                    item.SubItems.Add(p.CurrentValue.ToString("C0"));
                    itemsListView.Items.Add(item);
                }
            }
            setBackgroundColorInListView(itemsListView);            
        }

        /**
         * Checks the players inventory, and adds any item name and quantity found 
         * in the inventory to the inventoryListView();
         * If an item already in the listView has it's quantity set to 0 (i.e. the player
         * sold all of the items) then we remove it from the listView.
         */
        public void updateItemsInInventory()
        {
            // SHOULD PROBABLY THINK OF SOMETHING BETTER HERE -----
            inventoryListView.Items.Clear();
            //////////////////////////////////////////////////////

            foreach (string key in game.player.Inventory.Keys)
            {
                ListViewItem currentItem = inventoryListView.FindItemWithText(key);
                // Make sure the item doesn't already exist in the listView, if 
                // it doesn't, add it to the listView
                if (currentItem == null)
                {
                    ListViewItem item = new ListViewItem(key, key);
                    item.SubItems.Add(game.player.Inventory[key].ToString());
                    inventoryListView.Items.Add(item);
                }
                else
                {
                    // if Inventory[key] <= 0 then remove from listView?
                    currentItem.SubItems[1].Text = game.player.Inventory[key].ToString();
                }
            }

            setBackgroundColorInListView(inventoryListView);            
        }

        // CAN WE MESH THESE TWO (buyButton / sellButton) CLICK FUNCTIONS TOGETHER?
        /**
         * Checks to make sure only 1 item is selected in the itemsListView. If so, we get
         * the item info (name, price) from getItemInfo() for the particular item and then 
         * create a TradeWindow for buying with the relevent data.
         */
        private void buyButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = getSelectedItemFromListView(itemsListView); ///< ListViewItem Will be set to null if none/more than 1 item selected.
      
            if (selectedItem != null)
            {
                string name;
                int price;

                getItemInfo(selectedItem, out name, out price);
                createTradeWindow(name, price, true);

                // Unselect the selected item once the TradeWindow returns.
                inventoryListView.SelectedIndices.Clear();
            }
        }

        /**
         * Checks to make sure only 1 item is selected in the inventoryListView. If so, we get
         * the item info (name, price) from getItemInfo() for the particular item and then
         * create a TradeWindow for selling with the relevent data.
         */ 
        private void sellButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = getSelectedItemFromListView(inventoryListView);

            if (selectedItem != null)
            {
                string name;
                int price;

                getItemInfo(selectedItem, out name, out price);
                createTradeWindow(name, price, false);

                // Unselect the selected item once the TradeWindow returns.
                inventoryListView.SelectedIndices.Clear();
            }
        }

        /**
         * Creates either a Buy or Sell TradeWindow as a Dialogue Window.
         * If the user Buys or Sells, update the GameForm to reflect the changes.
         * @param name - the name of the item the player is trying to buy/sell.
         * @param price - the price of the item the player is trying to buy/sell.
         * @param isBuy - flag to notify the TradeWindow whether to be a buy or sell window.
         */ 
        private void createTradeWindow(string name, int price, bool isBuy)
        {
            using (tradeWindow = new TradeWindow(ref game.player, name, price, isBuy))
            {
                //tradeWindow.Pos = dialogOpenLocation;

                Point loc = buyButton.PointToScreen(Point.Empty);
                loc.X -= 200;
                loc.Y -= 200;
                tradeWindow.Pos = loc;

                DialogResult result = tradeWindow.ShowDialog();
                if (result == DialogResult.OK)
                {
                    setState();
                }
            }
        }
        
        /**
         * Gets the name and price for the selected item in a particular ListView.
         * @param lvi - The currently selected item in a list view.
         * @param {Out} name - The name of the selected item in the ListView.
         * @param {Out} price - The price of the selected item in the ListView.
         */ 
        private void getItemInfo(ListViewItem lvi, out string name, out int price)
        {
            name = "ERROR NAME NOT FOUND";
            price = -1;

            foreach (Product p in game.Products)
            {
                if (lvi.SubItems[0].Text == p.Name)
                {
                    name = p.Name;
                    price = p.CurrentValue;
                }
            }           
        }

        /**
         * Sets an alternating background color for items in a certain ListView.
         * Pattern is - even: light gray, odd: white
         * @param view - The ListView you want to apply the background pattern to.
         */ 
        private void setBackgroundColorInListView(ListView view)
        {
            foreach (ListViewItem item in view.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.LightGray : Color.WhiteSmoke;
            }
        }

        /**
         * Returns the selected item from a ListView. Will only accept 1 item being selected.
         * @param view - The ListView you want the selected item from.
         * @return The selected item from the list view. will return NULL if 0 or more than 1 items 
         * are currently selected in the view.
         */
        private ListViewItem getSelectedItemFromListView(ListView view)
        {
            if (view.SelectedItems.Count != 1)
            {
                return null;
            }
            return view.SelectedItems[0];
        }

        /**
         * Removes the currently selected item from the inventoryListView. This
         * also completely removes the item from the Players Inventory. Updates the
         * inventoryListView to reflect that the item has been removed. No money is
         * gained by the player with this action.
         */ 
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

        /**
         * Creates a new LocationWindow as a Dialogue Window.
         * This is used for the player to select a new location to travel to.
         * Once the player has selected a new location (other than the current location)
         * The day counter is advanced and the GameForm is remade to reflect the new location.
         */ 
        private void travelButton_Click(object sender, EventArgs e)
        {
            using (locationWindow = new LocationWindow(game.Locations, game.CurrentLocation.Name))
            {
                Point loc = buyButton.PointToScreen(Point.Empty);
                loc.X -= 200;
                loc.Y -= 200;
                locationWindow.Pos = loc;

                DialogResult result = locationWindow.ShowDialog();
                nextLocation = locationWindow.NextLocation;

                if (result == DialogResult.OK)
                {
                    // Change the day here
                    changeLocation();
                }
            }
        }

        /**
         * Event callback that happens when the Player travels to a new location.
         * This event calls game.update() (changes location, advances the day etc).
         * If any events trigger from game.update(), this function will display
         * the event message for that event. This also calls setState() to set up
         * the GameForm to show the correct information once the Player has traveled to
         * a new location.
         */ 
        private void changeLocation()
        {            
            game.update(nextLocation);

            eventTextBox.Clear();

            if (game.playerEvents.Message.Count > 0)
            {
                foreach (string s in game.playerEvents.Message)
                {
                    eventTextBox.AppendText(s);
                }
            }

            if (game.itemEvents.Message.Count > 0)
            {
                foreach (string s in game.itemEvents.Message)
                {
                    eventTextBox.AppendText(s);
                }
            }
            
            setState();
        }

        /**
         * Sets the state for the GameForm.
         * This is used to update the Labels and ListViews in one single call.
         */ 
        private void setState()
        {
            // Update the text labels
            dayCounterLabel.Text = "Day " + game.Day.ToString() + "/" + game.GameLength.ToString();

            debtValLabel.Text = game.player.Debt.ToString("C0");
            cashValLabel.Text = game.player.Money.ToString("C0");

            spaceValLabel.Text = game.player.InventorySlots.ToString();

            locationNameLabel.Text = game.CurrentLocation.Name;

            healthValLabel.Text = game.player.Health.ToString();

            // Update the list views
            updateItemsInListView();
            updateItemsInInventory();
        }

        /**
         * Sets up the labels and numeric up down of the errand panel.
         */ 
        private void setErrandPanelState()
        {
            errandCashValLabel.Text = game.player.Money.ToString("C0");
            errandDebtValLabel.Text = game.player.Debt.ToString("C0");
            errandNumUpDn.Minimum = 0;
            errandNumUpDn.Maximum = game.player.Money > game.player.Debt ? game.player.Debt : game.player.Money;
            errandNumUpDn.Value = 0;
        }

        /**
         * Sets the size of the GameForm Form. This is needed because we put the
         * errandPanel on top of the itemAndInvPanel and we want to resize the
         * form to get rid of the empty space at the bottom.
         */ 
        private void setGameFormSize()
        {
            Point pt = itemAndInvPanel.Location;
            errandPanel.Location = pt;

            Size cliSize = this.ClientSize;
            cliSize.Height = this.ClientSize.Height - errandPanel.Height;
            this.ClientSize = cliSize;
        }

        /**
         * Make sure the GameForm closes properly.
         */ 
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //tradeWindow.Close();
            Application.Exit();
        }

        /**
         * Makes function calls to setErrandPanelState() and showErrandPanel() to setup 
         * the state of the errandPanel and then shows the errandPanel in the place of
         * the itemAndInvPanel's place.
         */ 
        private void errandsButton_Click(object sender, EventArgs e)
        {
            setErrandPanelState();
            showErrandPanel();            
        }

        /**
         * The Player has canceled the current Errand option, hide the errandPanel and
         * show the itemAndInvPanel in its place.
         */ 
        private void errandCancelBtn_Click(object sender, EventArgs e)
        {
            hideErrandPanel();
        }

        /**
         * Hides the itemAndInvPanel and shows the errandPanel in its place.
         */ 
        private void showErrandPanel()
        {
            if (!errandPanel.Visible)
            {
                errandPanel.Show();
            }
            if (itemAndInvPanel.Visible)
            {
                itemAndInvPanel.Hide();
            }
        }

        /**
         * Hides the errandPanel and shows the itemAndInvPanel in its place.
         */ 
        private void hideErrandPanel()
        {
            if (!itemAndInvPanel.Visible)
            {
                itemAndInvPanel.Show();
            }
            if (errandPanel.Visible)
            {
                errandPanel.Hide();
            }
        }

        /**
         * The Player has chosen to either pay money to the Loan Shark or deposit
         * money in the bank. Update the players money / debt / bank accordingly
         * then hide the errandPanel and show the itemAndInvPanel in its place.
         * Updates the GameForm afterward to reflect the errand changes.
         */ 
        private void errandSubmitBtn_Click(object sender, EventArgs e)
        {
            if (errandNumUpDn.Value > 0)
            {
                game.player.Money -= (int)errandNumUpDn.Value;
                game.player.Debt -= (int)errandNumUpDn.Value;
                hideErrandPanel();
                setState();
            }
            else
            {
                hideErrandPanel();
            }
        }
    }
}


// MessageBox.Show("Text Here", "Something", MessageBoxButtons.OK, MessageBoxIcon.None);