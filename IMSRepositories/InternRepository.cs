using IMSBussinessObjects;
using IMSDaos;

namespace IMSRepositories
{
    public class InternRepository : IInternRepository
    {
        public void AddIntern(Intern intern) => InternDAO.Instance.AddIntern(intern);
        public List<Intern> GetAllIntern() => InternDAO.Instance.GetAllIntern();

        public List<Intern> GetAllInternByStatus(string status) => InternDAO.Instance.GetAllInternByStatus(status);

        public Intern GetInternById(int internID) => InternDAO.Instance.GetInternById(internID);

        public Intern GetInternByName(string name) => InternDAO.Instance.GetInternByName(name);

        public IEnumerable<Intern> GetInternByTeamId(int teamID)
        => InternDAO.Instance.GetInternByTeamId(teamID);


        public void RemoveIntern(int internID) => InternDAO.Instance.RemoveIntern(internID);

        public void UpdateIntern(int internID, Intern newIntern) => InternDAO.Instance.UpdateIntern(internID, newIntern);

    }
}
