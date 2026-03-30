namespace poo02.Entidades;

public class ContaCorrente : ContaBancaria
{
    #region Construtores

    public ContaCorrente(string numero, string titular, string cpf, decimal limite) : base(numero, titular, cpf)
    {
        if(limite < 0)
        {
            throw new ArgumentException("Limite deve ser maior ou igual a zero.");
        }
        _limite = limite;
    }
   
    #endregion
   
    #region Propriedades Privadas
    private decimal _limite;

    #endregion

    #region Propriedades Públicas
    public decimal Limite
    {
        get { return _limite; }
    }  
    #endregion

    #region Métodos Públicos
    protected override bool PodeDebitar(decimal valor)
    {
       return valor <= _saldo + _limite;
    }

    #endregion
}
