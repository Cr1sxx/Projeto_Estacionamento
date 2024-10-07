using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        int vagasPrivativas, vagasPrioritarias, vagasComuns, vagasTotais;
        int opcoes = 0;
        List<veiculos> ListaVeiculos = new List<veiculos>();

        Console.WriteLine("Digite a quantidade de vagas privativas: ");
        vagasPrivativas = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a quantidade de vagas prioritárias: ");
        vagasPrioritarias = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a quantidade de vagas comuns: ");
        vagasComuns = int.Parse(Console.ReadLine());

        vagasTotais = vagasPrivativas + vagasPrioritarias + vagasComuns;

        while (opcoes != 5)
        {
            Console.WriteLine("Bem vindo ao estacionamento da cidade Fim do Mundo do Sul!\n Escolha uma das opções:\n 1. Registrar entrada\n 2. Registrar saída\n 3. Consultar vagas\n 4. Exibir resumo\n 5. Sair");

            opcoes = int.Parse(Console.ReadLine());

            switch (opcoes)
            {
                case 1:

                    veiculos veiculos = new veiculos();

                    Console.WriteLine("Por favor informe seus dados.");

                    Console.WriteLine("Digite seu nome: ");
                    veiculos.proprietario = Console.ReadLine();

                    Console.WriteLine("Digite sua idade: ");
                    veiculos.idadeProprietario = int.Parse(Console.ReadLine());

                    if (veiculos.idadeProprietario < 18)
                    {
                        Console.WriteLine("Informe uma idade válida");
                    }

                    Console.WriteLine("Informe o modelo de seu veículo: ");
                    veiculos.modelo = Console.ReadLine();

                    Console.WriteLine("Informe a placa de seu veículo: ");
                    veiculos.placa = Console.ReadLine();

                    Console.WriteLine("Informe a cor de seu veículo: ");
                    veiculos.cor = Console.ReadLine();

                    Console.WriteLine($"Informe o tipo de vaga que deseja ocupar:\n 1. Vaga privativa\n 2. Vaga Prioritária\n 3. Vaga comum");
                    veiculos.tipoVaga = Console.ReadLine();

                    if (veiculos.tipoVaga == "1")
                    {
                        if (vagasPrivativas > 0)
                        {
                            vagasPrivativas--;
                            vagasTotais--;
                            ListaVeiculos.Add(veiculos);

                            Console.WriteLine($"Você ocupou uma vaga privativa. Obrigado pela preferência {veiculos.proprietario}!");
                            Console.WriteLine($"O número de vagas privativas restantes é: {vagasPrivativas}");
                        }
                    }

                    else if (veiculos.tipoVaga == "2")
                    {
                        if (vagasPrioritarias > 0)
                        {
                            if (veiculos.idadeProprietario >= 60)
                            {
                                vagasPrioritarias--;
                                vagasTotais--;
                                ListaVeiculos.Add(veiculos);

                                Console.WriteLine($"Você ocupou uma vaga prioritária. Obrigado pela preferência {veiculos.proprietario}!");
                                Console.WriteLine($"O número de vagas prioritárias restantes é: {vagasPrioritarias}");
                            }

                            else
                            {
                                Console.WriteLine("As vagas prioitárias são exclusivas para pessoas a partir de 60 anos.");
                            }
                        }
                    }

                    else if (veiculos.tipoVaga == "3")
                    {
                        if (vagasComuns > 0)
                        {
                            vagasComuns--;
                            vagasTotais--;
                            ListaVeiculos.Add(veiculos);

                            Console.WriteLine($"Você ocupou uma vaga comum. Obrigado pela preferência {veiculos.proprietario}!");
                            Console.WriteLine($"O número de vagas comuns restantes é: {vagasComuns}");
                        }
                    }
                    break;

                case 2:

                    Console.WriteLine("Por favor informe a placa do carro: ");
                    string Exist = Console.ReadLine();

                    veiculos veiculosSaida = ListaVeiculos.Find(v => v.placa == Exist);

                    if (veiculosSaida != null)
                    {
                        ListaVeiculos.Remove(veiculosSaida);

                        if (veiculosSaida.tipoVaga == "1")
                        {
                            Console.WriteLine($"Muito obrigado pela preferência {veiculosSaida.proprietario}. Volte sempre");
                            vagasPrivativas++;
                            Console.WriteLine($"Vaga privativa liberada");
                        }

                        else if (veiculosSaida.tipoVaga == "2")
                        {
                            Console.WriteLine($"Muito obrigado pela preferência {veiculosSaida.proprietario}. Volte sempre");
                            vagasPrioritarias++;
                            Console.WriteLine($"Vaga prioritária liberada");
                        }

                        else if (veiculosSaida.tipoVaga == "3")
                        {
                            Console.WriteLine($"Muito obrigado pela preferência {veiculosSaida.proprietario}. Volte sempre");
                            vagasComuns++;
                            Console.WriteLine($"Vaga comum liberada");
                        }

                        Console.WriteLine($"O veículo {veiculosSaida.modelo} saiu do estacionamento.");
                    }

                    else
                    {
                        Console.WriteLine("O veículo não foi encontrado");
                    }
                    break;

                case 3:

                    Console.WriteLine($"O número de vagas privativas disponíveis é: {vagasPrivativas}");
                    Console.WriteLine($"O número total de vagas prioritárias disponíveis é: {vagasPrioritarias}");
                    Console.WriteLine($"O número total de vagas comuns disponíveis é: {vagasComuns}");
                    break;

                case 4:
                    Console.WriteLine($"Resumo do estacionamento:\n Vagas totais disponíveis: {vagasTotais}\n Vagas privativas disponíveis: {vagasPrivativas}\n Vagas prioritárias disponíveis: {vagasPrioritarias}\n Vagas comuns disponíveis: {vagasComuns}");
                    break;

                case 5:
                    Console.WriteLine("Saindo do sistema...");
                    break;

                default:
                    Console.WriteLine("Insira uma opção válida.");
                    break;
            }
        }
    }
}
public class veiculos
{
    public string placa, modelo, cor, proprietario, tipoVaga;
    public int idadeProprietario = 0;
}