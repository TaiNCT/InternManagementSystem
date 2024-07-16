using IMSBussinessObjects;

namespace IMSServices
{
    public interface IInterviewService
    {
        Interview GetInterviewById(int interviewID);
        List<Interview> GetAllInterview();
        void AddInterview(Interview interview);
        void RemoveIntern(int interviewID);
        void UpdateInterview(int interviewID, Interview newInterview);
    }
}
