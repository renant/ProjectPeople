using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProjectPeople.Domain.Entities;
using ProjectPeople.Domain.Interfaces.IServices;

namespace ProjectPeople.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IServicePeople _servicePeople;

        public PeopleController(IServicePeople servicePeople)
        {
            _servicePeople = servicePeople;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<Person>> Get()
        {
            var model = await _servicePeople.Find(FilterDefinition<Person>.Empty);

            return model.ToList();
        }

        // GET api/values/5
        [HttpGet]
        public async Task<Person> Bla()
        {
            var add = new Person() {Age = 23, Email = "teste2@teste.com", Name = "Teste2"};

            var model = await _servicePeople.Insert(add);

            return model;
        }

    }
}
