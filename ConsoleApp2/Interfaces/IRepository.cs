using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T obj);
        void Exclui(int id);
        void Atualiza(int id, T obj);
        int ProximoId();
    }
}
