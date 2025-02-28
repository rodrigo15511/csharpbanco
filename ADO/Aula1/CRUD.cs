using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Diagnostics;

namespace Aula1
{
    public class CRUD
    {
        string conexao = "Host=localhost;Database=Back1;Username=postgres;Password=010206";

        void InserirUsuario(string nome, string email)
        {
            string query = $"insert into usuario (nome, email) values ('{nome}', '{email}')";

            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        void LerUsuario()
        {
            string query = "select * from usuario order by id";

            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using(NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        System.Console.WriteLine("USUARIOS");
                        while(dr.Read())
                        {
                            System.Console.WriteLine(dr["id"] + " - " + dr["nome"] + " - " + dr["email"]);
                        }
                    }
                }
                con.Close();
            }
        }

        void AtualizarUsuario(int id, string nome, string email)
        {
            string query = $"update usuario set nome = '{nome}', email = '{email}' where id = {id}";

            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        void DeletarUsuario(int id)
        {
            string query = $"delete from usuario where id = {id}";

            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        static void Main(string[] args)
        {
            CRUD crud = new CRUD();
            Stopwatch sw = new Stopwatch();
            TimeSpan tempoTotal;

            sw.Start();
            crud.LerUsuario();
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