using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GerenciamentoFuncionario.ViewModel.Comandos
{
    public class DelegarComando : ICommand
    {
        private readonly Action _executar;

        public Func<bool> _podeExecutar { get; }

        public DelegarComando(Action executar, Func<bool> podeExecutar = null)
        {
            _executar = executar ?? throw new ArgumentNullException(nameof(executar));
            _podeExecutar = podeExecutar;
        }

        public void RaiseCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

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
