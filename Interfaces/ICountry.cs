using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICountry
    {
        List<CountryBE> ObterCountry();
        List<CountryBE> ObterCountry(string p_countryid);

        void SalvarCountry(string pCountryId, string pCountryName, long pRegionID); 
        void AlterarCountry(string pCountryId, string pCountryName, long pRegionID);
    }
}
