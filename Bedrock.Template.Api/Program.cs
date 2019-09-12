using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Bedrock.Template.Api.Core
{
	public class Program
    {
		#region Public Methods
		public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
		#endregion
	}
}
