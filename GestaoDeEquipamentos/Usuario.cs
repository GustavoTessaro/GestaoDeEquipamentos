class Usuario
{

    private string nome;
    private string senha;

    private List<Equipamentos> equipamentos;

    public Usuario(string nome, string senha)
    {
        this.nome = nome;
        this.senha = senha;
        this.equipamentos = new List<Equipamentos>();
    }

    public Usuario()
    {

    }

    public string getNome()
    {
        return nome;
    }

    public string getSenha()
    {
        return senha;
    }
    public List<Equipamentos> getEquipamentos()
    {
        return equipamentos;
    }
    public void setEquipamentos(List<Equipamentos> equipamentos)
    {
        this.equipamentos = equipamentos;
    }
    public void CadastrarEquipamento()
    {
        Console.Write("Digite o ID do equipamento (APENAS NUMEROS): ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();
        Console.Write("\nDigite o preço do equipamento: ");
        float preco = float.Parse(Console.ReadLine());
        Console.Write("\nDigite o fabricante do equipamento: ");
        string fabricante = Console.ReadLine();
        Console.Write("\nDigite a data de fabricação do equipamento (dd/MM/yyyy): ");
        DateTime dataFabricacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Equipamentos novoEquipamento = new Equipamentos(id, nome, preco, fabricante, dataFabricacao);

        equipamentos.Add(novoEquipamento);
        Console.WriteLine("Equipamento cadastrado com sucesso!");
    }

    public void MostrarEquipamentos()
    {
        if (equipamentos.Count == 0)
        {
            Console.WriteLine("Nenhum equipamento cadastrado.");
        }
        else
        {
            Console.WriteLine("Equipamentos cadastrados:");
            foreach (var equipamento in equipamentos)
            {
                Console.WriteLine($"ID: {equipamento.getID()}, Nome: {equipamento.getNome()}, Preço: {equipamento.getPreco()}, Fabricante: {equipamento.getFabricante()}, Data de Fabricação: {equipamento.getDataFabricacao().ToString("dd/MM/yyyy")}");
            }
        }
    }
    public void EditarEquipamento()
    {
        MostrarEquipamentos();
        Console.Write("\nDigite o ID do equipamento que deseja editar: ");
        int id = int.Parse(Console.ReadLine());

        Equipamentos equipamentoEncontrado = null;
        foreach (var equipamento in equipamentos)
        {
            if (equipamento.getID() == id)
            {
                equipamentoEncontrado = equipamento;
                break;
            }
        }

        if (equipamentoEncontrado != null)
        {
            Console.Write("Digite o novo nome do equipamento: ");
            string nome = Console.ReadLine();
            Console.Write("\nDigite o novo preço do equipamento: ");
            float preco = float.Parse(Console.ReadLine());
            Console.Write("\nDigite o novo fabricante do equipamento: ");
            string fabricante = Console.ReadLine();
            Console.Write("\nDigite a nova data de fabricação do equipamento (dd/MM/yyyy): ");
            DateTime dataFabricacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            equipamentoEncontrado.setNome(nome);
            equipamentoEncontrado.setPreco(preco);
            equipamentoEncontrado.setFabricante(fabricante);
            equipamentoEncontrado.setDataFabricacao(dataFabricacao);

            Console.WriteLine("Equipamento editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Equipamento não encontrado.");
        }

    }

    public void ExcluirEquipamento()
    {
        MostrarEquipamentos();
        Console.Write("\nDigite o ID do equipamento que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        Equipamentos equipamentoEncontrado = null;
        foreach (var equipamento in equipamentos)
        {
            if (equipamento.getID() == id)
            {
                equipamentoEncontrado = equipamento;
                break;
            }
        }

        if (equipamentoEncontrado != null)
        {
            equipamentos.Remove(equipamentoEncontrado);
            Console.WriteLine("Equipamento excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Equipamento não encontrado.");
        }
    }
}