using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
    class Player
    {
        public Dictionary<Product, int> inventory; //<key, val>

        private int money;
        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        private int debt;
        public int Debt
        {
            get { return debt; }
            set { debt = value; }
        }

        private int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        // Use this constructor if starting a new game
        public Player()
        {
            money = 2000;
            debt = 5500;
            health = 100;
            inventory = new Dictionary<Product, int>();
        }
    }
}
