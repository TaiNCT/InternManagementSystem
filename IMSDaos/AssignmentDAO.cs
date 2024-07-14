using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDaos
{
    public class AssignmentDAO
    {
        private readonly AppDbContext db = null;
        private static AssignmentDAO instance = null;

        private AssignmentDAO()
        {
            db = new AppDbContext();
        }

        public static AssignmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssignmentDAO();
                }
                return instance;
            }
        }

        public Assignment GetAssignmentById(int assignId)
        {
            return db.Assignments.FirstOrDefault(x => x.AssignmentId == assignId);
        }

        public List<Assignment> GetAssignmentByInternId(int internId)
        {
            return db.Assignments.Where(x => x.InternId == internId).ToList();
        }

        public List<Assignment> GetAssignments()
        {
            return db.Assignments.ToList();
        }

        public void AddAssignment(Assignment assignment)
        {
            Assignment newAssignment = GetAssignmentById(assignment.AssignmentId);
            if (newAssignment == null)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
            }
        }

        public void RemoveAssignment(int assignId)
        {
            Assignment assignment = GetAssignmentById(assignId);
            if (assignment != null)
            {
                db.Assignments.Remove(assignment);
                db.SaveChanges();
            }
        }

        public void UpdateAssignment(int assignId, Assignment newAssignment, Team newTeam, Intern newIntern)
        {
            var existingAssignment = GetAssignmentById(assignId);
            if (existingAssignment != null)
            {
                existingAssignment.TeamId = newTeam.TeamId;
                existingAssignment.InternId = newIntern.InternId;
                existingAssignment.Description = newAssignment.Description;
                existingAssignment.Deadline = newAssignment.Deadline;
                existingAssignment.Grade = newAssignment.Grade;
                existingAssignment.Weight = newAssignment.Weight;
                existingAssignment.Complete = newAssignment.Complete;
                db.Assignments.Attach(existingAssignment);
                db.Entry(existingAssignment).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public async Task AddAssignmentAsync(Assignment assignment)
        {
            await db.Assignments.AddAsync(assignment);
            await db.SaveChangesAsync();
        }
    }
}
