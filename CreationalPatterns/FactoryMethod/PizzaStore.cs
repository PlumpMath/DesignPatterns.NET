﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.FactoryMethod
{

    public abstract class PizzaStore
    {
        public Pizza OrderPizza(PizzaType type)
        {
            // calls the factory method to create pizza
            Pizza pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }

        // A facotry method
        //    1. is abstract so the subclass are counted on to handle object creation.
        //    2. returns a Product.
        //    3. isolates the client from knowing what of concrete Product is actually created.
        //    4. may be parameterized (or not) to select among several variations of a product.
        protected abstract Pizza CreatePizza(PizzaType type);
    }

    public class AmericanPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(PizzaType type)
        {
            switch (type)
            {
                case PizzaType.Cheese:
                    return new AmericanCheesePizza();
                case PizzaType.Veggie:
                    return new AmericanVeggiePizza();
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public class ItalianPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(PizzaType type)
        {
            switch (type)
            {
                case PizzaType.Cheese:
                    return new ItalianCheesePizza();
                case PizzaType.Veggie:
                    return new ItalianVeggiePizza();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
