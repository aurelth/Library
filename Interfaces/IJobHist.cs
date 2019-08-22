using System;
using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IJobHist
    {
        List<JobHistBE> ObterJobsHist();

        void SalvarJobHist(int p_EmpID, DateTime p_StartDate, DateTime p_EndDate, string p_JobID, int p_DeptID);
    }
}
