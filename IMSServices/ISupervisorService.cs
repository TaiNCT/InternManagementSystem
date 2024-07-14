﻿using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public interface ISupervisorService
    {
        Task<Supervisor> GetSupervisorByTeamIdAsync(int teamId);
        public Supervisor GetSupervisorById(int supId);
        public void AddSupervisor(int UserId, Team newTeam);
    }
}
