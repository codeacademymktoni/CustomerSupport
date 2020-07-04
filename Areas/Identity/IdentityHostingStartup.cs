using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CustomerSupport.Areas.Identity.IdentityHostingStartup))]
namespace CustomerSupport.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}