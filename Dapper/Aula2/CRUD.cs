using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Aula2
{
    public class CRUD
    {
        public void InserirUsuario(string nome, string email)
        {
            using (var db = Conexao.GetConexao())
            {
                try
                {
                    db.Execute($"insert into usuario (nome, email) values ('{nome}','{email}')");
                    System.Console.WriteLine("Usuário inserido com sucesso!");
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Erro ao inserir usuário!");
                    throw;
                }
            }
        }

        public void ListarUsuarios()
        {
            using(IDbConnection db = Conexao.GetConexao())
            {
                string query = "select * from usuario";
                var usuarios = db.Query<Usuario>(query);
                foreach (var usuario in usuarios)
                {
                    System.Console.WriteLine($"Id: {usuario.Id} Nome: {usuario.Nome} Email: {usuario.Email}");
                }
            }
        }

        public void AtualizarUsuario(int id, string novoNome, string novoEmail)
        {
            using (var db = Conexao.GetConexao())
            {
                try
                {
                    db.Execute($"update usuario set nome = '{novoNome}', email = '{novoEmail}' where id = {id}");
                    System.Console.WriteLine("Usuário atualizado com sucesso!");
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Erro ao atualizar usuário!");
                    throw;
                }
            }
        }

        public void DeletarUsuario(int id)
        {
            using (var db = Conexao.GetConexao())
            {
                try
                {
                    db.Execute($"delete from usuario where id = {id}");
                    System.Console.WriteLine("Usuário deletado com sucesso!");
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Erro ao deletar usuário!");
                    throw;
                }
            }
        }
    }
}