using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationProjetoLegal.DAL
{
    public class DALFuncionario
    {
        string connectionString = "";

        public DALFuncionario()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2017WhatIFConnectionString"].ConnectionString;
        }
        //SelectAll
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Funcionario> SelectAll()
        {
            Modelo.Funcionario DALfuncionario;
            // Cria Lista Vazia
            List<Modelo.Funcionario> DALlistFuncionario = new List<Modelo.Funcionario>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Funcionario";
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    DALfuncionario = new Modelo.Funcionario(
                        dr["idFuncionario"].ToString(),
                        dr["nome"].ToString(),
                        dr["cpf"].ToString(),
                        dr["dataDeNascimento"].ToString(),
                        dr["conta"].ToString(),
                        dr["salario"].ToString());

                    // Adiciona o livro lido à lista
                    DALlistFuncionario.Add(DALfuncionario);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return DALlistFuncionario;
        }

        //Select
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Funcionario> Select(int idFuncionario)
        {
            // Variavel para armazenar um modulo
            Modelo.Funcionario DALfuncionario;
            // Cria Lista Vazia
            List<Modelo.Funcionario> DALlistFuncionario = new List<Modelo.Funcionario>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Funcionario Where idFuncionario = @idFuncionario";
            cmd.Parameters.AddWithValue("@idFuncionario", idFuncionario);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do modulo do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    DALfuncionario = new Modelo.Funcionario(
                        dr["idFuncionario"].ToString(),
                        dr["nome"].ToString(),
                        dr["cpf"].ToString(),
                        dr["dataDeNascimento"].ToString(),
                        dr["conta"].ToString(),
                        dr["salario"].ToString());
                    // Adiciona o livro lido à lista
                    DALlistFuncionario.Add(DALfuncionario);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return DALlistFuncionario;
        }

        //Delete
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Funcionario obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();

            SqlCommand cmd = new SqlCommand("DELETE FROM Funcionario WHERE idFuncionario = @idFuncionario", conn);
            cmd.Parameters.AddWithValue("@idFuncionario", obj.idFuncionario);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        //Insert
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Funcionario obj)
        {
            SqlConnection sc = new SqlConnection(connectionString);
            sc.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Funcionario(nome, cpf, dataDeNascimento, conta, salario) VALUES(@nome, @cpf, @dataDeNascimento, @conta, @salario)";
            cmd.Parameters.AddWithValue("@nome", obj.nome);
            cmd.Parameters.AddWithValue("@cpf", obj.cpf);
            cmd.Parameters.AddWithValue("@dataDeNascimento", obj.dataDeNascimento);
            cmd.Parameters.AddWithValue("@conta", obj.conta);
            cmd.Parameters.AddWithValue("@salario", obj.salario);
            cmd.Connection = sc;

            cmd.ExecuteNonQuery();
            sc.Close();
        }

        //Update
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Funcionario obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE Funcionario SET nome = @nome, cpf = @cpf, dataDeNascimento = @dataDeNascimento, conta = @conta, salario = @salario WHERE idFuncionario = @idFuncionario", conn);
            cmd.Parameters.AddWithValue("@idFuncionario", obj.idFuncionario);
            cmd.Parameters.AddWithValue("@nome", obj.nome);
            cmd.Parameters.AddWithValue("@cpf", obj.cpf);
            cmd.Parameters.AddWithValue("@dataDeNascimento",obj.dataDeNascimento);
            cmd.Parameters.AddWithValue("@conta", obj.conta);
            cmd.Parameters.AddWithValue("@salario", obj.salario);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }
    }
}