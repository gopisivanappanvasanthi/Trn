using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trn.Feature.UserForm.Controllers;
using Trn.Foundation.Analytics.Services;

namespace Trn.Feature.UserForm.DI
{
    public class RegisterDI : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UserController>();
            serviceCollection.AddTransient(typeof(IContactService),
                typeof(ContactService));
        }
    }
}