using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;


namespace Aula1
{
    public class Executar
    {
        static void Maina(string[] args)
        {
            string conexao = "Host=localhost;Database=Back1;Username=postgres;Password=010206";

            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                try {
                    con.Open();
                    System.Console.WriteLine("Conexão aberta com Postgres!");

                    string query = "Select * from usuario order by id";

                    string insert = "Insert into usuario (nome, email) values ('Maria', 'maria@email')";

                    string update = "Update usuario set nome = 'Pablo', email = 'pablo@email' where id = 1";

                    string delete = "Delete from usuario where id = 5";

                    // using(NpgsqlCommand cmd = new NpgsqlCommand(insert, con))
                    // {
                    //     int row = cmd.ExecuteNonQuery();

                    //     System.Console.WriteLine("Inserido: " + row);
                    // }

                    // using(NpgsqlCommand cmd = new NpgsqlCommand(update, con))
                    // {
                    //     int row = cmd.ExecuteNonQuery();

                    //     System.Console.WriteLine("Atualizado: " + row);
                    // }

                    // using(NpgsqlCommand cmd = new NpgsqlCommand(delete, con))
                    // {
                    //     int row = cmd.ExecuteNonQuery();

                    //     System.Console.WriteLine("Deletado: " + row);
                    // }

                    using(NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            System.Console.WriteLine("Tabelas do banco de dados:");
                            while(dr.Read())
                            {
                                System.Console.WriteLine(dr["id"] + " - " + dr["nome"] + " - " + dr["email"]);
                            }
                        }
                    }
                }   

                catch (NpgsqlException ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);

                }             
            }
        }
    }
}