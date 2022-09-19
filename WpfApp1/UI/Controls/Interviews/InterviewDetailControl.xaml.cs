using System.Windows;
using System.Windows.Controls;

namespace InterviewApp.UI.Controls.Interviews {
  /// <summary>
  /// Interaction logic for CompanyDetailView.xaml
  /// </summary>
  public partial class InterviewDetailControl: UserControl {
    public static readonly DependencyProperty InterviewProperty = DependencyProperty.Register
        ("Interview", typeof(Interview), typeof(InterviewDetailControl), new PropertyMetadata(null));

    public Interview Interview
    {
      get { return (Interview)GetValue(InterviewProperty); }
      set {
        SetValue(InterviewProperty, value);
      }
    }

    public InterviewDetailControl()
    {
      InitializeComponent();
    }
  }
}
