﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.BigO
{
    class Lesson34
    {
        public void Run()
        {
            var nemo = new string[] { "nemo" };
            var everyone = new string[] { "dory", "bruce", "marlin", "nemo", "gill", "bloat", "nigel", "squirt", "darla", "hank" };
            var large = Enumerable.Repeat("nemo", 100000).ToArray();

            FindNemo(large); // O(n) -> Big O only cares about the worst case scenario
        }

        private void FindNemo(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("running");
                if (array[i] == "nemo")
                {
                    Console.WriteLine("Found NEMO!");
                    break;
                }
            }
        }
    }
}