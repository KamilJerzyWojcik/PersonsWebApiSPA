using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persons.Shared.Models;

namespace Persons.Tests
{
	[TestClass]
	public class PersonTest
	{
		[TestMethod]
		public void verify_public_properties()
		{
			// Arrange

			const string expectedFirstName = "Dawid";
			const string expectedLastName = "Borycki";
			const string expectedEmail = "dawid@borycki.com.pl";
			const int expectedAge = 34;

			// Act

			Person person = new Person()
			{
				FirstName = expectedFirstName,
				LastName = expectedLastName,
				Email = expectedEmail,
				Age = expectedAge
			};

			// Assert

			Assert.AreEqual(expectedFirstName, person.FirstName, false, "Incorrect FirstName");
			Assert.AreEqual(expectedLastName, person.LastName, false, "Incorrect LastName");
			Assert.AreEqual(expectedEmail, person.Email, false, "Incorrect Email");
			Assert.AreEqual(expectedAge, person.Age, "Incorrect Age");
		}

		[TestMethod]
		public void verify_full_name()
		{
			//Arrange

			const string expectedFirstName = "Dawid";
			const string expectedLastName = "Borycki";

			string expectedFullName = $"{expectedFirstName} {expectedLastName}";

			//Act

			Person person = new Person()
			{
				FirstName = expectedFirstName,
				LastName = expectedLastName
			};

			string resultFullName = person.FullName();

			//Assert

			Assert.AreEqual(expectedFullName, resultFullName);
		}

		[TestMethod]
		public void verify_email()
		{
			//Arrange

			//const string email = "dawid@borycki.com.pl";
			const string email = "dawid@";

			//Act

			bool isValid = EmailCheck(email);
			bool resultIsValid = Person.IsEmailValid(email);

			//Assert

			Assert.AreEqual(isValid, resultIsValid);
		}

		private bool EmailCheck(string email)
		{
			const string emailPattern = "[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}";

			return Regex.IsMatch(email, emailPattern);
		}
	}
}
