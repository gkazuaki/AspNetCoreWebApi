using System.Threading.Tasks;
using SmartSchool.WebAPI.Helper;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();

        public Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeDisciplina = false);

         public Aluno[] GetAllAlunos(bool includeDisciplina = false);

        public Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeDisciplina = false);

        public Aluno GetAlunoById(int alunoId, bool includeDisciplina = false);

        public Professor[] GetAllProfessores(bool includeAluno = false);

        public Professor[] GetProfessoresByDisciplinaId(int idDisciplina, bool includeAluno);

        public Professor GetProfessorById(int idProfessor, bool includeAluno = false);
    }
}