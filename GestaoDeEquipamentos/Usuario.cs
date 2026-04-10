class Usuario
{

    private string nome;
    private string senha;

    private List<Equipamento> equipamentos;

    private List<ManutencaoEquipamento> manutencoes;

    #region Construtores
    public Usuario(string nome, string senha)
    {
        this.nome = nome;
        this.senha = senha;
        this.equipamentos = new List<Equipamento>();
        this.manutencoes = new List<ManutencaoEquipamento>();
    }

    public Usuario()
    {
        this.nome = "";
        this.senha = "";
        this.equipamentos = new List<Equipamento>();
        this.manutencoes = new List<ManutencaoEquipamento>();
    }

    #endregion

    #region Getters e Setters
    public string Nome { get => getNome(); set => setNome(value); }
    public string Senha { get => getSenha(); set => setSenha(value); }
    public List<Equipamento> Equipamentos { get => getEquipamentos(); set => setEquipamentos(value); }

    public List<ManutencaoEquipamento> Manutencoes { get => manutencoes; set => manutencoes = value; }

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

    public List<Equipamento> getEquipamentos()
    {
        return equipamentos;
    }

    public void setEquipamentos(List<Equipamento> equipamentos)
    {
        this.equipamentos = equipamentos;
    }

    public void setManutencoes(List<ManutencaoEquipamento> manutencoes)
    {
        this.manutencoes = manutencoes;
    }

    #endregion

    #region Métodos para gerenciamento de equipamentos
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
            Equipamento novoEquipamento = new Equipamento(id, nome, preco, fabricante, dataFabricacao, "Não");

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
                Console.WriteLine($"ID: {equipamento.getID()}, Nome: {equipamento.getNome()}, Preço: {equipamento.getPreco()}, Fabricante: {equipamento.getFabricante()}, Data de Fabricação: {equipamento.getDataFabricacao().ToString("dd/MM/yyyy")}, Em Manutenção: {equipamento.getEstaEmManutencao()}, Última Manutenção: {equipamento.getUltimaVezManutencao().ToString("dd/MM/yyyy")}");
            }
        }
    }
    public bool EditarEquipamento()
    {
        MostrarEquipamentos();
        Console.Write("\nDigite o ID do equipamento que deseja editar: ");
        int id = int.Parse(Console.ReadLine());

        Equipamento equipamentoEncontrado = null;
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

        Equipamento equipamentoEncontrado = null;
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

    #endregion

    #region Métodos para gerenciamento de manutenções

    public bool VerificarManutencoes()
    {
        bool verifica = false;

        foreach (var equipamento in equipamentos)
        {
            TimeSpan tempoDesdeUltimaManutencao = DateTime.Now - equipamento.getUltimaVezManutencao();

            if (tempoDesdeUltimaManutencao.TotalDays >= 180)
            {
                if (verifica == false)
                {
                    Console.WriteLine("ATENÇÃO");
                    verifica = true;
                }

                Console.WriteLine($"O equipamento '{equipamento.getNome()}' precisa de manutenção. Última manutenção foi há {tempoDesdeUltimaManutencao.TotalDays} dias.");

                if (equipamento.getEstaEmManutencao() == "Não")
                {
                    ManutencaoEquipamento novaManutencao = new ManutencaoEquipamento(equipamento.getID(), equipamento.getNome(), "Manutenção Automática/Testes/Preventiva", "A mais de 2 mesês sem manutenção");

                    manutencoes.Add(novaManutencao);

                    equipamento.setEstaEmManutencao("Sim");
                    equipamento.setUltimaVezManutencao(DateTime.Now);

                    return true;
                }

            }
        }
        return false;
    }
    public bool CadastrarManutencao()
    {
        MostrarEquipamentos();

        int id = 0;
        string titulo = "";
        string? descricao = "";

        try
        {
            Console.Write("\nDigite o ID do equipamento para o qual deseja cadastrar a manutenção: ");
            id = int.Parse(Console.ReadLine());
            Equipamento equipamentoEncontrado = null;
            foreach (var equipamento in equipamentos)
            {
                if (equipamento.getID() == id)
                {
                    equipamentoEncontrado = equipamento;
                    equipamento.setEstaEmManutencao("Sim");
                    break;
                }
            }

            if (equipamentoEncontrado != null)
            {
                Console.Write("Digite o título da manutenção: ");
                titulo = Console.ReadLine();
                Console.Write("Digite a descrição da manutenção: ");
                descricao = Console.ReadLine() ?? "";

                ManutencaoEquipamento novaManutencao = new ManutencaoEquipamento(equipamentoEncontrado.getID(), equipamentoEncontrado.getNome(), titulo, descricao);

                manutencoes.Add(novaManutencao);

                Console.WriteLine("Manutenção cadastrada com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Equipamento não encontrado. Falha ao cadastrar a manutenção.");
                return false;
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Entrada inválida. Certifique-se de inserir os dados corretamente.");
            return false;
        }

    }
    public bool EditarManutencao()
    {
        MostrarManutencoes();

        int id = 0;
        string titulo = "";
        string? descricao = "";

        try
        {
            Console.Write("\nDigite o ID da manutenção que deseja editar: ");
            id = int.Parse(Console.ReadLine());

            ManutencaoEquipamento manutencaoEncontrada = null;

            foreach (var manutencao in manutencoes)
            {
                if (manutencao.getID() == id)
                {
                    manutencaoEncontrada = manutencao;
                    break;
                }
            }

            if (manutencaoEncontrada != null)
            {
                Console.Write("Digite o novo título da manutenção: ");
                titulo = Console.ReadLine();
                Console.Write("Digite a nova descrição da manutenção: ");
                descricao = Console.ReadLine() ?? "";

                manutencaoEncontrada.setTitulo(titulo);
                manutencaoEncontrada.setDescricao(descricao);

                Console.WriteLine("Manutenção editada com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Manutenção não encontrada.");
                return false;
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Entrada inválida. Certifique-se de inserir os dados corretamente.");
            return false;
        }
    }
    public bool ExcluirManutencao()
    {
        MostrarManutencoes();
        Console.Write("\nDigite o ID da manutenção que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        ManutencaoEquipamento manutencaoEncontrada = null;

        foreach (var manutencao in manutencoes)
        {
            if (manutencao.getID() == id)
            {
                manutencaoEncontrada = manutencao;

                foreach (var equipamento in equipamentos)
                {
                    if (equipamento.getID() == manutencao.getID())
                    {
                        equipamento.setEstaEmManutencao("Não");
                        break;
                    }
                }

                break;
            }
        }

        if (manutencaoEncontrada != null)
        {
            manutencoes.Remove(manutencaoEncontrada);
            Console.WriteLine("Manutenção excluída com sucesso!");
            return true;

        }
        else
        {
            Console.WriteLine("Manutenção não encontrada.");
            return false;
        }
    }
    public void MostrarManutencoes()
    {
        if (manutencoes.Count == 0)
        {
            Console.WriteLine("Nenhuma manutenção registrada.");
        }
        else
        {
            Console.WriteLine("Manutenções registradas:");
            foreach (var manutencao in manutencoes)
            {
                Console.WriteLine($"ID: {manutencao.getID()}, Nome: {manutencao.getNome()}, Título: {manutencao.Titulo}, Descrição: {manutencao.Descricao}, Data de Abertura: {manutencao.DataAbertura.ToString("dd/MM/yyyy")}, Dias desde Abertura: {manutencao.CalcularDiasDesdeAbertura()}");
            }
        }

    }

    #endregion

}