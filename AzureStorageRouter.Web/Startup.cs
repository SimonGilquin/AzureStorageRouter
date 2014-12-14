using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

/*
[assembly: OwinStartup(typeof(AzureStorageRouter.Web.Startup))]
*/

namespace AzureStorageRouter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
