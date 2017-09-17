using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;

namespace node3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");

            StandardOutLogger.UseColors = false;
            var config = ConfigurationFactory.ParseString(File.ReadAllText(args[0]));
            var sys = ActorSystem.Create("acme", config);
            
            // sys.ActorOf<StartUp>("startup");

            var r = new ManualResetEvent(false);
            Console.CancelKeyPress += (_,e) => { Console.WriteLine("Caught ctrl-c.."); e.Cancel = true; r.Set(); };
            r.WaitOne();

            Console.WriteLine("Exiting..");

            sys.Terminate().Wait();

            Console.WriteLine("Bye");
        }
    }
}