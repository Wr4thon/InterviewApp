using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using InterviewApp.UI.Windows;

namespace InterviewApp {
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application {
    private readonly InterviewApp.Infrastructure.Provider _serviceProvider;

    public App()
    {
      InterviewApp.Infrastructure.Provider serviceProvider = new InterviewApp.Infrastructure.Provider();
      ConfigureServices(serviceProvider);
      serviceProvider.Build();

      this._serviceProvider = serviceProvider;
    }

    private void ConfigureServices(InterviewApp.Infrastructure.Provider serviceProvider) {
      serviceProvider.RegisterWindow<MainWindow>();
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
      //ThemeManager.Current.ChangeTheme(this, "Dark.Green");
      var mainWindow = _serviceProvider.GetService<MainWindow>();
      mainWindow.Show();
    }
  }
}
