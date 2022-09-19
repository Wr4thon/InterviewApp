using System;

namespace Interview.db.contract {
  public class Interview : IDEntity {
    public string Name;
    public Guid CompanyID;

    public Interview() { }
    public Interview(string name, Guid companyID) : this(Guid.Empty, name, companyID) { }
    public Interview(Guid iD, string name, Guid companyID) : base(iD)
    {
      this.Name = name;
      this.CompanyID = companyID;
    }
  }
}
