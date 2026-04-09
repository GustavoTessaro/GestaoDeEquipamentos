class Equipamentos
{
    
    private int ID;
    private string nome;
    private float preco;
    private string fabricante;
    private DateTime dataFabricacao;

    public Equipamentos(int ID, string nome, float preco, string fabricante, DateTime dataFabricacao)
    {
        this.ID = ID;
        this.nome = nome;
        this.preco = preco;
        this.fabricante = fabricante;
        this.dataFabricacao = dataFabricacao;
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

}