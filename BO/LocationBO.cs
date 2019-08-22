using Entities;
using DAO;
using Interfaces;
using System.Collections.Generic;

namespace BO
{
    public class LocationBO
    {
        public List<LocationBE> ObterLocation()
        {
            ILocation location = LocationDAO.GetInstance();
            return location.ObterLocation();
        }

        public List<LocationBE> ObterLocation(int p_locId)
        {
            ILocation location = LocationDAO.GetInstance();
            return location.ObterLocation(p_locId);
        }

        public void SalvarLocation(string pStreet, string pCodPost, string pCity, string pState, string pCountryId)
        {
            ILocation location = LocationDAO.GetInstance();
            location.SalvarLoc(pStreet, pCodPost, pCity, pState, pCountryId);
        }

        public void AlterarLocation(int pLocId, string pStreet, string pCodPost, string pCity, string pState, string pCountryId)
        {
            ILocation location = LocationDAO.GetInstance();
            location.AlterarLoc(pLocId, pStreet, pCodPost, pCity, pState, pCountryId);
        }

        public List<CountryBE> ObterCountry()
        {
            ICountry country = CountryDAO.GetInstance();
            return country.ObterCountry();
        }
    }
}
