using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;

namespace IMSDaos
{
    public class InternDAO
    {
        private readonly AppDbContext db = null;
        private static InternDAO instance = null;

        public InternDAO()
        {
            db = new AppDbContext();
        }

        public static InternDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InternDAO();
                }
                return instance;
            }
        }

        public Intern GetInternById(int internID)
        {
            return db.Interns.FirstOrDefault(x => x.InternId == internID);
        }

        public IEnumerable<Intern> GetApprovedInternsByTeamId(int teamId)
        {
            return db.Interns.Where(x => x.TeamId == teamId && x.Status == "approved").ToList();
        }
        public Intern GetInternByName(string fullName)
        {
            return db.Interns.FirstOrDefault(x => x.FullName == fullName);
        }

        public IEnumerable<Intern> GetInternByTeamId(int teamID)
        {
            return db.Interns.Where(i => i.TeamId == teamID).ToList();
        }

        public List<Intern> GetAllIntern()
        {
            return db.Interns.ToList();
        }

        public void AddIntern(Intern intern)
        {
            Intern newIntern = GetInternById(intern.InternId);
            if (newIntern == null)
            {
                db.Interns.Add(intern);
                db.SaveChanges();
            }
        }

        public void RemoveIntern(int internID)
        {
            Intern intern = GetInternById(internID);
            if (intern != null)
            {
                /* var assignments = db.Assignments.Where(a => a.InternId == internID).ToList();
                 db.Assignments.RemoveRange(assignments);*/

                db.Interns.Remove(intern);
                db.SaveChanges();
            }
        }
        public void UpdateIntern(int internID, Intern newIntern)
        {
            var existingIntern = GetInternById(internID);
            if (existingIntern != null)
            {
                existingIntern.FullName = newIntern.FullName;
                existingIntern.PersonalId = newIntern.PersonalId;
                existingIntern.PhoneNumber = newIntern.PhoneNumber;
                existingIntern.Uni = newIntern.Uni;
                existingIntern.Major = newIntern.Major;
                existingIntern.Gpa = newIntern.Gpa;
                existingIntern.Birthday = newIntern.Birthday;
                existingIntern.CvUrl = newIntern.CvUrl;
                existingIntern.PhotoUrl = newIntern.PhotoUrl;

                db.Interns.Attach(existingIntern);
                db.Entry(existingIntern).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public List<Intern> GetAllInternByStatus(string status)
        {
            return db.Interns.Where(x => x.Status.Equals(status)).ToList();
        }
        public List<Intern> GetApprovedInterns()
        {
            return db.Interns.Where(i => i.Status == "approved").ToList();
        }


    }
}
