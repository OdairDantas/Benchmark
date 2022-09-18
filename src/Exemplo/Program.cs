using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TarefaService>();

            Console.ReadKey();
        }
        
    }
}

