using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FalzoGamer.Api
{
/// <summary>
/// Classe Program
/// </summary>
    public class Program
    {
        /// <summary>
        /// Método Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Método CreateWebHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
