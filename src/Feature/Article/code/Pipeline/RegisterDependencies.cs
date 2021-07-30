using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trn.Feature.Article.Controllers;
using Trn.Feature.Article.Repositories;

namespace Trn.Feature.Article.Pipeline
{
    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<FeaturedArticleController>();
            serviceCollection.AddTransient<TrnArticleController>();
            serviceCollection.AddTransient<TrnBlogListController>();
            serviceCollection.AddTransient<TrnCommentsController>();
            serviceCollection.AddTransient<TrnCommentsListController>();
            serviceCollection.AddTransient(typeof(ITrnArticleRepository), typeof(TrnArticleRepository));
            serviceCollection.AddTransient(typeof(ITrnBlogRepository), typeof(TrnBlogRepository));
            serviceCollection.AddTransient(typeof(ITrnCommentRepository), typeof(TrnCommentRepository));

        }
    }
}