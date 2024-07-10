using IMSBussinessObjects;
using IMSRepositories;

namespace IMSServices
{
    public class InternService : IInternService
    {
        private readonly IInternRepository _internRepository;

        public InternService(IInternRepository internRepository)
        {
            _internRepository = internRepository;
        }

        public void AddIntern(Intern intern)
        {
            _internRepository.AddIntern(intern);
        }

        public List<Intern> GetAllIntern()
        {
            return _internRepository.GetAllIntern();
        }

        public Intern GetInternById(int internID)
        {
            return _internRepository.GetInternById(internID);
        }

        public Intern GetInternByName(string name)
        {
            return _internRepository.GetInternByName(name);
        }

        public void RemoveIntern(int internID)
        {
            _internRepository.RemoveIntern(internID);
        }

        public void UpdateIntern(int internID, Intern newIntern)
        {
            _internRepository.UpdateIntern(internID, newIntern);
        }
    }
}
