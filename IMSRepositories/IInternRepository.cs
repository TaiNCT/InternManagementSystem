using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IInternRepository
    {
        public Intern GetInternById(int internID);
        public Intern GetInternByName(string name);
        public List<Intern> GetAllIntern();
        public void AddIntern(Intern intern);
        public void RemoveIntern(int internID);
        public void UpdateIntern(int internID, Intern newIntern);
        public List<Intern> GetAllInternByStatus(string status);
        
        
        IEnumerable<Intern> GetInternByTeamId(int teamID);

        IEnumerable<Intern> GetInternsByTeamId(int teamId);
        List<Intern> GetApprovedInterns();
    }
}
