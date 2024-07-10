using IMSBussinessObjects;

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

        public Intern GetInternByName(string name)
        {
            return db.Interns.FirstOrDefault(x => x.Name == name);
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
                existingIntern.Name = newIntern.Name;
                existingIntern.PersonalId = newIntern.PersonalId;
                existingIntern.PhoneNumber = newIntern.PhoneNumber;
                existingIntern.Email = newIntern.Email;
                existingIntern.Uni = newIntern.Uni;
                existingIntern.Major = newIntern.Major;
            }
        }
    }
}
