using GerenciamentoFuncionario.Comuns.Modelos;
using System.Collections.Generic;

namespace GerenciamentoFuncionario.Comuns.ProvedorDados
{
    public interface IFuncionarioProvedorDados
    {
        IEnumerable<Funcionario> CarregaFuncionarios();
        Funcionario RecuperaFuncionarioPorId(int id);
        void SalvaFuncionario(Funcionario funcionario);
        void AtualizaFuncionario(Funcionario funcionario);
        void ExcluiFuncionario(Funcionario funcionario);
    }
}


