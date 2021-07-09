using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trn.Foundation.Customization.Pipelines
{
    public class Set404Status : Sitecore.Pipelines.HttpRequest.HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (Sitecore.Context.Item != null)
            {
                if (Sitecore.Context.Item["is404page"] != null
                    && Sitecore.Context.Item["is404page"].ToString() == "true")
                {
                    HttpContext.Current.Response.StatusCode = 404;
                    HttpContext.Current.Response.TrySkipIisCustomErrors = true; //to disable IIS custom errors
                }
            }
        }
    }
}