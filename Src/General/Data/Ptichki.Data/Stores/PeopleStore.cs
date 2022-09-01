using System;
using System.Collections.Generic;
using Ptichki.Domain.Models;

namespace Ptichki.Data.Stores
{
    public class PeopleStore
    {
        public event Action<Person> PersonAdded;
        public event Action<IEnumerable<Person>> PeopleAdded;

        public void AddPerson(Person person)
        {
            PersonAdded?.Invoke(person);
        }

        public void AddPeople(IEnumerable<Person> people)
        {
            PeopleAdded?.Invoke(people);
        }
    }
}
