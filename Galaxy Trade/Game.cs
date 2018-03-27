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
        public Product[] products;
        public string[] locations;
        public int day;
        public int gameLength; ///< int Total length of the game in days

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

            locations = new string[5] { "Mars", "Earth", "Venus", "Moon", "Sun" };

            day = 0;
            gameLength = 30;
        }
    }
}
