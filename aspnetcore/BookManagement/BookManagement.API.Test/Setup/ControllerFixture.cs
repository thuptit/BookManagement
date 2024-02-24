using BookManagement.Domain;
using Microsoft.Extensions.DependencyInjection;
namespace BookManagement.API.Test.Setup;

public class ControllerFixture : IDisposable
{
    protected readonly BookManagementDbContext Context;

    private readonly IServiceProvider _serviceProvider =
        SetupServiceCollections.GetContainerInstance() ?? throw new ArgumentNullException();

    protected ControllerFixture()
    {
        Context = Resolve<BookManagementDbContext>() ?? throw new ArgumentNullException();
    }
    
    protected T? Resolve<T>() => _serviceProvider.GetService<T>();
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}