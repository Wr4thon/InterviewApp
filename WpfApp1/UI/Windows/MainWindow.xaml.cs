using MahApps.Metro.Controls;
using contract = Interview.db.contract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;

namespace InterviewApp.UI.Windows {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : MetroWindow, INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    private bool ExecuteAlways() => true;

    private ICommand _addInterview;
    private ICollection<Company> _companies;
    private Interview _selectedInterview;
    private ObservableCollection<Interview> _interviews;
    private readonly contract.IInterviewRepository _interviewsRepo;
    private readonly contract.ICompanyRepository _companiesRepo;

    public ObservableCollection<Interview> Interviews
    {
      get => _interviews; set {
        _interviews = value;
        OnPropertyChanged();
      }
    }

    public Interview SelectedInterview
    {
      get => _selectedInterview; set {
        _selectedInterview = value;
        OnPropertyChanged();
      }
    }

    public ICommand AddInterview
    {
      get {
        return _addInterview ?? (_addInterview = new CommandHandler(AddIterviewClick, this.ExecuteAlways));
      }
    }

    private MainWindow()
    {
      InitializeComponent();
    }

    public MainWindow(contract.IInterviewRepository interviewsRepo, contract.ICompanyRepository companiesRepo) : this()
    {
      this._interviewsRepo = interviewsRepo;
      this._companiesRepo = companiesRepo;

      this._companies = new List<Company>();
      foreach (contract.Company company in companiesRepo.FetchAll()) {
        this._companies.Add(new Company(company));
      }

      this.Interviews = new ObservableCollection<Interview>();
      foreach (contract.Interview interview in interviewsRepo.FetchAll()) {
        this.Interviews.Add(new Interview(interview, this._companies.Where(c => c.ID == interview.CompanyID).FirstOrDefault()));
      }
    }

    public void AddIterviewClick()
    {
      AddInterviewWindow aiv = new AddInterviewWindow();
      aiv.Companies = new ObservableCollection<Company>(_companies);

      bool? aivResult = aiv.ShowDialog();
      if (!aivResult.GetValueOrDefault()) {
        return;
      }
      aiv.Interview.Company = aiv.SelectedCompany;

      if (aiv.IsNewCompany) {
        Company company = aiv.NewCompany;
        AddNewCompany(ref company);
        aiv.Interview.Company = company;
      }

      AddNewInterview(aiv.Interview);
    }

    private void AddNewCompany(ref Company company)
    {
      company.ID = _companiesRepo.Upsert(new contract.Company(company.Name, company.Homepage));
      _companies.Add(company);
    }

    private void AddNewInterview(Interview interview)
    {
      interview.ID = _interviewsRepo.Upsert(new contract.Interview(interview.Name, interview.Company.ID));
      this.Interviews.Add(interview);
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }
}
