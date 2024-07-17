using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IAssignmentRepository
    {
        Assignment GetAssignmentById(int assignId);
        List<Assignment> GetAssignments();
        void AddAssignment(Assignment assignment);
        void RemoveAssignment(int assignId);
        Task UpdateAssignment(int assignId, Assignment newAssignment);
        List<Assignment> GetAssignmentByInternId(int internId);
        Task<List<Assignment>> GetAssignmentsAsync();
        Task AddAssignmentAsync(Assignment assignment);
        Task<Assignment> GetAssignmentByIdAsync(int assignId);
        Task RemoveAssignmentAsync(int assignId);
        Task UpdateAssignmentAsync(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);

    }
}
