using System;

namespace clog.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido{ get; set; }
        private Interesse Interesse{ get; set; }

        public Serie(int id, Genero genero, string nome, string descricao, int ano, Interesse Interesse)
		{
			this.Id = id;
			this.Genero = genero;
			this.Nome = nome;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
            this.Interesse = Interesse;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            if(this.Excluido)
                retorno += "Excluido: " + this.Excluido;
            else
                retorno += "Marcador: " + this.Interesse;
			return retorno;
		}

        public string retornaNome()
		{
			return this.Nome;
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
        public Genero retornaGenero(){
            return this.Genero;
        }
        public Interesse retornaInteresse(){
            return this.Interesse;
        }
    }
}