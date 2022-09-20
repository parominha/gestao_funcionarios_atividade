using GerenciamentoFuncionario.AcessoDados;
using GerenciamentoFuncionario.Comuns.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GerenciamentoFuncionario.Terminal
{
    class Program
    {
        static void Main()
        {
            var provedorFuncionario = new FuncionarioProvedorDados();
            var provedorCargo = new CargoProvedorDados();

            var funcionarios = provedorFuncionario.CarregaFuncionarios();
            var cargos = provedorCargo.CarregaCargos();

        Menu:
            Console.WriteLine("----------- Gerenciamento -----------");
            Console.WriteLine("------ Escolha uma das opções -------");
            Console.WriteLine("1- GERENCIAR FUNCIONARIOS");
            Console.WriteLine("2- GERENCIAR CARGOS");
            Console.WriteLine("3- SAIR");
            Console.Write("-> ");
            string opcaoEscolhidaMenu = Console.ReadLine();
            Console.Clear();

            if (opcaoEscolhidaMenu == "1")
            {
                MenuFuncionario:
                Console.WriteLine("--- Gerenciamento de Funcionários ---");
                Console.WriteLine("------ Escolha uma das opções -------");
                Console.WriteLine("1- CRIAR");
                Console.WriteLine("2- EXCLUIR");
                Console.WriteLine("3- ATUALIZAR");
                Console.WriteLine("4- LISTAR");
                Console.WriteLine("5- VOLTAR");
                Console.Write("-> ");
                string opcaoEscolhidaFuncionario = Console.ReadLine();

                switch (opcaoEscolhidaFuncionario)
                {
                    case "1":
                        Console.WriteLine("\n");
                        Console.Write("Digite o nome completo do funcionário: ");
                        string nomeCompleto = Console.ReadLine();

                        Console.WriteLine("");
                        Console.WriteLine("Digite o ID do cargo:");
                        ApresentaCargosMenu(cargos);
                        Console.Write("-> ");
                        string idCargo = Console.ReadLine();
                        int IdCargo = int.Parse(idCargo);
                        // TODO: FAZER VALIDACAO DE CARGOS
                        Console.WriteLine("");
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

                        var funcionarioCriado = provedorFuncionario.SalvaFuncionario(nomeCompleto, IdCargo, BebeCafe);

                        //var funcionarioAdicionado = provedorFuncionario.SalvaFuncionario(new Funcionario(nomeCompleto, IdCargo, BebeCafe));


                        Console.WriteLine("\n");
                        Console.WriteLine("--- Dados do funcionário criado ---");

                        Console.WriteLine("Id: " + funcionarioCriado.Id);

                        Console.WriteLine("Nome completo: " + funcionarioCriado.NomeCompleto);

                        Console.WriteLine("Cargo: " + funcionarioCriado.CargoId);

                        if (BebeCafe == false)
                        {
                            Console.WriteLine("Bebe café?: Não");
                        }
                        else if (BebeCafe == true)
                        {
                            Console.WriteLine("Bebe café?: Sim");
                        }
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("\n");

                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;


                    case "2":
                        Console.WriteLine("");
                        Console.Write("Digite o ID do funcionário: ");
                        string idExclui = Console.ReadLine();
                        int IdExclui = int.Parse(idExclui);

                    confirmaExclusao:
                        Console.WriteLine("");
                        var funcionarioExcluir = provedorFuncionario.RecuperaFuncionarioPorId(IdExclui);
                        Console.Write("Confirma exclusão do funcionário? -> " + funcionarioExcluir.NomeCompleto + " (S/N): ");
                        string confirmaExclusao = Console.ReadLine();
                        if (confirmaExclusao.ToUpper() == "S")
                        {
                            provedorFuncionario.ExcluiFuncionario(funcionarioExcluir);
                            Console.WriteLine("");
                            Console.WriteLine("Funcionário excluído com sucesso!");
                            Console.WriteLine("\n");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Menu;
                        }
                        else if (confirmaExclusao.ToUpper() == "N")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Menu;
                        }
                        else
                        {
                            Console.WriteLine("** Opção inválida, tente novamente! **");
                            goto confirmaExclusao;
                        }

                    case "3":
                        Console.WriteLine("");
                        Console.Write("Digite o ID do funcionário: ");
                        string idSelecionado = Console.ReadLine();
                        int IdSelecionado = int.Parse(idSelecionado);
                        var _funcionarioSelecionado = provedorFuncionario.RecuperaFuncionarioPorId(IdSelecionado);
                        Console.WriteLine("Funcionario validado: " + _funcionarioSelecionado.NomeCompleto);

                    AlteracoesFunc:
                        Console.WriteLine("");
                        Console.WriteLine("Qual informação deseja alterar?");
                        Console.WriteLine("1- NOME");
                        Console.WriteLine("2- CARGO");
                        Console.WriteLine("3- CAFE");
                        Console.Write("-> ");
                        string opcaoEscolhidaAtualiza = Console.ReadLine();
                        switch (opcaoEscolhidaAtualiza)
                        {
                            case "1":
                                Console.WriteLine("");
                                Console.Write("Digite o nome completo atualizado: ");
                                string nomeAtualizado = Console.ReadLine();
                                _funcionarioSelecionado.NomeCompleto = nomeAtualizado;
                                provedorFuncionario.AtualizaFuncionario(_funcionarioSelecionado);
                                break;

                            case "2":
                                Console.WriteLine("");
                                Console.WriteLine("Digite o ID do cargo");
                                ApresentaCargosMenu(cargos);
                                Console.Write("-> ");
                                string cargoAtualizado = Console.ReadLine();
                                int CargoAtualizado = int.Parse(cargoAtualizado);
                                _funcionarioSelecionado.SetCargoId(CargoAtualizado);
                                provedorFuncionario.AtualizaFuncionario(_funcionarioSelecionado);
                                break;

                            case "3":
                            bebedorCafe:
                                Console.WriteLine("");
                                Console.Write("É bebedor de café? (S/N): ");
                                string BebeCafeAtualizado = Console.ReadLine();
                                if (BebeCafeAtualizado.ToUpper() == "S")
                                {
                                    _funcionarioSelecionado.EBebedorDeCafe();
                                    provedorFuncionario.AtualizaFuncionario(_funcionarioSelecionado);
                                }
                                else if (BebeCafeAtualizado.ToUpper() == "N")
                                {
                                    _funcionarioSelecionado.NaoEBebedorDeCafe();
                                    provedorFuncionario.AtualizaFuncionario(_funcionarioSelecionado);
                                }
                                else
                                {
                                    Console.WriteLine("** Opção inválida, tente novamente! **");
                                    goto bebedorCafe;
                                }
                                break;

                            default:
                                break;
                        }

                        Console.WriteLine("\n");
                        Console.WriteLine("--- Dados atualizados ---");
                        Console.WriteLine("Id: " + _funcionarioSelecionado.Id);
                        Console.WriteLine("Nome completo: " + _funcionarioSelecionado.NomeCompleto);
                        Console.WriteLine("Cargo: " + _funcionarioSelecionado.CargoId);
                        Console.WriteLine("Bebe café: " + _funcionarioSelecionado.EBebedorCafe);
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("\n");

                    desejaAlterarFunc:
                        Console.Write("Deseja alterar mais alguma informação? (S/N): ");
                        string alterarMais = Console.ReadLine();
                        if (alterarMais.ToUpper() == "S")
                        {   
                            goto AlteracoesFunc;
                        }
                        else if (alterarMais.ToUpper() == "N")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Menu;
                        }
                        else
                        {
                            Console.WriteLine("** Opção inválida, tente novamente! **");
                            goto desejaAlterarFunc;
                        }

                    case "4":
                        Console.WriteLine("");
                        Console.WriteLine("!! OBS: se o funcionario não constar na lista abaixo, reinicie o programa para atualizá-la !!");
                        Console.WriteLine("");
                        Console.WriteLine("---- Funcionarios cadastrados ----");
                        ApresentaFuncionarios(funcionarios);
                        Console.WriteLine("\n");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;

                    case "5":
                        Console.Clear();
                        goto Menu;

                    default:
                        Console.WriteLine("** Opção inválida, tente novamente! **");
                        Console.WriteLine("\n");
                        goto MenuFuncionario;
                }
            }

            else if (opcaoEscolhidaMenu == "2")
            {
                MenuCargos:
                Console.WriteLine("------ Gerenciamento de Cargos ------");
                Console.WriteLine("------ Escolha uma das opções -------");
                Console.WriteLine("1- CRIAR");
                Console.WriteLine("2- EXCLUIR");
                Console.WriteLine("3- ATUALIZAR");
                Console.WriteLine("4- LISTAR");
                Console.WriteLine("5- VOLTAR");
                Console.Write("-> ");
                string opcaoEscolhidaCargos = Console.ReadLine();

                switch (opcaoEscolhidaCargos)
                {
                    case "1":
                        Console.WriteLine("");
                        Console.Write("Digite o nome do cargo que deseja criar: ");
                        string nomeCargoAdicionado = Console.ReadLine();

                        var cargoCriado = provedorCargo.SalvaCargo(nomeCargoAdicionado);

                        Console.WriteLine("\n");
                        Console.WriteLine("--- Dados do cargo criado ---");
                        Console.WriteLine("Id: " + cargoCriado.Id);
                        Console.WriteLine("Cargo: " + cargoCriado.CargoNome);
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("\n");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;

                    case "2":
                        Console.WriteLine("");
                        Console.Write("Digite o ID do cargo: ");
                        string idExclui = Console.ReadLine();
                        int IdExclui = int.Parse(idExclui);

                    confirmaExclusao:
                        Console.WriteLine("");
                        var cargoExcluir = provedorCargo.RecuperaCargoPorId(IdExclui);
                        Console.Write("Confirma exclusão do cargo? -> " + cargoExcluir.CargoNome + " (S/N): ");
                        string confirmaExclusao = Console.ReadLine();
                        if (confirmaExclusao.ToUpper() == "S")
                        {
                            provedorCargo.ExcluiCargo(cargoExcluir);
                            Console.WriteLine("");
                            Console.WriteLine("Cargo excluído com sucesso!");
                            Console.WriteLine("\n");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Menu;
                        }
                        else if (confirmaExclusao.ToUpper() == "N")
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                            Console.ReadKey();
                            Console.Clear();
                            goto Menu;
                        }
                        else
                        {
                            Console.WriteLine("** Opção inválida, tente novamente! **");
                            goto confirmaExclusao;
                        }

                    case "3":
                        Console.WriteLine("");
                        Console.Write("Digite o ID do cargo: ");
                        string idSelecionado = Console.ReadLine();
                        int IdSelecionado = int.Parse(idSelecionado);
                        var _cargoSelecionado = provedorCargo.RecuperaCargoPorId(IdSelecionado);
                        Console.WriteLine("Cargo validado: " + _cargoSelecionado.CargoNome);

                        Console.WriteLine("");
                        Console.Write("Digite o nome do cargo atualizado: ");
                        string nomeAtualizado = Console.ReadLine();
                        _cargoSelecionado.CargoNome = nomeAtualizado;
                        provedorCargo.AtualizaCargo(_cargoSelecionado);
                        Console.WriteLine("\n");
                        Console.WriteLine("--- Dados atualizados ---");
                        Console.WriteLine("Id: " + _cargoSelecionado.Id);
                        Console.WriteLine("Nome: " + _cargoSelecionado.CargoNome);
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("\n");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;

                    case "4":
                        Console.WriteLine("");
                        Console.WriteLine("!! OBS: se o cargo não constar na lista abaixo, reinicie o programa para atualizá-la !!");
                        Console.WriteLine("");
                        Console.WriteLine("---- Cargos cadastrados ----");
                        ApresentaCargos(cargos);
                        Console.WriteLine("\n");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;

                    case "5":
                        Console.Clear();
                        goto Menu;

                    default:
                        Console.WriteLine("** Opção inválida, tente novamente! **");
                        Console.WriteLine("\n");
                        goto MenuCargos;
                }

            }

            else if (opcaoEscolhidaMenu == "3")
            {
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("** Opção inválida, tente novamente! **");
                Console.WriteLine("\n");
                goto Menu;
            }
        }

        private static void ApresentaFuncionarios(IEnumerable<Comuns.Modelos.Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine("");
                Console.WriteLine("Id: " + funcionario.Id);
                Console.WriteLine("Nome: " + funcionario.NomeCompleto);
                Console.WriteLine("");
            }
        }

        private static void ApresentaCargos(IEnumerable<Comuns.Modelos.Cargo> cargos)
        {
            foreach (var cargo in cargos)
            {
                Console.WriteLine("");
                Console.WriteLine("Id: " + cargo.Id);
                Console.WriteLine("Cargo: " + cargo.CargoNome);
                Console.WriteLine("");
            }
        }

        private static void ApresentaCargosMenu(IEnumerable<Comuns.Modelos.Cargo> cargos)
        {
            foreach (var cargo in cargos)
            {
                Console.WriteLine("Id: " + cargo.Id + " - Cargo: " + cargo.CargoNome);
            }
        }
    }
}


