using Series.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Class
{
    public class SerieRepositorio : ListaSeries<Serie>
    {
        private List<Serie> listSeries = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            listSeries[id] = entidade;
        }

        public void Excluir(int id)
        {
            listSeries[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            listSeries.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public Serie ReturnId(int id)
        {
            return listSeries[id];
        }
    }
}
