using Interfaces;
using Entities;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace DAO
{
    public class JobHistDAO : BaseDAO<JobHistDAO>, IJobHist
    {
        public List<JobHistBE> ObterJobsHist()
        {
            List<JobHistBE> jobsHist = new List<JobHistBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_JOB_HIST";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            cmd.Parameters.Add(Cursor);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                JobHistBE obtendo = new JobHistBE();

                obtendo.EmpID = ObterValor<int>(retorno["EMPLOYEE_ID"]);
                string primNome = ObterValor<string>(retorno["FIRST_NAME"]);
                string seguNome = ObterValor<string>(retorno["LAST_NAME"]);
                obtendo.EmpName = primNome + " " + seguNome;
                obtendo.StartDate = ObterValor<string>(retorno["START_DATE"]);
                obtendo.EndDate = ObterValor<string>(retorno["END_DATE"]);
                obtendo.JobID = ObterValor<string>(retorno["JOB_ID"]);
                obtendo.JobName = ObterValor<string>(retorno["JOB_TITLE"]);
                obtendo.DeptID = ObterValor<int>(retorno["DEPARTMENT_ID"]);
                obtendo.DeptName = ObterValor<string>(retorno["DEPARTMENT_NAME"]);

                jobsHist.Add(obtendo);
            };

            conn.Dispose();
            return jobsHist;
        }

        public void SalvarJobHist(int p_EmpID, DateTime p_StartDate, DateTime p_EndDate, string p_JobID, int p_DeptID)
        {
            List<JobHistBE> jobsHist = new List<JobHistBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_IN_JOB_HIST";//Não feita ainda
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter empId = new OracleParameter();
            empId.ParameterName = "P_EMPID";
            empId.Direction = ParameterDirection.Input;
            empId.Value = p_EmpID;

            OracleParameter startDate = new OracleParameter();
            startDate.ParameterName = "P_STARTDATE";
            startDate.Direction = ParameterDirection.Input;
            startDate.Value = p_StartDate;

            OracleParameter endDate = new OracleParameter();
            endDate.ParameterName = "P_ENDATE";
            endDate.Direction = ParameterDirection.Input;
            endDate.Value = p_EndDate;

            OracleParameter jobId = new OracleParameter();
            jobId.ParameterName = "P_JOBID";
            jobId.Direction = ParameterDirection.Input;
            jobId.Value = p_JobID;

            OracleParameter dptId = new OracleParameter();
            dptId.ParameterName = "P_DPTID";
            dptId.Direction = ParameterDirection.Input;
            dptId.Value = p_DeptID;

            cmd.Parameters.Add(empId);
            cmd.Parameters.Add(startDate);
            cmd.Parameters.Add(endDate);
            cmd.Parameters.Add(jobId);
            cmd.Parameters.Add(dptId);

            cmd.ExecuteReader();
            conn.Dispose();
        }
    }
}
