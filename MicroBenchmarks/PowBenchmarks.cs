using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Loops
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class MultiplicationBenchmarks
    {
        [Benchmark]
        public void DefaultBenchmark()
        {
            for (int i = 0; i < 100; i++)
            {
                int c = 25000 + i;
                double c1 = Math.PI * c * c;
            }
        }

        [Benchmark]
        public void TypeConversionBenchmark()
        {
            for (int i = 0; i < 100; i++)
            {
                double c = 25000.01 + i;
                double c1 = Math.PI * c * c;
            }
        }
        
        [Benchmark]
        public void OrderBenchmark()
        {
            for (int i = 0; i < 100; i++)
            {
                int c = 25000 + i;
                double c1 = (c * c) * Math.PI;
            }
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class PowBenchmarks
    {
        [Benchmark]
        public void FasterPowBenchmark()
        {
            double res = PowerHelper.FasterPow(1234.5, 12.1);
        }

        [Benchmark]
        public void MathPowBenchmark()
        {
            double res = Math.Pow(1234.5, 12.1);
        }

        /*[Benchmark]
        public void IntPowBenchmark()
        {
            int res = PowerHelper.IntPow(139, 4);
        }
        
        [Benchmark]
        public void IntPowByFasterPowBenchmark()
        {
            double res = Math.Round(Program.FasterPow(139, 7));
        }
        
        [Benchmark]
        public void IntPowByMathPowBenchmark()
        {
            double res = Math.Pow(139, 7);
        }*/
    }

    class PowerHelper
    {
        public static double FasterPow(double x, double y)
        {
            return Math.Exp(y * Math.Log(x));
        }

        public static int IntPow(int a, int b)
        {
            int result = 1;
            for (int i = 0; i < b; i++)
            {
                result *= a;
            }

            return result;
        }
    }
}