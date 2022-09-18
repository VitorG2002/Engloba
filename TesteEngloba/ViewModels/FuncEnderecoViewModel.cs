using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TesteEngloba.Models;

namespace TesteEngloba.ViewModels
{
    public class FuncEnderecoViewModel
    {
        public long? FuncEnderecoViewModelId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string RgEmissor { get; set; }
        public string TituloEleitor { get; set; }
        public string CNH { get; set; }
        public bool Gestor { get; set; }
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

        [ForeignKey("EnderecoId")]
        public long? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }


    }
}
