using ByteBank.Conta;
using ByteBank.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_1._0.Lista
{
    public class ListaClientes
    {
        private Cliente[] clientes = null;
        private int pos = 0;
        public ListaClientes(int tamanhoInicial = 5)
        {
            clientes = new Cliente [tamanhoInicial];
        }

        public void Adicionar(Cliente cliente)
        {
            //Console.WriteLine($"Adicionando cliente na posição {pos}");
            VerificarCapacidade(pos + 1);
            clientes[pos] = cliente;
            pos++;
        }


        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (clientes.Length >= tamanhoNecessario)
            {
                return;
            }
            //Console.WriteLine("Aumentando a capacidade da lista de clientes!");
            Cliente[] novoArray = new Cliente[tamanhoNecessario];

            for (int i = 0; i < clientes.Length; i++)
            {
                novoArray[i] = clientes[i];
            }
            clientes = novoArray;
        }

        public int Tamanho()
        {
            return pos;
        }

        public Cliente this[int indice]
        {
            get
            {
                return clientes[indice];
            }
        }
    }
}
