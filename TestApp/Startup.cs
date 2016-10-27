using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(TestApp.Startup))]
namespace TestApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}