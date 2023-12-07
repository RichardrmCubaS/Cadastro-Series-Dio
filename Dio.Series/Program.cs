using System;
using Dio.Series.Classes;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
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
            Console.Clear();
            Console.WriteLine("===================================================");
            Console.WriteLine("| Obrigado por sua Preferencia ,Voçê Saiu do App. |");
            Console.WriteLine("===================================================");
			Console.ReadLine();

        }

        private static void ExcluirSerie()
		{
			Console.WriteLine("==========================================");
            Console.WriteLine("|            Excluir Série                |");
            Console.WriteLine("==========================================");
            
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
            Console.WriteLine("==========================================");
		}
        private static void VisualizarSerie()
		{
			Console.WriteLine("==========================================");
            Console.WriteLine("|            Vizualizar Série              |");
            Console.WriteLine("==========================================");

            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
            Console.WriteLine("==========================================");
		}

        private static void AtualizarSerie()
		{
			Console.WriteLine("==========================================");
            Console.WriteLine("|            Atualizar Série              |");
            Console.WriteLine("==========================================");
            
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			
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

            Console.WriteLine("==========================================");

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

         private static void ListarSeries()
		{
			Console.WriteLine("=======================================");
            Console.WriteLine("|           Listar séries             |");
            Console.WriteLine("=======================================");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("=======================================");
                Console.WriteLine("| Nenhuma Série Ainda foi cadastrada. |");
                Console.WriteLine("=======================================");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("Codigo       Nombre da Série          EStado");
                Console.WriteLine("============================================");
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

         private static void InserirSerie()
		{
			Console.WriteLine("==========================================");
            Console.WriteLine("|          Inserir Nova Série             |");
            Console.WriteLine("==========================================");
            			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			
            Console.Write("Digite o gênero entre as opções acima ==> ");
			int entradaGenero = int.Parse(Console.ReadLine());
            
			Console.Write("Digite o Título da Série ==> ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série ==> ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série ==> ");
			string entradaDescricao = Console.ReadLine();

            Console.WriteLine("==========================================");

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

         private static string ObterOpcaoUsuario()
		{
			Console.WriteLine("================================");
			Console.WriteLine("|  ***  App   DIO  Séries  ***  |");
            Console.WriteLine("================================");
			Console.WriteLine("|         Menu de Opções        |");
            Console.WriteLine("================================");
			Console.WriteLine("|  [ 1 ] - Listar séries        |");
			Console.WriteLine("|  [ 2 ] - Inserir nova série   |");
			Console.WriteLine("|  [ 3 ] - Atualizar série      |");
			Console.WriteLine("|  [ 4 ] - Excluir série        |");
			Console.WriteLine("|  [ 5 ] - Visualizar série     |");
			Console.WriteLine("|  [ C ] - Limpar Tela          |");
			Console.WriteLine("|  [ X ] - Sair do App          |");
            Console.WriteLine("================================");
			Console.WriteLine("|   Escolhe a opção desejada e  |");
            Console.WriteLine("|   Pressione a tecla [Enter]   |");
            Console.WriteLine("=================================");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
