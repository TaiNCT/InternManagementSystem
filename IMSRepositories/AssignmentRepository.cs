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
        public void AddIntern(Assignment assignment) => AssignmentDAO.Instance.AddIntern(assignment);

        public Assignment GetAssignmentById(int assignId) => AssignmentDAO.Instance.GetAssignmentById(assignId);

        public List<Assignment> GetAssignmentByInternId(int internId) => AssignmentDAO.Instance.GetAssignmentByInternId(internId);

        public List<Assignment> GetAssignments() => AssignmentDAO.Instance.GetAssignments();
        public void RemoveAssignment(int assignId) => AssignmentDAO.Instance.RemoveAssignment(assignId);

        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern) => UpdateAssignment(assignId, newAssignment, newTeam, newIntern);
    }
}
