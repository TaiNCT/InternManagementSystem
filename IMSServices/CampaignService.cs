using IMSBussinessObjects;
using IMSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public void AddCampaign(Campaign campaign)
        {
            _campaignRepository.AddCampaign(campaign);
        }

        public Campaign GetCampaignById(int campId)
        {
            return _campaignRepository.GetCampaignById(campId);
        }

        public List<Campaign> GetCampaigns()
        {
            return _campaignRepository.GetCampaigns();
        }

        public void RemoveCampaign(int campId)
        {
            _campaignRepository.RemoveCampaign(campId);
        }
    }
}
