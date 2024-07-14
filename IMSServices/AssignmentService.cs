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
        public void AddIntern(Assignment assignment) => _assignmentRepository.AddIntern(assignment);

        public Assignment GetAssignmentById(int assignId) => _assignmentRepository.GetAssignmentById(assignId);

        public List<Assignment> GetAssignmentByInternId(int internId) => _assignmentRepository.GetAssignmentByInternId(internId);
        public List<Assignment> GetAssignments() => _assignmentRepository.GetAssignments();

        public void RemoveAssignment(int assignId) => _assignmentRepository.RemoveAssignment(assignId);

        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern) => _assignmentRepository.UpdateAssignment(assignId, newAssignment, newTeam, newIntern);
    }
}
