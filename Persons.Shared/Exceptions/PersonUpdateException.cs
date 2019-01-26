using System;

namespace Persons.Shared.Exceptions
{
	public class PersonUpdateException : Exception
	{
		public PersonUpdateException(string message) : base(message)
		{
		}
	}
}
