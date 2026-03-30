namespace poo02.Entidades;

public class ContaPoupanca : ContaBancaria
{
    #region Construtores

    public ContaPoupanca(string numero, string titular, string cpf, decimal taxaRendimento) : base(numero, titular, cpf)
    {
        if(taxaRendimento < 0)
        {
            throw new ArgumentException("Taxa de rendimento deve ser maior ou igual a zero.");
        }
        _taxaRendimento = taxaRendimento/100;
    }
   
    #endregion

    #region Propriedades Privadas
    private decimal _taxaRendimento;

    #endregion

    #region Propriedades Públicas
    public decimal TaxaRendimento
    {
        get
        {
            return _taxaRendimento;
        }
    }
    #endregion

    #region Métodos 
    
    /// <summary>
    /// Aplica o rendimento de acordo com a taxa.
    /// </summary>
    public void AplicarRendimento()
    {
        var rendimento = _saldo * _taxaRendimento;
        _saldo += rendimento;  

       RegistrarMovimentacao(Enumeradores.Operacao.Rendimento, $"Taxa: {_taxaRendimento:P}", rendimento);  
    }

    #endregion
}

