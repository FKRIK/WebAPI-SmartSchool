using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchoolWebAPI.models;

namespace SmartSchoolWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase //Herdar a classe ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Fernando",
                Sobrenome = "Krik",
                Telefone = "996303088"
            },
            new Aluno()
            {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kent",
                Telefone = "996303088"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "John",
                Sobrenome = "Doe",
                Telefone = "996303088"
            }
        };
        public AlunoController() { }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        //---- Primeira forma de fazer requisição por id ---- Rota: api/aluno/{id}
        // [HttpGet("{id:int}")]
        // public IActionResult GetById(int id)
        // {
        //     var aluno = Alunos.FirstOrDefault(a => a.Id == id);
        //     if(aluno == null) return BadRequest("Aluno não encontrado");
        //     return Ok(aluno);
        // }

        //---- Segunda forma de fazer requisição por id ---- Rota: api/aluno/byId?id=1
         [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        //---- Primeira forma de fazer requisição por nome ---- Rota: api/aluno/{nome}
        // [HttpGet("{nome}")]
        // public IActionResult GetByName(string nome)
        // {
        //     var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));
        //     if(aluno == null) return BadRequest("Aluno não encontrado");
        //     return Ok(aluno);
        // }

        //---- Segunda forma de fazer requisição por nome ---- Rota: api/aluno/byName?nome=Fernando&sobrenome=Krik
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        //api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        //api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}