/*
 * Arthur: Tony Anderson
 * Date: 10/27/2020
 * Filename: Program.cs
 * Description: This is a program that 
 * estimates the value of pi using the monte carlo method
 * by throwing darts and use the ratio of darts that hit the
 * target
 * 
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace DartThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            int totaldarts = 0;
            int hits = 0;

            Console.WriteLine("How many darts do you want to throw at the board?");
            string string1  = Console.ReadLine();
            Console.WriteLine("How many threads do you want to throw your darts at?");
            string string2 = Console.ReadLine();

            int userDarts;
            int userThreads;

            int.TryParse(string1, out userDarts);
            int.TryParse(string2, out userThreads);

            //Threads
            List<Thread> threadslist = new List<Thread>(userThreads);
            List<FindPiThread> Pithreadslist  = new List<FindPiThread>(userThreads);

            //Setting up threads
            for(int i = 0; i < userThreads; i++)
            {
                FindPiThread piThread = new FindPiThread(userDarts);
                Pithreadslist.Add(piThread);
                Thread myThread = new Thread(new ThreadStart(piThread.throwDarts));
                threadslist.Add(myThread);
                myThread.Start();
                Thread.Sleep(16);
            }

            //Waiting
            for(int i = 0; i < threadslist.Count; i++)
            {
                threadslist[i].Join();
            }

            //Collecting Data
            for(int i = 0; i < Pithreadslist.Count; i++)
            {
                hits += Pithreadslist[i].hitsAccesor;
            }

            
            totaldarts = userDarts * userThreads;
            double piEvaluation = 4 * ((double)hits / (double)totaldarts);

            //Results
            Console.WriteLine($"The number of darts that hit are {hits}" );
            Console.WriteLine($"The total darts thrown at the target were {totaldarts}");
            Console.WriteLine($"The evaluation of Pi was {piEvaluation} ");

        }
    }
}
