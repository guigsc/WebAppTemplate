using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppTemplate.Database.BaseRepository
{
    public interface IRepository<T> : ICommandRepository<T>, IQueryRepository<T> where T : class
    {

    }
}
