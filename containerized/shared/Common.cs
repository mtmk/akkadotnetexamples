using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;

namespace shared
{
    public static class Common
    {
        public static ActorSystem CreateSystem(string configFile)
        {
            Console.WriteLine("Starting..");

            StandardOutLogger.UseColors = false;
            var conf = File.ReadAllText(configFile)
                .Replace("{{OWN_HOST}}", Environment.GetEnvironmentVariable("OWN_HOST") ?? System.Net.Dns.GetHostName())
                .Replace("{{SEED_NODE_HOST}}", Environment.GetEnvironmentVariable("SEED_NODE_HOST") ?? "localhost")
                .Replace("{{SEED_NODE_PORT}}", Environment.GetEnvironmentVariable("SEED_NODE_PORT") ?? "8080");
            Console.WriteLine(conf);
            
            var config = ConfigurationFactory.ParseString(conf);
            return ActorSystem.Create("acme", config);
        }

        public static void WaitForExit()
        {
            var r = new ManualResetEvent(false);
            Console.CancelKeyPress += (_,e) => { Console.WriteLine("Caught ctrl-c.."); e.Cancel = true; r.Set(); };
            r.WaitOne();

            Console.WriteLine("Exiting..");
        }

        public static void Shutdown(ActorSystem sys)
        {
            CoordinatedShutdown.Get(sys).Run().Wait(TimeSpan.FromSeconds(10));

            Console.WriteLine("Bye");
        }
    }
}