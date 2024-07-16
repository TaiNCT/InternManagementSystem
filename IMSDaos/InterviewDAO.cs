using IMSBussinessObjects;

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


    }
}
