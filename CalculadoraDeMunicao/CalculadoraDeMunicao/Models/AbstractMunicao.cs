using Newtonsoft.Json;
using System;

namespace CalculadoraDeMunicao.Models
{
    [JsonObject]
    public class AbstractMunicao
    {
        public int QuantidadeTotal { get; set; }

        public double ValorTotal { get; set; }

        public double ValorUnitário { get { return Math.Round(ValorTotal / QuantidadeTotal, 2); } }
    }
}