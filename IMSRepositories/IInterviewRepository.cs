using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IInterviewRepository
    {
        Interview GetInterviewById(int interviewID);
        List<Interview> GetAllInterview();
        void AddInterview(Interview interview);
        void RemoveInterview(int interviewID);
        void UpdateInterview(int interviewID, Interview newInterview);
    }
}
