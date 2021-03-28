using System;
namespace clog.Series
{
    class Program
    {
        static SerieRepositore repositorio = new SerieRepositore();
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
					case "6":
						ListaPorGenero();
						break;
					case "7":
						ListaPorInteresse();
						break;
					case "C":
						Console.Clear();
						break;

					default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Opção errada! Digite a correta.");
                        Console.ResetColor();
                        break;
				}
				opcaoUsuario = ObterOpcaoUsuario();
                Console.Clear();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("---------- s2 ----------");
            Console.ResetColor();
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			if(indiceSerie < repositorio.ProximoId() && indiceSerie >= 0 ){
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Serie deletada");
				Console.ResetColor();
				repositorio.Exclui(indiceSerie);
			}else{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Id da serie inválida ou inexistente");
				Console.ResetColor();
			}
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			if(indiceSerie < repositorio.ProximoId() && indiceSerie >= 0 ){
				var serie = repositorio.RetornaPorId(indiceSerie);
				Console.WriteLine(serie);
			}
			else{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Id da serie inválida ou inexistente");
				Console.ResetColor();
			}
		}

        private static void AtualizarSerie()
		{

			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			if(indiceSerie < repositorio.ProximoId() && indiceSerie >= 0 ){
				foreach (int i in Enum.GetValues(typeof(Genero)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
				}
				Console.Write("Digite o gênero entre as opções acima: ");
				int entradaGenero = int.Parse(Console.ReadLine());

				Console.Write("Digite o Nome da Série: ");
				string entradaNome = Console.ReadLine();

				Console.Write("Digite o Ano de Início da Série: ");
				int entradaAno = int.Parse(Console.ReadLine());

				Console.Write("Digite a Descrição da Série: ");
				string entradaDescricao = Console.ReadLine();

				Console.WriteLine();

				Console.WriteLine("Qual é o nivel de interesse");
				foreach (int i in Enum.GetValues(typeof(Interesse)))
				{
					Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Interesse), i));
				}
				Console.Write("Digite o Interesse:");
				int entradaInteresse = int.Parse(Console.ReadLine());

				Serie atualizaSerie = new Serie(id: indiceSerie,
											genero: (Genero)entradaGenero,
											nome: entradaNome,
											ano: entradaAno,
											descricao: entradaDescricao,
											Interesse: (Interesse)entradaInteresse);

				repositorio.Atualiza(indiceSerie, atualizaSerie);
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Atualizado");
				Console.ResetColor();
			}
			else{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Id da serie inválida ou inexistente");
				Console.ResetColor();	
			}
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
                Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Nenhuma série cadastrada.");
                Console.ResetColor();
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaNome(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da Série: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Qual é o nivel de interesse"); //* procurar nome melhor
            foreach (int i in Enum.GetValues(typeof(Interesse)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Interesse), i));
			}
            Console.Write("Digite o Interesse:");

            int? entradaInteresse = int.Parse(Console.ReadLine());

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										nome: entradaNome,
										ano: entradaAno,
										descricao: entradaDescricao,
                                        Interesse: (Interesse)entradaInteresse); 

			repositorio.Insere(novaSerie);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Inserido com sucesso");
            Console.ResetColor();
		}

		private static void ListaPorGenero(){

			Console.WriteLine("Selecione o Genero da Serie:");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.WriteLine();
			int entradaGenero = int.Parse(Console.ReadLine());

			var porGenero = repositorio.RetornaPorGenero((Genero)entradaGenero);

			foreach (var serie in porGenero)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaNome(), (excluido ? "*Excluído*" : ""));
			}

		}
		private static void ListaPorInteresse(){

			Console.WriteLine("Selecione o Interesse da Serie:");

			foreach (int i in Enum.GetValues(typeof(Interesse)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Interesse), i));
			}

			Console.WriteLine();
			int entradaInteresse = int.Parse(Console.ReadLine());

			var porInteresse = repositorio.RetornaPorInteresse((Interesse)entradaInteresse);

			foreach (var serie in porInteresse)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaNome(), (excluido ? "*Excluído*" : ""));
			}

		}

        private static string ObterOpcaoUsuario()
		{
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(Environment.NewLine);
			builder.Append("DIO Séries a seu dispor!!!" + Environment.NewLine);
			builder.Append("Informe a opção desejada:" + Environment.NewLine);
            builder.Append(Environment.NewLine);
			builder.Append("1- Listar séries" + Environment.NewLine);
			builder.Append("2- Inserir nova série" + Environment.NewLine);
			builder.Append("3- Atualizar série" + Environment.NewLine);
			builder.Append("4- Excluir série" + Environment.NewLine);
			builder.Append("5- Visualizar série" + Environment.NewLine);
            builder.Append("6- Listar por Genero" + Environment.NewLine); 
			builder.Append("7- Listar por Interesse" + Environment.NewLine);
			builder.Append("C- Limpar Tela" + Environment.NewLine);
			builder.Append("X- Sair");
			builder.Append(Environment.NewLine);
            string opcao = builder.ToString();
            Console.WriteLine(opcao);
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}


