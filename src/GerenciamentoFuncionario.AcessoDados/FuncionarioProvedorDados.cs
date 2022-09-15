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

        public FuncionarioProvedorDados()
        {
            _contexto = new Contexto();
        }

        public void AtualizaFuncionario(Funcionario funcionarioAtualizado)
        {
            _contexto.Funcionarios.ForEach(f =>
            {
                if (f.Id == funcionarioAtualizado.Id)
                {
                    f.NomeCompleto = funcionarioAtualizado.NomeCompleto;
                    f.SetCargoId(funcionarioAtualizado.CargoId);
                    f.SetBebedorCafe(funcionarioAtualizado.EBebedorCafe);

                    if (funcionarioAtualizado.EBebedorCafe)
                        f.EBebedorDeCafe();
                    else
                        f.NaoEBebedorDeCafe();
                }
            });

        }

        public void ExcluiFuncionarioPorId(int id)
        {
            var funcionario = RecuperaFuncionarioPorId(id);
            ExcluiFuncionario(funcionario);
        }

        public void ExcluiFuncionario(Funcionario funcionario)
        {
            _contexto.Funcionarios.Remove(funcionario);
        }

        public Funcionario RecuperaFuncionarioPorId(int id)
        {
            return _contexto.Funcionarios.Find(x => x.Id == id);
            //return _contexto.Funcionarios.FirstOrDefault(x => x.Id == id);
            //return _contexto.Funcionarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public void SalvaFuncionario(Funcionario funcionario)
        {
            //Debug.WriteLine($"Funcionário salvo: {funcionario.PrimeiroNome}");
            var id = GeradorDeId();
            funcionario.Id = id;
            _contexto.Funcionarios.Add(funcionario);
        }

        public int GeradorDeId()
        {
            var maiorId = _contexto.Funcionarios.Any() ? _contexto.Funcionarios.Max(x => x.Id) : 0;
            bool temId;
            do
            {
                maiorId++;
                temId = _contexto.Funcionarios.Any(x => x.Id.Equals(maiorId));
                //temId = _contexto.Funcionarios.Any(x => x.Id == maiorId);
            } while (temId);

            return maiorId;
        }

        //public int RetornoId()
        //{
        //    return maiorId;
        //}

        public IEnumerable<Funcionario> CarregaFuncionarios()
        {
            return _contexto.Funcionarios;
        }
    }
}


