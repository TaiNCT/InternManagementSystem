using IMSBussinessObjects;
using IMSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public void AddAssignment(Assignment assignment) => _assignmentRepository.AddAssignment(assignment);
        public async Task AddAssignmentAsync(Assignment assignment) => await _assignmentRepository.AddAssignmentAsync(assignment);
        public Assignment GetAssignmentById(int assignId) => _assignmentRepository.GetAssignmentById(assignId);

        public List<Assignment> GetAssignments() => _assignmentRepository.GetAssignments();

        public void RemoveAssignment(int assignId) => _assignmentRepository.RemoveAssignment(assignId);

        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern) => _assignmentRepository.UpdateAssignment(assignId, newAssignment, newTeam, newIntern);

        public List<Assignment> GetAssignmentByInternId(int internId) => _assignmentRepository.GetAssignmentByInternId(internId);

        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await _assignmentRepository.GetAssignmentsAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int assignId)
        {
            return await _assignmentRepository.GetAssignmentByIdAsync(assignId);
        }

        public async Task UpdateAssignmentAsync(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern)
        {
            await _assignmentRepository.UpdateAssignmentAsync(assignId, newAssignment, newTeam, newIntern);
        }

        public async Task RemoveAssignmentAsync(int assignId)
        {
            await _assignmentRepository.RemoveAssignmentAsync(assignId);
        }
    }
}
