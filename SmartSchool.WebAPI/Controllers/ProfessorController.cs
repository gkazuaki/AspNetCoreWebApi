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
        private readonly IRepository _repo;

        public ProfessorController(IRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professorBusca = _repo.GetProfessorById(id);
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            return Ok(professorBusca);
        }

        // [HttpGet("ByName")]
        // public IActionResult GetByName(string nome)
        // {
        //     var professorBusca = _context.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
        //     if (professorBusca == null) return BadRequest("Professor não encontrado!");

        //     return Ok(professorBusca);
        // }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado!");
        }

        //AsNoTracking -> Não trava o recurso
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorBusca = _repo.GetProfessorById(id);
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            _repo.Update(professorBusca);
            if (_repo.SaveChanges())
            {
                return Ok(professorBusca);
            }
            return BadRequest("Professor não atualizado!");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorBusca = _repo.GetProfessorById(id);
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            _repo.Update(professorBusca);
            if (_repo.SaveChanges())
            {
                return Ok(professorBusca);
            }
            return BadRequest("Professor não atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professorBusca = _repo.GetProfessorById(id);
            if (professorBusca == null) return BadRequest("Professor não encontrado!");

            _repo.Delete(professorBusca);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado!");
            }
            return BadRequest("Professor não deletado!");
        }
    }
}