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
        static async Task Main()
        {
            var provedorFuncionario = new FuncionarioProvedorDados();

            var funcionarios = provedorFuncionario.CarregaFuncionarios();

        Menu:
            Console.WriteLine("--- Gerenciamento de Funcionários ---");
            Console.WriteLine("------ Escolha uma das opções -------");
            Console.WriteLine("1- CRIAR");
            Console.WriteLine("2- EXCLUIR");
            Console.WriteLine("3- ATUALIZAR");
            Console.WriteLine("4- LISTAR");
            Console.WriteLine("5- SAIR");
            Console.Write("-> ");
            string opcaoEscolhida = Console.ReadLine();

            switch (opcaoEscolhida)
            {
                case "1":
                    Console.WriteLine("\r\n");
                    Console.Write("Digite o nome completo do funcionário: ");
                    string nomeCompleto = Console.ReadLine();

                Cargos:
                    Console.WriteLine("");
                    Console.WriteLine("Digite o ID do cargo");
                    Console.WriteLine("1- Desenvolvedor");
                    Console.WriteLine("2- Engenheiro");
                    Console.WriteLine("3- Arquiteto");
                    Console.WriteLine("4- Gerente de Projetos");
                    Console.Write("-> ");
                    string idCargo = Console.ReadLine();
                    int IdCargo = int.Parse(idCargo);
                    if (IdCargo == 1)
                    {
                        Console.WriteLine("Cargo validado: " + IdCargo + "- Desenvolvedor");
                    }
                    else if (IdCargo == 2)
                    {
                        Console.WriteLine("Cargo validado: " + IdCargo + "- Engenheiro");
                    }
                    else if (IdCargo == 3)
                    {
                        Console.WriteLine("Cargo validado: " + IdCargo + "- Arquiteto");
                    }
                    else if (IdCargo == 4)
                    {
                        Console.WriteLine("Cargo validado: " + IdCargo + "- Gerente de Projetos");
                    }
                    else
                    {
                        Console.WriteLine("** Opção inválida, tente novamente! **");
                        goto Cargos;
                    }
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



                    var funcionarioAdicionado = provedorFuncionario.SalvaFuncionario(new Funcionario(nomeCompleto, IdCargo, BebeCafe));


                    Console.WriteLine("\n");
                    Console.WriteLine("--- Dados do funcionário ---");

                    Console.WriteLine("Id: " + funcionarioAdicionado.Id);

                    Console.WriteLine("Nome completo: " + funcionarioAdicionado.NomeCompleto);

                    if (IdCargo == 1)
                    {
                        Console.WriteLine("Cargo: " + IdCargo + "- Desenvolvedor");
                    }
                    else if (IdCargo == 2)
                    {
                        Console.WriteLine("Cargo: " + IdCargo + "- Engenheiro");
                    }
                    else if (IdCargo == 3)
                    {
                        Console.WriteLine("Cargo: " + IdCargo + "- Arquiteto");
                    }
                    else if (IdCargo == 4)
                    {
                        Console.WriteLine("Cargo: " + IdCargo + "- Gerente de Projetos");
                    }

                    if (BebeCafe == false)
                    {
                        Console.WriteLine("Bebe café?: Não");
                    }
                    else if (BebeCafe == true)
                    {
                        Console.WriteLine("Bebe café?: Sim");
                    }
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("\n");

                    Console.Write("Deseja salvar o funcionário? (S/N): ");
                    string desejaSalvar = Console.ReadLine();

                    if (desejaSalvar.ToUpper() == "S")
                    {
                        string filePath = @"C:\temp\funcionarios.json";
                        var ObjetoDados = JsonConvert.SerializeObject(funcionarioAdicionado);
                        await File.WriteAllTextAsync(filePath, ObjetoDados);
                        Console.WriteLine("Dados Salvos com Sucesso !!!");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;
                    }
                    else if (desejaSalvar.ToUpper() == "N")
                    {
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;
                    }
                    else
                    {
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;
                    }
                    break;

                case "2":
                    Console.WriteLine("");
                    Console.Write("Digite o Id do funcionário: ");
                    string idExclui = Console.ReadLine();
                    int IdExclui = int.Parse(idExclui);
                    confirmaExclusao:
                    Console.WriteLine("");
                    Console.Write("Confirma exclusão do funcionário? (S/N): ");
                    string confirmaExclusao = Console.ReadLine();
                    if (confirmaExclusao.ToUpper() == "S")
                    {
                        provedorFuncionario.ExcluiFuncionarioPorId(IdExclui);
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
                    break;

                case "3":
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
                            Console.WriteLine("Digite o ID do cargo");
                            Console.WriteLine("1- Desenvolvedor");
                            Console.WriteLine("2- Engenheiro");
                            Console.WriteLine("3- Arquiteto");
                            Console.WriteLine("4- Gerente de Projetos");
                            Console.Write("-> ");
                            string cargoAtualizado = Console.ReadLine();
                            int CargoAtualizado = int.Parse(cargoAtualizado);
                            _funcionarioSelecionado.SetCargoId(CargoAtualizado);
                            break;

                        case "CAFE":
                            bebedorCafe:
                            Console.Write("É bebedor de café? (S/N): ");
                            string BebeCafeAtualizado = Console.ReadLine();
                            if (BebeCafeAtualizado.ToUpper() == "S")
                            {
                                _funcionarioSelecionado.EBebedorDeCafe();
                            }
                            else if (BebeCafeAtualizado.ToUpper() == "N")
                            { _funcionarioSelecionado.NaoEBebedorDeCafe(); }
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
                    Console.WriteLine("Nome completo: " + _funcionarioSelecionado.NomeCompleto);
                    Console.WriteLine("Cargo: " + _funcionarioSelecionado.CargoId);
                    Console.WriteLine("Bebe café: " + _funcionarioSelecionado.EBebedorCafe);
                    Console.WriteLine("--- ----------------- ---");
                    Console.WriteLine("\n");
                    desejaAlterar:
                    Console.Write("Deseja alterar mais alguma informação? (S/N): ");
                    string alterarMais = Console.ReadLine();
                    if (alterarMais.ToUpper() == "S")
                    {
                        goto Alteracoes;
                    }
                    else if (alterarMais.ToUpper() == "N")
                    {
                        goto Menu;
                    }
                    else
                    {
                        Console.WriteLine("** Opção inválida, tente novamente! **");
                        goto desejaAlterar;
                    }
                    break;

                case "4":
                    ApresentaFuncionarios(funcionarios);
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("** Opção inválida, tente novamente! **");
                    Console.WriteLine("\n");
                    goto Menu;
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
                Console.WriteLine("");
                Console.WriteLine($"{funcionario.Id} {funcionario.NomeCompleto}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}


