using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IJob
    {
        List<JobBE> ObterJobs();
        List<JobBE> ObterJobs(string p_JobId);

        void SalvarJob(string pJobId, string pJobName, int pSalMin, int SalMax);
        void AlterarJob(string pJobId, string pJobName, int pSalMin, int SalMax);
    }
}
