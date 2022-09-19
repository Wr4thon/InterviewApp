using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.db.contract {
  public interface IRepository<TEntity> where TEntity : class {
    IEnumerable<TEntity> FetchAll();
    IQueryable<TEntity> Query { get; }
    Guid Upsert(TEntity entity);
    void Delete(TEntity entity);
    void DeleteByID(Guid id);
    void Save();
  }
}
