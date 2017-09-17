using System;
using System.Collections.Generic;
using System.Threading;
using Akka.Actor;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var actorSystem = ActorSystem.Create("test");
            var actorRef = actorSystem.ActorOf<TestActor>();
            actorRef.Tell("hello");
            
            Thread.Sleep(3000);
        }
    }

    public class TestActor: ReceiveActor
    {
        public TestActor()
        {
            Receive<string>(s =>
            {
                Console.WriteLine(s);
            });
        }
    }
}