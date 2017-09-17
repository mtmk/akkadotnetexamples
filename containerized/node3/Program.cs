using Akka.Actor;
using shared;

namespace node3
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var sys = Common.CreateSystem(args[0]);
            
            sys.ActorOf<Task3>("task3");
            
            Common.WaitForExit();
            Common.Shutdown(sys);
        }
    }
}