using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OkamiBooks.Startup))]
namespace OkamiBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
