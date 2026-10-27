using System;

class Program
{
    static Medicamentos medicamentos = new Medicamentos();

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("          SISTEMA DA FARMÁCIA");
            Console.WriteLine("======================================");
            Console.WriteLine("0 - Finalizar processo");
            Console.WriteLine("1 - Cadastrar medicamento");
            Console.WriteLine("2 - Consultar medicamento - Sintético");
            Console.WriteLine("3 - Consultar medicamento - Analítico");
            Console.WriteLine("4 - Comprar medicamento - Cadastrar lote");
            Console.WriteLine("5 - Vender medicamento");
            Console.WriteLine("6 - Listar medicamentos");
            Console.WriteLine("======================================");

            Console.Write("Digite uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    cadastrarMedicamento();
                    break;

                case 2:
                    consultarSintetico();
                    break;

                case 3:
                    consultarAnalitico();
                    break;

                case 4:
                    comprarMedicamento();
                    break;

                case 5:
                    venderMedicamento();
                    break;

                case 6:
                    listarMedicamentos();
                    break;

                case 0:
                    Console.WriteLine("Processo finalizado.");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }

        } while (opcao != 0);
    }

    static void cadastrarMedicamento()
    {
        Console.WriteLine("=== CADASTRAR MEDICAMENTO ===");

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Laboratório: ");
        string laboratorio = Console.ReadLine();

        Medicamento medicamento = new Medicamento(
            id,
            nome,
            laboratorio
        );

        Medicamento existente = medicamentos.pesquisar(medicamento);

        if (existente.getId() != 0)
        {
            Console.WriteLine("Já existe um medicamento com esse ID.");
            return;
        }

        medicamentos.adicionar(medicamento);

        Console.WriteLine("Medicamento cadastrado com sucesso.");
    }

    static void consultarSintetico()
    {
        Console.WriteLine("=== CONSULTAR MEDICAMENTO ===");

        Console.Write("Digite o ID: ");
        int id = int.Parse(Console.ReadLine());

        Medicamento medicamento = new Medicamento();
        Medicamento pesquisa = new Medicamento(id, "", "");

        medicamento = medicamentos.pesquisar(pesquisa);

        if (medicamento.getId() == 0)
        {
            Console.WriteLine("Medicamento não encontrado.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Dados do medicamento:");
        Console.WriteLine(medicamento.ToString());
    }

    static void consultarAnalitico()
    {
        Console.WriteLine("=== CONSULTA ANALÍTICA ===");

        Console.Write("Digite o ID: ");
        int id = int.Parse(Console.ReadLine());

        Medicamento pesquisa = new Medicamento(id, "", "");

        Medicamento medicamento = medicamentos.pesquisar(pesquisa);

        if (medicamento.getId() == 0)
        {
            Console.WriteLine("Medicamento não encontrado.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("DADOS DO MEDICAMENTO");
        Console.WriteLine("---------------------");
        Console.WriteLine(medicamento.ToString());

        Console.WriteLine();
        Console.WriteLine("LOTES");
        Console.WriteLine("---------------------");

        if (medicamento.getLotes().Count == 0)
        {
            Console.WriteLine("Nenhum lote cadastrado.");
            return;
        }

        foreach (Lote lote in medicamento.getLotes())
        {
            Console.WriteLine(lote.ToString());
        }
    }

    static void comprarMedicamento()
    {
        Console.WriteLine("=== COMPRAR MEDICAMENTO ===");

        Console.Write("ID do medicamento: ");
        int idMedicamento = int.Parse(Console.ReadLine());

        Medicamento pesquisa = new Medicamento(
            idMedicamento,
            "",
            ""
        );

        Medicamento medicamento = medicamentos.pesquisar(pesquisa);

        if (medicamento.getId() == 0)
        {
            Console.WriteLine("Medicamento não encontrado.");
            return;
        }

        Console.Write("ID do lote: ");
        int idLote = int.Parse(Console.ReadLine());

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Data de vencimento (dd/MM/yyyy): ");
        DateTime vencimento = DateTime.Parse(Console.ReadLine());

        Lote lote = new Lote(
            idLote,
            quantidade,
            vencimento
        );

        medicamento.comprar(lote);

        Console.WriteLine("Lote cadastrado com sucesso.");
    }

    static void venderMedicamento()
    {
        Console.WriteLine("=== VENDER MEDICAMENTO ===");

        Console.Write("ID do medicamento: ");
        int idMedicamento = int.Parse(Console.ReadLine());

        Medicamento pesquisa = new Medicamento(
            idMedicamento,
            "",
            ""
        );

        Medicamento medicamento = medicamentos.pesquisar(pesquisa);

        if (medicamento.getId() == 0)
        {
            Console.WriteLine("Medicamento não encontrado.");
            return;
        }

        Console.Write("Quantidade para venda: ");
        int quantidade = int.Parse(Console.ReadLine());

        bool sucesso = medicamento.vender(quantidade);

        if (sucesso)
        {
            Console.WriteLine("Venda realizada com sucesso.");
            Console.WriteLine(
                "Quantidade disponível: " +
                medicamento.qtdeDisponivel()
            );
        }
        else
        {
            Console.WriteLine(
                "Não foi possível realizar a venda."
            );

            Console.WriteLine(
                "Quantidade disponível: " +
                medicamento.qtdeDisponivel()
            );
        }
    }

    static void listarMedicamentos()
    {
        Console.WriteLine("=== LISTA DE MEDICAMENTOS ===");

        if (medicamentos.listar().Count == 0)
        {
            Console.WriteLine("Nenhum medicamento cadastrado.");
            return;
        }

        foreach (Medicamento medicamento in medicamentos.listar())
        {
            Console.WriteLine(medicamento.ToString());
        }
    }
}
