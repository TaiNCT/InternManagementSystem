using IMSBussinessObjects;
using IMSDaos;
using Microsoft.EntityFrameworkCore;

namespace IMSRepositories
{
    public class InternRepository : IInternRepository
    {
        public void AddIntern(Intern intern) => InternDAO.Instance.AddIntern(intern);
        public List<Intern> GetAllIntern() => InternDAO.Instance.GetAllIntern();

        public Intern GetInternById(int internID) => InternDAO.Instance.GetInternById(internID);

        public Intern GetInternByName(string name) => InternDAO.Instance.GetInternByName(name);


        public void RemoveIntern(int internID)  => InternDAO.Instance.RemoveIntern(internID);

        public void UpdateIntern(int internID, Intern newIntern) => InternDAO.Instance.UpdateIntern(internID, newIntern);
        public IEnumerable<Intern> GetInternsByTeamId(int teamId)
        {
            // Gọi phương thức GetInternsByTeamId từ InternDAO và trả về danh sách thực tập sinh
            return InternDAO.Instance.GetAllIntern().Where(i => i.TeamId == teamId);
        }
    }
}
