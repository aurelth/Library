using Interfaces;
using Entities;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Data;


namespace DAO
{
    public class JobDAO:BaseDAO<JobDAO>, IJob
    {
        public List<JobBE> ObterJobs()
        {
            List<JobBE> jobs = new List<JobBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_JOBS";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            cmd.Parameters.Add(Cursor);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                JobBE obtendo = new JobBE();

                obtendo.JobId = ObterValor<string>(retorno["JOB_ID"]);
                obtendo.JobName = ObterValor<string>(retorno["JOB_TITLE"]);
                obtendo.SalaryMin = ObterValor<int>(retorno["MIN_SALARY"]);
                obtendo.SalaryMax = ObterValor<int>(retorno["MAX_SALARY"]);
                jobs.Add(obtendo);
            };

            conn.Dispose();
            return jobs;
        }

        public List<JobBE> ObterJobs(string pJobId)
        {
            List<JobBE> jobs = new List<JobBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_JOBS_POR_ID";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "P_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;
            OracleParameter JobId = new OracleParameter();
            JobId.ParameterName = "P_JOBID";
            JobId.Direction = ParameterDirection.Input;
            JobId.OracleDbType = OracleDbType.Varchar2;
            JobId.Value = pJobId;

            cmd.Parameters.Add(Cursor);
            cmd.Parameters.Add(JobId);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                JobBE obtendo = new JobBE();

                obtendo.JobId = ObterValor<string>(retorno["JOB_ID"]);
                obtendo.JobName = ObterValor<string>(retorno["JOB_TITLE"]);
                obtendo.SalaryMin = ObterValor<int>(retorno["MIN_SALARY"]);
                obtendo.SalaryMax = ObterValor<int>(retorno["MAX_SALARY"]);
                jobs.Add(obtendo);
            };

            conn.Dispose();
            return jobs;
        }

        public void SalvarJob(string pJobId, string pJobName, int pSalMin, int SalMax)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_IN_JOBS";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter JobId = new OracleParameter();
            JobId.ParameterName = "P_JOBID";
            JobId.Direction = ParameterDirection.Input;
            JobId.OracleDbType = OracleDbType.Long;
            JobId.Value = pJobId;
            OracleParameter JobName = new OracleParameter();
            JobName.ParameterName = "P_JOBNAME";
            JobName.Direction = ParameterDirection.Input;
            JobName.OracleDbType = OracleDbType.Long;
            JobName.Value = pJobName;
            OracleParameter MinSal = new OracleParameter();
            MinSal.ParameterName = "P_MINSAL";
            MinSal.Direction = ParameterDirection.Input;
            MinSal.OracleDbType = OracleDbType.Long;
            MinSal.Value = pSalMin;
            OracleParameter MaxSal = new OracleParameter();
            MaxSal.ParameterName = "P_MAXSAL";
            MaxSal.Direction = ParameterDirection.Input;
            MaxSal.OracleDbType = OracleDbType.Long;
            MaxSal.Value = SalMax;

            cmd.Parameters.Add(JobId);
            cmd.Parameters.Add(JobName);
            cmd.Parameters.Add(MinSal);
            cmd.Parameters.Add(MaxSal);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void AlterarJob(string pJobId, string pJobName, int pSalMin, int SalMax)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_UP_JOBS";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter JobId = new OracleParameter();
            JobId.ParameterName = "P_JOBID";
            JobId.Direction = ParameterDirection.Input;
            JobId.OracleDbType = OracleDbType.Long;
            JobId.Value = pJobId;
            OracleParameter JobName = new OracleParameter();
            JobName.ParameterName = "P_JOBNAME";
            JobName.Direction = ParameterDirection.Input;
            JobName.OracleDbType = OracleDbType.Long;
            JobName.Value = pJobName;
            OracleParameter MinSal = new OracleParameter();
            MinSal.ParameterName = "P_MINSAL";
            MinSal.Direction = ParameterDirection.Input;
            MinSal.OracleDbType = OracleDbType.Long;
            MinSal.Value = pSalMin;
            OracleParameter MaxSal = new OracleParameter();
            MaxSal.ParameterName = "P_MAXSAL";
            MaxSal.Direction = ParameterDirection.Input;
            MaxSal.OracleDbType = OracleDbType.Long;
            MaxSal.Value = SalMax;

            cmd.Parameters.Add(JobId);
            cmd.Parameters.Add(JobName);
            cmd.Parameters.Add(MinSal);
            cmd.Parameters.Add(MaxSal);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }
    }
}
