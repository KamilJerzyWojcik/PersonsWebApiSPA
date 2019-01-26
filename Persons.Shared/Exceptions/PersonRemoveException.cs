using System;

namespace Persons.Shared.Exceptions
{
	public class PersonRemoveException : Exception
	{
		public PersonRemoveException(string message) : base(message)
		{
		}
	}
}
