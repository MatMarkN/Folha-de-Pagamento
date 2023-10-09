using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.Models
{
    public class Folha
    {
        public int folhaId { get; set; }
        public float valor { get; set; }
        public int quantidade { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }

        
        public float salarioBruto { get; set; }

        
        public float impostoIrrf { get; set; }

        
        public float impostoInss { get; set; }

        
        public float salarioFgts { get; set; }

        
        public float salarioLiquido { get; set; }

        public int funcionarioId { get; set; }
        public Funcionario funcionario { get; set; }
    }
}