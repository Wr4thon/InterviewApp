using System.Windows;
using System.Windows.Controls;

namespace InterviewApp.UI.Controls.Companies {
  /// <summary>
  /// Interaction logic for CompanyDetailControl.xaml
  /// </summary>
  public partial class CompanyDetailControl : UserControl {
    public Company Company
    {
      get { return (Company)GetValue(CompanyProperty); }
      set { SetValue(CompanyProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Company.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CompanyProperty =
        DependencyProperty.Register("Company", typeof(Company), typeof(CompanyDetailControl), new PropertyMetadata(new Company()));

    public CompanyDetailControl()
    {
      InitializeComponent();
    }
  }
}
