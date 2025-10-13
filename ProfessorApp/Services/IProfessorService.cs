using ProfessorApp.Models;

namespace ProfessorApp.Services
{
    public interface IProfessorService
    {
        IEnumerable<Professor> GetAllProfessor();
        List<Department> GetAllDepartments();
        void AddProfessor(Professor professor);
    }
}

