using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProjetoLegal.Modelo
{
    public class Cliente
    {
            public string idCliente { get; set; }
            public string nome { get; set; }
            public string cpf { get; set; }
            public string dataDeNascimento { get; set; }
            // Construtor
            public Cliente()
            {
                this.idCliente = "";
                this.nome = "";
                this.cpf = "";
                this.dataDeNascimento = "";
            }
            public Cliente(string idCliente, string nome, string cpf, string dataDeNascimento)
            {
                this.idCliente = idCliente;
                this.nome = nome;
                this.cpf = cpf;
                this.dataDeNascimento = dataDeNascimento;
            }
    }
}