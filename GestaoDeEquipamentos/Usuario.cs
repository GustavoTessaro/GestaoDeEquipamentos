using System.Dynamic;

class Usuario
{

    private string nome;
    private string senha;

    private List<Equipamento> equipamentos;
    private List<ManutencaoEquipamento> manutencoes;
    private List<Fabricante> fabricantes;

    #region Construtores
    public Usuario(string nome, string senha)
    {
        this.nome = nome;
        this.senha = senha;
        this.equipamentos = new List<Equipamento>();
        this.manutencoes = new List<ManutencaoEquipamento>();
        this.fabricantes = new List<Fabricante>();
    }

    public Usuario()
    {
        this.nome = "";
        this.senha = "";
        this.equipamentos = new List<Equipamento>();
        this.manutencoes = new List<ManutencaoEquipamento>();
        this.fabricantes = new List<Fabricante>();
    }

    #endregion

    #region Getters e Setters
    public string Nome { get => getNome(); set => setNome(value); }
    public string Senha { get => getSenha(); set => setSenha(value); }
    public List<Equipamento> Equipamentos { get => getEquipamentos(); set => setEquipamentos(value); }
    public List<ManutencaoEquipamento> Manutencoes { get => getManutencoes(); set => setManutencoes(value); }
    public List<Fabricante> Fabricantes { get => getFabricantes(); set => setFabricantes(value); }
    public List<Fabricante> getFabricantes()
    {
        return fabricantes;
    }

    public List<ManutencaoEquipamento> getManutencoes()
    {
        return manutencoes;
    }
    public void setFabricantes(List<Fabricante> fabricantes)
    {
        this.fabricantes = fabricantes;
    }
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
        string NomeFabricante = "";
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
            NomeFabricante = Console.ReadLine();
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
            bool fabricanteExiste = false;

            foreach (var fabricante in fabricantes)
            {
                if (fabricante.getNome() == NomeFabricante)
                {
                    fabricante.setQuantidadeEquipamentos(fabricante.getQuantidadeEquipamentos() + 1);
                    fabricanteExiste = true;
                    break;
                }
            }

            if (fabricanteExiste == false)
            {
                Console.WriteLine("Fabricante não encontrado. Deseja Cadastrar o fabricante agora para cadastrar o equipamento? (S/N)");
                char resposta = char.ToUpper(Console.ReadKey(true).KeyChar);
                if (resposta == 'S')
                {
                    CadastrarFabricante();
                }
                else
                {
                    Console.WriteLine("Equipamento não cadastrado. O fabricante é necessário para cadastrar o equipamento.");
                    return false;
                }
            }

            Equipamento novoEquipamento = new Equipamento(id, nome, preco, NomeFabricante, dataFabricacao, "Não");

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

            foreach (var fabricante in fabricantes)
            {
                if (fabricante.getNome() == equipamentoEncontrado.getFabricante())
                {
                    fabricante.setQuantidadeEquipamentos(fabricante.getQuantidadeEquipamentos() - 1);
                    break;
                }
            }

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

    #region Métodos para gerenciamento de fabricantes

    public bool CadastrarFabricante()
    {
        int id = 0;
        string nome = "";
        string email = "";
        string telefone = "";

        bool verifica = true;

        try
        {
            Console.Write("Digite o ID do Fabricante (APENAS NUMEROS): ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do fabricante: ");
            nome = Console.ReadLine();
            Console.Write("Digite o email do fabricante: ");
            email = Console.ReadLine();
            Console.Write("Digite o telefone do fabricante: ");
            telefone = Console.ReadLine();
        }
        catch (System.Exception)
        {
            Console.WriteLine("Entrada inválida. Certifique-se de inserir os dados corretamente.");
            verifica = false;
        }

        if (verifica == true)
        {
            Fabricante novoFabricante = new Fabricante(id, nome, email, telefone);

            fabricantes.Add(novoFabricante);
            Console.WriteLine("Fabricante cadastrado com sucesso!");
            return true;
        }
        else
        {
            Console.WriteLine("Falha ao cadastrar o fabricante. Tente novamente.");
            return false;
        }
    }
    public bool EditarFabricante()
    {
        MostrarFabricantes();
        Console.Write("\nDigite o ID do fabricante que deseja editar: ");
        int id = int.Parse(Console.ReadLine());

        Fabricante fabricanteEncontrado = null;
        foreach (var fabricante in fabricantes)
        {
            if (fabricante.getId() == id)
            {
                fabricanteEncontrado = fabricante;
                break;
            }
        }

        if (fabricanteEncontrado != null)
        {
            bool verifica = true;

            string nome = "";
            string email = "";
            string telefone = "";

            try
            {
                Console.Write("Digite o novo nome do fabricante: ");
                nome = Console.ReadLine();
                Console.Write("Digite o novo email do fabricante: ");
                email = Console.ReadLine();
                Console.Write("Digite o novo telefone do fabricante: ");
                telefone = Console.ReadLine();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Entrada inválida. Certifique-se de inserir os dados corretamente.");
                verifica = false;
            }

            if (verifica == true)
            {
                fabricanteEncontrado.setNome(nome);
                fabricanteEncontrado.setEmail(email);
                fabricanteEncontrado.setTelefone(telefone);

                Console.WriteLine("Fabricante editado com sucesso!");

                return true;
            }
            else
            {
                Console.WriteLine("Falha ao editar o fabricante. Tente novamente.");
                return false;
            }

        }
        else
        {
            Console.WriteLine("Fabricante não encontrado.");
            return false;
        }
    }
    public bool ExcluirFabricante()
    {
        MostrarFabricantes();
        Console.Write("\nDigite o ID do fabricante que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        Fabricante fabricanteEncontrado = null;

        foreach (var fabricante in fabricantes)
        {
            if (fabricante.getId() == id)
            {
                fabricanteEncontrado = fabricante;

                break;
            }
        }

        if (fabricanteEncontrado != null)
        {

            Console.WriteLine($"ATENÇÃO: O fabricante '{fabricanteEncontrado.getNome()}' possui {fabricanteEncontrado.getQuantidadeEquipamentos()} equipamentos associados. Excluir o fabricante também excluirá esses equipamentos. Deseja continuar? (S/N)");
            char resposta = char.ToUpper(Console.ReadKey(true).KeyChar);

            if (resposta == 'S')
            {
                //ToList() ele faz uma copia da lista original, permitindo que seja modificado como por exemplo removendo o equipamento sem causar erros durante a remoção
                foreach (var equipamento in equipamentos.ToList())
                {
                    if (equipamento.getFabricante() == fabricanteEncontrado.getNome())
                    {
                        equipamentos.Remove(equipamento);
                    }
                }

                fabricantes.Remove(fabricanteEncontrado);
                Console.WriteLine("Fabricante excluído com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Exclusão cancelada.");
                return false;
            }

        }
        else
        {
            Console.WriteLine("Fabricante não encontrado.");
            return false;
        }
    }
    public void MostrarFabricantes()
    {
        if (fabricantes.Count == 0)
        {
            Console.WriteLine("Nenhum fabricante registrado.");
        }
        else
        {
            Console.WriteLine("Fabricantes registrados:");
            foreach (var fabricante in fabricantes)
            {
                Console.WriteLine($"ID: {fabricante.getId()}, Nome: {fabricante.getNome()}, Email: {fabricante.getEmail()}, Telefone: {fabricante.getTelefone()}, Quantidade de Equipamentos: {fabricante.getQuantidadeEquipamentos()}");
            }
        }
    }

    #endregion

}