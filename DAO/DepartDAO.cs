using Interfaces;
using Entities;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Data;

namespace DAO
{
    public class DepartDAO:BaseDAO<DepartDAO>, IDepartment
    {
        public List<DepartmentBE> ObterDepart()
        {
            List<DepartmentBE> departments = new List<DepartmentBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_DEPART";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            cmd.Parameters.Add(Cursor);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                DepartmentBE obtendo = new DepartmentBE();

                obtendo.DepId = ObterValor<int>(retorno["DEPARTMENT_ID"]);
                obtendo.DepName = ObterValor<string>(retorno["DEPARTMENT_NAME"]);
                obtendo.LocatId = ObterValor<int>(retorno["LOCATION_ID"]);
                obtendo.LocatName = ObterValor<string>(retorno["STREET_ADDRESS"]);
                obtendo.ManagID = ObterValor<int>(retorno["MANAGER_ID"]);
                obtendo.ManagName = ObterValor<string>(retorno["LAST_NAME"]);
                departments.Add(obtendo);
            };

            conn.Dispose();
            return departments;
        }

        public List<DepartmentBE> ObterDepart(int p_DepartId)
        {
            List<DepartmentBE> departments = new List<DepartmentBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_DEPART_POR_ID";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            OracleParameter department = new OracleParameter();
            department.ParameterName = "p_DepartId";
            department.Direction = ParameterDirection.Input;
            department.OracleDbType = OracleDbType.Long;
            department.Value = p_DepartId;

            cmd.Parameters.Add(Cursor);
            cmd.Parameters.Add(department);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                DepartmentBE obtendo = new DepartmentBE();

                obtendo.DepId = ObterValor<int>(retorno["DEPARTMENT_ID"]);
                obtendo.DepName= ObterValor<string>(retorno["DEPARTMENT_NAME"]);
                obtendo.LocatId = ObterValor<int>(retorno["LOCATION_ID"]);
                obtendo.LocatName = ObterValor<string>(retorno["STREET_ADDRESS"]);
                obtendo.ManagID = ObterValor<int>(retorno["MANAGER_ID"]);
                obtendo.ManagName = ObterValor<string>(retorno["LAST_NAME"]);
                departments.Add(obtendo);
            };
            conn.Dispose();
            return departments;
        }

        public List<EmployeeBE> ObterEmployee()
        {
            List<EmployeeBE> employees = new List<EmployeeBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_EMPLOYEES_MNG";
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
                obtendo.LastName = ObterValor<string>(retorno["LAST_NAME"]);

                employees.Add(obtendo);
            };

            conn.Dispose();
            return employees;
        }

        public void SalvarDep(string departName, int pLocatId, int pManagerId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_IN_DEPART";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter depart = new OracleParameter();
            depart.ParameterName = "P_DEPARTNAME";
            depart.Direction = ParameterDirection.Input;
            depart.OracleDbType = OracleDbType.Long;
            depart.Value = departName;
            OracleParameter codPost = new OracleParameter();
            codPost.ParameterName = "P_MANAGERID";
            codPost.Direction = ParameterDirection.Input;
            codPost.OracleDbType = OracleDbType.Long;
            codPost.Value = pManagerId;
            OracleParameter city = new OracleParameter();
            city.ParameterName = "P_LOCID";
            city.Direction = ParameterDirection.Input;
            city.OracleDbType = OracleDbType.Long;
            city.Value = pLocatId;

            cmd.Parameters.Add(depart);
            cmd.Parameters.Add(codPost);
            cmd.Parameters.Add(city);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void SalvarDep(string departName, int pLocatId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_IN_DEPART_SEM_MNG";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter depart = new OracleParameter();
            depart.ParameterName = "P_DEPARTNAME";
            depart.Direction = ParameterDirection.Input;
            depart.OracleDbType = OracleDbType.Long;
            depart.Value = departName;
            OracleParameter local = new OracleParameter();
            local.ParameterName = "P_LOCID";
            local.Direction = ParameterDirection.Input;
            local.OracleDbType = OracleDbType.Long;
            local.Value = pLocatId;

            cmd.Parameters.Add(depart);  
            cmd.Parameters.Add(local);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void AlterarDep(int pDepartId, string departName, int pLocatId, int pManagerId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_UP_DEPART";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter depId = new OracleParameter();
            depId.ParameterName = "P_DEPID";
            depId.Direction = ParameterDirection.Input;
            depId.OracleDbType = OracleDbType.Long;
            depId.Value = pDepartId;
            OracleParameter depName = new OracleParameter();
            depName.ParameterName = "P_DEPNAME";
            depName.Direction = ParameterDirection.Input;
            depName.OracleDbType = OracleDbType.Long;
            depName.Value = departName;
            OracleParameter managId = new OracleParameter();
            managId.ParameterName = "P_MANAGID";
            managId.Direction = ParameterDirection.Input;
            managId.OracleDbType = OracleDbType.Long;
            managId.Value = pManagerId;
            OracleParameter locId = new OracleParameter();
            locId.ParameterName = "P_LOCATID";
            locId.Direction = ParameterDirection.Input;
            locId.OracleDbType = OracleDbType.Long;
            locId.Value = pLocatId;

            cmd.Parameters.Add(depId);
            cmd.Parameters.Add(depName);
            cmd.Parameters.Add(managId);
            cmd.Parameters.Add(locId);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }

        public void AlterarDep(int pDepartId, string departName, int pLocatId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_UP_DEPART_SEM_MNG";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter depId = new OracleParameter();
            depId.ParameterName = "P_DEPID";
            depId.Direction = ParameterDirection.Input;
            depId.OracleDbType = OracleDbType.Long;
            depId.Value = pDepartId;
            OracleParameter depName = new OracleParameter();
            depName.ParameterName = "P_DEPNAME";
            depName.Direction = ParameterDirection.Input;
            depName.OracleDbType = OracleDbType.Long;
            depName.Value = departName;
            OracleParameter locId = new OracleParameter();
            locId.ParameterName = "P_LOCATID";
            locId.Direction = ParameterDirection.Input;
            locId.OracleDbType = OracleDbType.Long;
            locId.Value = pLocatId;

            cmd.Parameters.Add(depId);
            cmd.Parameters.Add(depName);
            cmd.Parameters.Add(locId);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }
    }
}
