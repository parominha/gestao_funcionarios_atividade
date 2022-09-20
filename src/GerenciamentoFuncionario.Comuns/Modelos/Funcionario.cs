using System;
using System.Linq;

namespace GerenciamentoFuncionario.Comuns.Modelos
{
    public class Funcionario : EntidadeBase
    {
        public Funcionario()
        {

        }

        public Funcionario(int id, string nomeCompleto, int cargoId,
            bool eBebedorCafe = false)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            CargoId = cargoId;
            EBebedorCafe = eBebedorCafe;
            DataEntrada = DateTime.Now;
        }

        private string _nomeCompleto;

        public string NomeCompleto
        {
            get { return _nomeCompleto; }
            set
            {
                string[] pedacosNome = value.Trim().Split(" ");
                PrimeiroNome = pedacosNome[0];
                UltimoNome = pedacosNome.Last();
                _nomeCompleto = value;
            }
        }

        public int CargoId { get; protected set; }
        public bool EBebedorCafe { get; protected set; }
        public string PrimeiroNome { get; protected set; }
        public string UltimoNome { get; protected set; }
        public DateTimeOffset DataEntrada { get; protected set; }

        public void NaoEBebedorDeCafe()
        {
            EBebedorCafe = false;
        }

        public void EBebedorDeCafe()
        {
            EBebedorCafe = true;
        }

        public void SetCargoId(int cargoId)
        {
            if (cargoId <= 0)
                throw new Exception("Cargo Inválido");

            CargoId = cargoId;
        }
    }
}

