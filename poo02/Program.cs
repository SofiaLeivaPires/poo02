// Instancia de uma propriedade
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;
using poo02.Entidades;
using System.Linq;

List <ContaBancaria> contas = new List<ContaBancaria>();

bool executando = true;

while (executando)
{
    Console.Clear();
    Console.WriteLine("========================");
    Console.WriteLine("    Sistema Bancário    ");
    Console.WriteLine("========================");

    Console.WriteLine("1. Consultar conta");
    Console.WriteLine("2. Criar conta Corrente");
    Console.WriteLine("3. Criar conta Poupança");
    Console.WriteLine("4. Depositar");
    Console.WriteLine("5. Sacar");
    Console.WriteLine("6. Aplicar Rendimento");
    Console.WriteLine("7. Transferir");
    Console.WriteLine("0. Sair");
    Console.Write("\nEscolha: ");

    var opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                ConsultarConta(); 
                break;
            case "2":
                CriarContaCorrente();  
                break;
            case "3":
                CriarContaPoupanca();  
                break;
            case "4":
                Depositar();  
                break;
            case "5":
                Sacar();
                break;
            case "6":
                AplicarRendimento();
                break;
            case "7":
                Transferir();
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
        Pausar();
    }

}

#region Métodos

void Pausar()
{
    Console.WriteLine("Pressione Enter para continuar...");
    Console.ReadLine();
}

void ListarContas()
{
    Console.WriteLine("--------------------------------------------------------------------------------------------");
    Console.WriteLine($"{"índice",6} | {"Número", -10} | {"Titular", -10} | {"CPF", -12} | { "Saldo", 10}");
    Console.WriteLine("--------------------------------------------------------------------------------------------");

    for(int i = 0; i < contas.Count; i++)
    {
        var conta = contas[i];
        Console.WriteLine($"| {i,4} | {conta.Numero, -10} | {conta.Titular, -10} | {conta.Cpf, -12} | {conta.Saldo, 10:C}");
    }

    Console.WriteLine("--------------------------------------------------------------------------------------------1");
    Console.WriteLine();
}

void ConsultarConta() {
    Console.Clear();
    Console.WriteLine("=== Lista de contas bancárias ===");
    ListarContas();

    if(contas.Count != 0)
    {
        Console.Write("Conta (índice):");
        int i = int.Parse(Console.ReadLine()!);

        ContaBancaria conta = contas[i];

        Console.Clear();
        Console.WriteLine("=== Detalhes da Conta ===");
        Console.WriteLine($"Conta: {conta.Numero}");
        Console.WriteLine($"Titular: {conta.Titular}"); 
        Console.WriteLine($"CPF: {conta.Cpf}");
        Console.WriteLine($"Saldo: {conta.Saldo:C}");

        if (conta is ContaPoupanca poupanca)
        {
            Console.WriteLine($"Tipo:\t\tConta Poupança");
            Console.WriteLine($"Taxa:\t\t{poupanca.TaxaRendimento:P}");

        } 
        if (conta is ContaCorrente corrente)
        {
            Console.WriteLine($"Tipo: \t\tConta Corrente");
            Console.WriteLine($"Limite: \t\t{corrente.Limite:C}");
        }

        // Extrato
        Console.WriteLine("\n=== Extrato ===");
        Console.WriteLine("====================================================================================================================================");
        Console.WriteLine($"{"Data/Hora",20} | {"Operação", 15} | {"Descrição", -50} | {"Valor", 20:C}");
        Console.WriteLine("====================================================================================================================================");

        foreach(var mov in conta.Movimentacoes)
        {
            Console.WriteLine($"{mov.DataHora,20} | {mov.Operacao, 15} | {mov.Descricao, -50} | {mov.Valor, 20:C}");
        }

    } else
    {
        Console.WriteLine("Nenhuma conta cadastrada ainda.");
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



void CriarContaCorrente()
{
    Console.Clear();

    Console.WriteLine("=== Criar Conta Corrente ===");

    Console.Write("Número: ");
    var numero = Console.ReadLine();

    Console.Write("Titular: ");
    var titular = Console.ReadLine();

    Console.Write("CPF: ");
    var cpf = Console.ReadLine();

    Console.Write("Limite: ");
    var limite = decimal.Parse(Console.ReadLine()!);

    // Não entendi por que da erro sem exclamação
    var contaCorrente = new ContaCorrente(numero!, titular!.ToUpper(), cpf!, limite);

    contas.Add(contaCorrente);

    Console.WriteLine("Conta corrente criada com sucesso!");
    Pausar();
}


void CriarContaPoupanca()
{
    Console.Clear();

    Console.WriteLine("=== Criar Conta Poupança ===");

    Console.Write("Número: ");
    var numero = Console.ReadLine();

    Console.Write("Titular: ");
    var titular = Console.ReadLine();

    Console.Write("CPF: ");
    var cpf = Console.ReadLine();

    Console.Write("Taxa de Rendimento: ");
    var taxa = decimal.Parse(Console.ReadLine()!);

    // Não entendi por que da erro sem exclamação
    var contaPoupanca = new ContaPoupanca(numero!, titular!.ToUpper(), cpf!, taxa);

    contas.Add(contaPoupanca);

    Console.WriteLine("Conta poupança criada com sucesso!");
    Pausar();
}

void Transferir()
{
    Console.Clear();
    Console.WriteLine("=== Transferência ===");
    ListarContas();

    Console.Write("Conta de origem (índice):");
    int origemIndex = int.Parse(Console.ReadLine()!);

    Console.Write("Conta de destino (índice):");
    int destinoIndex = int.Parse(Console.ReadLine()!);

    Console.Write("Valor: ");
    decimal valor = decimal.Parse(Console.ReadLine()!);

    var contaOrigem = contas[origemIndex];
    var contaDestino = contas[destinoIndex];

    contaOrigem.Transferir(contaDestino, valor);

    Console.WriteLine("Transferência realizada com sucesso!");
    Pausar();
}

void AplicarRendimento()
{
    Console.Clear();
    Console.WriteLine("=== Aplicar Rendimento ===");
    ListarContas();

    Console.Write("Conta (índice):");
    int i = int.Parse(Console.ReadLine()!);

    if (contas[i] is ContaPoupanca poupanca)
    {
        poupanca.AplicarRendimento();
        Console.WriteLine("Rendimento aplicado com sucesso!");
    }
    else
    {
        Console.WriteLine("A conta selecionada não é uma conta poupança.");
        Console.ReadKey();
    }

}

#endregion