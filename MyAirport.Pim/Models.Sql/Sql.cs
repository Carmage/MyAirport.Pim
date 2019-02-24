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

        string commandGetNomCompagnie = "SELECT NOM"
            + " from dbo.COMPAGNIE"
            + " where CODE_IATA = @code_iata_compagnie;";

        // Unused unless precised by teacher (email sent on the 24 feb 2019 at 00:10)
        string commandGetPrioritaire = "SELECT PRIORITAIRE"
            + " from COMPAGNIE_CLASSE cc left outer join COMPAGNIE c on c.ID_COMPAGNIE = cc.ID_COMPAGNIE"
            + " where c.ID_COMPAGNIE = @id_compagnie and CLASSE = @classe_bagage;";

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
                        EnContinuation = sdr.GetString(sdr.GetOrdinal("CONTINUATION")).Equals("Y"),
                        Ligne = sdr.GetString(sdr.GetOrdinal("LIGNE")),
                        Compagnie = sdr.GetString(sdr.GetOrdinal("COMPAGNIE")),
                        DateVol = sdr.GetDateTime(sdr.GetOrdinal("DATE_CREATION")),
                        ClasseBagage = sdr.GetString(sdr.GetOrdinal("CLASSE")),
                        Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("PRIORITAIRE")),
                        Itineraire = sdr.GetString(sdr.GetOrdinal("ESCALE")),
                        Rush = sdr.GetBoolean(sdr.GetOrdinal("RUSH"))
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
                    listBagRes.Add(new BagageDefinition()
                    {
                        IdBagage = sdr.GetInt32(sdr.GetOrdinal("ID_BAGAGE")),
                        CodeIata = sdr.GetString(sdr.GetOrdinal("CODE_IATA")),
                        EnContinuation = sdr.GetString(sdr.GetOrdinal("CONTINUATION")).Equals("Y"),
                        Ligne = sdr.GetString(sdr.GetOrdinal("LIGNE")),
                        Compagnie = sdr.GetString(sdr.GetOrdinal("COMPAGNIE")),
                        DateVol = sdr.GetDateTime(sdr.GetOrdinal("DATE_CREATION")),
                        ClasseBagage = sdr["CLASSE"] is DBNull ? "Y" : Convert.ToString(sdr["CLASSE"]),
                        Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("PRIORITAIRE")),
                        Itineraire = sdr.GetString(sdr.GetOrdinal("ESCALE")),
                        Rush = sdr.GetBoolean(sdr.GetOrdinal("RUSH"))
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

        public override string GetNomCompagnieFromIata(string codeIataCompagnie)
        {
            string nomCompagnie = null;

            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(commandGetNomCompagnie, cnx);
                cmd.Parameters.AddWithValue("@code_iata_compagnie", codeIataCompagnie);
                cnx.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    nomCompagnie = sdr.GetString(sdr.GetOrdinal("NOM"));
                }
            }

            return nomCompagnie;
        }
    }
}