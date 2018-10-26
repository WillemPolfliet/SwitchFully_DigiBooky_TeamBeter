using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Lendings.Exceptions
{
	public class LendingException : Exception
	{
		public LendingException(string message) : base(message)
		{
		}
	}
}
