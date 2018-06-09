using Notflix.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notlifx.Data.Repositories.Interfaces
{
    public interface IVideoRepository : IRepository<Video>
	{
		int Save();

    }
}
