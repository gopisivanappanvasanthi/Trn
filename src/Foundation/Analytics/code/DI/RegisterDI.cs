using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Trn.Foundation.Analytics.Services;

namespace Trn.Foundation.Analytics.DI
{
    public class RegisterDI : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IContactService),
                typeof(ContactService));
        }
    }
}