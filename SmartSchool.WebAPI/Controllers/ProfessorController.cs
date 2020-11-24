using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartSchoolContext _context;

        public ProfessorController(SmartSchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var professorBusca = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            return Ok(professorBusca);
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var professorBusca = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            return Ok(professorBusca);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        git
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorBusca = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorBusca = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professorBusca = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            _context.Remove(professorBusca);
            _context.SaveChanges();
            return Ok();
        }
    }
}