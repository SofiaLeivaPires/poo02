using System.Runtime.CompilerServices;

namespace poo02.Entidades;

public abstract class ContaBancaria
{
    #region Construtores

    public ContaBancaria(string numero, string titular, string cpf)
    {
        if (string.IsNullOrWhiteSpace(numero))
        {
            throw new ArgumentException("Número inválido.");
        }
        if (string.IsNullOrWhiteSpace(titular))
        {
            throw new ArgumentException("Titular inválido.");
        }
        if (string.IsNullOrWhiteSpace(cpf))
        {
            throw new ArgumentException("CPF inválido.");
        }

        _numero = numero;
        _titular = titular;
        _cpf = cpf;
        _saldo = 0;
    }


    #endregion

    #region Propriedades Protegidas

    protected decimal _saldo;
    protected string _numero;

    protected string _titular;

    protected string _cpf;

    protected readonly List<Movimentacao> _movimentacoes = new List<Movimentacao>();

    #endregion

    #region Propriedades Públicas


    public string Numero
    {
        get { return _numero; }
    }

    public string Titular
    {
        get { return _titular; }
    }

    public string Cpf
    {
        get { return _cpf; }
    }

      public decimal Saldo
    {
        get { return _saldo;}
    }

    public IReadOnlyCollection<Movimentacao> Movimentacoes
    {
        get { return _movimentacoes.AsReadOnly(); }
    }
    #endregion


    #region Métodos Públicos
    public virtual void Depositar(decimal valor)
    {
        if(valor <= 0)
        {
            throw new ArgumentException("Valor de depósito deve ser positivo.");
        }
        _saldo += valor;

        RegistrarMovimentacao(Enumeradores.Operacao.Deposito, string.Empty, valor);
    }

    public virtual void Sacar(decimal valor)
    {
        Debitar(valor);

        RegistrarMovimentacao(Enumeradores.Operacao.Saque, string.Empty, -valor);
      
    }

    public virtual void Transferir(ContaBancaria contaDestino, decimal valor)
    {
        if(contaDestino == null)
        {
            throw new ArgumentNullException("Conta de destino inválida.");
        }

        Debitar(valor);

        contaDestino.Creditar(valor);

        RegistrarMovimentacao(Enumeradores.Operacao.Transferencia, $"Transferência para conta {contaDestino.Numero} - {contaDestino.Titular}", -valor);

        contaDestino.RegistrarMovimentacao(Enumeradores.Operacao.Transferencia, $"Transferência recebida da conta {Numero} - {Titular}", valor);

       
    }
    protected virtual void Creditar(decimal valor)
    {
        _saldo += valor;
    }
    protected virtual void Debitar(decimal valor)
    {
        if(!PodeDebitar(valor))
        {
            throw new InvalidOperationException("Saldo insuficiente para débito.");
        }
        _saldo -= valor;
    }

    protected virtual bool PodeDebitar(decimal valor)
    {
        return valor <= _saldo;
    }

    protected void RegistrarMovimentacao(Enumeradores.Operacao operacao, string descricao, decimal valor)
    {
        var movimentacao = new Movimentacao(operacao, descricao, valor);
        _movimentacoes.Add(movimentacao);
    }

    #endregion
}