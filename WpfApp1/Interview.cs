using System;

namespace InterviewApp {
  public class Interview : NotifyPropertyChanged {
    public Interview() { }
    public Interview(global::Interview.db.contract.Interview interview, Company company)
    {
      this.ID = interview.ID;
      this.Name = interview.Name;
      this.Company = company;
    }

    private Guid id;
    public Guid ID
    {
      get { return id; }
      set {
        id = value;
        OnPropertyChanged();
      }
    }

    private string name;
    public string Name
    {
      get { return name; }
      set {
        name = value;
        OnPropertyChanged();
      }
    }

    private Company company;
    public Company Company
    {
      get { return company; }
      set {
        company = value;
        OnPropertyChanged();
      }
    }
  }
}
