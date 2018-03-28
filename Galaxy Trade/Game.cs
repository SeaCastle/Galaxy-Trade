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
        public Location currenLocation;

        private Product[] products;
        private string[] locations;
        private int day;
        private int gameLength; ///< int Total length of the game in days
        
        public struct Location
        {
            public string name;
            public List<Product> currentProducts;

            private Product[] totalProducts;

            public Location(string name, Product[] p)
            {
                this.name = name;
                totalProducts = p;

                currentProducts = setCurrentProducts();
            }

            public List<Product> setCurrentProducts()
            {
                int total = 0;

                Random rnd = new Random();
                int num = rnd.Next(101);

                if (num == 1)
                {
                    total = 6;
                }
                else if (num <= 4 && num > 1)
                {
                    total = 8;
                }
                else if (num > 4 && num <= 17)
                {
                    total = 9;
                }
                else if (num > 17 && num <= 48)
                {
                    total = 10;
                }
                else if (num > 48 && num <= 80)
                {
                    total = 11;
                }
                else if (num > 80)
                {
                    total = 12;
                }

                for (int i = 0; i < total; i++)
                {

                }
            }
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
            currentLocation = locations[0];

            day = 1;
            gameLength = 30;
        }
    }
}
