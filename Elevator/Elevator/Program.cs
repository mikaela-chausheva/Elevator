using System;
using System.Threading;

namespace Area51
{
    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            const int maxEnters = 1;
            Elevator elevator = new Elevator();
          
            Semaphore semaphore = new Semaphore(maxEnters,maxEnters);

            Console.WriteLine("Welcome to Area51");
            Console.WriteLine("######################");

            Thread t1 = new Thread(elevator.Enter);
            t1.Name = "ConfidentialAgent";

            Thread t2 = new Thread(elevator.Enter);
            t2.Name = "SecretAgent";

            Thread t3 = new Thread(elevator.Enter);
            t3.Name = "TopSecretAgent";

            
            t1.Start("ConfidentialAgent");
            t2.Start("SecretAgent");
            t3.Start("TopSecretAgent");
           

            Console.WriteLine();
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("GOODBYE FROM AREA51");

        }
        
    }
}
