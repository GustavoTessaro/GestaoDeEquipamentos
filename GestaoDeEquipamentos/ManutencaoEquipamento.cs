class ManutencaoEquipamento : Equipamento 
{
    private string titulo;
    private string? descricao;
    private DateTime dataAbertura;
    private int diasDesdeAbertura;

    public ManutencaoEquipamento(int ID, string nome, string titulo, string descricao) 
        : base(ID, nome) 
    {
        this.titulo = titulo;
        this.descricao = descricao;
        this.dataAbertura = DateTime.Now;
        this.DiasDesdeAbertura = 0;
    }

    #region Getters e Setters
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descricao { get => descricao ?? " "; set => descricao = value; }
    public DateTime DataAbertura { get => dataAbertura; }
    public int DiasDesdeAbertura { get => diasDesdeAbertura; set => diasDesdeAbertura = value; }

    public void setTitulo(string titulo)
    {
        this.titulo = titulo;
    }

    public void setDescricao(string descricao)
    {
        this.descricao = descricao;
    }

    #endregion

    public int CalcularDiasDesdeAbertura()
    {
        TimeSpan tempoAberto = DateTime.Now - dataAbertura;
        diasDesdeAbertura = tempoAberto.Days;
        return diasDesdeAbertura;
    }

}
