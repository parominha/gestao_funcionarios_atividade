using GerenciamentoFuncionario.Comuns.Interfaces.Infra.Json;
using GerenciamentoFuncionario.Comuns.Modelos;
using GerenciamentoFuncionario.Infra.Json.Entidades;
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
    }
}

