using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();

         public Aluno[] GetAllAlunos(bool includeDisciplina = false);

        public Aluno[] GetAlunosByDisciplinaId(int disciplinaId, bool includeDisciplina = false);

        public Aluno GetAlunoById(int alunoId, bool includeDisciplina = false);

        public Professor[] GetAllProfessores(bool includeAluno = false);

        public Professor[] GetProfessoresByDisciplinaId(int idDisciplina, bool includeAluno);

        public Professor GetProfessorById(int idProfessor, bool includeAluno = false);
    }
}