namespace Projeto_medicamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Processo finalizado.");
                        break;
                    case 1:
                        CadastrarMedicamento(medicamentos);
                        break;
                    case 2:
                        ConsultarMedicamentoSintetico(medicamentos);
                        break;
                    case 3:
                        ConsultarMedicamentoAnalitico(medicamentos);
                        break;
                    case 4:
                        ComprarMedicamento(medicamentos);
                        break;
                    case 5:
                        VenderMedicamento(medicamentos);
                        break;
                    case 6:
                        medicamentos.ListarMedicamentos();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }
        static void CadastrarMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do medicamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o laboratório do medicamento: ");
            string laboratorio = Console.ReadLine();

            Medicamento medicamento = new Medicamento(id, nome, laboratorio);
            medicamentos.Adicionar(medicamento);
            Console.WriteLine("Medicamento cadastrado com sucesso!");
        }
        static void ConsultarMedicamentoSintetico(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento para consulta: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento { Id = id });
            if (medicamento != null)
            {
                Console.WriteLine(medicamento.ToString());
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }
        static void ConsultarMedicamentoAnalitico(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento para consulta: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento { Id = id });
            if (medicamento != null)
            {
                Console.WriteLine(medicamento.ToString());
                foreach (var lote in medicamento.Lotes)
                {
                    Console.WriteLine(lote.ToString());
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }
        static void ComprarMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento para compra: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento { Id = id });
            if (medicamento != null)
            {
                Console.Write("Digite o ID do lote: ");
                int loteId = int.Parse(Console.ReadLine());

                Console.Write("Digite a quantidade do lote: ");
                int qtde = int.Parse(Console.ReadLine());

                Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
                DateTime venc = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Lote lote = new Lote(loteId, qtde, venc);
                medicamento.Comprar(lote);
                Console.WriteLine("Lote comprado e cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }

        static void VenderMedicamento(Medicamentos medicamentos)
        {
            Console.Write("Digite o ID do medicamento para venda: ");
            int id = int.Parse(Console.ReadLine());

            Medicamento medicamento = medicamentos.Pesquisar(new Medicamento { Id = id });
            if (medicamento != null)
            {
                Console.Write("Digite a quantidade para venda: ");
                int qtde = int.Parse(Console.ReadLine());

                bool sucesso = medicamento.Vender(qtde);
                if (sucesso)
                {
                    Console.WriteLine("Venda realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há quantidade suficiente para venda.");
                }
            }
            else
            {
                Console.WriteLine("Medicamento não encontrado.");
            }
        }
    }
}
