using System;

namespace InterviewApp {
  public class Company : NotifyPropertyChanged {
    public static Company AddNew;
    static Company()
    {
      AddNew = new Company() {
        _name = "(Add new)",
      };
    }

    public Company(global::Interview.db.contract.Company company)
    {
      this.Name = company.Name;
      this.ID = company.ID;
      this.Homepage= company.Homepage;
    }

    public Company()
    {
    }

    private string _name;
    public string Name
    {
      get { return _name; }
      set {
        _name = value;
        OnPropertyChanged();
      }
    }

    private string _homepage;
    public string Homepage
    {
      get { return _homepage; }
      set {
        _homepage = value;
        OnPropertyChanged();
      }
    }

    private Guid _id;
    public Guid ID
    {
      get { return _id; }
      set {
        _id = value;
        OnPropertyChanged();
      }
    }

    public override string ToString()
    {
      return base.ToString() + " " + this.Name;
    }
  }
}
