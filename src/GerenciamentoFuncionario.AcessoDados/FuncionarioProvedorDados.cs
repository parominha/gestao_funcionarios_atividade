using GerenciamentoFuncionario.Comuns.Modelos;
using GerenciamentoFuncionario.Comuns.ProvedorDados;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GerenciamentoFuncionario.AcessoDados
{
    public class FuncionarioProvedorDados : IFuncionarioProvedorDados
    {
        private readonly Contexto _contexto;

        public FuncionarioProvedorDados() => _contexto = new Contexto();

        public Funcionario RecuperaFuncionarioPorId(int id) => RecebeListaFuncionariosContexto().Find(x => x.Id.Equals(id));

        public IEnumerable<Funcionario> CarregaFuncionarios() => RecebeListaFuncionariosContexto();

        public void AtualizaFuncionario(Funcionario funcionario)
        {
            var listaFuncionariosAtualizada = RecebeListaFuncionariosContexto();
            listaFuncionariosAtualizada.Remove(listaFuncionariosAtualizada?.FirstOrDefault(x => x.Id.Equals(funcionario?.Id)));
            listaFuncionariosAtualizada.Add(funcionario);
            AtribuiListaFuncionariosContexto(listaFuncionariosAtualizada);
        }

        public void ExcluiFuncionario(Funcionario funcionario)
        {
            var listaComFuncionarioExcluido = RecebeListaFuncionariosContexto();
            listaComFuncionarioExcluido.Remove(listaComFuncionarioExcluido?.FirstOrDefault(x => x.Id.Equals(funcionario?.Id)));
            AtribuiListaFuncionariosContexto(listaComFuncionarioExcluido);
        }

        public Funcionario SalvaFuncionario(string nomeCompleto, int cargoId, bool eBebedorCafe)
        {
            var listaFuncionarioNovo = RecebeListaFuncionariosContexto();
            var novoFuncionario = new Funcionario(GeradorDeId(), nomeCompleto, cargoId, eBebedorCafe);
            listaFuncionarioNovo.Add(novoFuncionario);
            AtribuiListaFuncionariosContexto(listaFuncionarioNovo);
            return novoFuncionario;
        }

        private int GeradorDeId()
        {
            var maiorId = RecebeListaFuncionariosContexto().Any() ? RecebeListaFuncionariosContexto().Max(x => x.Id) : 0;
            bool temId;
            do
            {
                maiorId++;
                temId = RecebeListaFuncionariosContexto().Any(x => x.Id.Equals(maiorId));
            } while (temId);

            return maiorId;
        }
         
        private void AtribuiListaFuncionariosContexto(List<Funcionario> listaFuncionarios) => _contexto.Funcionarios = listaFuncionarios;

        private List<Funcionario> RecebeListaFuncionariosContexto() => _contexto.Funcionarios;
    }
}


