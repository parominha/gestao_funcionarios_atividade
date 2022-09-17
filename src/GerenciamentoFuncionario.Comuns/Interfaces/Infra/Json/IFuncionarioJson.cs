using GerenciamentoFuncionario.Comuns.Modelos;
using System.Collections.Generic;

namespace GerenciamentoFuncionario.Comuns.Interfaces.Infra.Json
{
    public interface IFuncionarioJson
    {
        List<Funcionario> RecebeFuncionarios();
        void AtribuiFuncionarios(List<Funcionario> value);
    }
}