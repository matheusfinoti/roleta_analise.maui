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

        private string BuscaCaminho()
        {
            var caminhoRaizProjeto = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\"));
            return Path.Combine(caminhoRaizProjeto, "data", "numeros.json");
        }

        public void AdicionaNumero(string json)
        {
            File.WriteAllText(this._filePath, json);
        }

    }
}
