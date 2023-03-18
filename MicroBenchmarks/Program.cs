using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Running;

namespace Loops
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<MultiplicationBenchmarks>();
        }
    }
}