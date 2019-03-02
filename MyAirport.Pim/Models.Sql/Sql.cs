using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using MyAirport.Pim.Entities;

namespace MyAirport.Pim.Models
{
    public class Sql : AbstractDefinition
    {
        string strCnx = ConfigurationManager.ConnectionStrings["MyAirport.Pim.Settings.DbConnect"].ConnectionString;

        string commandGetBagageId = "SELECT NOM, b.ID_BAGAGE, b.CODE_IATA, b.COMPAGNIE, b.LIGNE, b.DATE_CREATION, b.DESTINATION, b.PRIORITAIRE,"
            + " b.ESCALE, b.CLASSE, b.CONTINUATION, bp.ID_PARTICULARITE, cast(iif(bp.ID_PARTICULARITE is null, 0, 1) as bit) as 'RUSH'"
            + " from COMPAGNIE, BAGAGE b"
            + " left outer join BAGAGE_A_POUR_PARTICULARITE bp on bp.ID_BAGAGE = b.ID_BAGAGE and bp.ID_PARTICULARITE = 15"
            + " left outer join COMPAGNIE c on COMPAGNIE = c.CODE_IATA"
            + " where b.id_bagage = @id_bagage";

        string commandGetBagageIata = "SELECT NOM, b.ID_BAGAGE, b.CODE_IATA, b.COMPAGNIE, b.LIGNE, b.DATE_CREATION, b.DESTINATION, b.PRIORITAIRE,"
            + " b.ESCALE, b.CLASSE, b.CONTINUATION, bp.ID_PARTICULARITE, cast(iif(bp.ID_PARTICULARITE is null, 0, 1) as bit) as 'RUSH'"
            + " from BAGAGE b"
            + " left outer join BAGAGE_A_POUR_PARTICULARITE bp on bp.ID_BAGAGE = b.ID_BAGAGE and bp.ID_PARTICULARITE = 15"
            + " left outer join COMPAGNIE c on COMPAGNIE = c.CODE_IATA"
            + " where SUBSTRING(b.code_iata, 5, 6) like @code_iata"; // This line makes the request accept 6 characters of codeIata
            // + " where b.code_iata = @code_iata"; // This line makes it only accept full codeIata

        string commandGetCompagnieClasse = "SELECT CLASSE, PRIORITAIRE"
            + " from COMPAGNIE c left outer join COMPAGNIE_CLASSE cc on c.ID_COMPAGNIE = cc.ID_COMPAGNIE"
            + " where CODE_IATA = @compagnieAlpha;";

        string commandCreateBagage = "INSERT into BAGAGE (CODE_IATA, ORIGINE_CREATION, DATE_CREATION, CLASSE, PRIORITAIRE, ISUR, DESTINATION, ESCALE, EMB, RECOLE, COMPAGNIE, LIGNE, JOUR_EXPLOITATION, CONTINUATION, ORIGINE_SAFIR, EN_CONTINUATION, EN_TRANSFERT)"
        + " values(@codeIata, 'D', GETDATE(), @classe, @prioritaire, 0, @escale, @escale, 1, 0, @compagnie, @ligne, @jourExploitation, @continuation, 0, 0, 0);";

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
                        CodeIata = sdr.GetString(sdr.GetOrdinal("CODE_IATA")),
                        EnContinuation = sdr.GetString(sdr.GetOrdinal("CONTINUATION")).Equals("Y"),
                        Ligne = sdr.GetString(sdr.GetOrdinal("LIGNE")),
                        NomCompagnie = sdr.GetString(sdr.GetOrdinal("NOM")),
                        Compagnie = sdr.GetString(sdr.GetOrdinal("COMPAGNIE")),
                        DateVol = sdr.GetDateTime(sdr.GetOrdinal("DATE_CREATION")),
                        ClasseBagage = sdr["CLASSE"] is DBNull ? "Y" : Convert.ToString(sdr["CLASSE"]),
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

            // Deals with 12 digits IATA
            // If 12 digits, just keep the 6 of interest
            
            if (codeIataBagage.Length.Equals(12))
            { codeIataBagage = "%" + codeIataBagage.Substring(4,6) + "%"; }
            

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
                        // IdBagage = sdr.GetString(sdr.GetOrdinal("ID_BAGAGE")),
                        CodeIata = sdr.GetString(sdr.GetOrdinal("CODE_IATA")),
                        EnContinuation = sdr.GetString(sdr.GetOrdinal("CONTINUATION")).Equals("Y"),
                        Ligne = sdr.GetString(sdr.GetOrdinal("LIGNE")),
                        NomCompagnie = sdr.GetString(sdr.GetOrdinal("NOM")),
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

            if (listBagRes.Count > 1)
            {
                throw new ApplicationException();
            }

            return listBagRes.Count == 0 ? null : listBagRes;
        }

        private Dictionary<string, int> GetCompagnieClasses(string compagnieAlpha)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(commandGetCompagnieClasse, cnx);
                cmd.Parameters.AddWithValue("@compagnieAlpha", compagnieAlpha);
                cnx.Open();
                SqlDataReader sdr = cmd.ExecuteReader();


                // Call Read before accessing data.
                while (sdr.Read())
                {
                    var record = (IDataRecord) sdr;
                    string classe = Convert.ToString(record[0]);
                    int prioritaire = Convert.ToInt32(record[1]);
                    res.Add(classe, prioritaire);
                }

                // Call Close when done reading.
                sdr.Close();
            }

            return res;
        }

        public override string InsertBagage(string codeIata, bool continuation, string ligne, string nomCompagnie, string compagnie, string jourExploitation, string classeBagage, string escale, bool rush)
        {
            string res = "";
            bool userError = false;

            // Check that codeIata length is lower or equal than 12 chars and that it terminates by "00"
            if (codeIata.Length > 12)
            {
                userError = true;
                res = "CodeIata a plus de 12 caractères";
            }
            else
            {
                while (codeIata.Length < 12)
                {
                    codeIata += '0';
                }
            }

            // Check that classeBagage is valid in regard to compagnie (if this flag is valid for this company)
            Dictionary<string, int> compagnieClasses = GetCompagnieClasses(compagnie);

            if (!compagnieClasses.ContainsKey(classeBagage))
            {
                userError = true;
                res = res.Equals("") ? res + "Classe '" + classeBagage + "' invalide" : ", classe " + classeBagage + " invalide";
            }

            // Optionnally : Check that nomCompagnie is the full name of the compagnie with codeIata compagnie
            
            if (userError)
            {
                return res;
            }

            SqlConnection cnx = new SqlConnection(strCnx);
            cnx.Open();
            SqlTransaction transaction = cnx.BeginTransaction();
            SqlCommand cmd = new SqlCommand(commandCreateBagage, cnx, transaction);
            cmd.Parameters.AddWithValue("@codeIata", codeIata);
            cmd.Parameters.AddWithValue("@classe", classeBagage);
            cmd.Parameters.AddWithValue("@prioritaire", compagnieClasses[classeBagage]);
            cmd.Parameters.AddWithValue("@escale", escale);
            cmd.Parameters.AddWithValue("@compagnie", compagnie);
            cmd.Parameters.AddWithValue("@ligne", ligne);
            cmd.Parameters.AddWithValue("@jourExploitation", jourExploitation);
            cmd.Parameters.AddWithValue("@continuation", continuation ? "Y" : "N");
            // Execute the command
            if (cmd.ExecuteNonQuery() != 0)
            {
                // If some rows were inserted, then it is good and we commit
                transaction.Commit();
                return "Création OK";
            }

            // If nothing was inserted, there was an error somewhere and we rollback
            transaction.Rollback();
            return "Erreur lors de l'insertion en base";
        }
    }
}