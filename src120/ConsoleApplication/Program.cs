using System;
using Akka.Actor;
using Akka.Routing;

namespace ConsoleApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            var config = @"
                akka.actor {
                  provider = ""Akka.Cluster.ClusterActorRefProvider, Akka.Cluster""
                  deployment {
                    /ActorOne/ActorTwo {
                        router = consistent-hashing-pool
                        nr-of-instances = 1
                        cluster {
                          enabled = on
                          allow-local-routees = on
                          use-role = role-one
                          max-nr-of-instances-per-node = 1
                        }
                    }
                  }
                }
                ";

            var actorSystem = ActorSystem.Create("example", config);
            var actorRef = actorSystem.ActorOf(Props.Create(()=>new ActorOne()), "ActorOne");

            while (true)
            {
                actorRef.Tell(new MessageOne { Name = "Msg-"+DateTime.Now } );
                Console.ReadLine();
            }
        }
    }

    public class ActorOne : TypedActor, IHandle<MessageOne>
    {
        private IActorRef _actorTwo;

        public ActorOne()
        {
            Console.WriteLine("[ActorOne] .ctor");
        }

        protected override void PreStart()
        {
            Console.WriteLine("[ActorOne] PreStart");
            _actorTwo = Context.ActorOf(Props.Create(() => new ActorTwo()).WithRouter(FromConfig.Instance), "ActorTwo");
            base.PreStart();
        }

        public void Handle(MessageOne message)
        {
            Console.WriteLine($"[ActorOne] Handle {message.Name}");
            _actorTwo.Forward(new ConsistentHashableEnvelope(message, message.Name));
        }
    }

    public class ActorTwo : TypedActor, IHandle<MessageOne>
    {
        public ActorTwo()
        {
            Console.WriteLine("[ActorTwo] .ctor");
        }

        public void Handle(MessageOne message)
        {
            Console.WriteLine($"[ActorTwo] Handle {message.Name}");
        }
    }

    public class MessageOne
    {
        public string Name { get; set; }
    }
}
