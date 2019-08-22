using System.Collections.Generic;
using Entities;
using Interfaces;
using DAO;
using System;

namespace BO
{
    public class JobHistBO
    {
        public List<JobHistBE> ObterJobsHist()
        {
            IJobHist jobHist = JobHistDAO.GetInstance();
            return jobHist.ObterJobsHist();
        }

        public void SalvarJobHist(int p_EmpID, DateTime p_StartDate, DateTime p_EndDate, string p_JobID, int p_DeptID)
        {
            IJobHist jobHist = JobHistDAO.GetInstance();
            jobHist.SalvarJobHist(p_EmpID, p_StartDate, p_EndDate, p_JobID, p_DeptID);
        }

    }
}
