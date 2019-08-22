using Interfaces;
using DAO;
using Entities;
using System.Collections.Generic;
using System;

namespace BO
{
    public class EmployeeBO
    {
        public List<EmployeeBE> ObterEmployee()
        {
            IEmployee employee = EmployeeDAO.GetInstance();
            return employee.ObterEmployees();
        }

        public List<EmployeeBE> ObterEmployee(int p_EmpId)
        {
            IEmployee employee = EmployeeDAO.GetInstance();
            return employee.ObterEmployees(p_EmpId);
        }

        public void SalvarEmployees(string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_Comissao, int p_MngId, int p_DptId)
        {
            IEmployee employee = EmployeeDAO.GetInstance();
            employee.SalvarEmployees(p_FirstName, p_LastName, p_Email, p_FoneNum, p_HireDate, p_JobId, p_Salary, p_Comissao, p_MngId, p_DptId);
        }

        public void SalvarEmployees(string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_MngId, int p_DptId)
        {
            IEmployee employee = EmployeeDAO.GetInstance();
            employee.SalvarEmployees(p_FirstName, p_LastName, p_Email, p_FoneNum, p_HireDate, p_JobId, p_Salary, p_MngId, p_DptId);
        }

        public void AlterarEmployees(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_Comissao, int p_MngId, int p_DptId)
        {
            IEmployee employee = EmployeeDAO.GetInstance();
            employee.AlterarEmployee(p_EmpId, p_FirstName, p_LastName, p_Email, p_HireDate, p_FoneNum, p_JobId, p_Salary, p_Comissao, p_MngId, p_DptId);
        }
        public void AlterarEmployees(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_MngId, int p_DptId)
        {
            IEmployee employee = EmployeeDAO.GetInstance();
            employee.AlterarEmployee(p_EmpId, p_FirstName, p_LastName, p_Email, p_HireDate, p_FoneNum, p_JobId, p_Salary, p_MngId, p_DptId);
        }
        public void AlterarEmployees(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_DptId)
        {
            IEmployee employee = EmployeeDAO.GetInstance();
            employee.AlterarEmployee(p_EmpId, p_FirstName, p_LastName, p_Email, p_HireDate, p_FoneNum, p_JobId, p_Salary, p_DptId);
        }
    }
}
