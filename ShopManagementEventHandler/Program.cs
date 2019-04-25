using BlackYellow.Infrastructure.Messaging;
using Microsoft.Extensions.Configuration;
using Polly;
using Serilog;
using ShopManagementEventHandler.Context;
using ShopManagementEventHandler.Repositories;
using System;
using System.IO;
using System.Threading;

namespace ShopManagementEventHandler
{
    public class Program
    {
        private static string _env;
        public static IConfigurationRoot Config { get; private set; }

         static Program()
        {
            _env = "Development";

            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
               // .AddJsonFile($"appsettings.{_env}.json", optional: false)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Config)
                .CreateLogger();

            Log.Information($"Environment: {_env}");
        }

        static void Main(string[] args)
        {
            Startup();
        }

        private static void Startup()
        {
            // setup messagehandler
            RabbitMQMessageHandler messageHandler = new RabbitMQMessageHandler("localhost", "guest", "guest", "blackyellow", "ShopManagement", "");

            var dbContext =  new MongoContext()
            {
                ConnectionString = Config.GetSection("Mongo:ConnectionString").Get<string>(),
                DataBase = Config.GetSection("Mongo:DataBase").Get<string>()
            };

            // start event-handler
            EventHandler eventHandler = new EventHandler(messageHandler, new CustomerRepository(dbContext));
            eventHandler.Start();

            if (_env == "Development")
            {
                Log.Information("ShopManagement Eventhandler started.");
                Console.WriteLine("Press any key to stop...");
                Console.ReadKey();
                eventHandler.Stop();
            }
            else
            {
                Log.Information("ShopManagement Eventhandler started.");
                while (true)
                {
                    Thread.Sleep(10000);
                }
            }
        }
    }
}
