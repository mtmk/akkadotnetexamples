﻿using Akka.Actor;
using Akka.Event;
using shared;

namespace node2
{
    public class Task2 : ReceiveActor
    {
        private readonly ILoggingAdapter _log = Context.GetLogger();

        public Task2()
        {
            Receive<WorkItem>(w =>
            {
                _log.Info($"[TASK2] Got work to do {w.Id} - {w.Name}");
            });
        }
    }
}