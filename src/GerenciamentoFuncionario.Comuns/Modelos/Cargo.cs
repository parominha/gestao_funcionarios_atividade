using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoFuncionario.Comuns.Modelos
{
    public class Cargo : EntidadeBase
    {
        public Cargo(int id, string cargoNome)
        {
            Id = id;
            CargoNome = cargoNome;
        }
                
        public string CargoNome { get; protected set; }
    }
}
