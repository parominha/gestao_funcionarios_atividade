using System.Collections.Generic;

namespace GerenciamentoFuncionario.Comuns.Interfaces.Infra.Json
{
    public interface IManagmentJson<T>
    {
        List<T> LerBaseJson();
        void EscreverBaseJson(List<T> list);
    }
}
