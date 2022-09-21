using System;
using System.Windows.Input;

namespace GerenciamentoFuncionario.ViewModel.Comandos
{
    public class DelegarComando : ICommand
    {
        private readonly Action _executar;

        public Func<bool> _podeExecutar { get; }

        public event EventHandler CanExecuteChanged;

        public DelegarComando(Action executar, Func<bool> podeExecutar = null)
        {
            _executar = executar ?? throw new ArgumentNullException(nameof(executar));
            _podeExecutar = podeExecutar;
        }

        public void RaiseCanExecuteChange()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _podeExecutar == null ? true : _podeExecutar();
        }

        public void Execute(object parameter)
        {
            _executar();
        }
    }
}