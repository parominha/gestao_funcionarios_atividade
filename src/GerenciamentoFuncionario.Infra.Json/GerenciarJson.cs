using GerenciamentoFuncionario.Comuns.Interfaces.Infra.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GerenciamentoFuncionario.Infra.Json
{
    public class GerenciarJson<T> : IManagmentJson<T> where T : class
    {
        private readonly string _jsonFile;

        public GerenciarJson(string basePath, string fileName)
        {
            _jsonFile = @$"{basePath}{fileName}.json";
            CriarArquivoBase(basePath);
        }

        public List<T> LerBaseJson() => JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(_jsonFile));

        public void EscreverBaseJson(List<T> list)
        {
            string output = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(_jsonFile, output);
        }


        private void CriarArquivoJson()
        {
            if (!File.Exists(_jsonFile)) File.CreateText(_jsonFile);
        }

        private void RemoverArquivoJson() => File.Delete(_jsonFile);

        private void CriarArquivoBase(string basePath)
        {
            CriarDiretorio(basePath);
            CriarArquivoJson();
        }

        private void CriarDiretorio(string basePath)
        {
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
        }
    }
}