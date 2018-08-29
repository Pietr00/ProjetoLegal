using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProjetoLegal.Modelo
{
    public class Funcionario
    {
        public string idFuncionario { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string dataDeNascimento { get; set; }
        public string conta { get; set; }
        public string salario { get; set; }
        // Construtor
        public Funcionario()
        {
            this.idFuncionario = "";
            this.nome = "";
            this.cpf = "";
            this.dataDeNascimento = "";
            this.conta = "";
            this.salario = "";
        }
        public Funcionario(string idFuncionario, string nome, string cpf, string dataDeNascimento, string conta, string salario)
        {
            this.idFuncionario = idFuncionario;
            this.nome = nome;
            this.cpf = cpf;
            this.dataDeNascimento = dataDeNascimento;
            this.conta = conta;
            this.salario = salario;
        }
    }​
}