using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using PurplecometWebpage.DTO;
using PurplecometWebpage.Utils;

namespace PurplecometWebpage.DAO
{
    public class ScheduleDAO
    {
        public static void AddSchedule(Schedule schedule)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"insert into schedules (name, description, fk_institution, lunesin, lunesout, martesin, martesout, miercolesin, miercolesout, juevesin, juevesout, viernesin, viernesout, sabadoin, sabadoout, domingoin, domingoout, active) 
                                    values (@name, @description, @fk_institution, @lunesin, @lunesout, @martesin, @martesout, @miercolesin, @miercolesout, @juevesin, @juevesout, @viernesin, @viernesout, @sabadoin, @sabadoout, @domingoin, @domingoout, 1)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", schedule.Name);
                    command.Parameters.AddWithValue("@description", schedule.Description);
                    command.Parameters.AddWithValue("@fk_institution", schedule.Fk_institution);
                    command.Parameters.AddWithValue("@lunesin", schedule.Lunesin);
                    command.Parameters.AddWithValue("@lunesout", schedule.Lunesout);
                    command.Parameters.AddWithValue("@martesin", schedule.Martesin);
                    command.Parameters.AddWithValue("@martesout", schedule.Martesout);
                    command.Parameters.AddWithValue("@miercolesin", schedule.Miercolesin);
                    command.Parameters.AddWithValue("@miercolesout", schedule.Miercolesout);
                    command.Parameters.AddWithValue("@juevesin", schedule.Juevesin);
                    command.Parameters.AddWithValue("@juevesout", schedule.Juevesout);
                    command.Parameters.AddWithValue("@viernesin", schedule.Viernesin);
                    command.Parameters.AddWithValue("@viernesout", schedule.Viernesout);
                    command.Parameters.AddWithValue("@sabadoin", schedule.Sabadoin);
                    command.Parameters.AddWithValue("@sabadoout", schedule.Sabadoout);
                    command.Parameters.AddWithValue("@domingoin", schedule.Domingoin);
                    command.Parameters.AddWithValue("@domingoout", schedule.Domingoout);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }

        public static Schedule GetSchedule (int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select * from schedules where active = 1 and id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Schedule sc = new Schedule();

                    while (reader.Read())
                    {
                        sc.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        sc.Name = reader.GetString(reader.GetOrdinal("name"));
                        sc.Fk_institution = reader.GetInt32(reader.GetOrdinal("fk_institution"));
                        sc.Description = reader.GetString(reader.GetOrdinal("description"));
                        sc.Lunesin = reader.GetString(reader.GetOrdinal("lunesin"));
                        sc.Lunesout = reader.GetString(reader.GetOrdinal("lunesout"));
                        sc.Martesin = reader.GetString(reader.GetOrdinal("martesin"));
                        sc.Martesout = reader.GetString(reader.GetOrdinal("martesout"));
                        sc.Miercolesin = reader.GetString(reader.GetOrdinal("miercolesin"));
                        sc.Miercolesout = reader.GetString(reader.GetOrdinal("miercolesout"));
                        sc.Juevesin = reader.GetString(reader.GetOrdinal("juevesin"));
                        sc.Juevesout = reader.GetString(reader.GetOrdinal("juevesout"));
                        sc.Viernesin = reader.GetString(reader.GetOrdinal("viernesin"));
                        sc.Viernesout = reader.GetString(reader.GetOrdinal("viernesout"));
                        sc.Sabadoin = reader.GetString(reader.GetOrdinal("sabadoin"));
                        sc.Sabadoout = reader.GetString(reader.GetOrdinal("sabadoout"));
                        sc.Domingoin = reader.GetString(reader.GetOrdinal("domingoin"));
                        sc.Domingoout = reader.GetString(reader.GetOrdinal("domingoout"));

                        return sc;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            return new Schedule();
        }

        public static List<Schedule> GetSchedules()
        {
            List<Schedule> list = new List<Schedule>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select * from schedules where active = 1";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Schedule sc = new Schedule();
                        sc.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        sc.Name = reader.GetString(reader.GetOrdinal("name"));
                        sc.Description = reader.GetString(reader.GetOrdinal("description"));
                        sc.Fk_institution = reader.GetInt32(reader.GetOrdinal("fk_institution"));
                        sc.Lunesin = reader.GetString(reader.GetOrdinal("lunesin"));
                        sc.Lunesout = reader.GetString(reader.GetOrdinal("lunesout"));
                        sc.Martesin = reader.GetString(reader.GetOrdinal("martesin"));
                        sc.Martesout = reader.GetString(reader.GetOrdinal("martesout"));
                        sc.Miercolesin = reader.GetString(reader.GetOrdinal("miercolesin"));
                        sc.Miercolesout = reader.GetString(reader.GetOrdinal("miercolesout"));
                        sc.Juevesin = reader.GetString(reader.GetOrdinal("juevesin"));
                        sc.Juevesout = reader.GetString(reader.GetOrdinal("juevesout"));
                        sc.Viernesin = reader.GetString(reader.GetOrdinal("viernesin"));
                        sc.Viernesout = reader.GetString(reader.GetOrdinal("viernesout"));
                        sc.Sabadoin = reader.GetString(reader.GetOrdinal("sabadoin"));
                        sc.Sabadoout = reader.GetString(reader.GetOrdinal("sabadoout"));
                        sc.Domingoin = reader.GetString(reader.GetOrdinal("domingoin"));
                        sc.Domingoout = reader.GetString(reader.GetOrdinal("domingoout"));

                        list.Add(sc);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            return list;
        }

        public static List<Schedule> GetSchedulesByInstitution(int institution_fk)
        {
            List<Schedule> list = new List<Schedule>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"select * from schedules where active = 1 and fk_institution = @fk";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fk", institution_fk);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Schedule sc = new Schedule();
                        sc.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        sc.Name = reader.GetString(reader.GetOrdinal("name"));
                        sc.Description = reader.GetString(reader.GetOrdinal("description"));
                        sc.Fk_institution = reader.GetInt32(reader.GetOrdinal("fk_institution"));
                        sc.Lunesin = reader.GetString(reader.GetOrdinal("lunesin"));
                        sc.Lunesout = reader.GetString(reader.GetOrdinal("lunesout"));
                        sc.Martesin = reader.GetString(reader.GetOrdinal("martesin"));
                        sc.Martesout = reader.GetString(reader.GetOrdinal("martesout"));
                        sc.Miercolesin = reader.GetString(reader.GetOrdinal("miercolesin"));
                        sc.Miercolesout = reader.GetString(reader.GetOrdinal("miercolesout"));
                        sc.Juevesin = reader.GetString(reader.GetOrdinal("juevesin"));
                        sc.Juevesout = reader.GetString(reader.GetOrdinal("juevesout"));
                        sc.Viernesin = reader.GetString(reader.GetOrdinal("viernesin"));
                        sc.Viernesout = reader.GetString(reader.GetOrdinal("viernesout"));
                        sc.Sabadoin = reader.GetString(reader.GetOrdinal("sabadoin"));
                        sc.Sabadoout = reader.GetString(reader.GetOrdinal("sabadoout"));
                        sc.Domingoin = reader.GetString(reader.GetOrdinal("domingoin"));
                        sc.Domingoout = reader.GetString(reader.GetOrdinal("domingoout"));

                        list.Add(sc);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            return list;
        }
        public static void RemoveSchedule(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"update schedules set active = 0 where id = @id";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }

        public static void ModSchedule(Schedule schedule)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"update schedules set name = @name, description = @description, fk_institution = @fk_institution, lunesin = @lunesin, lunesout = @lunesout, martesin = @martesin, martesout = @martesout, miercolesin = @miercolesin, miercolesout = @miercolesout, juevesin = @juevesin, juevesout = @juevesout, viernesin = @viernesin, viernesout = @viernesout, sabadoin = @sabadoin, sabadoout = @sabadoout, domingoin = @domingoin, domingoout = @domingoout where id = @id";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", schedule.Id);
                    command.Parameters.AddWithValue("@name", schedule.Name);
                    command.Parameters.AddWithValue("@fk_institution", schedule.Fk_institution);
                    command.Parameters.AddWithValue("@description", schedule.Description);
                    command.Parameters.AddWithValue("@lunesin", schedule.Lunesin);
                    command.Parameters.AddWithValue("@lunesout", schedule.Lunesout);
                    command.Parameters.AddWithValue("@martesin", schedule.Martesin);
                    command.Parameters.AddWithValue("@martesout", schedule.Martesout);
                    command.Parameters.AddWithValue("@miercolesin", schedule.Miercolesin);
                    command.Parameters.AddWithValue("@miercolesout", schedule.Miercolesout);
                    command.Parameters.AddWithValue("@juevesin", schedule.Juevesin);
                    command.Parameters.AddWithValue("@juevesout", schedule.Juevesout);
                    command.Parameters.AddWithValue("@viernesin", schedule.Viernesin);
                    command.Parameters.AddWithValue("@viernesout", schedule.Viernesout);
                    command.Parameters.AddWithValue("@sabadoin", schedule.Sabadoin);
                    command.Parameters.AddWithValue("@sabadoout", schedule.Sabadoout);
                    command.Parameters.AddWithValue("@domingoin", schedule.Domingoin);
                    command.Parameters.AddWithValue("@domingoout", schedule.Domingoout);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }
    }
}