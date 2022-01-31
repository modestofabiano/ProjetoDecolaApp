using System.Collections.Generic;

namespace DIO.BlackMetal.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        List<T> ListaBanda();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Exclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}