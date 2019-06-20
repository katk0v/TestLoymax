using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TestLoymax.Models;

namespace TestLoymax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        ClientsContext db;

        public ClientsController(ClientsContext context)
        {
            this.db = context;
            if (!db.Clients.Any())
            {
                db.Clients.Add(new Client
                {
                    Name = "Ivan",
                    Surname = "Rudov",
                    MiddleName = "Andreevich",
                    DateOfBirth = DateTime.Parse("1994-4-20"),
                    Deposit = 1000M
                });
                db.Clients.Add(new Client
                {
                    Name = "Dmitriy",
                    Surname = "Izotov",
                    MiddleName = "Andreevich",
                    DateOfBirth = DateTime.Parse("1994-5-02"),
                    Deposit = 2000M
                });
                db.Clients.Add(new Client
                {
                    Name = "Vladimir",
                    Surname = "Katkov",
                    MiddleName = "Vladimirovich",
                    DateOfBirth = new DateTime(1994, 01, 15),
                    Deposit = 3000M
                });
                db.Clients.Add(new Client
                {
                    Name = "Pavel",
                    Surname = "Kireev",
                    MiddleName = "Aleksandrovich",
                    DateOfBirth = new DateTime(1994, 06, 21),
                    Deposit = 4000M
                });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Client> Get() //получить всю информацию по всем клиентам
        {
            return db.Clients.ToList();
        }

        // GET api/clients/id
        [HttpGet("{id}")]
        public IActionResult Get(int id) //получить информацию по конкретному клиенту по ID
        {
            Client client = db.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
                return NotFound();
            return new ObjectResult(client);
        }

        // POST api/clients
        [HttpPost]
        public IActionResult Post([FromBody]Client client) //зарегистрировать нового клиента
        {
            if (client == null)
            {
                return BadRequest();
            }

            db.Clients.Add(client);
            db.SaveChanges();
            return Ok(client);
        }

        // PUT api/clients/
        [HttpPut]
        public IActionResult Put([FromBody]Client client) //редактировать существующего клиента
        {
            if (client == null)
            {
                return BadRequest();
            }
            if (!db.Clients.Any(x => x.Id == client.Id))
            {
                return NotFound();
            }

            db.Update(client);
            db.SaveChanges();
            return Ok(client);
        }

        // DELETE api/clients/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //удалить клиента по ID
        {
            Client client = db.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            db.Clients.Remove(client);
            db.SaveChanges();
            return Ok(client);
        }



        // PUT api/clients/1?change=5000 начислить 5000 клиенту с Id=1
        // PUT api/clients/3?change=-5000 списать 5000 с клиента с Id=3
        [HttpPut("{id}")]
        public IActionResult ChangeAmount (int id, decimal change)
        {
            Client client = db.Clients.FirstOrDefault(x => x.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            client.Deposit += change;
            db.Update(client);
            db.SaveChanges();

            return new ObjectResult(client.Deposit);
        }
    }
}