using Akka.Actor;
using Akka.Event;

namespace shared
{
    public class Task2 : ReceiveActor
    {
        private readonly ILoggingAdapter _log = Context.GetLogger();

        public Task2()
        {
            Receive<WorkItem>(w =>
            {
                _log.Info($"Got work to do {w.Id} - {w.Name}");
            });
        }
    }
}