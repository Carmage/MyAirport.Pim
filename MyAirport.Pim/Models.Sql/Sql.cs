using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MyAirport.Pim.Entities;

namespace MyAirport.Pim.Models
{
    public class Sql : AbstractDefinition
    {
        //string strCnx = ConfigurationManager.ConnectionStrings["MyAirport.Pim.Settings.DbConnect"].ConnectionString;
        string strCnx = "Data Source=DESKTOP-CG3AG4S\\SQLEXPRESS;Initial Catalog=MyAirport;Integrated Security=True";

        string commandGetBagageId = "SELECT b.ID_BAGAGE, b.CODE_IATA, b.COMPAGNIE, b.LIGNE, b.DATE_CREATION, b.DESTINATION, b.PRIORITAIRE,"
            + " b.ESCALE, b.CLASSE, b.CONTINUATION, bp.ID_PARTICULARITE, cast(iif(bp.ID_PARTICULARITE is null, 0, 1) as bit) as 'RUSH'"
            + " from BAGAGE b"
            + " left outer join BAGAGE_A_POUR_PARTICULARITE bp on bp.ID_BAGAGE = b.ID_BAGAGE and bp.ID_PARTICULARITE = 15"
            + " where b.id_bagage = @id_bagage";

        string commandGetBagageIata = "SELECT b.ID_BAGAGE, b.CODE_IATA, b.COMPAGNIE, b.LIGNE, b.DATE_CREATION, b.DESTINATION, b.PRIORITAIRE,"
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
                        EnContinuation = sdr.GetString(sdr.GetOrdinal("CONTINUATION")).Equals("1"),
                        Ligne = sdr.GetString(sdr.GetOrdinal("LIGNE")),
                        Compagnie = sdr.GetString(sdr.GetOrdinal("COMPAGNIE")),
                        DateVol = sdr.GetDateTime(sdr.GetOrdinal("DATE_CREATION")),
                        Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("PRIORITAIRE")),
                        Itineraire = sdr.GetString(sdr.GetOrdinal("ESCALE"))
                    };
                }
            }

            Console.WriteLine(bagRes.ToString());
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
                    // Treatment for EnContinuation
                    String curEnContinuation = sdr.GetString(sdr.GetOrdinal("CONTINUATION"));
                    bool curBoolEnContinuation = curEnContinuation.Equals("Y");

                    listBagRes.Add(new BagageDefinition()
                    {
                        IdBagage = sdr.GetInt32(sdr.GetOrdinal("ID_BAGAGE")),
                        CodeIata = sdr.GetString(sdr.GetOrdinal("CODE_IATA")),
                        EnContinuation = curBoolEnContinuation,
                        Ligne = sdr.GetString(sdr.GetOrdinal("LIGNE")),
                        Compagnie = sdr.GetString(sdr.GetOrdinal("COMPAGNIE")),
                        DateVol = sdr.GetDateTime(sdr.GetOrdinal("DATE_CREATION")),
                        Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("PRIORITAIRE")),
                        Itineraire = sdr.GetString(sdr.GetOrdinal("ESCALE"))
                    });
                }

                Console.WriteLine("GetBagage returned :");

                foreach (BagageDefinition b in listBagRes)
                {
                    Console.WriteLine("\t" + b.ToString());
                }
            }
            return listBagRes;
        }
    }
}