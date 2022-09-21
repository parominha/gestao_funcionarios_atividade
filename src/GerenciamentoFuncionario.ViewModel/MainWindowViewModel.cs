using GerenciamentoFuncionario.Comuns.Modelos;
using GerenciamentoFuncionario.Comuns.ProvedorDados;
using GerenciamentoFuncionario.ViewModel.Comandos;
using System.Collections.ObjectModel;

namespace GerenciamentoFuncionario.ViewModel
{

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFuncionarioProvedorDados _funcionarioProvedorDados;
        private readonly ICargoProvedorDados _cargoProvedorDados;


        private FuncionarioViewModel _funcionarioSelecionadoViewModel;

        public MainWindowViewModel(IFuncionarioProvedorDados funcionarioProvedorDados,
            ICargoProvedorDados cargoProvedorDados)
        {
            _funcionarioProvedorDados = funcionarioProvedorDados;
            _cargoProvedorDados = cargoProvedorDados;

            ComandoCarregar = new DelegarComando(Carregar);
        }
        public DelegarComando ComandoCarregar { get; }

        public ObservableCollection<FuncionarioViewModel> Funcionarios { get; } = new ObservableCollection<FuncionarioViewModel>();
        public ObservableCollection<Cargo> Cargos { get; } = new ObservableCollection<Cargo>();

        public FuncionarioViewModel FuncionarioSelecionado
        {
            get => _funcionarioSelecionadoViewModel;
            set
            {
                if (_funcionarioSelecionadoViewModel != value)
                {
                    _funcionarioSelecionadoViewModel = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FuncionarioEstaSelecionado));
                }
            }
        }

        public bool FuncionarioEstaSelecionado => FuncionarioSelecionado != null;

        public void Carregar()
        {
            CarregaFuncionarios();
            CarregaCargos();
        }

        private void CarregaFuncionarios()
        {
            var funcionarios = _funcionarioProvedorDados.CarregaFuncionarios();
            Funcionarios.Clear();

            foreach (var funcionario in funcionarios)
            {
                Funcionarios.Add(
                    new FuncionarioViewModel(
                        new FuncionarioModel
                        {
                            NomeCompleto = funcionario.NomeCompleto,
                            CargoId = funcionario.CargoId,
                            EBebedorCafe = funcionario.EBebedorCafe,
                            DataEntrada = funcionario.DataEntrada,
                        }, _funcionarioProvedorDados)
                );
            }
        }

        private void CarregaCargos()
        {
            var cargos = _cargoProvedorDados.CarregaCargos();
            Cargos.Clear();

            foreach (var cargo in cargos)
            {
                Cargos.Add(cargo);
            }
        }
    }
}