using GerenciamentoFuncionario.Comuns.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoFuncionario.Comuns.ProvedorDados
{
    public interface ICargoProvedorDados
    {
        IEnumerable<Cargo> CarregaCargos();
        Cargo RecuperaCargoPorId(int id);
        void SalvaCargo(Cargo cargo);
        void AtualizaCargo(Cargo cargo);
        void ExcluiCargo(Cargo cargo);
    }
}
