using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Interface
{
    public interface ListaSeries <T>
    {
        List<T> Lista();
        T ReturnId(int id);
        void Insere(T entidade);
        void Excluir(int id);
        void Atualizar(int id, T entidade);
        int NextId();
    }
}
