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
        public int GetInternCountByTeamId(int teamId)
        {
            return db.Interns.Count(i => i.TeamId == teamId);
        }

        public Intern GetInternByName(string fullName)
        {
            return db.Interns.FirstOrDefault(x => x.FullName == fullName);
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
                existingIntern.TeamId = newIntern.TeamId;
                existingIntern.Birthday = newIntern.Birthday;
                existingIntern.CvUrl = newIntern.CvUrl;
                existingIntern.PhotoUrl = newIntern.PhotoUrl;
                existingIntern.OverallSuccess = newIntern.OverallSuccess;
                existingIntern.InternshipStartingDate = newIntern.InternshipStartingDate;
                existingIntern.InternshipEndingDate = newIntern.InternshipEndingDate;

                db.Interns.Attach(existingIntern);
                db.Entry(existingIntern).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


    }
}
