using GerenciamentoFuncionario.Comuns.Modelos;
using System.Collections.Generic;

namespace GerenciamentoFuncionario.Comuns.Interfaces.Infra.Json
{
    public interface ICargoJson
    {
        List<Cargo> RecebeCargos();
        void AtribuiCargos(List<Cargo> value);
    }
}