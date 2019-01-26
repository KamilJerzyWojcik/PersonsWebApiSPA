using Persons.Shared.Models;
using System.Collections.Generic;

namespace Persons.Shared.Services
{
	public interface IPersonsRepository
	{
		IEnumerable<Person> Get();
		Person GetById(int Id);
		void Add(Person person);
		void Update(Person person);
		void Remove(Person person);
	}
}
