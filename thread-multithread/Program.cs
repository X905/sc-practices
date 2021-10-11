using System;
using System.Globalization;

namespace thread_multithread
{
    //this is an example of the use of threads 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
        }

        //returns a randon sentence 
        static string RandomSentence (){
            Random rnd = new Random();
            string[] arr = new string[]{"Look","This","Football","Words","Styles","What","Programming","Rock","Repeat","The","He","Array"};
            int length = arr.Length;
            string output = "";
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
