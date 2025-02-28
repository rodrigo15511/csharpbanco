using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Aula2
{
    public class Program
    {
        static void Main(string[] args)
        {
            CRUD crud = new CRUD();
            Stopwatch sw = new Stopwatch();
            TimeSpan tempoTotal;

            sw.Start();
            crud.ListarUsuarios();
            sw.Stop();
            System.Console.WriteLine($"Tempo de execução: {sw.ElapsedMilliseconds} ms");


            TimeSpan tempoLeitura = sw.Elapsed;

            sw.Restart();
            System.Console.WriteLine("----------------------");
            crud.InserirUsuario("Carlos", "carlos@email");
            sw.Stop();
            System.Console.WriteLine($"Tempo de execução: {sw.ElapsedMilliseconds} ms");
            TimeSpan tempoInsercao = sw.Elapsed;

            sw.Restart();
            System.Console.WriteLine("----------------------");
            crud.AtualizarUsuario(1, "Pablo", "pablo@email");
            sw.Stop();
            System.Console.WriteLine($"Tempo de execução: {sw.ElapsedMilliseconds} ms");
            TimeSpan tempoAtualizacao = sw.Elapsed;

            sw.Restart();
            System.Console.WriteLine("----------------------");
            crud.DeletarUsuario(1);
            sw.Stop();
            System.Console.WriteLine($"Tempo de execução: {sw.ElapsedMilliseconds} ms");
            TimeSpan tempoDelecao = sw.Elapsed;

            tempoTotal = tempoLeitura + tempoInsercao + tempoAtualizacao + tempoDelecao;
            System.Console.WriteLine($"Tempo total de execução: {tempoTotal}");

        }
    }
}