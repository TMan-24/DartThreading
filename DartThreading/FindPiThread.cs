/*
 * Arthur: Tony Anderson
 * Date: 10/27/2020
 * Filename: FindPiThread.cs
 * Description: This is a Thread class this is used by the program
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DartThreading
{
    class FindPiThread
    {
        private int darts;
        private int hits;
        Random throws;

        //Accesor for main
        public int hitsAccesor { get => hits; }

        //Parameterized Constructor
        public FindPiThread(int darts)
        {
            this.darts = darts;
            hits = 0;
            throws = new Random();
        }

        //Running Thread
        public void throwDarts()
        {
            for (int i = 0; i < darts; i++)
            {
                double x = throws.NextDouble();
                double y = throws.NextDouble();
                x *= x;
                y *= y;

                double guess = Math.Sqrt(x + y);

                if (guess <= 1)
                {
                    hits += 1;
                }

            }
        }
    }
}
