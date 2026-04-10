using System.Dynamic;

class Equipamento
{
    
    private int ID;
    private string nome;
    private float preco;
    private string fabricante;
    private DateTime dataFabricacao;
    private string EstaEmManutencao;
    private DateTime ultimaVezManutencao;

    #region Construtores
    public Equipamento(int ID, string nome, float preco, string fabricante, DateTime dataFabricacao, string EstaEmManutencao)
    {
        this.ID = ID;
        this.nome = nome;
        this.preco = preco;
        this.fabricante = fabricante;
        this.dataFabricacao = dataFabricacao;
        this.ultimaVezManutencao = DateTime.Now;
        this.EstaEmManutencao = "Não";
    }

    public Equipamento()
    {
        
    }

    public Equipamento(int ID, string nome)
    {
        this.ID = ID;
        this.nome = nome;
    }

    #endregion

    #region Getters e Setters
    public int Id { get => getID(); set => setID(value); }
    public string Nome { get => getNome(); set => setNome(value); }
    public float Preco { get => getPreco(); set => setPreco(value); }
    public string Fabricante { get => getFabricante(); set => setFabricante(value); }
    public DateTime DataFabricacao { get => getDataFabricacao(); set => setDataFabricacao(value); }
    public string EstaEmManutencao1 { get => EstaEmManutencao; set => EstaEmManutencao = value; }

    public string getEstaEmManutencao()
    {
        return EstaEmManutencao;
    }

    public void setEstaEmManutencao(string status)
    {
        this.EstaEmManutencao = status;
    }

    public DateTime ultimaVezManutencao1 { get => ultimaVezManutencao; set => ultimaVezManutencao = value; }

    public DateTime getUltimaVezManutencao()
    {
        return ultimaVezManutencao;
    }

    public void setUltimaVezManutencao(DateTime data)
    {
        this.ultimaVezManutencao = data;
    }
    public int getID()
    {
        return ID;
    }

    public string getNome()
    {
        return nome;
    }

    public float getPreco()
    {
        return preco;
    }

    public string getFabricante()
    {
        return fabricante;
    }

    public DateTime getDataFabricacao()
    {
        return dataFabricacao;
    }

    public int setID(int ID)
    {
        return this.ID = ID;
    }

    public string setNome(string nome)
    {
        return this.nome = nome;
    }

    public float setPreco(float preco)
    {
        return this.preco = preco;
    }

    public string setFabricante(string fabricante)
    {
        return this.fabricante = fabricante;
    }

    public DateTime setDataFabricacao(DateTime dataFabricacao)
    {
        return this.dataFabricacao = dataFabricacao;
    }

    #endregion

}