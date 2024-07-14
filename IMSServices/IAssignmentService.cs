using IMSBussinessObjects;

namespace IMSServices
{
    public interface IAssignmentService
    {
        void AddAssignment(Assignment assignment);
        Assignment GetAssignmentById(int assignId);
        Task AddAssignmentAsync(Assignment assignment);
        List<Assignment> GetAssignments();
        void RemoveAssignment(int assignId);
        void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);
        List<Assignment> GetAssignmentByInternId(int internId);
        Task<List<Assignment>> GetAssignmentsAsync();
        Task<Assignment> GetAssignmentByIdAsync(int assignId);
        Task UpdateAssignmentAsync(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);
        Task RemoveAssignmentAsync(int assignId);
    }
}
