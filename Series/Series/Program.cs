using Series.Class;
using Series.Enum;
using System;

public class Sereis
{
        static SerieRepositorio repositorio = new SerieRepositorio();
    static void Main(string[] args)
    {


        string opcaoUsuario = ObeterOpUsuario();
        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSerie();
                    break;
                case "2":
                    InserirSerie();
                    break;
                case "3":
                    AtualizarSerie();
                    break;
                case "4":
                    ExcluirSerie();
                    break;
                case "5":
                    VisualizarSerie();
                    break;
                case "C":
                    Console.Clear();
                    break;
                case "X":

                default:
                    throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObeterOpUsuario();
        }
        Console.WriteLine("Obrigada!");
        Console.ReadLine();
    }

    private static void ListarSerie() //Lista
    {
        Console.WriteLine("Listar Series");

        var lista = repositorio.Lista();
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhuma seria nos registro");
            return;
        }

        foreach (var serie in lista)
        {
            Console.WriteLine($"#ID {serie.ReturnId()}: {serie.ReturnTitulo()}");
        }
    }

    private static void InserirSerie() // Adicionar
    {
        Console.WriteLine("Inserir Serie");
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine($"{i} {Enum.GetName(typeof(Genero), i)}");
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorio.NextId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
    }

    private static void AtualizarSerie() //Atualizar
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Atualizar(indiceSerie, atualizaSerie);
    }

    private static void ExcluirSerie() //Excluir
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Excluir(indiceSerie);
    }

    private static void VisualizarSerie() //Visualizar
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.ReturnId(indiceSerie);

        Console.WriteLine(serie);
    }

    private static string ObeterOpUsuario() // Obeter
    {
        Console.WriteLine();
        Console.WriteLine("Dio Serie ao seu dispor!!!");
        Console.WriteLine("Iforme sua escolha");

        Console.WriteLine("1 - Listar series");
        Console.WriteLine("2 - Iserir serie");
        Console.WriteLine("3 - Atualizar Serie");
        Console.WriteLine("4 - Excluir serie");
        Console.WriteLine("5 - Visualizar serie");
        Console.WriteLine("C - Limpar tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;

    }
}
