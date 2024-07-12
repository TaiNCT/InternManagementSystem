using IMSBussinessObjects;
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
    }
}
