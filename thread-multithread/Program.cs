using System;
using System.Globalization;
using System.Threading;

namespace thread_multithread
{
    //this is an example of the use of threads 
    class Program
    {
        static void Main(string[] args)
        {
            //example of normal operation on the default thread  
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "Main thread";
            Console.WriteLine(RandomSentence() + " --- RUNNING IN = " + currentThread.Name + " --- IS A BACKGROUND THREAD? " + currentThread.IsBackground);
            Console.WriteLine(RandomNumber() + " --- RUNNING IN = " + currentThread.Name +  " --- IS A BACKGROUND THREAD? " + currentThread.IsBackground);
            Console.WriteLine(GetDateTime() + " --- RUNNING IN = " + currentThread.Name +  " --- IS A BACKGROUND THREAD? " + currentThread.IsBackground);
            Console.ReadLine();
            Console.Clear();

            //example of a multithread process


            Console.Read();
        }

        //returns a randon sentence 
        static string RandomSentence (){
            Random rnd = new Random();
            string[] arr = new string[]{"Look","This","Football","Words","Styles","What","Programming","Rock","Repeat","The","He","Array"};
            int length = arr.Length;
            string output = arr[0];
            while(length > 1){
                output += (" " + arr[rnd.Next(--length)]).ToLower();
            }
            return output;
        }

        static int RandomNumber(){
            Random rnd = new Random();
            return rnd.Next(1, int.MaxValue);
        }


        static string GetDateTime(){
            CultureInfo culture = new CultureInfo("en-US");
            return(DateTime.Now.ToString("f",culture));
        }
    }
}
