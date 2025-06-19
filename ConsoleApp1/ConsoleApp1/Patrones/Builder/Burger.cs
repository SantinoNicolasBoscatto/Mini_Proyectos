using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Builder
{
    public class Burger
    {
        public string? Bread { get; set; }
        public string? Meat { get; set; }
        public string? Cheese { get; set; }
        public string? Dressing { get; set; }
        public bool Tomato { get; set; }
        public bool Lettuce { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine("Burger order:");
            Console.WriteLine($"Bread: {Bread}");
            Console.WriteLine($"Meat: {Meat}");
            Console.WriteLine($"Cheese: {Cheese}");
            Console.WriteLine($"Dressing: {Dressing}");
            Console.WriteLine($"Tomato: {Tomato}");
            Console.WriteLine($"Lettuce: {Lettuce}");
        }
    }

    public interface IBurgerBuilder
    {
        void BuildBread();
        void BuildMeat();
        void BuildCheese();
        void BuildDressing();
        void BuildTomato();
        void BuildLettuce();
        Burger GetBurger();
    }

    public class ClassicBurgerBuilder : IBurgerBuilder
    {
        private Burger _burger = new Burger();
        public void BuildTomato()
        {
            _burger.Tomato = true;
        }
        public void BuildLettuce()
        {
            _burger.Lettuce = false;
        }
        public void BuildBread()
        {
            _burger.Bread = "Common";
        }
        public void BuildCheese()
        {
            _burger.Cheese = "Chedar";
        }
        public void BuildDressing()
        {
            _burger.Dressing = "Ketchup";
        }
        public void BuildMeat()
        {
            _burger.Meat = "Res Meat";
        }
        public Burger GetBurger()
        {
           return _burger;
        }
    }
    public class VeggieBurgerBuilder : IBurgerBuilder
    {
        private Burger _burger = new Burger();

        public void BuildTomato()
        {
            _burger.Tomato = true;
        }
        public void BuildLettuce()
        {
            _burger.Lettuce = true;
        }
        public void BuildBread()
        {
            _burger.Bread = "Veggie Bread";
        }
        public void BuildCheese()
        {
            _burger.Cheese = "None";
        }
        public void BuildDressing()
        {
            _burger.Dressing = "Mustard";
        }
        public void BuildMeat()
        {
            _burger.Meat = "Veggie Meat";
        }
        public Burger GetBurger()
        {
            return _burger;
        }
    }

    // Otra manera y mas realista de implementar el director, donde este no define los datos, sino que el mismo constructor
    // Define los datos y el director solo da la orden de construccion
    public class BurgerDirector
    {
        private IBurgerBuilder _burgerBuilder;
        public BurgerDirector(IBurgerBuilder burgerBuilder)
        {
            _burgerBuilder = burgerBuilder;
        }

        public void MakeBurger()
        {
            _burgerBuilder.BuildBread();
            _burgerBuilder.BuildMeat();
            _burgerBuilder.BuildCheese();
            _burgerBuilder.BuildDressing();
            _burgerBuilder.BuildTomato();
            _burgerBuilder.BuildLettuce();
        }
    }
}
