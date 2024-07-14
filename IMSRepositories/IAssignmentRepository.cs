using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IAssignmentRepository
    {
        Assignment GetAssignmentById(int assignId);
        List<Assignment> GetAssignments();
        void AddAssignment(Assignment assignment);
        void RemoveAssignment(int assignId);
        void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);
        List<Assignment> GetAssignmentByInternId(int internId);
        Task<List<Assignment>> GetAssignmentsAsync();
        Task AddAssignmentAsync(Assignment assignment);
        Task<Assignment> GetAssignmentByIdAsync(int assignId);
        Task UpdateAssignmentAsync(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);
    }
}
