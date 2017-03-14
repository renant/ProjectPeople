using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPeople.Domain.Interfaces
{
    public interface IEntity
    {
        string Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
