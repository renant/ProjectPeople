using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectPeople.Domain.Entities;

namespace ProjectPeople.Domain.Interfaces.IServices
{
    public interface IServicePeople
    {
        Task<Person> Get(FilterDefinition<Person> filter);
        Task<IEnumerable<Person>> Find(FilterDefinition<Person> filter);
        Task<Person> Insert(Person person);
        Task<Person> Update(Person person);
        Task<Person> Delete(string id);
    }
}
