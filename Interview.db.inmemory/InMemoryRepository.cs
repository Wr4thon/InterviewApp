using Interview.db.contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.db.inmemory {
  public abstract class InMemoryRepository<TEntity> : IRepository<TEntity>
    where TEntity : IDEntity {
    private IDictionary<Guid, TEntity> _entries;

    public InMemoryRepository()
    {
      this._entries = new Dictionary<Guid, TEntity>();
    }

    public IQueryable<TEntity> Query => _entries.Values.AsQueryable();

    public virtual Guid Upsert(TEntity entity)
    {
      if (entity.ID == Guid.Empty) {
        entity.ID = Guid.NewGuid();
        this._entries.Add(entity.ID, entity);
      } else if (this._entries.ContainsKey(entity.ID)) {
        this._entries[entity.ID] = entity;
      } else {
        this._entries.Add(entity.ID, entity);
      }

      return entity.ID;
    }

    public void Delete(TEntity entity)
    {
      this.DeleteByID(entity.ID);
    }

    public void DeleteByID(Guid entityID)
    {
      if (!this._entries.ContainsKey(entityID)) {
        //throw
      }

      this._entries.Remove(entityID);
    }

    public IEnumerable<TEntity> FetchAll()
    {
      return this._entries.Values.ToList();
    }

    public void Save()
    {
    }
  }
}
