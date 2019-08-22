using Entities;
using Interfaces;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class RegionDAO:BaseDAO<RegionDAO>, IRegion
    {
        public List<RegionBE> ObterRegion()
        {
            List<RegionBE> result = new List<RegionBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SP_SE_REGIONS";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            cmd.Parameters.Add(Cursor);
            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                RegionBE obtendo = new RegionBE();

                obtendo.RegionID = ObterValor<long>(retorno["REGION_ID"]);
                obtendo.RegionName = ObterValor<string>(retorno["REGION_NAME"]);

                result.Add(obtendo);
            }

            conn.Dispose();

            return result;
        }

        public List<RegionBE> ObterRegion(long p_regionid)
        {
            List<RegionBE> result = new List<RegionBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_SE_REGIONS_POR_ID";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter Cursor = new OracleParameter();
            Cursor.ParameterName = "p_CURSOR";
            Cursor.Direction = ParameterDirection.Output;
            Cursor.OracleDbType = OracleDbType.RefCursor;

            OracleParameter region = new OracleParameter();
            region.ParameterName = "p_RegionID";
            region.Direction = ParameterDirection.Input;
            region.OracleDbType = OracleDbType.Long;
            region.Value = p_regionid;

            cmd.Parameters.Add(Cursor);
            cmd.Parameters.Add(region);

            IDataReader retorno = cmd.ExecuteReader();

            while (retorno.Read())
            {
                RegionBE obtendo = new RegionBE();

                obtendo.RegionID = ObterValor<long>(retorno["REGION_ID"]);
                obtendo.RegionName = ObterValor<string>(retorno["REGION_NAME"]);

                result.Add(obtendo);
            }

            conn.Dispose();

            return result;
        }

        public void SalvarRegion(string pRegionName)
        {
            List<RegionBE> result = new List<RegionBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SP_IN_REGIONS";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter RegionName = new OracleParameter();
            RegionName.ParameterName = "p_region_name";
            RegionName.Direction = ParameterDirection.Input;
            RegionName.OracleDbType = OracleDbType.Varchar2;
            RegionName.Value = pRegionName;

            cmd.Parameters.Add(RegionName);

            cmd.ExecuteNonQuery();

            conn.Dispose();
        }

        public void SalvarAlteracoesRegion(long pRegionID, string pRegionName)
        {
            List<RegionBE> result = new List<RegionBE>();

            OracleConnection conn = new OracleConnection(oradb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SP_UP_REGIONS";
            cmd.CommandType = CommandType.StoredProcedure;

            OracleParameter RegionID = new OracleParameter();
            RegionID.ParameterName = "p_region_id";
            RegionID.Direction = ParameterDirection.Input;
            RegionID.OracleDbType = OracleDbType.Decimal;
            RegionID.Value = pRegionID;

            OracleParameter RegionName = new OracleParameter();
            RegionName.ParameterName = "p_region_name";
            RegionName.Direction = ParameterDirection.Input;
            RegionName.OracleDbType = OracleDbType.Varchar2;
            RegionName.Value = pRegionName;

            cmd.Parameters.Add(RegionID);
            cmd.Parameters.Add(RegionName);

            cmd.ExecuteNonQuery();

            conn.Dispose();
        }
    }
}
