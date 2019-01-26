using System;
using System.Collections.Generic;
using System.Linq;
using Persons.Shared.Exceptions;
using Persons.Shared.Models;

namespace Persons.Shared.Services
{
	public class PersonsRepository : IPersonsRepository
	{
		private List<Person> _persons = new List<Person>();

		public void Add(Person person)
		{
			try
			{
				person.Id = AssignId();
				_persons.Add(person);
			}
			catch (Exception e)
			{
				throw new PersonAddException(e.Message);
			}
		}

		public IEnumerable<Person> Get()
		{
			return _persons;
		}

		public Person GetById(int Id)
		{
			return _persons.Where(y => y.Id == Id).SingleOrDefault();
		}

		public void Remove(Person person)
		{
			try
			{
				_persons.Remove(person);
			}
			catch(Exception e)
			{
				throw new PersonRemoveException(e.Message);
			}
		}

		public void Update(Person person)
		{
			try
			{
				Person p = GetById(person.Id);
				p = person;
			}
			catch(Exception e)
			{
				throw new PersonUpdateException(e.Message);
			}
		}

		public void GenerateSampleData()
		{
			Add(new Person
			{
				FirstName = "Dawid",
				LastName = "Borycki",
				Age = 34,
				Email = "dawid@borycki.com.pl"
			});

			Add(new Person
			{
				FirstName = "Jan",
				LastName = "Kowalski",
				Age = 42,
				Email = "Janusz@kowalski.com.pl"
			});
		}

		private int AssignId()
		{
			var id = 1;
			if (_persons.Count > 0)
			{
				id = _persons.Max(x => x.Id) + 1;
			}

			return id;
		}
	}
}
