/**
 * Game is a class to store the state of the game in Galaxy Trade. This class
 * holds all the information necessary to manage Galaxy Trade and is to be used
 * by GameForm.cs
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Galaxy_Trade.Events;

namespace Galaxy_Trade
{
    public class Game
    {
        public Player player;
        public PlayerEvents playerEvents;
        public ItemEvents itemEvents;

        private Location currentLocation;
        private Product[] products;
        private string[] locations;
        private int day;
        private int gameLength; ///< int Total length of the game in days

        public Location CurrentLocation
        {
            get => currentLocation;
        }

        public Product[] Products
        {
            get => products;
        }

        public string[] Locations
        {
            get => locations;
        }

        public int Day
        {
            get => day;
            set => day = value;
        }

        public int GameLength
        {
            get => gameLength;
        }

        /**
         * Initial Game constructor.
         * This sets up all the variables needed to run Galaxy Trade.
         * This is to be used at the start of a new game.
         */ 
        public Game()
        {
            player = new Player();
            products = new Product[12]
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

            playerEvents = new PlayerEvents(7, ref player, ref products);
            itemEvents = new ItemEvents(35, ref products);

            locations = new string[5] { "Earth", "51 Pegasi B", "Kepler-452b", "Gliese 876d", "PSR B1257+12 A" };
            currentLocation = new Location(locations[0], ref products);

            day = 1;
            gameLength = 30;
        }

        /**
         * Updates the current state of the game. This includes: increasing the day counter,
         * increasing Player debt (if any), updating the current value of all products, running
         * both Player and Item events, and updating our location (name, current products), or
         * ending the game if the Player has reached the end.
         * @param nextLoc - The name of the next location the player has chosen to travel to.
         */ 
        public void update(string nextLoc)
        {            
            if (!gameOver())
            {
                day += 1;

                playerEvents.clearMessage();
                itemEvents.clearMessage();

                if (player.Debt > 0)
                {
                    player.Debt += (int)(player.Debt * 0.1);
                }

                if (player.Savings > 0)
                {
                    player.Savings += (int)(player.Savings * 0.05);
                }

                foreach (Product p in products)
                {
                    p.updateCurrentValue();
                }

                // Run Player Events
                if (playerEvents.isActive())
                {
                    playerEvents.chooseEvent();
                }

                // run Item Events
                if (itemEvents.isActive())
                {
                    itemEvents.chooseEvent();
                }

                // Update location
                currentLocation.Name = nextLoc;
                currentLocation.updateCurrentProducts();
            }
            else
            {
                int score = (player.Money + player.Savings) - (player.Debt * 2);

                string m = String.Format("Congratulations! You made it to the end and have seen that I don't " +
                    "have a proper screen for the game over :( \nAnyway, your score was: {0:n0}! Is that all you" +
                    " got? Sigh.", score);

                MessageBox.Show(m, "Game Over!", MessageBoxButtons.OK);
                Application.Exit();
            }            
        }

        /**
         * Checks whether the game is over or not.
         * @return - False if we haven't hit the game length yet, True otherwise.
         */ 
        private bool gameOver()
        {
            return (day >= gameLength);
        }
    }    
}
