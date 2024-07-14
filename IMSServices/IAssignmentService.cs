using IMSBussinessObjects;

namespace IMSServices
{
    public interface IAssignmentService
    {

        public void AddAssignment(Assignment assignment);
        public Assignment GetAssignmentById(int assignId);
        Task AddAssignmentAsync(Assignment assignment);
        public List<Assignment> GetAssignments();
        public void RemoveAssignment(int assignId);
        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);
        public List<Assignment> GetAssignmentByInternId(int internId);
        public Task<List<Assignment>> GetAssignmentsAsync();
    }
}
