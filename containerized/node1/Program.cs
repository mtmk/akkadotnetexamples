using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;

namespace node1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");

            var config = ConfigurationFactory.ParseString(File.ReadAllText(args[0]));
            var sys = ActorSystem.Create("acme", config);
            new ManualResetEvent(false).WaitOne();
            sys.Terminate();
        }
    }
}
