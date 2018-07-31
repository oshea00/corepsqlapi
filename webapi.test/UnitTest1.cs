using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using webapi.api.Models;
using webapi.api.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class Tests
    {
        DbContextOptions<mosheaContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<mosheaContext>()
                .UseInMemoryDatabase("todos")
                .Options;
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestTodosController()
        {
            using (var ctx = new mosheaContext(_options)) {
                var c = new TodosController(ctx);
                ctx.Todos.Add(new Todos { Id = 1, Description = "test", Iscomplete = false});
                ctx.SaveChanges();
                var all = c.Get();
                Assert.AreEqual(1,all.Count());
                Assert.AreEqual("test",all.ToList()[0].Description);
            }
        }
    }
}