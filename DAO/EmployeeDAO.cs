using Interfaces;
using Entities;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace DAO
{
    public class EmployeeDAO:BaseDAO<EmployeeDAO>, IEmployee
    {

        public List<EmployeeBE> ObterEmployees()
        {
            List<EmployeeBE> employees = new List<EmployeeBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_EMPLOYEES";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            cmd.Parameters.Add(Cursor);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                EmployeeBE obtendo = new EmployeeBE();

                obtendo.EmpId = ObterValor<int>(retorno["EMPLOYEE_ID"]);
                obtendo.FirstName = ObterValor<string>(retorno["FIRST_NAME"]);
                obtendo.LastName = ObterValor<string>(retorno["LAST_NAME"]);
                obtendo.NomeComp = obtendo.FirstName + " " + obtendo.LastName;
                obtendo.Email = ObterValor<string>(retorno["EMAIL"]);
                obtendo.FoneNum = ObterValor<string>(retorno["PHONE_NUMBER"]);
                obtendo.HireDate = ObterValor<string>(retorno["HIRE_DATE"]);
                obtendo.JobId = ObterValor<string>(retorno["JOB_ID"]);
                obtendo.JobName = ObterValor<string>(retorno["JOB_TITLE"]);
                obtendo.Salary = ObterValor<int>(retorno["SALARY"]);
                obtendo.MaxSalary = ObterValor<int>(retorno["MAX_SALARY"]);
                obtendo.Minsalary = ObterValor<int>(retorno["MIN_SALARY"]);
                obtendo.Comissao = ObterValor<double>(retorno["COMMISSION_PCT"]);
                obtendo.MngId = ObterValor<int>(retorno["MANAGER_ID"]);
                obtendo.DptId = ObterValor<int>(retorno["DEPARTMENT_ID"]);
                obtendo.DptNome = ObterValor<string>(retorno["DEPARTMENT_NAME"]);

                employees.Add(obtendo);
            };

            conn.Dispose();
            return employees;
        }

        public List<EmployeeBE> ObterEmployees(int p_EmpId)
        {
            List<EmployeeBE> employees = new List<EmployeeBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_EMPLOYEES_POR_ID";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "P_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;
            OracleParameter EmpID = new OracleParameter();
            EmpID.ParameterName = "P_EMPID";
            EmpID.Direction = ParameterDirection.Input;
            EmpID.OracleDbType = OracleDbType.Int16;
            EmpID.Value = p_EmpId;

            cmd.Parameters.Add(Cursor);
            cmd.Parameters.Add(EmpID);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                EmployeeBE obtendo = new EmployeeBE();

                obtendo.EmpId = ObterValor<int>(retorno["EMPLOYEE_ID"]);
                obtendo.FirstName = ObterValor<string>(retorno["FIRST_NAME"]);
                obtendo.LastName = ObterValor<string>(retorno["LAST_NAME"]);
                obtendo.Email = ObterValor<string>(retorno["EMAIL"]);
                obtendo.FoneNum = ObterValor<string>(retorno["PHONE_NUMBER"]);
                obtendo.HireDate = ObterValor<string>(retorno["HIRE_DATE"]);
                obtendo.JobId = ObterValor<string>(retorno["JOB_ID"]);
                obtendo.JobName = ObterValor<string>(retorno["JOB_TITLE"]);
                obtendo.Salary = ObterValor<int>(retorno["SALARY"]);
                obtendo.MaxSalary = ObterValor<int>(retorno["MAX_SALARY"]);
                obtendo.Minsalary = ObterValor<int>(retorno["MIN_SALARY"]);
                obtendo.Comissao = ObterValor<double>(retorno["COMMISSION_PCT"]);
                obtendo.MngId = ObterValor<int>(retorno["MANAGER_ID"]);
                obtendo.DptId = ObterValor<int>(retorno["DEPARTMENT_ID"]);
                obtendo.DptNome = ObterValor<string>(retorno["DEPARTMENT_NAME"]);

                employees.Add(obtendo);
            };

            conn.Dispose();
            return employees;
        }

        public void SalvarEmployees(string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_Comissao, int p_MngId, int p_DptId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_IN_EMPLOYEES";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter FirstName = new OracleParameter();
            FirstName.ParameterName = "P_FIRSTNAME";
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = p_FirstName;

            OracleParameter LastName = new OracleParameter();
            LastName.ParameterName = "P_LASTNAME";
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = p_LastName;

            OracleParameter Email = new OracleParameter();
            Email.ParameterName = "P_EMAIL";
            Email.Direction = ParameterDirection.Input;
            Email.Value = p_Email;

            OracleParameter FoneNum = new OracleParameter();
            FoneNum.ParameterName = "P_PHONENUM";
            FoneNum.Direction = ParameterDirection.Input;
            FoneNum.Value = p_FoneNum;

            OracleParameter HireDate = new OracleParameter();
            HireDate.ParameterName = "P_HIREDATE";
            HireDate.Direction = ParameterDirection.Input;
            HireDate.Value = p_HireDate;

            OracleParameter JobId = new OracleParameter();
            JobId.ParameterName = "P_JOBID";
            JobId.Direction = ParameterDirection.Input;
            JobId.Value = p_JobId;

            OracleParameter Salary = new OracleParameter();
            Salary.ParameterName = "P_SALARY";
            Salary.Direction = ParameterDirection.Input;
            Salary.Value = p_Salary;

            OracleParameter Comissao = new OracleParameter();
            Comissao.ParameterName = "P_COMMIS";
            Comissao.Direction = ParameterDirection.Input;
            Comissao.Value = p_Comissao;

            OracleParameter ManagerId = new OracleParameter();
            ManagerId.ParameterName = "P_MANAGERID";
            ManagerId.Direction = ParameterDirection.Input;
            ManagerId.Value = p_MngId;

            OracleParameter DptID = new OracleParameter();
            DptID.ParameterName = "P_DPTID";
            DptID.Direction = ParameterDirection.Input;
            DptID.Value = p_DptId;

            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(FoneNum);
            cmd.Parameters.Add(HireDate);
            cmd.Parameters.Add(JobId);
            cmd.Parameters.Add(Salary);
            cmd.Parameters.Add(Comissao);
            cmd.Parameters.Add(ManagerId);
            cmd.Parameters.Add(DptID);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void SalvarEmployees(string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_MngId, int p_DptId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_IN_EMPLOYEES_SEM_COMM";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter FirstName = new OracleParameter();
            FirstName.ParameterName = "P_FIRSTNAME";
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = p_FirstName;

            OracleParameter LastName = new OracleParameter();
            LastName.ParameterName = "P_LASTNAME";
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = p_LastName;

            OracleParameter Email = new OracleParameter();
            Email.ParameterName = "P_EMAIL";
            Email.Direction = ParameterDirection.Input;
            Email.Value = p_Email;

            OracleParameter FoneNum = new OracleParameter();
            FoneNum.ParameterName = "P_PHONENUM";
            FoneNum.Direction = ParameterDirection.Input;
            FoneNum.Value = p_FoneNum;

            OracleParameter HireDate = new OracleParameter();
            HireDate.ParameterName = "P_HIREDATE";
            HireDate.Direction = ParameterDirection.Input;
            HireDate.Value = p_HireDate;

            OracleParameter JobId = new OracleParameter();
            JobId.ParameterName = "P_JOBID";
            JobId.Direction = ParameterDirection.Input;
            JobId.Value = p_JobId;

            OracleParameter Salary = new OracleParameter();
            Salary.ParameterName = "P_SALARY";
            Salary.Direction = ParameterDirection.Input;
            Salary.Value = p_Salary;

            OracleParameter ManagerId = new OracleParameter();
            ManagerId.ParameterName = "P_MANAGERID";
            ManagerId.Direction = ParameterDirection.Input;
            ManagerId.Value = p_MngId;

            OracleParameter DptID = new OracleParameter();
            DptID.ParameterName = "P_DPTID";
            DptID.Direction = ParameterDirection.Input;
            DptID.Value = p_DptId;

            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(FoneNum);
            cmd.Parameters.Add(HireDate);
            cmd.Parameters.Add(JobId);
            cmd.Parameters.Add(Salary);
            cmd.Parameters.Add(ManagerId);
            cmd.Parameters.Add(DptID);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void AlterarEmployee(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, DateTime p_HireDate, string p_FoneNum, string p_JobId, int p_Salary, int p_Comissao, int p_MngId, int p_DptId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_UP_EMPLOYEES";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter EmpId = new OracleParameter();
            EmpId.ParameterName = "P_EMPID";
            EmpId.Direction = ParameterDirection.Input;
            EmpId.Value = p_EmpId;

            OracleParameter FirstName = new OracleParameter();
            FirstName.ParameterName = "P_FIRSTNAME";
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = p_FirstName;

            OracleParameter LastName = new OracleParameter();
            LastName.ParameterName = "P_LASTNAME";
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = p_LastName;

            OracleParameter Email = new OracleParameter();
            Email.ParameterName = "P_EMAIL";
            Email.Direction = ParameterDirection.Input;
            Email.Value = p_Email;

            OracleParameter FoneNum = new OracleParameter();
            FoneNum.ParameterName = "P_PHONENUM";
            FoneNum.Direction = ParameterDirection.Input;
            FoneNum.Value = p_FoneNum;

            OracleParameter HireDate = new OracleParameter();
            HireDate.ParameterName = "P_HIREDATE";
            HireDate.Direction = ParameterDirection.Input;
            HireDate.Value = p_HireDate;

            OracleParameter JobId = new OracleParameter();
            JobId.ParameterName = "P_JOBID";
            JobId.Direction = ParameterDirection.Input;
            JobId.Value = p_JobId;

            OracleParameter Salary = new OracleParameter();
            Salary.ParameterName = "P_SALARY";
            Salary.Direction = ParameterDirection.Input;
            Salary.Value = p_Salary;

            OracleParameter Comissao = new OracleParameter();
            Comissao.ParameterName = "P_COMMIS";
            Comissao.Direction = ParameterDirection.Input;
            Comissao.Value = p_Comissao;

            OracleParameter ManagerId = new OracleParameter();
            ManagerId.ParameterName = "P_MANAGERID";
            ManagerId.Direction = ParameterDirection.Input;
            ManagerId.Value = p_MngId;

            OracleParameter DptID = new OracleParameter();
            DptID.ParameterName = "P_DPTID";
            DptID.Direction = ParameterDirection.Input;
            DptID.Value = p_DptId;

            cmd.Parameters.Add(EmpId);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(FoneNum);
            cmd.Parameters.Add(HireDate);
            cmd.Parameters.Add(JobId);
            cmd.Parameters.Add(Salary);
            cmd.Parameters.Add(Comissao);
            cmd.Parameters.Add(ManagerId);
            cmd.Parameters.Add(DptID);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void AlterarEmployee(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, DateTime p_HireDate, string p_FoneNum, string p_JobId, int p_Salary, int p_MngId, int p_DptId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_UP_EMPLOYEES_SEM_COMM";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter EmpId = new OracleParameter();
            EmpId.ParameterName = "P_EMPID";
            EmpId.Direction = ParameterDirection.Input;
            EmpId.Value = p_EmpId;

            OracleParameter FirstName = new OracleParameter();
            FirstName.ParameterName = "P_FIRSTNAME";
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = p_FirstName;

            OracleParameter LastName = new OracleParameter();
            LastName.ParameterName = "P_LASTNAME";
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = p_LastName;

            OracleParameter Email = new OracleParameter();
            Email.ParameterName = "P_EMAIL";
            Email.Direction = ParameterDirection.Input;
            Email.Value = p_Email;

            OracleParameter FoneNum = new OracleParameter();
            FoneNum.ParameterName = "P_PHONENUM";
            FoneNum.Direction = ParameterDirection.Input;
            FoneNum.Value = p_FoneNum;

            OracleParameter HireDate = new OracleParameter();
            HireDate.ParameterName = "P_HIREDATE";
            HireDate.Direction = ParameterDirection.Input;
            HireDate.Value = p_HireDate;

            OracleParameter JobId = new OracleParameter();
            JobId.ParameterName = "P_JOBID";
            JobId.Direction = ParameterDirection.Input;
            JobId.Value = p_JobId;

            OracleParameter Salary = new OracleParameter();
            Salary.ParameterName = "P_SALARY";
            Salary.Direction = ParameterDirection.Input;
            Salary.Value = p_Salary;

            OracleParameter ManagerId = new OracleParameter();
            ManagerId.ParameterName = "P_MANAGERID";
            ManagerId.Direction = ParameterDirection.Input;
            ManagerId.Value = p_MngId;

            OracleParameter DptID = new OracleParameter();
            DptID.ParameterName = "P_DPTID";
            DptID.Direction = ParameterDirection.Input;
            DptID.Value = p_DptId;

            cmd.Parameters.Add(EmpId);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(FoneNum);
            cmd.Parameters.Add(HireDate);
            cmd.Parameters.Add(JobId);
            cmd.Parameters.Add(Salary);
            cmd.Parameters.Add(ManagerId);
            cmd.Parameters.Add(DptID);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void AlterarEmployee(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, DateTime p_HireDate, string p_FoneNum, string p_JobId, int p_Salary, int p_DptId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_UP_EMPLOYEES_SEM_COMM_SEM_MNG";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter EmpId = new OracleParameter();
            EmpId.ParameterName = "P_EMPID";
            EmpId.Direction = ParameterDirection.Input;
            EmpId.Value = p_EmpId;

            OracleParameter FirstName = new OracleParameter();
            FirstName.ParameterName = "P_FIRSTNAME";
            FirstName.Direction = ParameterDirection.Input;
            FirstName.Value = p_FirstName;

            OracleParameter LastName = new OracleParameter();
            LastName.ParameterName = "P_LASTNAME";
            LastName.Direction = ParameterDirection.Input;
            LastName.Value = p_LastName;

            OracleParameter Email = new OracleParameter();
            Email.ParameterName = "P_EMAIL";
            Email.Direction = ParameterDirection.Input;
            Email.Value = p_Email;

            OracleParameter FoneNum = new OracleParameter();
            FoneNum.ParameterName = "P_PHONENUM";
            FoneNum.Direction = ParameterDirection.Input;
            FoneNum.Value = p_FoneNum;

            OracleParameter HireDate = new OracleParameter();
            HireDate.ParameterName = "P_HIREDATE";
            HireDate.Direction = ParameterDirection.Input;
            HireDate.Value = p_HireDate;

            OracleParameter JobId = new OracleParameter();
            JobId.ParameterName = "P_JOBID";
            JobId.Direction = ParameterDirection.Input;
            JobId.Value = p_JobId;

            OracleParameter Salary = new OracleParameter();
            Salary.ParameterName = "P_SALARY";
            Salary.Direction = ParameterDirection.Input;
            Salary.Value = p_Salary;

            OracleParameter DptID = new OracleParameter();
            DptID.ParameterName = "P_DPTID";
            DptID.Direction = ParameterDirection.Input;
            DptID.Value = p_DptId;

            cmd.Parameters.Add(EmpId);
            cmd.Parameters.Add(FirstName);
            cmd.Parameters.Add(LastName);
            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(FoneNum);
            cmd.Parameters.Add(HireDate);
            cmd.Parameters.Add(JobId);
            cmd.Parameters.Add(Salary);
            cmd.Parameters.Add(DptID);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }
    }
}
