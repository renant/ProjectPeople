using ProjectPeople.Domain.Interfaces.IRepositories;
using ProjectPeople.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectPeople.Domain.Entities;

namespace ProjectPeople.Domain.Services
{
    public class ServicePeople : IServicePeople
    {
        private readonly IRepositoryPeople _repositoryPeople;

        public ServicePeople(IRepositoryPeople repositoryPeople)
        {
            _repositoryPeople = repositoryPeople;
        }

        public Task<Person> Get(FilterDefinition<Person> filter)
        {
            return _repositoryPeople.Get(filter);
        }

        public Task<IEnumerable<Person>> Find(FilterDefinition<Person> filter)
        {
            return _repositoryPeople.Find(filter);
        }

        public Task<Person> Insert(Person people)
        {
            return _repositoryPeople.Insert(people);
        }

        public Task<Person> Update(Person people)
        {
            return _repositoryPeople.Update(people);
        }

        public Task<Person> Delete(string id)
        {
            return _repositoryPeople.Delete(id);
        }
    }
}
