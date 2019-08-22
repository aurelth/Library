using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRegion
    {
        List<RegionBE> ObterRegion();
        List<RegionBE> ObterRegion(long RegionID);

        void SalvarAlteracoesRegion(long pRegionID, string pRegionName);
        void SalvarRegion(string pRegionName);
    }

}
