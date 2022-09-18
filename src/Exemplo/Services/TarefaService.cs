using Benchmark.Models;
using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Benchmark
{

    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [IterationsColumn]
    [GcConcurrent]
    public class TarefaService
    {


        [Benchmark(Description = "Stream")]
        public async Task Buscar()
        {
            try
            {
                using var cliente = new HttpClient();
                using var resultado = await cliente.GetAsync($"https://jsonplaceholder.typicode.com/users/1/todos", HttpCompletionOption.ResponseHeadersRead);
                var tarefas = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Tarefa>>(await resultado.Content.ReadAsStreamAsync());
            }
            catch
            {
                throw;
            }

        }


        [Benchmark(Description = "String")]
        public async Task BuscarAsync()
        {
            try
            {
                using var cliente = new HttpClient();
                using var resultado = await cliente.GetAsync($"https://jsonplaceholder.typicode.com/users/1/todos", HttpCompletionOption.ResponseHeadersRead);
                var tarefas = System.Text.Json.JsonSerializer.Deserialize<List<Tarefa>>(await resultado.Content.ReadAsStringAsync());

            }
            catch
            {
                throw;
            }

        }
    }
}