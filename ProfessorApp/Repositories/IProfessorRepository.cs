using ProfessorApp.Models;

namespace ProfessorApp.Repositories
{
    public interface IProfessorRepository
    {
        // List all professors
        IEnumerable<Professor> GetAllProfessor();

        // Get all departments
        public List<Department> GetAllDepartments();

        // Insert a new professor
        public void AddProfessor(Professor professor);

    }
}
