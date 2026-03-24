// Instancia de uma propriedade
using System.Runtime.ExceptionServices;
using poo02.Entidades;


// Instancia de uma lista de contas bancárias
List <ContaBancaria> contas = new();

// Variável boolean para controlar a execução do programa
bool executando = true;

while (executando)
{
    Console.Clear();
    Console.WriteLine("=== Sistema Bancário ===");
    Console.WriteLine("1. Criar conta");
    Console.WriteLine("2. Listar contas");
    Console.WriteLine("0. Sair");
    Console.Write("\nEscolha");


    var opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                CriarContas();  
                break;
            case "2":
                ListarContas();  
                break;
            case "0":
                executando = false;
                break;
            default:
                Console.WriteLine("Opção inválida. Pressione Enter para continuar.");
                Pausar();
                break;
        }
    } catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
        
    }


}


#region Métodos
void ListarContas()
{
    Console.Clear();
    Console.WriteLine("\n ####CONTAS####\n");

    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine($"{"índice",6} | {"Número", -10} | {"Titular", -40} | {"CPF", -14} | { "Saldo", 15}");
    Console.WriteLine("--------------------------------------------------");

    for(int i = 0; i < contas.Count; i++)
    {
        var conta = contas[i];
        Console.WriteLine($"| {i,6} | {conta.Numero, -10} | {conta.Titular, -40} | {conta.Cpf, -14} | {conta.Saldo, 15:C}");
    }

    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine();
    Pausar();
}

void CriarContas()
{
    Console.Clear();
    Console.WriteLine("=== Criar Conta ===");

    Console.Write("Número da conta: ");
    var numero = Console.ReadLine();

    Console.Write("Titular da conta: ");
    var titular = Console.ReadLine();

    Console.Write("CPF do titular: ");
    var cpf = Console.ReadLine();

    // Não entendi por que da erro sem exclamação
    var conta = new ContaBancaria(numero!, titular!.ToUpper(), cpf!);

    contas.Add(conta);

    Console.WriteLine("Conta criada com sucesso!");
    Pausar();
}

void Pausar()
{
    Console.WriteLine("Pressione Enter para continuar...");
    Console.ReadLine();
}


#endregion