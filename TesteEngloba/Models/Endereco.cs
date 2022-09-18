using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TesteEngloba.Models
{
    public class Endereco
    {
        public long? EnderecoId { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Nro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Referencia { get; set; }
        public bool Ativo { get; set; }
        [ForeignKey("FuncionarioId")]
        public long? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
