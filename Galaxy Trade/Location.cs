﻿/**
 * Location.cs is a class that holds all the information and functionality for a Location in
 * Galaxy Trade. This includes holding all the current Products for that location and the locations
 * name. Due to the nature of the list of products changing so frequently, it makes more
 * sense to only have 1 Location that is the players current location and just updating this one
 * object.
 */
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

        /**
         * Initial constructor.
         * @param name - The name of the current Location
         * @param p - A reference to the master set of Products
         */ 
        public Location(string name, ref Product[] p)
        {
            this.name = name;
            allProducts = p;
            currentProducts = new List<Product>();
            updateCurrentProducts();
        }

        /**
         * Decides how many Products the current location will have and then generates
         * a List of unique Products based on that number.
         */ 
        public void updateCurrentProducts()
        {
            Random rnd = new Random();
            int totalProducts = getTotalProducts();
           
            if (currentProducts.Count > 0)
            {
                currentProducts.Clear();
            }

            // No need to reroll over and over again to try and fill a list
            // with every unique item except for only a few. Instead, we start
            // with a full list and remove only a few items.
            currentProducts.AddRange(allProducts);

            for (int i = 0; i < allProducts.Length - totalProducts; i++)
            {
                int k = rnd.Next(currentProducts.Count);

                currentProducts.RemoveAt(k);
            }                  
        }

        /**
         * Decides how many Products (weighted) there will be for the day.
         * Currently there can be 6, 8, 9, 10, 11, or 12 Products at a current
         * location in a given day.
         */ 
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
