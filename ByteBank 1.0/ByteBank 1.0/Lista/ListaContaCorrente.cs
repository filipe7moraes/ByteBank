using ByteBank.Conta;
using ByteBank.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_1._0.Lista
{
    public class ListaContaCorrente
    {
        private ContaCorrente[] contas = null;
        private int pos = 0;
        public ListaContaCorrente(int tamanhoInicial = 5)
        {
            contas = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente conta)
        {
            //Console.WriteLine($"Adicionando conta na posição {pos}");
            VerificarCapacidade(pos+1);
            contas[pos] = conta;
            pos++;
        }

        public void Remover(int indice)
        {
            ContaCorrente[] novoArray = new ContaCorrente[pos-1];
            for(int i=0;i < indice; i++)
            {
                novoArray[i] = contas[i];
            }
            for (int i = indice; i < (novoArray.Length); i++)
            {
                novoArray[i] = contas[i+1];   
            }
            contas = novoArray;
            pos =  pos-1; 
        }


        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (contas.Length >= tamanhoNecessario)
            {
                return;
            }
            //Console.WriteLine("Aumentando a capacidade da lista de contas!");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];
            for (int i = 0; i < contas.Length; i++)
            {
                novoArray[i] = contas[i];
            }
            contas = novoArray;
        }

        public int Tamanho()
        {
            return pos;
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return contas[indice];
            }
        }
   
    }
}
