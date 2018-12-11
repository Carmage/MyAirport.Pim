using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAirport.Pim.Entities;

namespace MyAirport.Pim.Models
{
    public class Sql : AbstractDefinition
    {
        //string strCnx = ConfigurationManager.ConnectionStrings["MyAirport.Pim.Settings.DbConnect"].ConnectionString;
        string strCnx = "Data Source=DESKTOP-8COAIAC\\SQLEXPRESS;Initial Catalog=MyAirport;Integrated Security=True";

        string commandGetBagageId = "SELECT b.ID_BAGAGE, b.CODE_IATA, b.COMPAGNIE, b.LIGNE, b.DATE_CREATION,"
            + " b.ESCALE, b.CLASSE, b.CONTINUATION, bp.ID_PARTICULARITE, cast(iif(bp.ID_PARTICULARITE is null, 0, 1) as bit) as 'RUSH'"
            + " from BAGAGE b"
            + " left outer join BAGAGE_A_POUR_PARTICULARITE bp on bp.ID_BAGAGE = b.ID_BAGAGE and bp.ID_PARTICULARITE = 15"
            + " where b.id_bagage = @id_bagage";

        string commandGetBagageIata = "SELECT b.ID_BAGAGE, b.CODE_IATA, b.COMPAGNIE, b.LIGNE, b.DATE_CREATION,"
            + " b.ESCALE, b.CLASSE, b.CONTINUATION, bp.ID_PARTICULARITE, cast(iif(bp.ID_PARTICULARITE is null, 0, 1) as bit) as 'RUSH'"
            + " from BAGAGE b"
            + " left outer join BAGAGE_A_POUR_PARTICULARITE bp on bp.ID_BAGAGE = b.ID_BAGAGE and bp.ID_PARTICULARITE = 15"
            + " where b.code_iata = @code_iata";

        public override BagageDefinition GetBagage(int idBagage)
        {
            BagageDefinition bagRes = null;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(commandGetBagageId, cnx);
                cmd.Parameters.AddWithValue("@id_bagage", idBagage);
                cnx.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    bagRes = new BagageDefinition()
                    {
                        IdBagage = sdr.GetInt32(sdr.GetOrdinal("ID_BAGAGE")),
                        CodeIata = sdr.GetString(sdr.GetOrdinal("CODE_IATA")),
                        EnContinuation = sdr.GetBoolean(sdr.GetOrdinal("CONTINUATION"))
                    };
                }
            }
            return bagRes;
        }

        public override List<BagageDefinition> GetBagage(string codeIataBagage)
        {
            List<BagageDefinition> listBagRes = new List<BagageDefinition>();
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(commandGetBagageIata, cnx);
                cmd.Parameters.AddWithValue("@code_iata", codeIataBagage);
                cnx.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    listBagRes.Add(new BagageDefinition()
                    {
                        IdBagage = sdr.GetInt32(sdr.GetOrdinal("ID_BAGAGE")),
                        CodeIata = sdr.GetString(sdr.GetOrdinal("CODE_IATA")),
                        EnContinuation = sdr.GetBoolean(sdr.GetOrdinal("CONTINUATION"))
                    });
                }
            }
            return listBagRes;
        }
    }
}
