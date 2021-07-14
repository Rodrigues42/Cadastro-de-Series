using System.Collections.Generic;

namespace Cadastro.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T ReturnPorId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}