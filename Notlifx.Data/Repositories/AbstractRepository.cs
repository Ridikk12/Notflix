using System;
using System.Collections.Generic;
using System.Text;

namespace Notlifx.Data.Repositories
{
    public class AbstractRepository
    {
		protected readonly NotflixDbContext _dbContext;

		public AbstractRepository(NotflixDbContext dbContext)
		{
			_dbContext = dbContext;
		}

    }
}
