using System;

namespace Proj_Contato
{
    internal class Program
    {
        static Contatos contatos = new Contatos();

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                MostrarMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        sair = true;
                        break;
                    case "1":
                        AdicionarContato();
                        break;
                    case "2":
                        PesquisarContato();
                        break;
                    case "3":
                        AlterarContato();
                        break;
                    case "4":
                        RemoverContato();
                        break;
                    case "5":
                        ListarContatos();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Pesquisar contato");
            Console.WriteLine("3. Alterar contato");
            Console.WriteLine("4. Remover contato");
            Console.WriteLine("5. Listar contatos");
            Console.Write("Opção: ");
        }

        static void AdicionarContato()
        {
            Console.WriteLine("Adicionar Contato");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Data de Nascimento (dd/mm/aaaa): ");
            string[] dataNasc = Console.ReadLine().Split('/');
            var data = new Data();
            data.setData(int.Parse(dataNasc[0]), int.Parse(dataNasc[1]), int.Parse(dataNasc[2]));

            var contato = new Contato(nome, email, data);

            Console.Write("Adicionar telefone principal (sim/nao): ");
            if (Console.ReadLine().ToLower() == "sim")
            {
                Console.Write("Tipo de telefone: ");
                string tipo = Console.ReadLine();

                Console.Write("Número: ");
                string numero = Console.ReadLine();

                var telefone = new Telefone(tipo, numero, true);
                contato.AdicionarTelefone(telefone);
            }

            if (contatos.Adicionar(contato))
            {
                Console.WriteLine("Contato adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro: Contato já existe.");
            }
            Console.ReadLine();
        }

        static void PesquisarContato()
        {
            Console.WriteLine("Pesquisar Contato");

            Console.Write("Email: ");
            string email = Console.ReadLine();

            var contato = contatos.Pesquisar(new Contato("", email, new Data()));

            if (contato != null)
            {
                Console.WriteLine(contato.ToString());
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }

            Console.ReadLine();
        }

        static void AlterarContato()
        {
            Console.WriteLine("Alterar Contato");

            Console.Write("Email do contato a ser alterado: ");
            string email = Console.ReadLine();

            var contato = contatos.Pesquisar(new Contato("", email, new Data()));

            if (contato != null)
            {
                Console.Write("Novo nome: ");
                contato.Nome = Console.ReadLine();

                Console.Write("Novo email: ");
                contato.Email = Console.ReadLine();

                Console.Write("Alterar data de nascimento (dd/mm/aaaa): ");
                string[] dataNasc = Console.ReadLine().Split('/');
                var data = new Data();
                data.setData(int.Parse(dataNasc[0]), int.Parse(dataNasc[1]), int.Parse(dataNasc[2]));
                contato.DtNasc = data;

                Console.Write("Adicionar telefone principal (sim/nao): ");
                if (Console.ReadLine().ToLower() == "sim")
                {
                    Console.Write("Tipo de telefone: ");
                    string tipo = Console.ReadLine();

                    Console.Write("Número: ");
                    string numero = Console.ReadLine();

                    var telefone = new Telefone(tipo, numero, true);
                    contato.AdicionarTelefone(telefone);
                }

                if (contatos.Alterar(contato))
                {
                    Console.WriteLine("Contato alterado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Erro ao alterar o contato.");
                }
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }

            Console.ReadLine();
        }

        static void RemoverContato()
        {
            Console.WriteLine("Remover Contato");

            Console.Write("Email do contato a ser removido: ");
            string email = Console.ReadLine();

            var contato = contatos.Pesquisar(new Contato("", email, new Data()));

            if (contato != null)
            {
                if (contatos.Remover(contato))
                {
                    Console.WriteLine("Contato removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Erro ao remover o contato.");
                }
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }

            Console.ReadLine();
        }

        static void ListarContatos()
        {
            Console.WriteLine("Listar Contatos");

            contatos.Listar();

            Console.ReadLine();
        }
    }
}
