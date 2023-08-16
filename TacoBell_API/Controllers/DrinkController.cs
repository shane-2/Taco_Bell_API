using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBell_API.Models;

namespace TacoBell_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();
        //api/Drink
        [HttpGet]
        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        //api/Drink/1
        [HttpGet("{Id}")]
        public Drink GetById(int Id)
        {
            return dbContext.Drinks.FirstOrDefault(c => c.Id == Id);
        }

        [HttpPost]
        public Drink AddDrink(string name, float price, bool slushie)
        {
            Drink newDrink = new Drink();
            newDrink.Name = name;
            newDrink.Cost = price;
            newDrink.Slushie = slushie;
            dbContext.Drinks.Add(newDrink);
            dbContext.SaveChanges();
            return newDrink;
        }


        //api/Drink/Delete/1
        [HttpDelete("Delete/{Id}")]
        public Drink DeleteDrink(int Id)
        {
            Drink d = dbContext.Drinks.FirstOrDefault(b => b.Id == Id);
            dbContext.Drinks.Remove(d);
            dbContext.SaveChanges();
            return d;
        }



    }
}
