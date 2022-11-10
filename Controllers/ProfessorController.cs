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
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        //Rota: api/professor/byId?id=1
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetAllProfessorById(id, false);
            if(professor == null) return BadRequest("Professor não encontrado");

            return Ok(professor);
        }

        //Rota: api/professor/byName?nome=Fernando
        // [HttpGet("byName")]
        // public IActionResult GetByName(string nome)
        // {
        //     var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
        //     if(professor == null) return BadRequest("Professor não encontrado");

        //     return Ok(professor);
        // }

        //Rota: api/professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
           if (_repo.SaveChanges())
           {
                return Ok(professor);
           }

            return BadRequest("Professor não encontrado");
        }

        //api/professor/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var profe = _repo.GetAllProfessorById(id, false);
            if(profe == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não atualizado!");
        }

        //api/professor/1
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var profe =_repo.GetAllProfessorById(id);
            if(profe == null) return BadRequest("Professor não encontrado");

            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não atualizado!");
        }

        //api/professor/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetAllProfessorById(id, false);
            if(professor == null) return BadRequest("Professor não encontrado");

            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("professor deletado"); 
            }
            return BadRequest("Professor não encontrado!");
        }
    }
}