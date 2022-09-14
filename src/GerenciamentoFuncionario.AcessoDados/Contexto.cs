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
            //Funcionarios = new List<Funcionario> {
            //new Funcionario(1, "Fulano de Tal", 1, false),
            //new Funcionario(2, "Ciclano de Tal", 2, true),
            //new Funcionario(3, "Beltrano de Tal", 3, true)
            //};

            Cargos = new List<Cargo> {
            new Cargo(1, "Desenvolvedor"),
            new Cargo(2, "Engenheiro"),
            new Cargo(3, "Arquiteto"),
            new Cargo(4, "Gerente de Projetos")
            };
        }
            public List<Cargo> Cargos { get; set; }

            public List<Funcionario> Funcionarios { get; set; }
    }
}

