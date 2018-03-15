using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ArtProducts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run(); 
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) //sets up a default configuration file that we can use
                .ConfigureAppConfiguration(SetupConfiguration) //manually set up configuration file --> defined below
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //remove the default configuration options
            builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true)
                   .AddEnvironmentVariables();

        }
    }
}
