using GerenciamentoFuncionario.Comuns.Modelos;
using GerenciamentoFuncionario.Comuns.ProvedorDados;
using GerenciamentoFuncionario.ViewModel.Comandos;
using System;

namespace GerenciamentoFuncionario.ViewModel
{
    public class FuncionarioViewModel : ViewModelBase
    {
        private readonly IFuncionarioProvedorDados _funcionarioProvedorDados;
        private readonly FuncionarioModel _funcionarioModel;


        public FuncionarioViewModel(FuncionarioModel funcionarioModel, IFuncionarioProvedorDados funcionarioProvedorDados)
        {
            _funcionarioProvedorDados = funcionarioProvedorDados;
            _funcionarioModel = funcionarioModel;

            ComandoSalvar = new DelegarComando(Salvar, () => PodeSalvar);
        }
        public DelegarComando ComandoSalvar { get; }

        public string NomeCompleto
        {
            get => _funcionarioModel.NomeCompleto;
            set
            {
                if (_funcionarioModel.NomeCompleto != value)
                {
                    _funcionarioModel.NomeCompleto = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(PodeSalvar));
                    ComandoSalvar.RaiseCanExecuteChange();
                }
            }
        }

        public int CargoId
        {
            get => _funcionarioModel.CargoId;
            set
            {
                if (_funcionarioModel.CargoId != value)
                {
                    _funcionarioModel.CargoId = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool EBebedorCafe
        {
            get => _funcionarioModel.EBebedorCafe;
            set
            {
                if (_funcionarioModel.EBebedorCafe != value)
                {
                    _funcionarioModel.EBebedorCafe = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTimeOffset DataEntrada
        {
            get => _funcionarioModel.DataEntrada;
            set
            {
                if (_funcionarioModel.DataEntrada != value)
                {
                    _funcionarioModel.DataEntrada = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime DataHoraEntrada
        {
            get => _funcionarioModel.DataEntrada.DateTime;
            set
            {
                if (_funcionarioModel.DataEntrada.DateTime != value)
                {
                    _funcionarioModel.DataEntrada = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool PodeSalvar => !string.IsNullOrWhiteSpace(NomeCompleto);

        public void Salvar()
        {
            //_funcionarioProvedorDados.SalvaFuncionario(
            //    new Funcionario(
            //        _funcionarioModel.NomeCompleto,
            //        _funcionarioModel.CargoId,
            //        _funcionarioModel.EBebedorCafe)
            //);
        }
    }
}