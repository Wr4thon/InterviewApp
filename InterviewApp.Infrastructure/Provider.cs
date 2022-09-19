using Interview.db.contract;
using Interview.db.inmemory;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewApp.Infrastructure {
  public class Provider {
    private ServiceProvider _serviceProvider;
    private readonly ServiceCollection _services;

    public Provider()
    {
      ServiceCollection services = new ServiceCollection();
      ConfigureServices(services);
      this._services = services;
    }

    public void Build()
    {
      this._serviceProvider = this._services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
      services.AddTransient<IInterviewRepository, InterviewRepo>();
      services.AddTransient<ICompanyRepository, CompanyRepo>();
    }

    public void RegisterWindow<TService>() where TService : class
    {
      this._services.AddSingleton<TService>();
    }

    public void AddTransient<TService, TImplementation>() where TService : class where TImplementation : class, TService
    {
      this._services.AddTransient<TService, TImplementation>();
    }

    public TService GetService<TService>() where TService : class
    {
      return this._serviceProvider.GetService<TService>();
    }
  }
}
