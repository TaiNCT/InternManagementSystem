﻿using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDaos
{
    public class CampaignDAO
    {
        private readonly AppDbContext db = null;
        private static CampaignDAO instance = null;

        private CampaignDAO()
        {
            db = new AppDbContext();
        }

        public static CampaignDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CampaignDAO();
                }
                return instance;
            }
        }
        public Campaign GetCampaignById(int campId)
        {
            return db.Campaigns.FirstOrDefault(x => x.CampaignId == campId);
        }
        public List<Campaign> GetCampaigns()
        {
            return db.Campaigns.ToList();
        }
        public void AddCampaign(Campaign campaign)
        {
            Campaign newCampaign = GetCampaignById(campaign.CampaignId);
            if (newCampaign == null)
            {
                db.Campaigns.Add(campaign);
                db.SaveChanges();
            }
        }
        public void RemoveCampaign(int campId)
        {
            Campaign campaign = GetCampaignById(campId);

            if (campaign != null)
            {
                db.Campaigns.Remove(campaign);
                db.SaveChanges();
            }
        }
    }
}
