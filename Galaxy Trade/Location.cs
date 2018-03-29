using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy_Trade
{
    public class Location
    {
        private string name;
        private Product[] allProducts;
        private List<Product> currentProducts;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public List<Product> CurrentProducts
        {
            get => currentProducts;
        }

        public Location(string name, Product[] p)
        {
            this.name = name;
            allProducts = p;
            currentProducts = new List<Product>();
            updateCurrentProducts();
        }

        public void updateCurrentProducts()
        {
            Random rnd = new Random();
            int totalProducts = getTotalProducts();

            foreach (Product p in allProducts)
            {
                p.updateCurrentValue(1.0);
            }

            // No need to reroll over and over again to try and fill a list
            // with every unique item except for only a few. Instead, we start
            // with a full list and remove only a few items.
            if (currentProducts.Count > 0)
            {
                currentProducts.Clear();
            }
            currentProducts.AddRange(allProducts);

            for (int i = 0; i < allProducts.Length - totalProducts; i++)
            {
                int k = rnd.Next(currentProducts.Count);

                currentProducts.RemoveAt(k);
            }                  
        }

        private int getTotalProducts()
        {
            int totalProducts = 0;

            Random rnd = new Random();
            int num = rnd.Next(100) + 1;

            // How many products is the current location going to have?
            if (num == 1)
            {
                totalProducts = 6; // 1% chance
            }
            else if (num <= 4)
            {
                totalProducts = 8; // 3% chance
            }
            else if (num <= 17)
            {
                totalProducts = 9; // 13% chance
            }
            else if (num <= 48)
            {
                totalProducts = 10; // 31% chance
            }
            else if (num <= 80)
            {
                totalProducts = 11; // 32% chance
            }
            else if (num > 80)
            {
                totalProducts = 12; // 20% chance
            }

            return totalProducts;
        }
    }
}



/*
            else
            {
                for (int i = 0; i < totalProducts; i++)
                {
                    int k = rnd.Next(allProducts.Length);

                    // Search the List to see if we already have that product in the currentProducts.
                    Product p = currentProducts.Find(x => x.Name == allProducts[k].Name);
                    while (p != null)
                    {
                        k = rnd.Next(allProducts.Length);
                        p = currentProducts.Find(x => x.Name == allProducts[k].Name);
                    }
                    currentProducts.Add(allProducts[k]);
                }
            }
            */
