using BlogDataLibrary.Data;
using BlogDataLibrary.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace BlogTestUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Build Configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration config = builder.Build();

            // 2. Setup DI Container
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            services.AddSingleton<SqlData>();

            var serviceProvider = services.BuildServiceProvider();

            // 3. Test DI (Optional: You can write test code here later to add users/posts)
            Console.WriteLine("Dependency Injection configured successfully!");
            Console.ReadLine();
        }
    }
}