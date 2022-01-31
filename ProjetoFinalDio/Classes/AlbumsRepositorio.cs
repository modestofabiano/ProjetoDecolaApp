using System;
using System.Collections.Generic;
using DIO.BlackMetal.Interfaces;

namespace DIO.BlackMetal
{
	public class AlbumsRepositorio : IRepositorio<Albums>
	{
        private List<Albums> ListaAlbums = new List<Albums>();

		public void Atualiza(int id, Albums objeto)
		{
			ListaAlbums[id] = objeto;
		}

		public void Exclui(int id)
		{
			ListaAlbums[id].Excluir();
		}

		public void Insere(Albums objeto)
		{
			ListaAlbums.Add(objeto);
		}

		public List<Albums> Lista()
		{
			return ListaAlbums;
		}

		public List<Albums> ListaBanda()
		{
			return ListaAlbums;
		}

		public int ProximoId()
		{
			return ListaAlbums.Count;
		}

		public Albums RetornaPorId(int id)
		{
			return ListaAlbums[id];
		}
	}
}