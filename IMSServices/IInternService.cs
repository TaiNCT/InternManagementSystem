using IMSBussinessObjects;

namespace IMSServices
{
    public interface IInternService
    {
        public Intern GetInternById(int internID);
        public Intern GetInternByName(string name);
        public List<Intern> GetAllIntern();
        public void AddIntern(Intern intern);
        public void RemoveIntern(int internID);
        public void UpdateIntern(int internID, Intern newIntern);
        public void UpdateInternStatus(int internID, string status);
        public void ArchiveIntern(int internID);
        public int GetInternCountByTeamId(int teamId);
        public List<Intern> GetApprovedInterns();
        public List<Intern> GetInternsByStatus(string status);
        IEnumerable<Intern> GetInternByTeamId(int teamID);

    }
}
