using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportEntities;

namespace AirportModel
{
    public class SqlModel
    {
        private string connectionString; 
        SqlConnection session;
        Vol vol;
        Bagage bagage;

        public SqlModel()
        {
            connectionString = "Data Source=ANTHONY_PC\\SQLEXPRESS;Initial Catalog=Airport;Integrated Security=True";
            session = new SqlConnection(connectionString);
            vol = new Vol();
            bagage = new Bagage();
        }

        public Vol GetVolDetails(int idVol)
        {
            try
            {
                session.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = session;
                command.CommandText = "SELECT * FROM VOL v inner join CIE c on v.ID_CIE = c.ID_CIE WHERE ID_VOL = " + idVol;
                
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                           vol.idVol = (int)dataReader["ID_VOL"];
                           vol.company = (string)dataReader["NOM_CIE"];
                           vol.lineNumber = int.Parse((string)dataReader["LIG"]);
                           vol.lastTime = (DateTime)dataReader["DHC"];
                           vol.parking = (string)dataReader["PKG"];
                           vol.status = (string)dataReader["STA"];
                        }
                    }
                }

                session.Close();
            }

            catch (Exception ex) { Console.WriteLine(ex);}

            return vol;
        }

        public Bagage GetBagageDetails(int idBagage)
        {
            try
            {
                session.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = session;
                //command.CommandText = "SELECT * FROM BSM b inner join BSM_A_POUR_PART app on b.ID_BSM = app.ID_BSM inner join BSM_PARTICULARITEES par on app.ID_PART = par.ID_PART WHERE b.ID_BSM = " + idBagage;
                command.CommandText = "SELECT * FROM BSM WHERE ID_BSM = " + idBagage;

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            bagage.idBagage = (int)dataReader["ID_BSM"];
                            bagage.codeIata = (string)dataReader["CODE_IATA"];
                            bagage.dateCreation = (DateTime)dataReader["DAT_CRE"];
                            bagage.itineraire = (string)dataReader["ITI"];
                            bagage.compagnie = (string)dataReader["CIEE"];
                            bagage.idVol = (int)dataReader["ID_VOL"];
                        }
                    }
                }

                session.Close();
            }

            catch (Exception ex) { Console.WriteLine(ex); }

            return bagage;
        }

        public List<Bagage> GetBagagesFromVol(int idVol)
        {
            List<Bagage> list = new List<Bagage>();

            try
            {
                session.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = session;
                command.CommandText = "SELECT * FROM BSM WHERE ID_VOL = " + idVol;

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Bagage bagageTmp = new Bagage();

                            bagageTmp.idBagage = (int)dataReader["ID_BSM"];
                            bagageTmp.codeIata = (string)dataReader["CODE_IATA"];
                            bagageTmp.dateCreation = (DateTime)dataReader["DAT_CRE"];
                            bagageTmp.itineraire = (string)dataReader["ITI"];
                            bagageTmp.compagnie = (string)dataReader["CIEE"];
                            bagageTmp.idVol = (int)dataReader["ID_VOL"];

                            list.Add(bagageTmp);
                        }
                    }
                }

                session.Close();
            }

            catch (Exception ex) { Console.WriteLine(ex); }

            return list;
        }
    }
}
