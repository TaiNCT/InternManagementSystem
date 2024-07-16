using IMSBussinessObjects;
using IMSDaos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public class CampaignRepository : ICampaignRepository
    {
        public void AddCampaign(Campaign campaign) => CampaignDAO.Instance.AddCampaign(campaign);

        public Campaign GetCampaignById(int campId) => CampaignDAO.Instance.GetCampaignById(campId);

        public List<Campaign> GetCampaigns() => CampaignDAO.Instance.GetCampaigns();

        public void RemoveCampaign(int campId) => CampaignDAO.Instance.RemoveCampaign(campId);
    }
}
