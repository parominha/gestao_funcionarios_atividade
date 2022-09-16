using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GerenciamentoFuncionario.AcessoDados
{
    public class Desserealizador
    {
        public string NomeCompleto { get; set; }
        public int CargoId { get; set; }
        public bool EBebedorCafe { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public DateTimeOffset DataEntrada { get; set; }
        public int Id { get; set; }


        public Desserealizador DessJson()
        {
            string filePath = @"C:\temp\funcionarios.json";
            string jsonString = File.ReadAllText(filePath);
            Desserealizador desserealizador = JsonSerializer.Deserialize<Desserealizador>(jsonString);
            return desserealizador;
        }
    }
}
