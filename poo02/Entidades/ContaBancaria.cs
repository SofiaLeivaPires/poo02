using System.Runtime.CompilerServices;

namespace poo02.Entidades;

public class ContaBancaria
{

    #region Construtores

    public ContaBancaria(string numero, string titular, string cpf)
    {
        if(string.IsNullOrWhiteSpace(numero))
        {
            throw new ArgumentException("Número inválido.");
        }
        if(string.IsNullOrWhiteSpace(titular))
        {
            throw new ArgumentException("Titular inválido.");
        }
        if(string.IsNullOrWhiteSpace(cpf))
        {
            throw new ArgumentException("CPF inválido.");
        }

        _numero = numero;
        _titular = titular;
        _cpf = cpf;
        _saldo = 0;
    }


    #endregion




    #region Propriedades Privadas

    private decimal _saldo;
    private string _numero;

    private string _titular;

    private string _cpf;

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
    #endregion


    #region Métodos Públicos
    public void Depositar(decimal valor)
    {
        if(valor <= 0)
        {
            throw new ArgumentException("Valor de depósito deve ser positivo.");
        }
        _saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if(valor <= 0)
        {
            throw new ArgumentException("Valor de saque deve ser positivo.");
        }
        if(valor > _saldo)
        {
            throw new InvalidOperationException("Saldo insuficiente para saque.");
        }
        _saldo -= valor;
    }

    #endregion
}