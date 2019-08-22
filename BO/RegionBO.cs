using DAO;
using Entities;
using Interfaces;
using System.Collections.Generic;

namespace BO
{
    public class RegionBO
    {
        public List<RegionBE> ObterListaRegion()
        {
            IRegion region = RegionDAO.GetInstance();
            return region.ObterRegion();
        }

        public List<RegionBE> ObterListaRegion(long RegionID)
        {
            IRegion region = RegionDAO.GetInstance();
            return region.ObterRegion(RegionID);
        }

        public void SalvarAlteracoesRegion(long pRegionID, string pRegionName)
        {
            IRegion region = RegionDAO.GetInstance();
            region.SalvarAlteracoesRegion(pRegionID, pRegionName);
        }

        public void SalvarRegion(string pRegionName)
        {
            IRegion region = RegionDAO.GetInstance();
            region.SalvarRegion(pRegionName);
        }
    }
}
