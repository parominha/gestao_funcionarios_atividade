using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoFuncionario.ViewModel
{
    public class FuncionarioModel
    {
        public string NomeCompleto { get; internal set; }
        public int CargoId { get; internal set; }
        public bool EBebedorCafe { get; internal set; }
    }
}
