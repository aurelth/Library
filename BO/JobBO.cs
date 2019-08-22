using Entities;
using DAO;
using Interfaces;
using System.Collections.Generic;


namespace BO
{
    public class JobBO
    {
        public List<JobBE> ObterJob()
        {
            IJob job = JobDAO.GetInstance();
            return job.ObterJobs();
        }

        public List<JobBE> ObterJob(string p_jobId)
        {
            IJob job = JobDAO.GetInstance();
            return job.ObterJobs(p_jobId);
        }

        public void SalvarJob(string p_jobId, string p_jobName, int p_maxSal, int p_minSal)
        {
            IJob job = JobDAO.GetInstance();
            job.SalvarJob(p_jobId, p_jobName, p_maxSal, p_minSal);
        }

        public void AlterarJob(string p_jobId, string p_jobName, int p_maxSal, int p_minSal)
        {
            IJob job = JobDAO.GetInstance();
            job.AlterarJob(p_jobId, p_jobName, p_maxSal, p_minSal);
        }

    }
}
