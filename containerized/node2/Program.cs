using Akka.Actor;
using shared;

namespace node2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var sys = Common.CreateSystem(args[0]);

            sys.ActorOf<Task2>("task2");
            
            Common.WaitForExit();
            Common.Shutdown(sys);
        }
    }
}