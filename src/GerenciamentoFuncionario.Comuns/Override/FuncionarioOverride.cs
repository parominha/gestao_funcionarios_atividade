using GerenciamentoFuncionario.Comuns.Modelos;
using System;

namespace GerenciamentoFuncionario.Comuns.Override
{
    public class FuncionarioOverride : Funcionario
    {
        public new int Id { get => base.Id; set { base.Id = value; } }
        public new int CargoId { get => base.CargoId; set { base.CargoId = value; } }
        public new bool EBebedorCafe { get => base.EBebedorCafe; set { base.EBebedorCafe = value; } }
        public new string NomeCompleto { get => base.NomeCompleto; set { base.NomeCompleto = value; } }
        public new string PrimeiroNome { get => base.PrimeiroNome; set { base.PrimeiroNome = value; } }
        public new string UltimoNome { get => base.UltimoNome; set { base.UltimoNome = value; } }
        public new DateTimeOffset DataEntrada { get => base.DataEntrada; set { base.DataEntrada = value; } }
    }
}
