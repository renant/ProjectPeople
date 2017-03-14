using ProjectPeople.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPeople.Domain.Entities
{
    public class Person : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
