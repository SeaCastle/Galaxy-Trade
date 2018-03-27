/**
 * LocationWindow is a Form used to allow the Player to travel to a new location in the game.
 * This is a simple form with 5 location buttons and an accept / cancel option. If the Player 
 * accepts, the new location is sent to GameForm.cs and the GameForm is updated to advance 1 day
 * in time at the new location. This class is to be instantiated by GameForm.cs - The main Form for Galaxy Trade.
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
    public partial class LocationWindow : Form
    {
        private Button[] locationBtns;
        private Button currentButton; ///< string used to know which location button was last clicked.
        private string currentLocation;
        private string nextLocation;

        public string NextLocation
        {
            get => nextLocation;
            private set => nextLocation = value;
        }

        /**
         * Location Window constructor.
         * Sets the button text to reflect the names of the locations in the game.
         * @param locations - Array of the locations in the game
         * @param currentLocation - Used to make sure the player cannot travel to their
         * current location.
         */ 
        public LocationWindow(string[] locations, string currentLocation)
        {
            InitializeComponent();
            acceptBtn.Enabled = false;

            this.currentLocation = currentLocation;
            locationBtns = new Button[5]
            {
                locationBtn1,
                locationBtn2,
                locationBtn3,
                locationBtn4,
                locationBtn5
            };

            // locations and locationBtns should ALWAYS be the same length.
            for (int i = 0; i < locationBtns.Length; i++)
            {
                locationBtns[i].Text = locations[i];
            }
        }

        /**
         * Sets the currentButton to the button that was just clicked. Also 
         * checks whether the current location button clicked is equal to the 
         * Player's current location. If so, disbale to accept button because the
         * Player must travel to a new location.
         */ 
        private void locationBtn_Click(object sender, EventArgs e)
        {
            currentButton = sender as Button;

            if (currentButton.Text == currentLocation)
            {
                acceptBtn.Enabled = false;
            }
            else
            {
                acceptBtn.Enabled = true;
            }
        }

        /**
         * Sets the NextLocation property to the location the Player just
         * chose to travel to. This is used to update the GameForm to know
         * where to travel to next.
         */ 
        private void acceptBtn_Click(object sender, EventArgs e)
        {
            NextLocation = currentButton.Text;
            this.DialogResult = DialogResult.OK;
        }

        /**
         * Tells the Parent Form that the Player has cancelled the Dialogue Window.
         */ 
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
