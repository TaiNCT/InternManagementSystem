using IMSBussinessObjects;
using IMSDaos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        public void AddAssignment(Assignment assignment) => AssignmentDAO.Instance.AddAssignment(assignment);

        public Assignment GetAssignmentById(int assignId) => AssignmentDAO.Instance.GetAssignmentById(assignId);

        public List<Assignment> GetAssignmentByInternId(int internId) => AssignmentDAO.Instance.GetAssignmentByInternId(internId);

        public List<Assignment> GetAssignments() => AssignmentDAO.Instance.GetAssignments();

        public void RemoveAssignment(int assignId) => AssignmentDAO.Instance.RemoveAssignment(assignId);

        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern) => AssignmentDAO.Instance.UpdateAssignment(assignId, newAssignment, newTeam, newIntern);

        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await Task.Run(() => AssignmentDAO.Instance.GetAssignments());
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await Task.Run(() => AssignmentDAO.Instance.AddAssignment(assignment));
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int assignId)
        {
            return await AssignmentDAO.Instance.GetAssignmentByIdAsync(assignId);
        }

        public async Task UpdateAssignmentAsync(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern)
        {
            await AssignmentDAO.Instance.UpdateAssignmentAsync(assignId, newAssignment, newTeam, newIntern);
        }
        public async Task RemoveAssignmentAsync(int assignId)
        {
            await AssignmentDAO.Instance.RemoveAssignmentAsync(assignId);
        }
    }
}
