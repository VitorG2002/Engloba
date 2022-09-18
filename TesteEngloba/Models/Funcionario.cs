using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TesteEngloba.Models;


namespace TesteEngloba.Models
{
    public class Funcionario
    {
        public long? FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string RgEmissor { get; set; }
        public string TituloEleitor { get; set; }
        public string CNH { get; set; }
        public bool Gestor { get; set; }
        public Endereco Endereco { get; set; }


    }
}
