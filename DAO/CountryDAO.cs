using Interfaces;
using Entities;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class CountryDAO:BaseDAO<CountryDAO>, ICountry
    {
        public List<CountryBE> ObterCountry()
        {
            List<CountryBE> countries = new List<CountryBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_COUNTRY";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            cmd.Parameters.Add(Cursor);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                CountryBE obtendo = new CountryBE();

                obtendo.CountryId = ObterValor<string>(retorno["COUNTRY_ID"]);
                obtendo.CountryName = ObterValor<string>(retorno["COUNTRY_NAME"]);
                obtendo.RegionID = ObterValor<string>(retorno["REGION_ID"]);
                obtendo.RegionName = ObterValor<string>(retorno["REGION_NAME"]);
                countries.Add(obtendo);
            }

            conn.Dispose();

            return countries;
        }

        public List<CountryBE> ObterCountry(string p_countryid)
        {
            List<CountryBE> countries = new List<CountryBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_SE_COUNTRY_POR_ID";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            OracleParameter country = new OracleParameter();
            country.ParameterName = "p_RegionID";
            country.Direction = ParameterDirection.Input;
            country.OracleDbType = OracleDbType.Long;
            country.Value = p_countryid;

            cmd.Parameters.Add(Cursor);
            cmd.Parameters.Add(country);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                CountryBE obtendo = new CountryBE();

                obtendo.CountryId = ObterValor<string>(retorno["COUNTRY_ID"]);
                obtendo.CountryName = ObterValor<string>(retorno["COUNTRY_NAME"]);
                obtendo.RegionID = ObterValor<string>(retorno["REGION_ID"]);
                obtendo.RegionName = ObterValor<string>(retorno["REGION_NAME"]);

                countries.Add(obtendo);
            }

            conn.Dispose();

            return countries;
        }

        public void SalvarCountry(string pCountryId, string pCountryName, long pRegionID)
        {
            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_IN_COUNTRY";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter CountryID = new OracleParameter();
            CountryID.ParameterName = "pCountryId";
            CountryID.Direction = ParameterDirection.Input;
            CountryID.OracleDbType = OracleDbType.Char;
            CountryID.Value = pCountryId;

            OracleParameter CountryName = new OracleParameter();
            CountryName.ParameterName = "pCountryName";
            CountryName.Direction = ParameterDirection.Input;
            CountryName.OracleDbType = OracleDbType.Varchar2;
            CountryName.Value = pCountryName;

            OracleParameter RegionId = new OracleParameter();
            RegionId.ParameterName = "pRegionID";
            RegionId.Direction = ParameterDirection.Input;
            RegionId.OracleDbType = OracleDbType.Decimal;
            RegionId.Value = pRegionID;

            cmd.Parameters.Add(CountryID);
            cmd.Parameters.Add(CountryName);
            cmd.Parameters.Add(RegionId);

            cmd.ExecuteNonQuery();

            conn.Dispose();
        }

        public void AlterarCountry(string pCountryId , string pCountryName, long pRegionID)
        {
            List<RegionBE> result = new List<RegionBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "IGOR_SP_UP_COUNTRY";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter CountryID = new OracleParameter();
            CountryID.ParameterName = "pCountryId";
            CountryID.Direction = ParameterDirection.Input;
            CountryID.OracleDbType = OracleDbType.Char;
            CountryID.Value = pCountryId;

            OracleParameter CountryName = new OracleParameter();
            CountryName.ParameterName = "pCountryName";
            CountryName.Direction = ParameterDirection.Input;
            CountryName.OracleDbType = OracleDbType.Varchar2;
            CountryName.Value = pCountryName;

            OracleParameter RegionId = new OracleParameter();
            RegionId.ParameterName = "pRegionID";
            RegionId.Direction = ParameterDirection.Input;
            RegionId.OracleDbType = OracleDbType.Decimal;
            RegionId.Value = pRegionID;

            cmd.Parameters.Add(CountryID);
            cmd.Parameters.Add(CountryName);
            cmd.Parameters.Add(RegionId);

            cmd.ExecuteNonQuery();

            conn.Dispose();
        }
    }

}
