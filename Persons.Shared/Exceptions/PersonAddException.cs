using System;

namespace Persons.Shared.Exceptions
{
	public class PersonAddException : Exception
	{
		public PersonAddException(string message) : base(message)
		{
		}
	}
}
