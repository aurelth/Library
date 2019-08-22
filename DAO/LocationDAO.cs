using Interfaces;
using Entities;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class LocationDAO:BaseDAO<LocationDAO>, ILocation
    {
        public List<LocationBE> ObterLocation()
        {
            List<LocationBE> locations = new List<LocationBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_LOCATION";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            cmd.Parameters.Add(Cursor);
            IDataReader retorno = cmd.ExecuteReader();

            while(retorno.Read())
            {
                LocationBE obtendo = new LocationBE();

                obtendo.LocationId = ObterValor<int>(retorno["LOCATION_ID"]);
                obtendo.StreetAddress = ObterValor<string>(retorno["STREET_ADDRESS"]);
                obtendo.PostalCod = ObterValor<string>(retorno["POSTAL_CODE"]);
                obtendo.City = ObterValor<string>(retorno["CITY"]);
                obtendo.State = ObterValor<string>(retorno["STATE_PROVINCE"]);
                obtendo.CountryId = ObterValor<string>(retorno["COUNTRY_ID"]);
                obtendo.CountryName = ObterValor<string>(retorno["COUNTRY_NAME"]);
                locations.Add(obtendo);
            };

            conn.Dispose();
            return locations;
        }

        public List<LocationBE> ObterLocation(int p_LocId)
        {
            List<LocationBE> locations = new List<LocationBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_LOCATION_POR_ID";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            OracleParameter location = new OracleParameter();
            location.ParameterName = "p_Location";
            location.Direction = ParameterDirection.Input;
            location.OracleDbType = OracleDbType.Long;
            location.Value = p_LocId;

            cmd.Parameters.Add(Cursor);
            cmd.Parameters.Add(location);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                LocationBE obtendo = new LocationBE();

                obtendo.LocationId = ObterValor<int>(retorno["LOCATION_ID"]);
                obtendo.StreetAddress = ObterValor<string>(retorno["STREET_ADDRESS"]);
                obtendo.PostalCod = ObterValor<string>(retorno["POSTAL_CODE"]);
                obtendo.City = ObterValor<string>(retorno["CITY"]);
                obtendo.State = ObterValor<string>(retorno["STATE_PROVINCE"]);
                obtendo.CountryId = ObterValor<string>(retorno["COUNTRY_ID"]);
                obtendo.CountryName = ObterValor<string>(retorno["COUNTRY_NAME"]);
                locations.Add(obtendo);
            };
            conn.Dispose();
            return locations;
        }

        public void SalvarLoc(string pStreet, string pCodPost,string pCity,string pState,string pCountryId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_IN_LOCATION";
            cmd.CommandType = CommandType.StoredProcedure;
      
            OracleParameter street = new OracleParameter();
            street.ParameterName = "P_STREET";
            street.Direction = ParameterDirection.Input;
            street.OracleDbType = OracleDbType.Long;
            street.Value = pStreet;
            OracleParameter codPost = new OracleParameter();
            codPost.ParameterName = "P_CODPOST";
            codPost.Direction = ParameterDirection.Input;
            codPost.OracleDbType = OracleDbType.Long;
            codPost.Value = pCodPost;
            OracleParameter city = new OracleParameter();
            city.ParameterName = "P_CITY";
            city.Direction = ParameterDirection.Input;
            city.OracleDbType = OracleDbType.Long;
            city.Value = pCity;
            OracleParameter state = new OracleParameter();
            state.ParameterName = "P_STATE";
            state.Direction = ParameterDirection.Input;
            state.OracleDbType = OracleDbType.Long;
            state.Value = pState;
            OracleParameter country = new OracleParameter();
            country.ParameterName = "P_COUNTRYID";
            country.Direction = ParameterDirection.Input;
            country.OracleDbType = OracleDbType.Long;
            country.Value = pCountryId;

            cmd.Parameters.Add(street);
            cmd.Parameters.Add(codPost);
            cmd.Parameters.Add(city);
            cmd.Parameters.Add(state);
            cmd.Parameters.Add(country);
            
            cmd.ExecuteNonQuery();
            conn.Dispose();            
        }

        public void AlterarLoc(int pLocId, string pStreet, string pCodPost, string pCity, string pState, string pCountryId)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_UP_LOCATION";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter location = new OracleParameter();
            location.ParameterName = "P_LOCATIONID";
            location.Direction = ParameterDirection.Input;
            location.OracleDbType = OracleDbType.Long;
            location.Value = pLocId;
            OracleParameter street = new OracleParameter();
            street.ParameterName = "P_STREET";
            street.Direction = ParameterDirection.Input;
            street.OracleDbType = OracleDbType.Long;
            street.Value = pStreet;
            OracleParameter codPost = new OracleParameter();
            codPost.ParameterName = "P_CODPOST";
            codPost.Direction = ParameterDirection.Input;
            codPost.OracleDbType = OracleDbType.Long;
            codPost.Value = pCodPost;
            OracleParameter city = new OracleParameter();
            city.ParameterName = "P_CITY";
            city.Direction = ParameterDirection.Input;
            city.OracleDbType = OracleDbType.Long;
            city.Value = pCity;
            OracleParameter state = new OracleParameter();
            state.ParameterName = "P_STATE";
            state.Direction = ParameterDirection.Input;
            state.OracleDbType = OracleDbType.Long;
            state.Value = pState;
            OracleParameter country = new OracleParameter();
            country.ParameterName = "P_COUNTRYID";
            country.Direction = ParameterDirection.Input;
            country.OracleDbType = OracleDbType.Long;
            country.Value = pCountryId;

            cmd.Parameters.Add(location);
            cmd.Parameters.Add(street);
            cmd.Parameters.Add(codPost);
            cmd.Parameters.Add(city);
            cmd.Parameters.Add(state);
            cmd.Parameters.Add(country);

            cmd.ExecuteNonQuery();
            conn.Dispose();
        }
    }
}
