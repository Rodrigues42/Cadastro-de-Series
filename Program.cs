using System;
using Cadastro.Classes;
using Cadastro.Enum;

namespace Cadastro
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        LimparTela();
                        InserirSerie();
                        break;
                    case "3":
                        LimparTela();
                        ListarSeries();
                        AtualizarSerie();
                        LimparTela();
                        break;
                    case "4":
                        ExcluiSerie();
                        break;
                    case "5":
                        ListarSeries();
                        VisualizarSerie();
                        break;
                    case "6":
                       LimparTela();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine();
        }

        private static void LimparTela()
        {
            Console.Clear();
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Descrição da série");
            Console.WriteLine("----------------------------------");
            Console.Write("Digite a id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.ReturnPorId(indiceSerie);

            Console.WriteLine(serie);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
        }

        private static void ExcluiSerie()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Excluir nova série");
            Console.WriteLine("----------------------------------");
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
            Console.WriteLine();
            Console.WriteLine("Série Excluida com Sucesso!");
            Console.WriteLine("----------------------------------");
        }

        private static void AtualizarSerie()
        { 

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Atualizar nova série");
            Console.WriteLine("----------------------------------");

            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.Genero.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine();
            Console.Write("Digite o gênero entre as opçõea acima: ");
            int inputGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo: ");
            string inputTitulo = Console.ReadLine();

            Console.Write("Digite o ano de Inicio da série: ");
            int inputAno = int.Parse(Console.ReadLine());

            Console.Write("Digite uma descrição da série: ");
            string inputDescricao = Console.ReadLine();

            Console.Write("Digite o elenco da Série: ");
            string inputElenco = Console.ReadLine();

            Console.Write("Digite a nacionalidade da serie: ");
            string inputNacionalidade = Console.ReadLine();

            Serie AtualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)inputGenero, 
                                        titulo: inputTitulo,
                                        ano: inputAno, 
                                        descrition: inputDescricao,
                                        elenco: inputElenco, 
                                        nacionalidade: inputNacionalidade);
            
            repositorio.Atualiza(indiceSerie, AtualizaSerie);

        }

        private static void InserirSerie()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Inserir nova série");
            Console.WriteLine("----------------------------------");

            foreach(int i in Enum.Genero.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{Enum.Genero.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine();
            Console.Write("Digite o gênero entre as opçõea acima: ");
            int inputGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo: ");
            string inputTitulo = Console.ReadLine();

            Console.Write("Digite o ano de Inicio da série: ");
            int inputAno = int.Parse(Console.ReadLine());

            Console.Write("Digite uma descrição da série: ");
            string inputDescricao = Console.ReadLine();

            Console.Write("Digite o elenco da Série: ");
            string inputElenco = Console.ReadLine();

            Console.Write("Digite a nacionalidade da serie: ");
            string inputNacionalidade = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)inputGenero, 
                                        titulo: inputTitulo,
                                        ano: inputAno, 
                                        descrition: inputDescricao,
                                        elenco: inputElenco, 
                                        nacionalidade: inputNacionalidade);
            
            repositorio.Insere(novaSerie);
            Console.WriteLine("Serie Inserida com Sucesso!");
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
        }

        private static void ListarSeries()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Lista de Series");
            Console.WriteLine("==================================");

            var lista = repositorio.Lista();
        
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                Console.WriteLine("----------------------------------");
                Console.WriteLine();
                return;
            }

            foreach (var serie in lista)
            {   
                var excluido = serie.RetornaExcluido();
                Console.WriteLine($"> ID {serie.retornaId()} - {serie.retornaTitulo()} {(excluido ? "Excluido" : "")}");
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine();
        
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("##################################");
            Console.WriteLine("Catalogo de Series");
            Console.WriteLine("##################################");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("----------------------------------");

            Console.Write("Informe a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------------");
            return opcaoUsuario;
        }
    }
}
