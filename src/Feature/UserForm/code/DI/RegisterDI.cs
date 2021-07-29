using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Trn.Feature.UserForm.Controllers;

namespace Trn.Feature.UserForm.DI
{
    public class RegisterDI : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UserController>();
        }
    }
}