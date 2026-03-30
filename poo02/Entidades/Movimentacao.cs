using poo02.Enumeradores;

namespace poo02.Entidades;

public class Movimentacao
{
    #region Construtores

    public Movimentacao(Operacao operacao, string descricao, decimal valor)
    {
        _dataHora = DateTime.Now;
        _operacao = operacao;
        _descricao = descricao;
        _valor = valor;
    }

    #endregion

    #region Propriedades Privadas
    private DateTime _dataHora;
    private Operacao _operacao;
    private string _descricao;
    private decimal _valor;
    

    #endregion

    #region Propriedades Públicas
    public DateTime DataHora    {
        get { return _dataHora; }
    }
    public Operacao Operacao
    {
        get { return _operacao; }
    }
    public string Descricao
    {
        get { return _descricao; }
    }
    public decimal Valor
    {
        get { return _valor; }
    }

    #endregion

    #region Métodos Públicos

    #endregion
}