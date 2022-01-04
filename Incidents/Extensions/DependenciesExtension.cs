using Incidents.DataAccess.Repositories.Interfaces;
using Incidents.DataAccess.Repositories.Realization;
using Incidents.Services.Interfaces;
using Incidents.Services.Realization;

namespace Incidents.Extensions;

public static class DependenciesExtension
{
    public static IServiceCollection AddDependency(this IServiceCollection service)
    {
        service.AddScoped<IIncidentService, IncidentService>();
        service.AddScoped<IContactService, ContactService>();
        service.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        service.AddScoped<IAccountService, AccountService>();
        return service;
    }
}