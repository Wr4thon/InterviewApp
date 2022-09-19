using System;

namespace Interview.db.contract {
  public class Company : IDEntity {
    public string Name { get; set; }
    public string Homepage { get; set; }

    public Company() { }
    public Company(string name, string homepage) : this(Guid.Empty, name, homepage) { }
    public Company(Guid id, string name, string homepage) : base(id)
    {
      this.Name = name;
      this.Homepage = homepage;
    }
  }
}
