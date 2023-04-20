using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adonet_db_videogame
{
    internal class VideogameManager
    {
        public static void InserisciVideogame(string name, string overview, string date, int softwareId)
        {
            string stringaConnessione = "Data Source=localhost;Initial Catalog=videogame;Integrated Security=True";
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                try
                {
                    connessione.Open();
                    string query = "INSERT INTO videogames(name,overview,release_date,software_house_id) VALUES (@name,@overview,@date,@softwareId) ";
                    SqlCommand cmd = new SqlCommand(query, connessione);
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
        public static void RimuoviVideogame(string name)
        {
            string stringaConnessione = "Data Source=localhost;Initial Catalog=videogame;Integrated Security=True";
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                try
                {
                    connessione.Open();
                    string query = "DELETE FROM videogames WHERE videogames.name=@name";
                    SqlCommand cmd = new SqlCommand(query, connessione);
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    int righe = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }


        }
        public static void AggiornaVideogame(string name, string overview)
        {
            string stringaConnessione = "Data Source=localhost;Initial Catalog=videogame;Integrated Security=True";
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                try
                {
                    connessione.Open();
                    string query = "UPDATE videogames SET overview = @overview WHERE name=@name";
                    SqlCommand cmd = new SqlCommand(query, connessione);
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@overview", overview));
                    int righe = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }


        }
        public static void GetVideogameById(int id)
        {
            string stringaConnessione = "Data Source=localhost;Initial Catalog=videogame;Integrated Security=True";
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                try
                {
                    connessione.Open();
                    string query = "SELECT * FROM videogames  WHERE videogames.id=@id";
                    SqlCommand cmd = new SqlCommand(query, connessione);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int indexName = reader.GetOrdinal("name");
                            string name = reader.GetString(indexName);
                            int indexOverview = reader.GetOrdinal("overview");
                            string overview = reader.GetString(indexOverview);
                            int indexDate = reader.GetOrdinal("release_date");
                            DateTime date = reader.GetDateTime(indexDate);
                            DateOnly dateOnly = DateOnly.FromDateTime(date);
                            int indexSoftwareHouse = reader.GetOrdinal("software_house_id");
                            long softwareHouse = reader.GetInt64(indexSoftwareHouse);
                            Console.WriteLine($"Nome videogioco : {name}");
                            Console.WriteLine($"Riassunto videogioco : {overview}");
                            Console.WriteLine($"Data di rilascio videogioco : {dateOnly}");
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}