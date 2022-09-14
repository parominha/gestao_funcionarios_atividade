using GerenciamentoFuncionario.AcessoDados;
using GerenciamentoFuncionario.Comuns.Modelos;
using System;
using System.Collections.Generic;

namespace GerenciamentoFuncionario.Terminal
{
    class Program
    {
        static void Main()
        {
            var provedorFuncionario = new FuncionarioProvedorDados();

            var funcionarios = provedorFuncionario.CarregaFuncionarios();
            ApresentaFuncionarios(funcionarios);

            //CRIAR FUNCIONARIOS
            provedorFuncionario.SalvaFuncionario(new Funcionario("Fulano de Tal", 1, false));
            provedorFuncionario.SalvaFuncionario(new Funcionario("Ciclano de Tal", 2, true));
            provedorFuncionario.SalvaFuncionario(new Funcionario("Beltrano de Tal", 3, true));

            ApresentaFuncionarios(funcionarios);

            //BUSCA POR ID
            var funcionarioSelecionado = provedorFuncionario.RecuperaFuncionarioPorId(3);

            //EXCLUI FUNCIONARIO
            provedorFuncionario.ExcluiFuncionario(funcionarioSelecionado);
            //provedorFuncionario.ExcluiFuncionarioPorId(4);

            //BUSCA POR ID
            funcionarioSelecionado = provedorFuncionario.RecuperaFuncionarioPorId(2);

            //ATUALIZA FUNCIONARIO
            funcionarioSelecionado.NomeCompleto = "aaaaaaaaaaaaaaaa";
            funcionarioSelecionado.NaoEBebedorDeCafe();
            funcionarioSelecionado.SetCargoId(2);
            provedorFuncionario.AtualizaFuncionario(funcionarioSelecionado);

            ApresentaFuncionarios(funcionarios);
        }

        private static void ApresentaFuncionarios(IEnumerable<Comuns.Modelos.Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"{funcionario.Id} {funcionario.NomeCompleto}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("\n\n");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}


