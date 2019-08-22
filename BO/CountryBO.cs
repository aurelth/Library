using Interfaces;
using DAO;
using Entities;
using System.Collections.Generic;

namespace BO
{
    public class CountryBO
    {
        public List<CountryBE> ObterCountry()
        {
            ICountry country = CountryDAO.GetInstance();
            return country.ObterCountry();
        }

        public List<CountryBE> ObterCountry(string p_countryid)
        {
            ICountry country = CountryDAO.GetInstance();
            return country.ObterCountry(p_countryid);
        }

        public void SalvarCountry(string pCountryId, string pCountryName, long pRegionID)
        {
            ICountry country = CountryDAO.GetInstance();
            country.SalvarCountry(pCountryId, pCountryName, pRegionID);
        }

        public void AlterarCountry(string pCountryId, string pCountryName, long pRegionID)
        {
            ICountry country = CountryDAO.GetInstance();
            country.AlterarCountry(pCountryId, pCountryName, pRegionID);
        }
    }
}
