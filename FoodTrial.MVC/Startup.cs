using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodTrial.MVC.Startup))]
namespace FoodTrial.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
