using System.Collections.Generic;
using Entities;
using Interfaces;
using DAO;


namespace BO
{
    public class DepartmentBO
    {
        public List<LocationBE> ObterLocation()
        {
            ILocation location = LocationDAO.GetInstance();
            return location.ObterLocation();
        }

        public List<EmployeeBE> ObterEmployee()
        {
            IDepartment department = DepartDAO.GetInstance();
            return department.ObterEmployee();
        }

        public List<DepartmentBE> ObterDepart()
        {
            IDepartment department = DepartDAO.GetInstance();
            return department.ObterDepart();
        }

        public List<DepartmentBE> ObterDepart(int p_DepartId)
        {
            IDepartment department = DepartDAO.GetInstance();
            return department.ObterDepart(p_DepartId);
        }

        public void AlterarDepart(int p_DepartId, string p_departName, int p_ManagerId, int p_LocatId)
        {
            IDepartment department = DepartDAO.GetInstance();
            department.AlterarDep(p_DepartId, p_departName, p_ManagerId, p_LocatId);
        }

        public void AlterarDepart(int p_DepartId, string p_departName, int p_LocatId)
        {
            IDepartment department = DepartDAO.GetInstance();
            department.AlterarDep(p_DepartId, p_departName, p_LocatId);
        }

        public void SalvarDepart(string p_departName, int p_ManagerId, int p_LocatId)
        {
            IDepartment department = DepartDAO.GetInstance();
            department.SalvarDep(p_departName, p_ManagerId, p_LocatId);
        }

        public void SalvarDepart(string p_departName, int p_LocatId)
        {
            IDepartment department = DepartDAO.GetInstance();
            department.SalvarDep(p_departName, p_LocatId);
        }
    }
}
