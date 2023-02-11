using ByteBank.Conta;
using ByteBank.Titular;
using ByteBank_1._0.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_1._0.Atendimento
{
    public class Atendimento
    {
        ListaClientes listaClientes = new ListaClientes();
        ListaContaCorrente listaContaCorrente = new ListaContaCorrente();

        public void AtendimentoCliente()
        {
            char opcao = '0';
            while (opcao != '5')
            {
                Console.Clear();
                Console.WriteLine(" ---------------------- ");
                Console.WriteLine("| *** Atendimento *** |");
                Console.WriteLine("| 1 - Cadastrar Conta |");
                Console.WriteLine("| 2 - Listar Contas   |");
                Console.WriteLine("| 3 - Remover Conta   |");
                Console.WriteLine("| 4 - Pesquisar Conta |");
                Console.WriteLine("| 5 - Sair do Sistema |");
                Console.WriteLine(" ---------------------- ");
                Console.WriteLine();
                Console.Write("Digite a opção desejada: ");

                opcao = Console.ReadLine()[0]; //Pega apenas o primeiro elemento da string 
                switch (opcao)
                {
                    case '1':
                        CadastrarConta();
                        break;
                    case '2':
                        ListarContas();
                        break;
                    case '3':
                        RemoverConta();
                        break;
                    case '4':
                        PesquisarConta();
                        break;
                    case '5':
                        EncerraAtendimento();
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
        }

        private void CadastrarConta()
        {
            string nome;
            string cpf;
            string profissao;
            string numeroAgencia;
            int numeroConta;
            double saldoInicial;

            Console.Clear();
            Console.WriteLine(" -------------------- ");
            Console.WriteLine("| CADASTRO DE CONTAS |");
            Console.WriteLine(" -------------------- ");
            Console.WriteLine();
            Console.WriteLine("*** Informe dados da conta ***");

            Console.Write($"Digite o nome completo do cliente: ");
            nome = Console.ReadLine();

            Console.Write($"Digite o CPF do cliente: ");
            cpf = Console.ReadLine();

            Console.Write($"Digite a profissão do cliente: ");
            profissao = Console.ReadLine();

            Console.Write($"Digite o número da agência a ser cadastrada: ");
            numeroAgencia = Console.ReadLine();

            Console.Write($"Digite o saldo inicial da conta: ");
            saldoInicial = double.Parse(Console.ReadLine());

            Cliente cliente = new Cliente(nome, cpf, profissao);
            listaClientes.Adicionar(cliente);

            ContaCorrente conta = new ContaCorrente(cliente,numeroAgencia,saldoInicial);
            listaContaCorrente.Adicionar(conta);

            Console.WriteLine();
            Console.WriteLine("*** Conta cadastrada com sucesso! ***");
            VoltaAoMenu();
        }

        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine(" -------------------- ");
            Console.WriteLine("| CONTAS CADASTRADAS |");
            Console.WriteLine(" -------------------- ");
            Console.WriteLine();

            if (listaContaCorrente.Tamanho() <= 0)
            {
                Console.WriteLine("*** Não há contas cadastradas! ***");
                VoltaAoMenu();
                return;
            }

            for (int i = 0; i < listaContaCorrente.Tamanho(); i++)
            {
                MostrarConta(i);
            }
            VoltaAoMenu();
        }

        private void RemoverConta()
        {
            Console.Clear();
            Console.WriteLine(" ------------------- ");
            Console.WriteLine("| REMOÇÃO DE CONTAS |");
            Console.WriteLine(" ------------------- ");
            Console.WriteLine();
            Console.Write("Digite o nome completo do cliente a ser removido: ");

            string nomeBusca = Console.ReadLine();
            int indice = BuscarIndiceConta(nomeBusca);

            if (indice == -1)
            {
                Console.WriteLine();
                Console.WriteLine("*** Nenhum cliente encontrado! ***");
                VoltaAoMenu();
                return;
            }

            Console.WriteLine();
            MostrarConta(indice);
            Console.Write("Deseja realmente remover a conta(S/N)?");

            string resposta = Console.ReadLine();
            if ((String.Compare(resposta, "s", comparisonType: StringComparison.OrdinalIgnoreCase)) == 0)
            {
                listaContaCorrente.Remover(indice);
                Console.WriteLine();
                Console.WriteLine("*** Conta removida com sucesso! ***");
            }
            VoltaAoMenu();
        }

        private void MostrarConta(int indice)
        {
            Console.WriteLine("Nome do titular: " + listaContaCorrente[indice].Titular.Nome);
            Console.WriteLine("CPF do titular: " + listaContaCorrente[indice].Titular.Cpf);
            Console.WriteLine("Profissão: " + listaContaCorrente[indice].Titular.Profissao);
            Console.WriteLine("Número da conta: " + listaContaCorrente[indice].Conta);
            Console.WriteLine("Número da agência: " + listaContaCorrente[indice].Agencia);
            Console.WriteLine("Saldo: R$ " + listaContaCorrente[indice].Saldo);
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }

        private int BuscarIndiceConta(string nomeBusca)
        {
            int comparacao;
            int indice;

            for (int i = 0; i < listaContaCorrente.Tamanho(); i++)
            {
                comparacao = String.Compare(nomeBusca, listaContaCorrente[i].Titular.Nome, comparisonType: StringComparison.OrdinalIgnoreCase);
                if (comparacao == 0)
                {
                    indice = i;
                    return indice;
                }
            }
            return -1;
        }

        private void PesquisarConta()
        {
            Console.Clear();
            Console.WriteLine(" -------------------- ");
            Console.WriteLine("| PESQUISA DE CONTAS |");
            Console.WriteLine(" -------------------- ");
            Console.WriteLine();
            Console.Write("Digite o nome completo do cliente a ser buscado: ");

            string nomeBusca = Console.ReadLine();
            int indice = BuscarIndiceConta(nomeBusca);

            if (indice == -1)
            {
                Console.WriteLine();
                Console.WriteLine("*** Nenhum cliente encontrado! ***");
                VoltaAoMenu();
                return;
            }
            Console.WriteLine();
            MostrarConta(indice);
            VoltaAoMenu();
        }

        private void EncerraAtendimento()
        {
            Console.WriteLine();
            Console.WriteLine("Programa finalizado! Pressione ENTER para fechar!");
            Console.ReadKey();
        }

        private void VoltaAoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar ao menu principal");
            Console.ReadKey();
        }



    }
}
