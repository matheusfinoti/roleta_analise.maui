using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoletaAnalise.maui.Models;

namespace RoletaAnalise.maui.Context
{
    internal class ManipulaJson
    {
        private string _filePath { get; set; }


        public ManipulaJson()
        {
            _filePath = BuscaCaminho();
        }

        /*
        Futuramente implementar regra para salvar os arquivos separados por pastas referente 
        as datas, separando ano, mês e dia 
        */
        private string BuscaCaminho()
        {
            var caminhoRaizProjeto = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory));
            return Path.Combine(caminhoRaizProjeto, "data", "numeros.json");
        }

        public void AdicionaNumero(List<Numero> listaDeNumero)
        {

            if (VerificaCaminho(BuscaCaminho()))
            {
                List<Numero> x = LerJson();
                x.AddRange(listaDeNumero);
                string json = JsonConvert.SerializeObject(x, Formatting.Indented);
                File.WriteAllText(this._filePath, "{}");
                File.WriteAllText(this._filePath, json);
            }

        }

        public List<Numero> LerJson()
        {
            if (!VerificaCaminho(_filePath))
            {
                return new List<Numero>();
            }

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrEmpty(json))
            {
                return new List<Numero>();
            }

            return JsonConvert.DeserializeObject<List<Numero>>(json) ?? new List<Numero>();
        }


        public bool VerificaCaminho(string caminho)
        {
            if (File.Exists(caminho))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
