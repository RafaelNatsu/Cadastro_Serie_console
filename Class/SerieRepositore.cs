using System.Collections.Generic;
using clog.Series.Interface;

namespace clog.Series
{
    public class SerieRepositore : IRepositore<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }

        public List<Serie> RetornaPorGenero(Genero genero){
            List<Serie> PorGenero =  new List<Serie>();

            for (int i = 0; i < listaSerie.Count; i++)
            {
                if (genero.Equals(listaSerie[i].retornaGenero())){
                    PorGenero.Add(listaSerie[i]);
                }
            }
            return PorGenero;
        }
        public List<Serie> RetornaPorInteresse(Interesse Interesse){
            List<Serie> PorInteresse =  new List<Serie>();

            for (int i = 0; i < listaSerie.Count; i++)
            {
                if (Interesse.Equals(listaSerie[i].retornaInteresse())){
                    PorInteresse.Add(listaSerie[i]);
                }
            }
            return PorInteresse;
        }
    }
}