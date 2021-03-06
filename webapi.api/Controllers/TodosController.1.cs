﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.api.Models;

namespace webapi.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {   
        mosheaContext context;
        public TodosController(mosheaContext context) {
            this.context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Todos> Get()
        {
            return context.Todos.ToList<Todos>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Todos> Get(int id)
        {
            return Ok(context.Todos.Find(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
