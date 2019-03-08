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

