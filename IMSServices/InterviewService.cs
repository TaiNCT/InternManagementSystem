using IMSBussinessObjects;
using IMSRepositories;

namespace IMSServices
{
    public class InterviewService : IInterviewService
    {
        private readonly IInterviewRepository _interviewRepository;

        public InterviewService(IInterviewRepository interviewRepository)
        {
            _interviewRepository = interviewRepository;
        }
        public void AddInterview(Interview interview)
        {
            _interviewRepository.AddInterview(interview);
        }

        public List<Interview> GetAllInterview()
        {
            return _interviewRepository.GetAllInterview();
        }

        public Interview GetInterviewById(int interviewID)
        {
            return _interviewRepository.GetInterviewById(interviewID);
        }

        public void RemoveIntern(int interviewID)
        {
            _interviewRepository.RemoveIntern(interviewID);
        }

        public void UpdateInterview(int interviewID, Interview newInterview)
        {
            _interviewRepository.UpdateInterview(interviewID, newInterview);
        }
    }
}
