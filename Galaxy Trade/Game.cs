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

namespace Galaxy_Trade
{
    public class Game
    {
        public Player player;

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

            locations = new string[5] { "Earth", "Mars", "Venus", "Moon", "Sun" };
            currentLocation = new Location(locations[0], products);

            day = 1;
            gameLength = 30;
        }
    }
}
