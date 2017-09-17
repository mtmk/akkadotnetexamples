using Akka.Actor;
using Akka.Event;
using shared;

namespace node3
{
    public class Task3 : ReceiveActor
    {
        private readonly ILoggingAdapter _log = Context.GetLogger();

        public Task3()
        {
            Receive<WorkItem>(w =>
            {
                _log.Info($"[TASK3]Got work to do {w.Id} - {w.Name}");
            });
        }
    }
}