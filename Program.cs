public class Program
{
    static int vagasPrivativas, vagasPrioritarias, vagasComuns;
    static string? ultimaEntradaPlaca, ultimaEntradaModelo, ultimaEntradaCor, ultimaEntradaProprietario;
    static string? ultimaSaidaPlaca, ultimaSaidaModelo, ultimaSaidaCor, ultimaSaidaProprietario;

    public static void Main(string[] args)
    {
        Console.WriteLine("Digite a quantidade de vagas privativas: ");
        vagasPrivativas = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Digite a quantidade de vagas prioritárias: ");
        vagasPrioritarias = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Digite a quantidade de vagas comuns: ");
        vagasComuns = int.Parse(Console.ReadLine()!);

        int opcao;
        do
        {
            opcao = Menu();
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite os dados do veículo para registrar entrada:");
                    Console.Write("Placa: ");
                    string placaEntrada = Console.ReadLine()!;
                    Console.Write("Modelo: ");
                    string modeloEntrada = Console.ReadLine()!;
                    Console.Write("Cor: ");
                    string corEntrada = Console.ReadLine()!;
                    Console.Write("Proprietário: ");
                    string proprietarioEntrada = Console.ReadLine()!;
                    Console.Write("Tipo de vaga (1-Privativa, 2-Prioritária, 3-Comum): ");
                    int tipoVagaEntrada = int.Parse(Console.ReadLine()!);

                    RegistrarEntrada(placaEntrada, modeloEntrada, corEntrada, proprietarioEntrada, tipoVagaEntrada);
                    break;

                case 2:
                    Console.WriteLine("Digite os dados do veículo para registrar saída:");
                    Console.Write("Placa: ");
                    string placaSaida = Console.ReadLine()!;
                    Console.Write("Modelo: ");
                    string modeloSaida = Console.ReadLine()!;
                    Console.Write("Cor: ");
                    string corSaida = Console.ReadLine()!;
                    Console.Write("Proprietário: ");
                    string proprietarioSaida = Console.ReadLine()!;
                    Console.Write("Tipo de vaga (1-Privativa, 2-Prioritária, 3-Comum): ");
                    int tipoVagaSaida = int.Parse(Console.ReadLine()!);

                    RegistrarSaida(placaSaida, modeloSaida, corSaida, proprietarioSaida, tipoVagaSaida);
                    break;

                case 3:
                    ConsultarVagas();
                    break;

                case 4:
                    ExibirResumo();
                    break;

                case 5:
                    Console.WriteLine("Saindo do sistema...");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        } while (opcao != 5);
    }

    static int Menu()
    {
        Console.WriteLine("\nBem-vindo ao estacionamento!");
        Console.WriteLine("1. Registrar entrada");
        Console.WriteLine("2. Registrar saída");
        Console.WriteLine("3. Consultar vagas");
        Console.WriteLine("4. Exibir resumo");
        Console.WriteLine("5. Sair");
        Console.Write("Escolha uma opção: ");
        return int.Parse(Console.ReadLine()!);
    }

    static void RegistrarEntrada(string placa, string modelo, string cor, string proprietario, int tipoVaga)
    {
        switch (tipoVaga)
        {
            case 1:
                if (vagasPrivativas > 0)
                {
                    vagasPrivativas--;
                    ultimaEntradaPlaca = placa;
                    ultimaEntradaModelo = modelo;
                    ultimaEntradaCor = cor;
                    ultimaEntradaProprietario = proprietario;
                    Console.WriteLine("Vaga privativa ocupada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há vagas privativas disponíveis.");
                }
                break;

            case 2:
                if (vagasPrioritarias > 0)
                {
                    vagasPrioritarias--;
                    ultimaEntradaPlaca = placa;
                    ultimaEntradaModelo = modelo;
                    ultimaEntradaCor = cor;
                    ultimaEntradaProprietario = proprietario;
                    Console.WriteLine("Vaga prioritária ocupada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há vagas prioritárias disponíveis.");
                }
                break;

            case 3:
                if (vagasComuns > 0)
                {
                    vagasComuns--;
                    ultimaEntradaPlaca = placa;
                    ultimaEntradaModelo = modelo;
                    ultimaEntradaCor = cor;
                    ultimaEntradaProprietario = proprietario;
                    Console.WriteLine("Vaga comum ocupada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não há vagas comuns disponíveis.");
                }
                break;

            default:
                Console.WriteLine("Tipo de vaga inválido!");
                break;
        }
    }

    static void RegistrarSaida(string placa, string modelo, string cor, string proprietario, int tipoVaga)
    {
        switch (tipoVaga)
        {
            case 1:
                vagasPrivativas++;
                break;

            case 2:
                vagasPrioritarias++;
                break;

            case 3:
                vagasComuns++;
                break;

            default:
                Console.WriteLine("Tipo de vaga inválido!");
                return;
        }

        ultimaSaidaPlaca = placa;
        ultimaSaidaModelo = modelo;
        ultimaSaidaCor = cor;
        ultimaSaidaProprietario = proprietario;
        Console.WriteLine("Veículo registrado como saída com sucesso!");
    }

    static void ConsultarVagas()
    {
        Console.WriteLine($"Vagas privativas disponíveis: {vagasPrivativas}");
        Console.WriteLine($"Vagas prioritárias disponíveis: {vagasPrioritarias}");
        Console.WriteLine($"Vagas comuns disponíveis: {vagasComuns}");
    }

    static void ExibirResumo()
    {
        Console.WriteLine("Resumo do estacionamento:");
        Console.WriteLine($"Vagas privativas disponíveis: {vagasPrivativas}");
        Console.WriteLine($"Vagas prioritárias disponíveis: {vagasPrioritarias}");
        Console.WriteLine($"Vagas comuns disponíveis: {vagasComuns}");
        Console.WriteLine($"Último veículo a entrar: {ultimaEntradaPlaca}, {ultimaEntradaModelo}, {ultimaEntradaCor}, {ultimaEntradaProprietario}");
        Console.WriteLine($"Último veículo a sair: {ultimaSaidaPlaca}, {ultimaSaidaModelo}, {ultimaSaidaCor}, {ultimaSaidaProprietario}");
    }
}
