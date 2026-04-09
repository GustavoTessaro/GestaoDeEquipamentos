using System.Xml.Serialization;
using System.Text.Json;
using System.IO;
using System.Threading;
class Program
{

    public static void salvarUsuario(List<Usuario> usuario)
    {
        string jsonString = JsonSerializer.Serialize(usuario, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("usuario.json", jsonString);
    }
    public static List<Usuario> lerUsuarios(List<Usuario> usuario)
    {
        if (File.Exists("usuario.json"))
        {
            string jsonString = File.ReadAllText("usuario.json");
            return JsonSerializer.Deserialize<List<Usuario>>(jsonString) ?? new List<Usuario>();
        }
        return new List<Usuario>();
    }
    static string nomeArquivo = "usuario.json";
    static void AtualizarUsuario(Usuario usuarioLogado)
    {
        List<Usuario> usuarios = lerUsuarios(new List<Usuario>());

        foreach (var usuario in usuarios)
        {
            if (usuario.getNome() == usuarioLogado.getNome() && usuario.getSenha() == usuarioLogado.getSenha())
            {
                usuario.setEquipamentos(usuarioLogado.getEquipamentos());
                break;
            }
        }

        salvarUsuario(usuarios);
    }
    static void MostrarMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar equipamento");
        Console.WriteLine("2 - Editar equipamento");
        Console.WriteLine("3 - Excluir equipamento");
        Console.WriteLine("4 - Visualizar equipamentos");
        Console.WriteLine("S - Logout");
        Console.WriteLine("---------------------------------");
    }
    static bool VoltarMenuInicial()
    {
        Console.WriteLine("Deseja voltar ao menu inicial? (S/N)");
        char resposta = char.ToUpper(Console.ReadKey(true).KeyChar);

        if (resposta == 'S')
        {
            Console.Clear();
            return true;
        }
        else
        {
            Console.WriteLine("Encerrando o programa...");
            return false;
        }
    }
    static void Main(string[] args)
    {

        bool continuar = true;

        while (continuar == true)
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = lerUsuarios(usuarios);

            Usuario usuarioLogado = new Usuario();

            int opcao = 0;
            bool usuarioEncontrado = false;
            string nome = "";
            string senha = "";

            Console.WriteLine("Bem-vindo ao sistema de gestão de equipamentos!");

            while (usuarioEncontrado == false)
            {
                do
                {
                    Console.WriteLine("1 - Fazer login");
                    Console.WriteLine("2 - Cadastrar novo usuário");
                    Console.WriteLine("3 - Sair");
                    Console.Write("Escolha uma opção: ");
                    opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);
                } while (opcao != 1 && opcao != 2 && opcao != 3);

                if (opcao == 1)
                {
                    Console.WriteLine("Digite o nome do usuário:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite a senha do usuário:");
                    senha = Console.ReadLine();

                    usuarioEncontrado = false;
                    foreach (var usuario in usuarios)
                    {
                        if (usuario.getNome() == nome && usuario.getSenha() == senha)
                        {
                            Console.WriteLine("Login bem-sucedido!");
                            usuarioLogado = usuario;
                            usuarioEncontrado = true;
                            break;
                        }
                    }
                    if (!usuarioEncontrado)
                    {
                        Console.WriteLine("Usuário ou senha incorretos.");
                        Thread.Sleep(3000);
                        while (Console.KeyAvailable) Console.ReadKey(true);
                        Console.Clear();
                    }
                }
                else if (opcao == 2)
                {
                    Console.WriteLine("Digite o nome do usuário:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite a senha do usuário:");
                    senha = Console.ReadLine();
                    Usuario novoUsuario = new Usuario(nome, senha);
                    usuarios.Add(novoUsuario);
                    salvarUsuario(usuarios);
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("Encerrando o programa...");
                    System.Environment.Exit(0);
                }
            }

            opcao = 0;
            Console.Clear();
            do
            {
                MostrarMenu();
                opcao = (int)char.GetNumericValue(Console.ReadKey(true).KeyChar);

                bool verifica = true;

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Cadastrar equipamento");
                        verifica = usuarioLogado.CadastrarEquipamento();
                        if (verifica == true)
                        {
                            AtualizarUsuario(usuarioLogado);
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Editar equipamento");
                        verifica = usuarioLogado.EditarEquipamento();
                        if (verifica == true)
                        {
                            AtualizarUsuario(usuarioLogado);
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Excluir equipamento");
                        verifica = usuarioLogado.ExcluirEquipamento();
                        if (verifica == true)
                        {
                            AtualizarUsuario(usuarioLogado);
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Visualizar equipamentos");
                        usuarioLogado.MostrarEquipamentos();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Logout do Usuario...");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (opcao != 5);

            continuar = VoltarMenuInicial();
        }

    }

}