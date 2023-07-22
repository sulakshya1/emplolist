using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(emplolist.Startup))]
namespace emplolist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
