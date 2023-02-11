using ByteBank.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Conta
{
    public class ContaCorrente
    {
        public static int TotalContas { get; private set; }

        public Cliente Titular { get; set; }

        public string Conta { get; set; }

        public string Agencia { get; set; }

        private double saldo;
        public double Saldo
        {
            get
            {
                return this.saldo;
            }

            set
            {
                if (value > 0)
                {
                    this.saldo = value;
                }
                else
                {
                    return;
                }

            }
        }


        public void Depositar(double valor)
        {
            saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (saldo >= valor)
            {
                saldo -= valor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (saldo >= valor)
            {
                Sacar(valor);
                destino.Depositar(valor);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ContaCorrente(Cliente cliente, string numeroAgencia, double saldoInicial)
        {
            this.Conta = Guid.NewGuid().ToString().Substring(0, 8);
            this.Agencia = numeroAgencia;
            this.Titular = cliente;
            this.Saldo = saldoInicial;
            TotalContas++;
        }  
      
    }
}