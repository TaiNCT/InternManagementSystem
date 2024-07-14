using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public interface IAssignmentRepository
    {
        public Assignment GetAssignmentById(int assignId);
        public List<Assignment> GetAssignments();
        public void AddIntern(Assignment assignment);
        public void RemoveAssignment(int assignId);
        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern);
        public List<Assignment> GetAssignmentByInternId(int internId);
    }
}
