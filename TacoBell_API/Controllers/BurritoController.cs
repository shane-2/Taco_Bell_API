using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoBell_API.Models;

namespace TacoBell_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurritoController : ControllerBase
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();
        //api/Burrito
        [HttpGet]
        public List<Burrito> GetAll()
        {
            return dbContext.Burritos.ToList();
        }

        //api/Burrito/1
        [HttpGet("{Id}")]
        public Burrito GetById(int Id)
        {
            return dbContext.Burritos.FirstOrDefault(c => c.Id == Id);
        }

        [HttpPost]
        public Burrito AddBurrito(string name, float price, bool bean)
        {
            Burrito newBurrito = new Burrito();
            newBurrito.Name = name;
            newBurrito.Cost = price;
            newBurrito.Bean = bean;
            dbContext.Burritos.Add(newBurrito);
            dbContext.SaveChanges();
            return newBurrito;
        }


        //api/Burrito/Delete/1
        [HttpDelete("Delete/{Id}")]
        public Burrito DeleteBurrito(int Id)
        {
            Burrito b = dbContext.Burritos.FirstOrDefault(b => b.Id == Id);
            dbContext.Burritos.Remove(b);
            dbContext.SaveChanges();
            return b;
        }

        //api/Burritos/1?cost=158
        [HttpPatch("{Id}")]
        // float price pulls from url link
        public Burrito UpdateAge(int Id, float cost)
        {
            Burrito c = dbContext.Burritos.FirstOrDefault(c => c.Id == Id);
            c.Cost = cost;
            dbContext.Burritos.Update(c);
            dbContext.SaveChanges();

            return c;
        }










    }
}
