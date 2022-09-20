using GerenciamentoFuncionario.Comuns.Modelos;
using System.Collections.Generic;

namespace GerenciamentoFuncionario.Comuns.ProvedorDados
{
    public interface IFuncionarioProvedorDados
    {
        IEnumerable<Funcionario> CarregaFuncionarios();
        Funcionario RecuperaFuncionarioPorId(int id);
        void AtualizaFuncionario(Funcionario funcionario);
        void ExcluiFuncionario(Funcionario funcionario);
        Funcionario SalvaFuncionario(string nomeCompleto, int cargoId, bool eBebedorCafe);
    }
}

