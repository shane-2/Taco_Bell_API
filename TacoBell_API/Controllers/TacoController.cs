using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBell_API.Models;

namespace TacoBell_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();
        //api/Taco
        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }

        //api/Taco/1
        [HttpGet("{Id}")]
        public Taco GetById(int Id)
        {
            return dbContext.Tacos.FirstOrDefault(c => c.Id == Id);
        }

        [HttpPost]
        public Taco AddTaco(string name, float price, bool softShell, bool dorito)
        {
            Taco newTaco = new Taco();
            newTaco.Name = name;
            newTaco.Cost = price;
            newTaco.SoftShell = softShell;
            newTaco.Dorito = dorito;
            dbContext.Tacos.Add(newTaco);
            dbContext.SaveChanges();
            return newTaco;
        }


        //api/Taco/Delete/1
        [HttpDelete("Delete/{Id}")]
        public Taco DeleteTaco(int Id)
        {
            Taco t = dbContext.Tacos.FirstOrDefault(b => b.Id == Id);
            dbContext.Tacos.Remove(t);
            dbContext.SaveChanges();
            return t;
        }





    }
}
