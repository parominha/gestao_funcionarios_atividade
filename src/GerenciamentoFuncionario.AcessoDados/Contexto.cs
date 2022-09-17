using GerenciamentoFuncionario.Comuns.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoFuncionario.AcessoDados
{
    public class Contexto
    {
        private readonly IFuncionarioJson _funcionarioJson;
        private readonly ICargoJson _cargoJson;
        private List<Cargo> _cargos = new List<Cargo>();
        private List<Funcionario> _funcionarios = new List<Funcionario>();

        public Contexto()
        {
            _funcionarioJson = new FuncionarioJson();
            _cargoJson = new CargoJson();
        }

        public List<Funcionario> Funcionarios
        {
            get
            {
                if (_funcionarioJson.RecebeFuncionarios() != null)
                    _funcionarios = _funcionarioJson.RecebeFuncionarios();

                return _funcionarios;
            }
            set
            {
                _funcionarioJson.AtribuiFuncionarios(value);
                _funcionarios = value;
            }
        }

        public List<Cargo> Cargos
        {
            get
            {
                if (_cargoJson.RecebeCargos() != null)
                    _cargos = _cargoJson.RecebeCargos();
                return _cargos;
            }
            set
            {
                _cargoJson.AtribuiCargos(value);
                _cargos = value;
            }
        }

        //    var desserealizar = new Desserealizador().DessJson();

        //    Funcionarios = new List<Funcionario> {
        //    new Funcionario(desserealizar.NomeCompleto, desserealizar.CargoId, desserealizar.EBebedorCafe),
        //    };

        //    Cargos = new List<Cargo> {
        //    new Cargo(1, "Desenvolvedor"),
        //    new Cargo(2, "Engenheiro"),
        //    new Cargo(3, "Arquiteto"),
        //    new Cargo(4, "Gerente de Projetos")
        //    };
        //}
        //public List<Cargo> Cargos { get; set; } = new List<Cargo>();

        //public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}

