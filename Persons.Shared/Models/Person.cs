namespace Persons.Shared.Models
{
	public class Person
	{
		#region Properties

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int Id { get; set; }
		public int Age { get; set; }

		#endregion

		#region Methods

		public string FullName()
		{
			return $"{FirstName} {LastName}";
		}

		public override string ToString()
		{
			return $"{FullName()}, Email: {Email}, Age: {Age}";
		}

		public static bool IsEmailValid(string email)
		{
			return email.Contains("@");
		}

		#endregion
	}
}
