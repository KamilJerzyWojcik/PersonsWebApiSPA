using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Moq;
using Persons.Shared.Models;
using Persons.Shared.Services;
using Persons.Web3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Persons.Web.Tests
{
	public class PersonsControllerTests
	{

		[Fact]
		public void Get_test()
		{
			// Arrange

			IEnumerable<Person> persons = new Person[] {
				new Person() { FirstName = "test1" },
				new Person() { FirstName = "test1" },
				new Person() { FirstName = "test2" },
				new Person() { FirstName = "test3" }
			}.ToList();

			Mock<IPersonsRepository> mock = new Mock<IPersonsRepository>();
			mock.Setup(r => r.Get()).Returns((persons).AsQueryable<Person>());


			PersonsController personsController = new PersonsController(mock.Object);

			// Act
			IEnumerable<Person> result = personsController.Get();

			//Assert
			Assert.Equal(persons, result);
		}

		[Fact]
		public void GetById_test()
		{
			// Arrange

			IEnumerable<Person> persons = new Person[] {
				new Person() { FirstName = "test1", Id = 1, Age = 2, Email = "test@test.com.pl", LastName = "lastTest" },
				new Person() { FirstName = "test2", Id = 2 },
				new Person() { FirstName = "test3", Id = 3 },
				new Person() { FirstName = "test4", Id = 4 }
			}.ToList();
			Person expectedPerson = new Person() { FirstName = "test1", Id = 1, Age = 2, Email = "test@test.com.pl", LastName = "lastTest" };

			Mock< IPersonsRepository> mock = new Mock<IPersonsRepository>();

			mock.Setup(r => r.GetById(It.IsAny<int>()))
				.Returns<int>((a) => persons.Where(y => y.Id == a).SingleOrDefault());

			PersonsController personsController = new PersonsController(mock.Object);

			// Act

			ObjectResult result = personsController.Get(1) as ObjectResult;
			Person value = result.Value as Person;

			//Assert

			Assert.Equal(expectedPerson.Id, value.Id);
		}

		[Fact]
		public void Delete_test()
		{
			// Arrange

			IEnumerable<Person> persons = new Person[] {
				new Person() { FirstName = "test1", Id = 1},
				new Person() { FirstName = "test1", Id = 2},
				new Person() { FirstName = "test2", Id = 3},
				new Person() { FirstName = "test3", Id = 4}
			}.ToList();


			Mock<IPersonsRepository> mock = new Mock<IPersonsRepository>();
			mock.Setup(r => r.Get()).Returns((persons).AsQueryable<Person>());

			PersonsController personsController = new PersonsController(mock.Object);
			persons.ToList().Remove(new Person() { FirstName = "test1", Id = 1 });

			// Act

			personsController.Delete(1);
			IEnumerable<Person> result = personsController.Get();

			//Assert

			Assert.Equal(persons, result);
		}

		[Fact]
		public void Put_test()
		{
			// Arrange

			IEnumerable<Person> persons = new Person[] {
				new Person() { FirstName = "test1", Id = 1},
				new Person() { FirstName = "test1", Id = 2},
				new Person() { FirstName = "test2", Id = 3},
				new Person() { FirstName = "test3", Id = 4}
			}.ToList();

			Person person = new Person() { FirstName = "test12", Id = 1 };

			Mock<IPersonsRepository> mock = new Mock<IPersonsRepository>();
			mock.Setup(r => r.Update(It.IsAny<Person>())).Callback<Person>((x) => persons.Where(y => y.Id == x.Id).SingleOrDefault().FirstName = x.FirstName);

			//mock.Setup(r => r.GetById(It.IsAny<int>()))
			//	.Returns<int>((a) => persons.Where(y => y.Id == a).SingleOrDefault());

			PersonsController personsController = new PersonsController(mock.Object);

			// Act

			personsController.Put(person);
			ObjectResult result  = personsController.Get(person.Id) as ObjectResult;
			Person value = result.Value as Person;

			//Assert

			Assert.Equal(person, value);
		}
	}
}
