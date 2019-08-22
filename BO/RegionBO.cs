using DAO;
using Entities;
using System.Collections.Generic;

namespace BO
{
    public class RegionBO
    {
        public List<RegionBE> ObterListaRegion()
        {
            var region = RegionDAO.GetInstance();
            return region.ObterRegion();
        }

        public List<RegionBE> ObterListaRegion(long RegionID)
        {
            var region = RegionDAO.GetInstance();
            return region.ObterRegion(RegionID);
        }

        public void SalvarAlteracoesRegion(long pRegionID, string pRegionName)
        {
            var region = RegionDAO.GetInstance();
            region.SalvarAlteracoesRegion(pRegionID, pRegionName);
        }

        public void SalvarRegion(string pRegionName)
        {
            var region = RegionDAO.GetInstance();
            region.SalvarRegion(pRegionName);
        }
    }
}
