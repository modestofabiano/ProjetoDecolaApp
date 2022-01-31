using System;

namespace DIO.BlackMetal
{
    public class Albums : EntidadeBase
    {
        // Características dos discos
		private Genero Genero { get; set; }
        private string Banda { get; set; }
		private string Titulo { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

       
		public Albums(int id, Genero genero, string banda, string titulo, int ano)
		{
			this.Id = id;
			this.Genero = genero;
            this.Banda = banda;
			this.Titulo = titulo;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override string ToString()
		{
			string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Banda: " + this.Banda + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

        public string retornaBanda()
		{
			return this.Banda;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}