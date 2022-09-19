using System;

namespace Interview.db.contract {
  public class IDEntity {
    public Guid ID { get; set; }

    public IDEntity()
    {
    }

    public IDEntity(Guid iD)
    {
      this.ID = iD;
    }
  }
}
