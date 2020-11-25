using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartSchoolContext _context;
        public Repository(SmartSchoolContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeDisciplina)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeDisciplina)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.AlunosDisciplinas.Any(d => d.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool includeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeDisciplina)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(ad => ad.AlunosDisciplinas)
                    .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor[] GetProfessoresByDisciplinaId(int idDisciplina, bool includeAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(ad => ad.AlunosDisciplinas)
                    .ThenInclude(a => a.Aluno);
            }

            //query = query.AsNoTracking().OrderBy(p => p.Id).Where(d => d.Id == idDisciplina);

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(a => a.Disciplinas.Any(
                d => d.AlunosDisciplinas.Any(
                    ad => ad.DisciplinaId == idDisciplina
                )
            ));

            return query.ToArray();
        }

        public Professor GetProfessorById(int idProfessor, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(ad => ad.AlunosDisciplinas)
                    .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Id == idProfessor);

            return query.FirstOrDefault();
        }
    }
}