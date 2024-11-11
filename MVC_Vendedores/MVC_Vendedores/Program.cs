namespace MVC_Vendedores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores();
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Cadastrar vendedor");
                Console.WriteLine("2 - Consultar vendedor");
                Console.WriteLine("3 - Excluir vendedor");
                Console.WriteLine("4 - Registrar venda");
                Console.WriteLine("5 - Listar vendedores");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        sair = true;
                        break;

                    case "1":
                        CadastrarVendedor(vendedores);
                        break;

                    case "2":
                        ConsultarVendedor(vendedores);
                        break;

                    case "3":
                        ExcluirVendedor(vendedores);
                        break;

                    case "4":
                        RegistrarVenda(vendedores);
                        break;

                    case "5":
                        ListarVendedores(vendedores);
                        break;

                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        // Método para cadastrar um vendedor
        static void CadastrarVendedor(Vendedores vendedores)
        {
            if (vendedores.Qtde < 10)
            {
                Console.Write("Digite o ID do vendedor: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Digite o nome do vendedor: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o percentual de comissão do vendedor: ");
                double percComissao = double.Parse(Console.ReadLine());

                Vendedor vendedor = new Vendedor(id, nome, percComissao);
                if (vendedores.AddVendedor(vendedor))
                    Console.WriteLine("Vendedor cadastrado com sucesso!");
                else
                    Console.WriteLine("Erro ao cadastrar vendedor. Limite de 10 vendedores atingido.");
            }
            else
            {
                Console.WriteLine("Limite de 10 vendedores atingido.");
            }
            Console.ReadLine();
        }

        // Método para consultar um vendedor
        static void ConsultarVendedor(Vendedores vendedores)
        {
            Console.Write("Digite o ID do vendedor para consulta: ");
            int idConsulta = int.Parse(Console.ReadLine());

            Vendedor vendedorConsulta = vendedores.SearchVendedor(idConsulta);
            if (vendedorConsulta != null)
            {
                Console.WriteLine($"ID: {vendedorConsulta.Id}");
                Console.WriteLine($"Nome: {vendedorConsulta.Nome}");
                Console.WriteLine($"Total de Vendas: {vendedorConsulta.ValorVendas():C2}");
                Console.WriteLine($"Comissão: {vendedorConsulta.ValorComissao():C2}");
                Console.WriteLine($"Média das Vendas: {vendedorConsulta.ValorMedioVendas():C2}");
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado.");
            }
            Console.ReadLine();
        }

        // Método para excluir um vendedor
        static void ExcluirVendedor(Vendedores vendedores)
        {
            Console.Write("Digite o ID do vendedor para exclusão: ");
            int idExcluir = int.Parse(Console.ReadLine());

            if (vendedores.DelVendedor(idExcluir))
                Console.WriteLine("Vendedor excluído com sucesso.");
            else
                Console.WriteLine("Não foi possível excluir o vendedor. Verifique se ele possui vendas registradas.");
            Console.ReadLine();
        }

        // Método para registrar uma venda
        static void RegistrarVenda(Vendedores vendedores)
        {
            Console.Write("Digite o ID do vendedor: ");
            int idVenda = int.Parse(Console.ReadLine());
            Vendedor vendedorVenda = vendedores.SearchVendedor(idVenda);
            if (vendedorVenda != null)
            {
                Console.Write("Digite o dia da venda (1-31): ");
                int diaVenda = int.Parse(Console.ReadLine());

                Console.Write("Digite a quantidade de itens vendidos: ");
                int qtde = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor total da venda: ");
                double valor = double.Parse(Console.ReadLine());

                Venda venda = new Venda(qtde, valor);
                vendedorVenda.RegistrarVenda(diaVenda, venda);
                Console.WriteLine("Venda registrada com sucesso.");
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado.");
            }
            Console.ReadLine();
        }

        // Método para listar todos os vendedores
        static void ListarVendedores(Vendedores vendedores)
        {
            vendedores.ListarVendedores();
            Console.ReadLine();
        }
    }
}