using System;
using System.IO;
using Akka.Actor;
using Akka.Configuration;

namespace znode1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var configFile = File.ReadAllText("znode1.hcon");
            var config = ConfigurationFactory.ParseString(configFile);
            
            var actorSystem = ActorSystem.Create("zsys", config);
            
            Console.ReadLine();
            
            actorSystem.Dispose();
        }
    }
}