using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IDepartment
    {
        List<DepartmentBE> ObterDepart();
        List<DepartmentBE> ObterDepart(int pDepartID);
        List<EmployeeBE> ObterEmployee();

        void SalvarDep(string departName, int pManagerId, int pLocatId);
        void SalvarDep(string departName, int pLocatId);

        void AlterarDep(int pDepartId, string departName, int pManagerId, int pLocatId);
        void AlterarDep(int pDepartId, string departName, int pLocatId);
    }
}
