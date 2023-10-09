using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;
using api.Data;

namespace FuncionarioController
{
    [Route("api/funcionario")]
    public class FuncionarioController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public FuncionarioController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Funcionario> funcionarios = _ctx.Funcionarios.ToList();
                return Ok(funcionarios);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            try
            {  
                _ctx.Add(funcionario);
                _ctx.SaveChanges();
                return Created("", funcionario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
    }
}