using ProjectPeople.Domain.Entities;
using ProjectPeople.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace ProjectPeople.Infra.Repositories
{
    public class RepositoryPeople : RepositoryBase<Person>, IRepositoryPeople
    {
        public RepositoryPeople(MongoClient client) : base(client)
        {
        }
    }
}
