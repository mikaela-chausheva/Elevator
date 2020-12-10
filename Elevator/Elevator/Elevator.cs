using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Area51
{
    //4 methods for the buttons and floors -HAVEN'T DONE
    //we will use these method in the switch in the ELEVATOWORKER -HAVEN'T DONE
    //the elevator to be a thread -HAVEN'T DONE

    public enum Floors
    {
        GroundFloor = 1,
        SecretFloor = 2,
        TopSecretFloor1 = 3,
        TopSecretFoor2 = 4
    };
    class Elevator
    {
        public bool CA = false;
        public bool SA = false;
        public bool TSA = false;

        Random rnd = new Random();
        public int CurrentFloor = 0;
        const int minEnters = 1;
        const int maxEnters = 3;

        Agents agents = new Agents();
        Semaphore semaphore = new Semaphore(minEnters, maxEnters);
        static object agentLock = new object();

        //each thread enters the elevator
        public void Enter(object agent)
        {

            semaphore.WaitOne();
            agentLock = agent;
            lock (agentLock)
            {

                ElevatorWorker(agent);
                

            }
            semaphore.Release();

        }

        //the work of the elevator
        public void ElevatorWorker(object agent)
        {

            Console.WriteLine($"{agent} entered the elevator");

            for (int i = 0; i <= 3; i++)
            {
                int btn;
                
                btn = rnd.Next(1, 4);

                
                Console.WriteLine("..................");
                    switch (btn)
                    {
                        case 1:
                            Console.WriteLine($"{agent} entered in {Floors.GroundFloor}");
                            break;
                        case 2:
                            Console.WriteLine($"{agent} entered in {Floors.SecretFloor}");
                            break;
                        case 3:
                            Console.WriteLine($"{agent} entered in {Floors.TopSecretFloor1}");
                            break;
                        case 4:
                            Console.WriteLine($"{agent} entered in {Floors.TopSecretFoor2}");
                            break;
                    }
                
            }
            Console.WriteLine("..................");

            Console.WriteLine($"{agent} left the elevator");
            Console.WriteLine("###################################################");

        }
        private void SecurityCheck()
        { 
            
        }
    }
}

       
