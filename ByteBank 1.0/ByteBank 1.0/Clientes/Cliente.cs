using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Titular
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Profissao { get; set; }

        public static int TotalClientes { get; private set; }
        public Cliente(string nome, string cpf, string profissao)
        {
            TotalClientes++;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Profissao = profissao;
            
        }

    }

   
}
