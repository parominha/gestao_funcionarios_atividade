using System;

namespace GerenciamentoFuncionario.ViewModel
{
    public class FuncionarioModel
    {
        public string NomeCompleto { get; internal set; }
        public int CargoId { get; internal set; }
        public bool EBebedorCafe { get; internal set; }
        public DateTimeOffset DataEntrada { get; internal set; }

    }
}