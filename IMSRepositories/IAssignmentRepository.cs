using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IAssignmentRepository
    {
        public Assignment GetAssignmentById(int assignId);
        public List<Assignment> GetAssignments();
        public void AddAssignment(Assignment assignment);
        public void RemoveAssignment(int assignId);
        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);
        public List<Assignment> GetAssignmentByInternId(int internId);
        Task<List<Assignment>> GetAssignmentsAsync();
        Task AddAssignmentAsync(Assignment assignment);
    }
}
