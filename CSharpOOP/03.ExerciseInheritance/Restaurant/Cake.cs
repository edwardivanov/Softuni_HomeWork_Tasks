﻿
namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams,calories)
        {            
        }

        public Cake(string name) : base(name)
        {
            this.Grams = 250;
            this.Calories = 1000;
            this.Price = 5m;
        }
    }
}
