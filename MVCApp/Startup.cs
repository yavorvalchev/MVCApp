using Microsoft.Owin;
using MVCApp.Models;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(MVCApp.Startup))]
namespace MVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Database.SetInitializer<ApplicationDbContext>(null);
            ConfigureAuth(app);
        }
    }
}
