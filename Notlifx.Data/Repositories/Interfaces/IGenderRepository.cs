using Notflix.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notlifx.Data.Repositories.Interfaces
{
	public interface IGenderRepository : IRepository<Gender>
	{
		Task<List<Gender>> GetAll();
	}
}
