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
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        //Rota: api/professor/byId?id=1
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest("Professor não encontrado");

            return Ok(professor);
        }

        //Rota: api/professor/byName?nome=Fernando
        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if(professor == null) return BadRequest("Professor não encontrado");

            return Ok(professor);
        }

        //Rota: api;professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //api/professor/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var profe = _context.Alunos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(profe == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //api/professor/1
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var profe = _context.Alunos.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(profe == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        //api/professor/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Alunos.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest("Professor não encontrado");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}