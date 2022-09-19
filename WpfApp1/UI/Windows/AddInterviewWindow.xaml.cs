using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace InterviewApp.UI.Windows {
  /// <summary>
  /// Interaction logic for AddInterviewWindow.xaml
  /// </summary>
  public partial class AddInterviewWindow : MetroWindow {
    public static readonly DependencyProperty InterviewProperty = DependencyProperty.Register
        ("AddInterviewWindowInterview", typeof(Interview), typeof(AddInterviewWindow), new PropertyMetadata(new Interview()));
    public Interview Interview
    {
      get { return (Interview)GetValue(InterviewProperty); }
      set { SetValue(InterviewProperty, value); }
    }

    public static readonly DependencyProperty CompaniesProperty =
        DependencyProperty.Register(
          "Companies",
          typeof(ObservableCollection<Company>),
          typeof(AddInterviewWindow),
          new PropertyMetadata(
              new ObservableCollection<Company> {
                Company.AddNew
              },
              CompaniesChangedCallback
            )
          );
    public ObservableCollection<Company> Companies
    {
      get { return (ObservableCollection<Company>)GetValue(CompaniesProperty); }
      set { SetValue(CompaniesProperty, value); }
    }

    private static void CompaniesChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      if (e.NewValue == null) {
        return;
      }

      ICollection<Company> companies = e.NewValue as ICollection<Company>;
      companies?.Add(Company.AddNew);
      AddInterviewWindow window = d as AddInterviewWindow;
      if (window == null) {
        return;
      }

      window.SelectedCompany = companies.First();
    }


    public static readonly DependencyProperty SelectedCompanyProperty = DependencyProperty.Register
      ("SelectedCompany", typeof(Company), typeof(AddInterviewWindow), new PropertyMetadata(new Company(), SelectecCompanyChanged));
    public Company SelectedCompany
    {
      get { return (Company)GetValue(SelectedCompanyProperty); }
      set { SetValue(SelectedCompanyProperty, value); }
    }

    private static void SelectecCompanyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      AddInterviewWindow @this = d as AddInterviewWindow;
      if (@this == null) {
        return;
      }

      @this.IsNewCompany = e.NewValue == Company.AddNew;
    }

    public static readonly DependencyProperty IsNewCompanyProperty =
        DependencyProperty.Register("IsNewCompany", typeof(bool), typeof(AddInterviewWindow), new PropertyMetadata(false));
    public bool IsNewCompany
    {
      get { return (bool)GetValue(IsNewCompanyProperty); }
      set { SetValue(IsNewCompanyProperty, value); }
    }

    public Company NewCompany
    {
      get { return (Company)GetValue(NewCompanyProperty); }
      private set { SetValue(NewCompanyProperty, value); }
    }

    // Using a DependencyProperty as the backing store for EditCompany.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty NewCompanyProperty =
        DependencyProperty.Register("NewCompany", typeof(Company), typeof(AddInterviewWindow), new PropertyMetadata(new Company()));


    public AddInterviewWindow()
    {
      NewCompany = new Company();
      Interview = new Interview();
      InitializeComponent();
    }

    void acceptButton_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = true;
    }
  }
}
