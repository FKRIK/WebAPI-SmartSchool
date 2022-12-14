using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchoolWebAPI.Data;
using SmartSchoolWebAPI.models;

namespace SmartSchoolWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase //Herdar a classe ControllerBase
    {
        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
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
            var aluno = _repo.GetAllAlunoById(id, false);
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
        // [HttpGet("byName")]
        // public IActionResult GetByName(string nome, string sobrenome)
        // {
        //     var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
        //     if(aluno == null) return BadRequest("Aluno não encontrado");
        //     return Ok(aluno);
        // }

        //api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
           if (_repo.SaveChanges())
           {
                return Ok(aluno);
           }

            return BadRequest("Aluno não encontrado");
        }

        //api/aluno/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAllAlunoById(id, false);
            if(alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
           if (_repo.SaveChanges())
           {
                return Ok(aluno);
           }

            return BadRequest("Aluno não atualizado");
        }

        //api/aluno/1
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAllAlunoById(id, false);
            if(alu == null) return BadRequest("Aluno não encontrado");

            _repo.Update(aluno);
           if (_repo.SaveChanges())
           {
                return Ok(aluno);
           }

            return BadRequest("Aluno não atualizado");
        }

        //api/aluno/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAllAlunoById(id, false);
            if(aluno == null) return BadRequest("Aluno não encontrado");

            _repo.Delete(aluno);
           if (_repo.SaveChanges())
           {
                return Ok("Aluno deletado");
           }

            return BadRequest("Aluno não deletado");
        }
    }
}