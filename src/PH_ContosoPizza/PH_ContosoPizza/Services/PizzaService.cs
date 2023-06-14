using PH_ContosoPizza.Models;

namespace PH_ContosoPizza.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }

        static int NextId = 3;

        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? GetById(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(Pizza pizza)
        {
            pizza.Id = NextId++;
            Pizzas.Add(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.IndexOf(pizza);
            //Pizzas.FindIndex(pizza.Id == pizza.Id);
            if (index <= 0)
                return;

            Pizzas[index] = pizza;
        }

        public static void Delete(int id)
        {
            var pizza = GetById(id);

            if (pizza == null) return;

            Pizzas.Remove(pizza);
        }
    }
}
