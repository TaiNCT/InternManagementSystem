using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public interface ICampaignService
    {
        public Campaign GetCampaignById(int campId);
        public List<Campaign> GetCampaigns();
        public void AddCampaign(Campaign campaign);
        public void RemoveCampaign(int campId);
    }
}
