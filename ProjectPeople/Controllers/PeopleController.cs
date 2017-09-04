using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProjectPeople.API.Extensions;
using ProjectPeople.API.Responses;
using ProjectPeople.API.Responses.IResponses;
using ProjectPeople.Domain.Entities;
using ProjectPeople.Domain.Interfaces.IServices;
using ProjectPeople.Responses;

namespace ProjectPeople.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IServicePeople _servicePeople;

        public PeopleController(IServicePeople servicePeople)
        {
            _servicePeople = servicePeople;
        }
        

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var response = new SingleResponseModel<Person>();

            try
            {
                var entity = await _servicePeople.Get(new FilterDefinitionBuilder<Person>().Where(x => x.Id == id));

                response.Model = entity;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = new ListResponseModel<Person>();

            try
            {
                var entity = await _servicePeople.Find(FilterDefinition<Person>.Empty);

                response.Model = entity;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Person person)
        {
            var response = new SingleResponseModel<Person>() as ISingleResponseModel<Person>;

            try
            {
                var entity = await _servicePeople.Insert(person);

                response.Model = entity;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Person person)
        {
            var response = new SingleResponseModel<Person>() as ISingleResponseModel<Person>;

            try
            {
                var entity = await _servicePeople.Update(person);

                response.Model = entity;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var response = new SingleResponseModel<Person>() as ISingleResponseModel<Person>;

            try
            {
                var entity = await _servicePeople.Delete(id);

                response.Model = entity;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return response.ToHttpResponse();
        }
    }
}
