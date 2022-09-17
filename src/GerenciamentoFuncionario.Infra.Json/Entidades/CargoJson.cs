using GerenciamentoFuncionario.Comuns.Interfaces.Infra.Json;
using GerenciamentoFuncionario.Comuns.Modelos;
using System.Collections.Generic;

namespace GerenciamentoFuncionario.Infra.Json.Entidades
{
    public class CargoJson : ICargoJson
    {
        private readonly GerenciarJson<Cargo> _managmentJson;

        public CargoJson()
        {
            _managmentJson = new GerenciarJson<Cargo>(@"C:\TestJson\", "Cargos");
        }

        public void AtribuiCargos(List<Cargo> cargos) => _managmentJson.EscreverBaseJson(cargos);

        public List<Cargo> RecebeCargos() => _managmentJson.LerBaseJson();

    }
}
