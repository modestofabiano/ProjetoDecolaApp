using System;

namespace DIO.BlackMetal
{
    class Program
    {
        static AlbumsRepositorio repositorio = new AlbumsRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarAlbums();
						break;
					case "2":
						ListarBanda();
						break;
					case "3":
						InserirAlbum();
						break;
					case "4":
						AtualizarAlbum();
						break;
					case "5":
						ExcluirAlbum();
						break;
					case "6":
						VisualizarAlbum();
						break;
                    	case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirAlbum()
		{
			Console.Write("Digite o id do álbum: ");
			int indiceAlbum = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceAlbum);
		}

        private static void VisualizarAlbum()
		{
			Console.Write("Digite o id do álbum: ");
			int indiceAlbum = int.Parse(Console.ReadLine());

			var album = repositorio.RetornaPorId(indiceAlbum);

			Console.WriteLine(album);
		}

        private static void AtualizarAlbum()
		{
			Console.Write("Digite o id do álbum: ");
			int indiceAlbum = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da banda: ");
			string entradaBanda = (Console.ReadLine());

			Console.Write("Digite o título do álbum: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano do lançamento do álbum: ");
			int entradaAno = int.Parse(Console.ReadLine());

			
			Albums atualizaAlbum = new Albums(id: indiceAlbum,
										genero: (Genero)entradaGenero,
                                        banda: entradaBanda,
										titulo: entradaTitulo,
										ano: entradaAno);
										//descricao: entradaDescricao);

			repositorio.Atualiza(indiceAlbum, atualizaAlbum);
		}
        private static void ListarAlbums()
		{
			Console.WriteLine("Listar álbuns");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum álbum cadastrado.");
				return;
			}

			foreach (var album in lista)
			{
                var excluido = album.retornaExcluido();
                
				Console.WriteLine("#ID {0}: {1} - {2} {3}", album.retornaId(), album.retornaBanda(), album.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

 			private static void ListarBanda()
			{
				Console.WriteLine("Listar bandas");

				var lista = repositorio.ListaBanda();

				if (lista.Count == 0)
				{
					Console.WriteLine("Nenhuma banda cadastrado.");
					return;
				}

				foreach (var album in lista.Distinct())
				{
					var excluido = album.retornaExcluido();

					Console.WriteLine("#ID {0}: {1} {2}",  album.retornaId(), album.retornaBanda(), (excluido ? "*Excluído*" : ""));
				}
			}


        private static void InserirAlbum()
		{
			Console.WriteLine("Inserir novo álbum");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da banda: ");
			string entradaBanda = Console.ReadLine();

			Console.Write("Digite o título do Álbum: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o ano de lançamento do álbum: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Albums novoAlbum = new Albums(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
                                        banda: entradaBanda,
										titulo: entradaTitulo,
										ano: entradaAno);
										//descricao: entradaDescricao);

			repositorio.Insere(novoAlbum);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Black Metal Álbums \\m/");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Listar álbums");
			Console.WriteLine("2- Listar bandas");
			Console.WriteLine("3- Inserir nova álbum");
			Console.WriteLine("4- Atualizar álbum");
			Console.WriteLine("5- Excluir álbum");
			Console.WriteLine("6- Visualizar álbum");            
			Console.WriteLine("C- Limpar tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}