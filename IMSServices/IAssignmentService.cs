using IMSBussinessObjects;
using IMSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public interface IAssignmentService
    {
      
        public Assignment GetAssignmentById(int assignId);
        public List<Assignment> GetAssignments();
        public void AddIntern(Assignment assignment);
        public void RemoveAssignment(int assignId);
        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);
        public List<Assignment> GetAssignmentByInternId(int internId);
    }
}
