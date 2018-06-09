using Notflix.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notlifx.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
		Task<T> Get(Guid id);
		Task<List<T>> Get(List<Guid> ids);
		Task Add(T entity);
    }
}
