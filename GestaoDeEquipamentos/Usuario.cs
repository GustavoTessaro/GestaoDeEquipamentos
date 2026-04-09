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

    public string Nome { get => getNome(); set => setNome(value); }
    public string Senha { get => getSenha(); set => setSenha(value); }
    public List<Equipamentos> Equipamentos { get => getEquipamentos(); set => setEquipamentos(value); }

    public string getNome()
    {
        return nome;
    }

    public void setNome(string nome)
    {
        this.nome = nome;
    }

    public string getSenha()
    {
        return senha;
    }

    public void setSenha(string senha)
    {
        this.senha = senha;
    }
    public List<Equipamentos> getEquipamentos()
    {
        return equipamentos;
    }
    public void setEquipamentos(List<Equipamentos> equipamentos)
    {
        this.equipamentos = equipamentos;
    }
    public bool CadastrarEquipamento()
    {
        int id = 0;
        string nome = "";
        float preco = 0;
        string fabricante = "";
        DateTime dataFabricacao = DateTime.Now;

        bool verifica = true;

        try
        {
            Console.Write("Digite o ID do equipamento (APENAS NUMEROS): ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do equipamento: ");
            nome = Console.ReadLine();
            Console.Write("\nDigite o preço do equipamento: ");
            preco = float.Parse(Console.ReadLine());
            Console.Write("\nDigite o fabricante do equipamento: ");
            fabricante = Console.ReadLine();
            Console.Write("\nDigite a data de fabricação do equipamento (dd/MM/yyyy): ");
            dataFabricacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        }
        catch (System.Exception)
        {
            Console.WriteLine("Entrada inválida. Certifique-se de inserir os dados corretamente.");
            verifica = false;
        }

        if (verifica == true)
        {
            Equipamentos novoEquipamento = new Equipamentos(id, nome, preco, fabricante, dataFabricacao);

            equipamentos.Add(novoEquipamento);
            Console.WriteLine("Equipamento cadastrado com sucesso!");
            return true;
        }
        else
        {
            Console.WriteLine("Falha ao cadastrar o equipamento. Tente novamente.");
            return false;
        }

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
    public bool EditarEquipamento()
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

            bool verifica = true;

            string nome = "";
            float preco = 0;
            string fabricante = "";
            DateTime dataFabricacao = DateTime.Now;

            try
            {
                Console.Write("Digite o novo nome do equipamento: ");
                nome = Console.ReadLine();
                Console.Write("\nDigite o novo preço do equipamento: ");
                preco = float.Parse(Console.ReadLine());
                Console.Write("\nDigite o novo fabricante do equipamento: ");
                fabricante = Console.ReadLine();
                Console.Write("\nDigite a nova data de fabricação do equipamento (dd/MM/yyyy): ");
                dataFabricacao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Entrada inválida. Certifique-se de inserir os dados corretamente.");
                verifica = false;
            }

            if (verifica == true)
            {
                equipamentoEncontrado.setNome(nome);
                equipamentoEncontrado.setPreco(preco);
                equipamentoEncontrado.setFabricante(fabricante);
                equipamentoEncontrado.setDataFabricacao(dataFabricacao);

                Console.WriteLine("Equipamento editado com sucesso!");

                return true;
            }
            else
            {
                Console.WriteLine("Falha ao editar o equipamento. Tente novamente.");
                return false;
            }

        }
        else
        {
            Console.WriteLine("Equipamento não encontrado.");
            return false;
        }

    }
    public bool ExcluirEquipamento()
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
            return true;

        }
        else
        {
            Console.WriteLine("Equipamento não encontrado.");
            return false;
        }
    }
}