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
    Console.WriteLine("1. Detalhar contas");
    Console.WriteLine("2. Criar contas");
    Console.WriteLine("3. Depositar");
    Console.WriteLine("4. Sacar");
    Console.WriteLine("0. Sair");
    Console.Write("\nEscolha: ");


    var opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                DetalharContas(); 
                break;
            case "2":
                CriarContas();  
                break;
            case "3":
                Depositar();  
                break;
            case "4":
                Sacar();  
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
}

void DetalharContas()
{
    Console.Clear();
    Console.WriteLine("=== Detalhes das Contas ===");
    ListarContas();
    
    Console.WriteLine();

    if (contas.Any())
    {
        Console.Write("Conta (índice):");
        int i = int.Parse(Console.ReadLine()!);

        ContaBancaria conta = contas[i];

        Console.Clear();
        Console.WriteLine($"Conta: {conta.Numero}");
        Console.WriteLine($"Titular: {conta.Titular}");     
        Console.WriteLine($"CPF: {conta.Cpf}");
        Console.WriteLine($"Saldo: {conta.Saldo:C}");
    }
    Pausar();
}

void Depositar()
{
    Console.Clear();
    Console.WriteLine("=== Depósito ===");
    ListarContas();

    Console.Write("Conta (índice):");
    int i = int.Parse(Console.ReadLine()!);

    Console.Write("Valor: ");
    decimal valor = decimal.Parse(Console.ReadLine()!);

    contas[i].Depositar(valor);

    Console.WriteLine("Depósito realizado com sucesso!");
    Pausar();
}

void Sacar()
{
    Console.Clear();
    Console.WriteLine("=== Saque ===");
    ListarContas();

    Console.Write("Conta (índice):");
    int i = int.Parse(Console.ReadLine()!);

    Console.Write("Valor: ");
    decimal valor = decimal.Parse(Console.ReadLine()!);

    contas[i].Sacar(valor);

    Console.WriteLine("Saque realizado com sucesso!");
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