using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioController
{

    


    [Route("api/folha")]
    public class FolhaController : ControllerBase
    {

        

        private readonly AppDataContext _ctx;

        public FolhaController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var folhas = _ctx.Folhas.Include(f => f.funcionario).ToList();
            return Ok(folhas);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Folha folha)
        {
        try
        {
            Funcionario? funcionario = _ctx.Funcionarios.FirstOrDefault(f => f.funcionarioId == folha.funcionarioId);

            if(funcionario == null)
            {
                return NotFound("Funcionário não encontrado.");
            }

            folha.funcionario = funcionario;

            // Calculando os impostos e o salário líquido
            folha.salarioBruto = folha.valor * folha.quantidade;
            folha.impostoIrrf = CalcularIR(folha.salarioBruto);
            folha.impostoInss = CalcularINSS(folha.salarioBruto);
            folha.salarioFgts = CalcularFGTS(folha.salarioBruto);
            folha.salarioLiquido = CalcularSalarioLiquido(folha.salarioBruto, folha.impostoIrrf, folha.impostoInss);

            _ctx.Add(folha);
            _ctx.SaveChanges();
            return Created("", folha);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
}

        [HttpGet]
        [Route("buscar/{cpf}/{mes}/{ano}")]
        public IActionResult Buscar(string cpf, int mes, int ano)
        {
            var funcionario = _ctx.Funcionarios.FirstOrDefault(f => f.cpf == cpf);
            if (funcionario == null) return NotFound("Funcionário não encontrado.");

            var folha = _ctx.Folhas.FirstOrDefault(f => f.funcionarioId == funcionario.funcionarioId && f.mes == mes && f.ano == ano);
            if (folha == null) return NotFound("Folha de pagamento não encontrada.");

            return Ok(folha);
        }

        private float CalcularIR(float salarioBruto)
        {
            if (salarioBruto <= 1903.98) return 0;
            if (salarioBruto <= 2826.65) return  142.80f;
            if (salarioBruto <= 3751.05) return 354.80f;
            if (salarioBruto <= 4664.68) return 636.13f;
            return (salarioBruto * 0.275f) - 869.36f;
        }

        private float CalcularINSS(float salarioBruto)
        {
            if (salarioBruto <= 1693.72) return salarioBruto * 0.08f;
            if (salarioBruto <= 2822.90) return salarioBruto * 0.09f;
            if (salarioBruto <= 5645.80) return salarioBruto * 0.11f;
            return 621.03f; // Fixo
        }

        private float CalcularFGTS(float salarioBruto)
        {
            return salarioBruto * 0.08f;
        }

        private float CalcularSalarioLiquido(float salarioBruto, float ir, float inss)
        {
            return salarioBruto - ir - inss;
        }
                
    }
}