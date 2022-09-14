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

            Menu:
            Console.WriteLine("--- Gerenciamento de Funcionários ---");
            Console.WriteLine("Escolha uma das opções CRIAR/EXCLUIR/ATUALIZAR/SAIR: ");
            string opcaoEscolhida = Console.ReadLine();

            switch (opcaoEscolhida)
            {
                case "CRIAR":
                    Console.Write("Digite o nome completo do funcionário: ");
                    string nomeCompleto = Console.ReadLine();

                    Console.Write("Digite o ID do cargo (1-Desenvolvedor 2-Engenheiro 3-Arquiteto 4-Gerente de Projetos): ");
                    string idCargo = Console.ReadLine();
                    int IdCargo = int.Parse(idCargo);

                    Console.Write("É bebedor de café? (S/N): ");
                    string bebeCafe = Console.ReadLine();
                    bool BebeCafe;

                    if (bebeCafe.ToUpper() == "S")
                    {
                        BebeCafe = true;
                    }

                    else
                    {
                        BebeCafe = false;
                    }

                    
                    provedorFuncionario.SalvaFuncionario(new Funcionario(Id, nomeCompleto, IdCargo, BebeCafe));

                    //provedorFuncionario.SalvaFuncionario(new Funcionario("Fulano de Tal", 1, false));
                    //provedorFuncionario.SalvaFuncionario(new Funcionario("Ciclano de Tal", 2, true));
                    //provedorFuncionario.SalvaFuncionario(new Funcionario("Beltrano de Tal", 3, true));
                    break;

                case "EXCLUIR":
                    Console.Write("Digite o ID do funcionário: ");
                    string idExclui = Console.ReadLine();
                    int IdExclui = int.Parse(idExclui);
                    //Console.Write("Confirma exclusão do funcionário ");
                    provedorFuncionario.ExcluiFuncionarioPorId(IdExclui);
                    break;

                case "ATUALIZAR":
                    Console.Write("Digite o ID do funcionário: ");
                    string idSelecionado = Console.ReadLine();
                    int IdSelecionado = int.Parse(idSelecionado);
                    var _funcionarioSelecionado = provedorFuncionario.RecuperaFuncionarioPorId(IdSelecionado);
                    Alteracoes:
                    Console.Write("Qual informação deseja alterar? NOME/CARGO/CAFE: ");
                    string opcaoEscolhidaAtualiza = Console.ReadLine();
                    switch (opcaoEscolhidaAtualiza)
                    {
                        case "NOME":
                            Console.Write("Digite o nome completo atualizado: ");
                            string nomeAtualizado = Console.ReadLine();
                            _funcionarioSelecionado.NomeCompleto = nomeAtualizado;
                            break;

                        case "CARGO":
                            Console.Write("Digite o ID do cargo atualizado (1-Desenvolvedor 2-Engenheiro 3-Arquiteto 4-Gerente de Projetos): ");
                            string cargoAtualizado = Console.ReadLine();
                            int CargoAtualizado = int.Parse(cargoAtualizado);
                            _funcionarioSelecionado.SetCargoId(CargoAtualizado);
                            break;

                        case "CAFE":
                            Console.Write("É bebedor de café? S/N: ");
                            string BebeCafeAtualizado = Console.ReadLine();
                            if (BebeCafeAtualizado.ToUpper() == "S")
                            {
                                _funcionarioSelecionado.EBebedorDeCafe();
                            }
                            else
                            { _funcionarioSelecionado.NaoEBebedorDeCafe(); }
                            break;
                            
                        default:
                            break;
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("--- Dados atualizados ---");
                    Console.WriteLine("Nome completo: " + _funcionarioSelecionado.NomeCompleto);
                    Console.WriteLine("Cargo: " + _funcionarioSelecionado.CargoId);
                    Console.WriteLine("Bebe café: " + _funcionarioSelecionado.EBebedorCafe);
                    Console.WriteLine("--- ----------------- ---");
                    Console.WriteLine("\n");
                    Console.Write("Deseja alterar mais alguma informação? S/N: ");
                    string alterarMais = Console.ReadLine();
                    if (alterarMais.ToUpper() == "S")
                    {
                        goto Alteracoes;
                    }
                    else
                    { goto Menu; }

                    break;
                default:
                    break;
            }



            //ApresentaFuncionarios(funcionarios);

            //BUSCA POR ID
            //var funcionarioSelecionado = provedorFuncionario.RecuperaFuncionarioPorId(3);



            //ApresentaFuncionarios(funcionarios);
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


