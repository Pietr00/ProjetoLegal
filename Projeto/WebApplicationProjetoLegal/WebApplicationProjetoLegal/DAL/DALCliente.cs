using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationProjetoLegal.DAL
{
    public class DALCliente
    {
        string connectionString = "";

        public DALCliente()
        {
            connectionString = ConfigurationManager.ConnectionStrings["2017WhatIFConnectionString"].ConnectionString;
        }
        //SelectAll
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Cliente> SelectAll()
        {
            Modelo.Cliente DALcliente;
            // Cria Lista Vazia
            List<Modelo.Cliente> DALlistCliente = new List<Modelo.Cliente>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Cliente";
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    DALcliente = new Modelo.Cliente(
                        dr["idCliente"].ToString(),
                        dr["nome"].ToString(),
                        dr["cpf"].ToString(),
                        dr["dataDeNascimento"].ToString());

                    // Adiciona o livro lido à lista
                    DALlistCliente.Add(DALcliente);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return DALlistCliente;
        }

        //Select
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Modelo.Cliente> Select(int idCliente)
        {
            // Variavel para armazenar um modulo
            Modelo.Cliente DALcliente;
            // Cria Lista Vazia
            List<Modelo.Cliente> DALlistCliente = new List<Modelo.Cliente>();
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand cmd = conn.CreateCommand();
            // define SQL do comando
            cmd.CommandText = "Select * from Cliente Where idCliente = @idCliente";
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            // Executa comando, gerando objeto DbDataReader
            SqlDataReader dr = cmd.ExecuteReader();
            // Le titulo do modulo do resultado e apresenta no segundo rótulo
            if (dr.HasRows)
            {

                while (dr.Read()) // Le o proximo registro
                {
                    // Cria objeto com dados lidos do banco de dados
                    DALcliente = new Modelo.Cliente(
                        dr["idCliente"].ToString(),
                        dr["nome"].ToString(),
                        dr["cpf"].ToString(),
                        dr["dataDeNascimento"].ToString());
                    // Adiciona o livro lido à lista
                    DALlistCliente.Add(DALcliente);
                }
            }
            // Fecha DataReader
            dr.Close();
            // Fecha Conexão
            conn.Close();

            return DALlistCliente;
        }

        //Delete
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(Modelo.Cliente obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();

            SqlCommand cmd = new SqlCommand("DELETE FROM Cliente WHERE idCliente = @idCliente", conn);
            cmd.Parameters.AddWithValue("@idCliente", obj.idCliente);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }

        //Insert
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Modelo.Cliente obj)
        {
            SqlConnection sc = new SqlConnection(connectionString);
            sc.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Cliente(nome, cpf, dataDeNascimento) VALUES(@nome, @cpf, @dataDeNascimento)";
            cmd.Parameters.AddWithValue("@nome", obj.nome);
            cmd.Parameters.AddWithValue("@cpf", obj.cpf);
            cmd.Parameters.AddWithValue("@dataDeNascimento", obj.dataDeNascimento);
            cmd.Connection = sc;

            cmd.ExecuteNonQuery();
            sc.Close();
        }

        //Update
        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update(Modelo.Cliente obj)
        {
            // Cria Conexão com banco de dados
            SqlConnection conn = new SqlConnection(connectionString);
            // Abre conexão com o banco de dados
            conn.Open();
            // Cria comando SQL
            SqlCommand com = conn.CreateCommand();
            SqlCommand cmd = new SqlCommand("UPDATE Cliente SET nome = @nome, cpf = @cpf, dataDeNascimento = @dataDeNascimento WHERE idCliente = @idCliente", conn);
            cmd.Parameters.AddWithValue("@idCliente", obj.idCliente);
            cmd.Parameters.AddWithValue("@nome", obj.nome);
            cmd.Parameters.AddWithValue("@cpf", obj.cpf);
            cmd.Parameters.AddWithValue("@dataDeNascimento", obj.dataDeNascimento);

            // Executa Comando
            cmd.ExecuteNonQuery();

        }
    }
}