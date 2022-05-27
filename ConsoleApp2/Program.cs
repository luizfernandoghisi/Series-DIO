using System;

namespace Series
{
    public class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
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
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarSeries()
        {
            var lista = repository.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine($"#ID {serie.retornaId()}: -- {serie.retornaTitulo()} {(excluido ? "**Excluído**" : "" )}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine(" - Adicionar Nova Série - ");
            Console.WriteLine();

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
                //Console.WriteLine("{0} - {1}", i, Enum.);
            }
            Console.WriteLine();
            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Informe o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Informe o Ano de Lançamento da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Informe a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repository.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Informe o ID da série que deseja atualizar: ");

            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine();
            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Informe o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Informe o Ano de Lançamento da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Informe a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repository.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Informe o ID da série que você deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repository.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repository.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo a DIOFlix!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Adicionar Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
