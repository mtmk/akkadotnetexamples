using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;
using shared;

namespace node2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");

            StandardOutLogger.UseColors = false;
            var conf = File.ReadAllText(args[0])
                .Replace("{{OWN_HOST}}", Environment.GetEnvironmentVariable("OWN_HOST") ?? System.Net.Dns.GetHostName())
                .Replace("{{SEED_NODE_HOST}}", Environment.GetEnvironmentVariable("SEED_NODE_HOST") ?? "localhost")
                .Replace("{{SEED_NODE_PORT}}", Environment.GetEnvironmentVariable("SEED_NODE_PORT") ?? "8080");
            Console.WriteLine(conf);
            var config = ConfigurationFactory.ParseString(conf);
            var sys = ActorSystem.Create("acme", config);
            
            // sys.ActorOf<StartUp>("startup");
            sys.ActorOf<Task2>("task2");

            var r = new ManualResetEvent(false);
            Console.CancelKeyPress += (_,e) => { Console.WriteLine("Caught ctrl-c.."); e.Cancel = true; r.Set(); };
            r.WaitOne();

            Console.WriteLine("Exiting..");

            sys.Terminate().Wait();

            Console.WriteLine("Bye");
        }
    }
}