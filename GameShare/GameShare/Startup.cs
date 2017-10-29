using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameShare.Startup))]
namespace GameShare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
