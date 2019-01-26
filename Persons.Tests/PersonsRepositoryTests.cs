using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persons.Shared.Exceptions;
using Persons.Shared.Models;
using Persons.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Tests
{
	[TestClass]
	public class PersonsRepositoryTests
	{
		private PersonsRepository _persons = new PersonsRepository();

		[TestMethod]
		public void Add_test()
		{
			//Arrange

			Person person = new Person
			{
				FirstName = "Dawid",
				LastName = "Borycki",
				Age = 34,
				Email = "dawid@borycki.com.pl"
			};

			//Act

			_persons.Add(person);
			bool result = _persons.Get().Contains(person);

			//Assert

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Add_test_show_exception()
		{
			// Arrange

			Person person = null;

			//Act & Assert
			Assert.ThrowsException<PersonAddException>
				(
					() => 
					{
						_persons.Add(person);
					}
				);
		}
		
		[TestMethod]
		public void AssignId_test()
		{
			//Arrange

			const int expectedId = 1;
			PersonsRepository persons = new PersonsRepository();

			//Act

			PrivateObject privateObject = new PrivateObject(persons);
			var id = privateObject.Invoke("AssignId");

			//Assert

			Assert.AreEqual(expectedId, id);
		}
	}
}
