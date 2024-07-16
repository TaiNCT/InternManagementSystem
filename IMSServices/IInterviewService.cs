using IMSBussinessObjects;

namespace IMSServices
{
    public interface IInterviewService
    {
        Interview GetInterviewById(int interviewID);
        List<Interview> GetAllInterview();
        void AddInterview(Interview interview);
        void RemoveInterview(int interviewID);
        void UpdateInterview(int interviewID, Interview newInterview);
        public void RemoveExpiredInterviews(List<Interview> expiredInterviews);

    }
}
