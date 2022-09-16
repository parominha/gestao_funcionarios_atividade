using GerenciamentoFuncionario.Comuns.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoFuncionario.AcessoDados
{
    public class Contexto
    {
        public Contexto()
        {
            var desserealizar = new Desserealizador().DessJson();

            Funcionarios = new List<Funcionario> {
            new Funcionario(desserealizar.NomeCompleto, desserealizar.CargoId, desserealizar.EBebedorCafe),
            };

            Cargos = new List<Cargo> {
            new Cargo(1, "Desenvolvedor"),
            new Cargo(2, "Engenheiro"),
            new Cargo(3, "Arquiteto"),
            new Cargo(4, "Gerente de Projetos")
            };
        }
        public List<Cargo> Cargos { get; set; } = new List<Cargo>();

        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}

