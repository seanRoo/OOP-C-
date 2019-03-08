/*
Design a class called Stopwatch. The job of this class is to simulate a stopwatch. It should
provide two methods: Start and Stop. We call the start method first, and the stop method next.
Then we ask the stopwatch about the duration between start and stop. Duration should be a
value in TimeSpan. Display the duration on the console.
We should also be able to use a stopwatch multiple times. So we may start and stop it and then
start and stop it again. Make sure the duration value each time is calculated properly.
We should not be able to start a stopwatch twice in a row (because that may overwrite the initial
start time). So the class should throw an InvalidOperationException if its started twice. 
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new StopWatch();

            while(true){
                var input = Console.ReadLine();
                if(input.Equals("start")){
                    Console.WriteLine("Starting.....");
                    sw.Start();
                }
                else if(input.Equals("stop")){
                    Console.WriteLine("Stopping....");
                    Console.WriteLine(sw.Stop());
                    break;
                }
            }
            Console.ReadKey();
        }
    }

    class StopWatch
    {
        private Boolean on = false;
        private DateTime start;
        private DateTime stop;
        
        public void Start()
        {
            if(!on){
                on = true;
                start = DateTime.Now;

            }
            
        }
        public TimeSpan Stop(){
            if(on){
                on = false;
                stop = DateTime.Now;

            }
            return stop - start;
        }
    }

}

