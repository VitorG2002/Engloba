using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteEngloba.Data;
using TesteEngloba.Models;
using TesteEngloba.ViewModels;

namespace TesteEngloba.Controllers
{
    public class FuncEnderecoViewModelController : Controller
    {

        private TesteEnglobaContext contexto;

        public FuncEnderecoViewModelController(TesteEnglobaContext context)
        {
            this.contexto = context;
        }


        private List<FuncEnderecoViewModel> listaVM = new List<FuncEnderecoViewModel>();
        public IActionResult Index()
        {

            var listaFunc = (from func in contexto.Funcionario
                             join en in contexto.Endereco on func.FuncionarioId equals en.FuncionarioId
                             select new
                             {
                                 func.FuncionarioId,
                                 func.Nome,
                                 func.CPF,
                                 func.RG,
                                 func.RgEmissor,
                                 func.TituloEleitor,
                                 func.CNH,
                                 func.Gestor,
                                 en.CEP,
                                 en.Logradouro,
                                 en.Nro,
                                 en.Complemento,
                                 en.Bairro,
                                 en.Cidade,
                                 en.Estado,
                                 en.Referencia,
                                 en.Ativo,
                                 en.EnderecoId
                             }).ToList();

            foreach (var item in listaFunc)
            {
                FuncEnderecoViewModel vm = new FuncEnderecoViewModel(); //ViewModel
                vm.Nome = item.Nome;
                vm.CPF = item.CPF;
                vm.RG = item.RG;
                vm.RgEmissor = item.RgEmissor;
                vm.TituloEleitor = item.TituloEleitor;
                vm.CNH = item.CNH;
                vm.Gestor = item.Gestor;
                vm.CEP = item.CEP;
                vm.Logradouro = item.Logradouro;
                vm.Nro = item.Nro;
                vm.Complemento = item.Complemento;
                vm.Bairro = item.Bairro;
                vm.Cidade = item.Cidade;
                vm.Estado = item.Estado;
                vm.Referencia = item.Referencia;
                vm.Ativo = item.Ativo;
                vm.FuncionarioId = item.FuncionarioId;
                vm.EnderecoId = item.EnderecoId;
                this.listaVM.Add(vm);
            }
            //Retorna as informações para View
            return View(this.listaVM);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,CPF,RG,RgEmissor,TituloEleitor,CNH,Gestor,CEP,Logradouro,Nro,Complemento,Bairro,Cidade,Estado,Referencia,Ativo")] FuncEnderecoViewModel vm)
        {
            try
            {

                Funcionario f = new Funcionario
                {
                    Nome = vm.Nome,
                    CPF = vm.CPF,
                    RG = vm.RG,
                    RgEmissor = vm.RgEmissor,
                    TituloEleitor = vm.TituloEleitor,
                    CNH = vm.CNH,
                    Gestor = vm.Gestor
                };

                Endereco e = new Endereco
                {
                    CEP = vm.CEP,
                    Logradouro = vm.Logradouro,
                    Nro = vm.Nro,
                    Complemento = vm.Complemento,
                    Bairro = vm.Bairro,
                    Cidade = vm.Cidade,
                    Estado = vm.Estado,
                    Referencia = vm.Referencia,
                    Ativo = vm.Ativo
                };
                f.Endereco = e;
                e.FuncionarioId = f.FuncionarioId;
                vm.Funcionario = f;
                vm.Endereco = e;
                contexto.Add(f);
                contexto.Add(e);
                await contexto.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(vm);
            //Retorna as informações para View
        }
        public async Task<IActionResult> Edit(long? id)
        {

            var func = await contexto.Funcionario.SingleOrDefaultAsync(f => f.FuncionarioId == id);
            var endereco = contexto.Endereco.SingleOrDefault(e => e.FuncionarioId == func.FuncionarioId);
            FuncEnderecoViewModel fevm = new FuncEnderecoViewModel();

            fevm.Nome = func.Nome;
            fevm.CPF = func.CPF;
            fevm.RG = func.RG;
            fevm.RgEmissor = func.RgEmissor;
            fevm.TituloEleitor = func.TituloEleitor;
            fevm.CNH = func.CNH;
            fevm.Gestor = func.Gestor;
            fevm.CEP = endereco.CEP;
            fevm.Logradouro = endereco.Logradouro;
            fevm.Nro = endereco.Nro;
            fevm.Complemento = endereco.Complemento;
            fevm.Bairro = endereco.Bairro;
            fevm.Cidade = endereco.Cidade;
            fevm.Estado = endereco.Estado;
            fevm.Referencia = endereco.Referencia;
            fevm.Ativo = endereco.Ativo;


            if (fevm == null)
            {
                return NotFound(id);
            }
            return View(fevm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Nome,CPF,RG,RgEmissor,TituloEleitor,CNH,Gestor,CEP,Logradouro,Nro,Complemento,Bairro,Cidade,Estado,Referencia,Ativo,FuncionarioId,EnderecoId")] FuncEnderecoViewModel fevm)
        {

            var funcionario = contexto.Funcionario.SingleOrDefault(f => f.FuncionarioId == id);
            funcionario.Nome = fevm.Nome;
            funcionario.CPF = fevm.CPF;
            funcionario.RG = fevm.RG;
            funcionario.RgEmissor = fevm.RgEmissor;
            funcionario.TituloEleitor = fevm.TituloEleitor;
            funcionario.CNH = fevm.CNH;
            funcionario.Gestor = fevm.Gestor;

            var endereco = contexto.Endereco.SingleOrDefault(e => e.FuncionarioId == funcionario.FuncionarioId);
            endereco.CEP = fevm.CEP;
            endereco.Logradouro = fevm.Logradouro;
            endereco.Nro = fevm.Nro;
            endereco.Complemento = fevm.Complemento;
            endereco.Bairro = fevm.Bairro;
            endereco.Cidade = fevm.Cidade;
            endereco.Estado = fevm.Estado;
            endereco.Referencia = fevm.Referencia;
            endereco.Ativo = fevm.Ativo;

            contexto.Update(funcionario);
            contexto.Update(endereco);
            await contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var func = await contexto.Funcionario.SingleOrDefaultAsync(f => f.FuncionarioId == id);
            var endereco = contexto.Endereco.SingleOrDefault(e => e.FuncionarioId == func.FuncionarioId);

            FuncEnderecoViewModel fevm = new FuncEnderecoViewModel();

            fevm.Nome = func.Nome;
            fevm.CPF = func.CPF;
            fevm.RG = func.RG;
            fevm.RgEmissor = func.RgEmissor;
            fevm.TituloEleitor = func.TituloEleitor;
            fevm.CNH = func.CNH;
            fevm.Gestor = func.Gestor;
            fevm.CEP = endereco.CEP;
            fevm.Logradouro = endereco.Logradouro;
            fevm.Nro = endereco.Nro;
            fevm.Complemento = endereco.Complemento;
            fevm.Bairro = endereco.Bairro;
            fevm.Cidade = endereco.Cidade;
            fevm.Estado = endereco.Estado;
            fevm.Referencia = endereco.Referencia;
            fevm.Ativo = endereco.Ativo;
            if (fevm == null)
            {
                return NotFound();
            }
            return View(fevm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {

            var funcionario = await contexto.Funcionario.SingleOrDefaultAsync(f => f.FuncionarioId == id);
            var endereco = contexto.Endereco.SingleOrDefault(e => e.EnderecoId == funcionario.FuncionarioId);

            try
            {
                contexto.Remove(funcionario);
                contexto.Remove(endereco);
                await contexto.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível excluir os dados.");
            }
            return RedirectToAction("Index");
        }
    }

}
