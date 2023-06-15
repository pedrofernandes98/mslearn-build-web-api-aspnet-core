using Microsoft.AspNetCore.Mvc;
using PH_ContosoPizza.Models;
using PH_ContosoPizza.Services;

namespace PH_ContosoPizza.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll()
        {
            return PizzaService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Pizza?> Get(int id)
        {
            var pizza = PizzaService.GetById(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest($"O Id da rota {id} é diferente do Id do objeto passado no body {pizza.Id}");

            var pizzaExists = PizzaService.GetById(pizza.Id);

            if (pizzaExists == null)
                return NotFound();

            PizzaService.Update(pizza);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var pizzaExists = PizzaService.GetById(id);

            if(pizzaExists == null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}
