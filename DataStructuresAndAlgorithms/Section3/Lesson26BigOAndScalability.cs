﻿using System;
using System.Diagnostics;
using System.Linq;

namespace DataStructuresAndAlgorithms.Lessons.Section3
{
    public class Lesson26BigOAndScalability : IBaseLesson
    {
        public void Run()
        {
            var nemo = new string[] { "nemo" };
            var everyone = new string[] { "dory", "bruce", "marlin", "nemo", "gill", "bloat", "nigel", "squirt", "darla", "hank" };
            var large = Enumerable.Repeat("nemo", 100000).ToArray();

            FindNemo(large);
        }

        private static void FindNemo(string[] array)
        {
            var timer = new Stopwatch();
            timer.Start();

            for (var i= 0; i < array.Length; i++)
            {
                if (array[i] == "nemo")
                {
                    Console.WriteLine("Found NEMO!");
                }
            }
            
            timer.Stop();
            Console.WriteLine("Call to find Nemo took " + timer.ElapsedMilliseconds + " miliseconds");
        }
    }
}
