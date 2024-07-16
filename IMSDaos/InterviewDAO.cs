using IMSBussinessObjects;
using Microsoft.EntityFrameworkCore;

namespace IMSDaos
{
    public class InterviewDAO
    {
        private readonly AppDbContext db = null;
        private static InterviewDAO instance = null;

        public InterviewDAO()
        {
            db = new AppDbContext();
        }

        public static InterviewDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InterviewDAO();
                }
                return instance;
            }
        }

        public Interview GetInterviewById(int interviewID)
        {
            return db.Interviews.FirstOrDefault(x => x.InterviewId == interviewID);
        }

        public List<Interview> GetAllInterview()
        {
            return db.Interviews.ToList();
        }

        public void AddInterview(Interview interview)
        {
            Interview newInterview = GetInterviewById(interview.InterviewId);
            if (newInterview == null)
            {
                db.Interviews.Add(interview);
                db.SaveChanges();
            }
        }

        public void RemoveIntern(int interviewID)
        {
            Interview interview = GetInterviewById(interviewID);
            if (interview != null)
            {
                /* var assignments = db.Assignments.Where(a => a.InternId == internID).ToList();
                 db.Assignments.RemoveRange(assignments);*/

                db.Interviews.Remove(interview);
                db.SaveChanges();
            }
        }
        public void UpdateInterview(int interviewID, Interview newInterview)
        {
            var existingInterview = GetInterviewById(interviewID);
            if (existingInterview != null)
            {
                existingInterview.InterviewDate = newInterview.InterviewDate;
                existingInterview.Location = newInterview.Location;
                existingInterview.RoomNumber = newInterview.RoomNumber;

                db.Interviews.Attach(existingInterview);
                db.Entry(existingInterview).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
