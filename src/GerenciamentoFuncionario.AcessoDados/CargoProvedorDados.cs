using GerenciamentoFuncionario.Comuns.Modelos;
using GerenciamentoFuncionario.Comuns.ProvedorDados;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GerenciamentoFuncionario.AcessoDados
{
    public class CargoProvedorDados : ICargoProvedorDados
    {
        private readonly Contexto _contexto;

        public CargoProvedorDados()
        {
            _contexto = new Contexto();
        }

        public void AtualizaCargo(Cargo cargo)
        {
            var listaCargosAtualizada = _contexto.Cargos;

            listaCargosAtualizada.Remove(listaCargosAtualizada?.FirstOrDefault(x => x.Id.Equals(cargo?.Id)));
            listaCargosAtualizada.Add(cargo);
            _contexto.Cargos = listaCargosAtualizada;
        }

        public IEnumerable<Cargo> CarregaCargos() => _contexto.Cargos;

        public void ExcluiCargo(Cargo cargo)
        {
            var listaComCargoExcluido = _contexto.Cargos;
            listaComCargoExcluido.Remove(listaComCargoExcluido?.FirstOrDefault(x => x.Id.Equals(cargo?.Id)));
            _contexto.Cargos = listaComCargoExcluido;
        }

        public Cargo RecuperaCargoPorId(int id)
        {
            return _contexto.Cargos.Find(x => x.Id.Equals(id));
        }

        public Cargo RecuperaCargoPorNome(string nomeCargo)
        {
            return _contexto.Cargos.Find(x => x.CargoNome.Equals(nomeCargo));
        }

        public Cargo SalvaCargo(string nomeCargo)
        {
            var listaCargoNovo = _contexto.Cargos;
            var novoCargo = new Cargo(GeradorDeId(), nomeCargo);
            listaCargoNovo.Add(novoCargo);
            _contexto.Cargos = listaCargoNovo;
            Debug.WriteLine($"Cargo salvo: {novoCargo.CargoNome}");
            return novoCargo;
        }

        private int GeradorDeId()
        {
            var maiorId = _contexto.Cargos.Any() ? _contexto.Cargos.Max(x => x.Id) : 0;
            bool temId;
            do
            {
                maiorId++;
                temId = _contexto.Cargos.Any(x => x.Id.Equals(maiorId));
            } while (temId);

            return maiorId;
        }
    }
}