using System;
using Akka.Actor;
using Akka.Event;
using Akka.Routing;
using shared;

namespace node1
{
    public class StartUp: ReceiveActor
    {
        private readonly ILoggingAdapter _log = Context.GetLogger();

        public StartUp()
        {
            var task2 = Context.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "task2");
            var task3 = Context.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "task3");
            
            var i = 1;
            Receive<ReceiveTimeout>(t =>
            {
                _log.Info("Tick..");
                task2.Tell(new WorkItem { Id = i, Name = $"Work-{DateTime.Now.TimeOfDay}" });
                task3.Tell(new WorkItem { Id = i, Name = $"Work-{DateTime.Now.TimeOfDay}" });
                i++;
            });
        }

        protected override void PreStart()
        {
            _log.Info("Startup actor starting..");
            SetReceiveTimeout(TimeSpan.FromSeconds(3));
        }
        
    }
}
