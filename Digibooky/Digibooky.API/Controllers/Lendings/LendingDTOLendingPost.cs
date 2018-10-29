using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digibooky.API.Controllers.Lendings
{
	public class LendingDTOLendingPost
	{
		public long inss { get; private set; }
		public string isbn { get; private set; }

		public LendingDTOLendingPost(long inss, string isbn)
		{
			this.inss = inss;
			this.isbn = isbn;
		}
	}
}
