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

        string commandGetCompagnieClasse = "SELECT CLASSE, PRIORITAIRE"
            + " from COMPAGNIE c left outer join COMPAGNIE_CLASSE cc on c.ID_COMPAGNIE = cc.ID_COMPAGNIE"
            + " where CODE_IATA = @compagnieAlpha;";

        string commandCreateBagage = "INSERT into BAGAGE (CODE_IATA, ORIGINE_CREATION, DATE_CREATION, CLASSE, PRIORITAIRE, ISUR, DESTINATION, ESCALE, EMB, RECOLE, COMPAGNIE, LIGNE, JOUR_EXPLOITATION, CONTINUATION, ORIGINE_SAFIR, EN_CONTINUATION, EN_TRANSFERT)"
        + " output inserted.Id_BAGAGE"
        + " values(@codeIata, 'D', GETDATE(), @classe, @prioritaire, 0, @escale, @escale, 1, 0, @compagnie, @ligne, @jourExploitation, @continuation, 0, 0, 0);";

        string commandCreateBagageParticularite = "INSERT into BAGAGE_A_POUR_PARTICULARITE (ID_BAGAGE, ID_PARTICULARITE)"
            + " output inserted.ID_BAGAGE"
            + " values(@insertedIdBagage, 15);";

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

        public override BagageDefinition GetBagage(string codeIataBagage)
        {
            if (codeIataBagage.Length.Equals(12))
            {
                codeIataBagage = "%" + codeIataBagage.Substring(4, 6) + "%";
            }

            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(commandGetBagageIata, cnx);
                cmd.Parameters.AddWithValue("@code_iata", codeIataBagage);
                cnx.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                BagageDefinition res = null;

                if (sdr.Read())
                {
                    res = new BagageDefinition()
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
                    };

                    // If some more bagages were found, raise an exception
                    if (sdr.Read())
                    {
                        throw new ApplicationException();
                    }

                    return res;
                }
            }

            return null;
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

                while (sdr.Read())
                {
                    var record = (IDataRecord)sdr;
                    string classe = Convert.ToString(record[0]);
                    int prioritaire = Convert.ToInt32(record[1]);
                    res.Add(classe, prioritaire);
                }

                sdr.Close();
            }

            return res;
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private bool IsLetterOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < 'A' || c > 'Z') && (c < 'a' || c > 'z'))
                    return false;
            }

            return true;
        }

        public override bool InsertBagage(string codeIata, bool continuation, string ligne, string nomCompagnie, string compagnie, string jourExploitation, string classeBagage, string itineraire, bool rush, out string message)
        {
            compagnie = compagnie.ToUpper();
            classeBagage = classeBagage.ToUpper();
            itineraire = itineraire.ToUpper();

            message = "";
            bool userError = false;

            if (!IsDigitsOnly(codeIata))
            {
                userError = true;
                message += "Le code IATA ne doit être composé que de chiffres.\n";
            }

            if (codeIata.Length > 12)
            {
                userError = true;
                message += "Le Code IATA doit avoir au plus 12 chiffres\n";
            }

            if (itineraire.Length != 3)
            {
                userError = true;
                message += "L'itinéraire doit avoir exactement 3 lettres\n";
            }

            if (!IsDigitsOnly(ligne))
            {
                userError = true;
                message += "La ligne ne doit avoir que des chiffres\n";
            }

            if (!IsDigitsOnly(jourExploitation))
            {
                userError = true;
                message += "La date du vol doit être un nombre\n";
            }
            else if (Convert.ToInt32(jourExploitation) > 365)
            {
                userError = true;
                message += "La date du vol doit être entre 1 et 365\n";
            }

            Dictionary<string, int> compagnieClasses = new Dictionary<string, int>();

            if (compagnie.Length != 2)
            {
                userError = true;
                message += "La compagnie doit avoir exactement 2 lettres\n";
            }
            else if (classeBagage.Length != 1)
            {
                userError = true;
                message += "La classe doit avoir exactement 1 lettre\n";
            }
            else
            {
                compagnieClasses = GetCompagnieClasses(compagnie);

                // Check that the company exists
                if (compagnieClasses.Count == 0)
                {
                    userError = true;
                    message += "La compagnie '" + compagnie + "' n'existe pas\n";
                }
                // Check that classeBagage is valid in regard to compagnie (if this flag is valid for this company)
                else if (!compagnieClasses.ContainsKey(classeBagage))
                {
                    userError = true;
                    message += "La classe '" + classeBagage + "' n'existe pas pour '" + compagnie + "'\n";
                }
            }

            if (userError)
            {
                return false;
            }

            SqlConnection cnx = new SqlConnection(strCnx);
            cnx.Open();
            SqlTransaction transaction = cnx.BeginTransaction();
            SqlCommand cmd = new SqlCommand(commandCreateBagage, cnx, transaction);
            cmd.Parameters.AddWithValue("@codeIata", codeIata);
            cmd.Parameters.AddWithValue("@classe", classeBagage);
            cmd.Parameters.AddWithValue("@prioritaire", compagnieClasses[classeBagage]);
            cmd.Parameters.AddWithValue("@escale", itineraire);
            cmd.Parameters.AddWithValue("@compagnie", compagnie);
            cmd.Parameters.AddWithValue("@ligne", ligne);
            cmd.Parameters.AddWithValue("@jourExploitation", jourExploitation);
            // The follwing line only makes sense if the user is able to enter both the "destination" and the "escale" fields
            // cmd.Parameters.AddWithValue("@continuation", continuation ? "Y" : "N");
            cmd.Parameters.AddWithValue("@continuation", "Y");

            // Execute the command
            try
            {
                int insertedIdBagage = (int)cmd.ExecuteScalar();

                if (insertedIdBagage != 0)
                {
                    // If some rows were inserted, then we can insert the bagageId in the BAGAGE_A_POUR_PARTICULARITE table so that the RUSH attribute will show up correctly later
                    if (rush)
                    {
                        cmd = new SqlCommand(commandCreateBagageParticularite, cnx, transaction);
                        cmd.Parameters.AddWithValue("@insertedIdBagage", insertedIdBagage);
                        int insertedIdBagageParticularite = (int)cmd.ExecuteScalar();

                        if (insertedIdBagageParticularite == insertedIdBagage)
                        {
                            transaction.Commit();
                            message = "Bagage " + insertedIdBagageParticularite + " créé !";
                            return true;
                        }
                    }
                    else
                    {
                        transaction.Commit();
                        message = "Bagage " + insertedIdBagage + " créé !";
                        return true;
                    }
                }

                // If nothing was inserted, there was an error somewhere and we rollback
                transaction.Rollback();
                message = "Erreur lors de l'insertion en base";
                return false;
            }
            catch (Exception ex)
            {
                // If nothing was inserted, there was an error somewhere and we rollback
                transaction.Rollback();
                message = ex.Message;
                return false;
            }
        }
    }
}