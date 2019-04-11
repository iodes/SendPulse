using SendPulse.SDK;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SendPulse.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SendPulse .NET SDK");

            using (var sendpulse = new SendPulseService("CLIENT_ID", "CLIENT_SECRET"))
            {

            }
        }
    }
}
