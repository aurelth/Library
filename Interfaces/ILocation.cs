using Entities;
using System.Collections.Generic;


namespace Interfaces
{
    public interface ILocation
    {
        List<LocationBE> ObterLocation();
        List<LocationBE> ObterLocation(int p_LocId);

        void SalvarLoc(string pStreet, string pCodPost, string pCity, string pState, string pCountryId);
        void AlterarLoc(int pLocId, string pStreet, string pCodPost, string pCity, string pState, string pCountryId);
    }
}
