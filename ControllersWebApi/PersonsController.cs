using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persons.Shared.Models;
using Persons.Shared.Services;


namespace Persons.Web3.Controllers
{
	[Route("api/[controller]")]
	public class PersonsController : Controller
	{
		private IPersonsRepository _persons;

		public PersonsController(IPersonsRepository persons)
		{
			_persons = persons;
		}

		[HttpGet]
		public IEnumerable<Person> Get()
		{
			return _persons.Get();
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var person = _persons.GetById(id);

			if (person != null)
			{
				return new ObjectResult(person);
			}

			return new NotFoundResult();
		}

		[HttpPut]
		public IActionResult Put([FromBody]Person person)
		{
			if (person != null)
			{
				_persons.Update(person);
				return new OkResult();
			}

			return new NotFoundResult();
		}

		[HttpPost]
		public IActionResult Post([FromBody]Person person)
		{
			if (person != null)
			{
				_persons.Add(person);
				return new OkResult();
			}

			return new NotFoundResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Person person = _persons.GetById(id);

			if (person != null)
			{
				_persons.Remove(person);
				return new OkResult();
			}

			return new NotFoundResult();
		}
	}
}
