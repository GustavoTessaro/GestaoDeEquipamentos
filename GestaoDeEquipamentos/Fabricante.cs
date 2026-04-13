class Fabricante
{
    private int id;
    private string nome;
    private string email;
    private string telefone;
    private int quantidadeEquipamentos;

    public Fabricante(int id, string nome, string email, string telefone)
    {
        this.id = id;
        this.nome = nome;
        this.email = email;
        this.telefone = telefone;
        this.quantidadeEquipamentos = 0;
    }

    #region Getters e Setters
    public int getId()
    {
        return id;
    }

    public string getNome()
    {
        return nome;
    }

    public string getEmail()
    {
        return email;
    }

    public string getTelefone()
    {
        return telefone;
    }

    public int getQuantidadeEquipamentos()
    {
        return quantidadeEquipamentos;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setNome(string nome)
    {
        this.nome = nome;
    }

    public void setEmail(string email)
    {
        this.email = email;
    }

    public void setTelefone(string telefone)
    {
        this.telefone = telefone;
    }

    public void setQuantidadeEquipamentos(int quantidade)
    {
        this.quantidadeEquipamentos = quantidade;
    }

    #endregion

}