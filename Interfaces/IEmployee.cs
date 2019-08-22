using Entities;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEmployee
    {
        List<EmployeeBE> ObterEmployees();
        List<EmployeeBE> ObterEmployees(int p_EmpId);

        void SalvarEmployees(string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_Comissao, int p_MngId, int p_DptId);

        void SalvarEmployees(string p_FirstName, string p_LastName, string p_Email, string p_FoneNum, DateTime p_HireDate, string p_JobId, int p_Salary, int p_MngId, int p_DptId);

        void AlterarEmployee(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, DateTime p_FoneNum, string p_HireDate, string p_JobId, int p_Salary, int p_Comissao, int p_MngId, int p_DptId);
        
        void AlterarEmployee(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, DateTime p_FoneNum, string p_HireDate, string p_JobId, int p_Salary, int p_MngId, int p_DptId);

        void AlterarEmployee(int p_EmpId, string p_FirstName, string p_LastName, string p_Email, DateTime p_FoneNum, string p_HireDate, string p_JobId, int p_Salary, int p_DptId);
    }
}
