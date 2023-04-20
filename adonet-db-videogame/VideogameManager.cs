using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class VideogameManager
    {
        public static void InserisciVideogame(string name,string overview,string date,int softwareId)
        {
            string stringaConnessione = "Data Source=localhost;Initial Catalog=videogame;Integrated Security=True";
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                try
                {
                    connessione.Open();
                    string query = "INSERT INTO videogames(name,overview,release_date,software_house_id) VALUES (@name,@overview,@date,@softwareId) ";
                    SqlCommand cmd = new SqlCommand(query,connessione);
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@overview", overview));
                    cmd.Parameters.Add(new SqlParameter("@date", date));
                    cmd.Parameters.Add(new SqlParameter("@softwareId", softwareId));
                    int righe = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
           

        }
    }
}
