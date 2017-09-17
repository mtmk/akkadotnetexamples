using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;
using shared;

namespace seed1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var sys = Common.CreateSystem(args[0]);
            
            Common.WaitForExit();
            Common.Shutdown(sys);
        }
    }
}