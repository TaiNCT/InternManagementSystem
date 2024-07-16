using IMSBussinessObjects;
using IMSDaos;

namespace IMSRepositories
{
    public class InterviewRepository : IInterviewRepository
    {

        public void AddInterview(Interview interview)
        => InterviewDAO.Instance.AddInterview(interview);

        public List<Interview> GetAllInterview()
        => InterviewDAO.Instance.GetAllInterview();

        public Interview GetInterviewById(int interviewID)
        => InterviewDAO.Instance.GetInterviewById(interviewID);

        public void RemoveInterview(int interviewID)
        => InterviewDAO.Instance.RemoveInterview(interviewID);

        public void UpdateInterview(int interviewID, Interview newInterview)
        => InterviewDAO.Instance.UpdateInterview(interviewID, newInterview);
    }
}
