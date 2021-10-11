using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace thread_multithread
{
    //this is an example of the use of threads 
    class Program
    {
        static List<Thread> threads = new List<Thread>();

        static void Main(string[] args)
        {
            //example of normal operation on the default thread  
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "Main thread";
            RandomSentence();
            Console.WriteLine("first process running on the main thread, press any key to continue");
            Console.ReadKey();
            Console.Clear();

            //example of a multithread process
            //Creating Threads
            Thread sentenceThread = new Thread(RandomSentence)
            {
                Name = "Sentence Thread"
            };
            threads.Add(sentenceThread);

            Thread numberThread = new Thread(RandomNumber)
            {
                Name = "Number Thread"
            };

            threads.Add(numberThread);

            Thread datetimeThread = new Thread(GetDateTime)
            {
                Name = "Datetime Thread",
                IsBackground = true,
            };

            threads.Add(datetimeThread);

            // Thread keyThread = new Thread(() => PrintKey("F"))
            // {
            //     Name = "Key Thread"
            // };
            //Inician en este orden
            numberThread.Start();
            datetimeThread.Start();
            sentenceThread.Start();
            // keyThread.Start();
            
            PrintStatus();

            Console.ReadKey();
        }

        //returns a randon sentence 
        static void RandomSentence ()
        {
            Random rnd = new Random();
            string[] arr = new string[]{"Look","This","Football","Words","Styles","What","Programming","Rock","Repeat","The","He","Array"};
            int length = arr.Length;
            string output = arr[0];
            while(length > 1){
                output += (" " + arr[rnd.Next(--length)]).ToLower();
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(output);
            Console.WriteLine($"RUNNING IN = {Thread.CurrentThread.Name}  --- IS A BACKGROUND THREAD = {Thread.CurrentThread.IsBackground}");
            Console.WriteLine("-------------------------------------------------------------------------");

        }

        static void RandomNumber()
        {
            Thread.Sleep(10000);
            Random rnd = new Random();

            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(rnd.Next(1, int.MaxValue).ToString());
            Console.WriteLine($"RUNNING IN = {Thread.CurrentThread.Name}  --- IS A BACKGROUND THREAD = {Thread.CurrentThread.IsBackground}");
            Console.WriteLine("-------------------------------------------------------------------------");
        }


        static void GetDateTime()
        {
            CultureInfo culture = new CultureInfo("en-US");
            int n = 10;
            while(n > 1){
                Thread.Sleep(10000);
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine(DateTime.Now.ToString("f",culture));
                Console.WriteLine($"RUNNING IN = {Thread.CurrentThread.Name}  --- IS A BACKGROUND THREAD = {Thread.CurrentThread.IsBackground}");
                Console.WriteLine("-------------------------------------------------------------------------");
                PrintStatus();
                n--;
            }
        }


        static void PrintKey(string key)
        {
             Console.WriteLine($"------------------------Pressed-Key--{key}---------------------------------");
        }

        static void PrintStatus()
        {

            Thread numberThread = threads.FirstOrDefault(x=>x.Name == "Number Thread") ,
                    datetimeThread = threads.FirstOrDefault(x=>x.Name == "Datetime Thread"), 
                    sentenceThread = threads.FirstOrDefault(x=>x.Name == "Sentence Thread");
            Console.WriteLine("_________________________________________________________________________");
            Console.WriteLine($"THREAD: {sentenceThread.Name} - IS ALIVE: {sentenceThread.IsAlive}");
            Console.WriteLine($"THREAD: {datetimeThread.Name} - IS ALIVE: { datetimeThread.IsAlive}");
            Console.WriteLine($"THREAD: {numberThread.Name} - IS ALIVE:  {numberThread.IsAlive}");
            Console.WriteLine("_________________________________________________________________________");
        }
    }
}
