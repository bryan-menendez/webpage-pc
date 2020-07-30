using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using PurplecometWebpage.DTO;
using PurplecometWebpage.DAO;
using PurplecometWebpage.Utils;

namespace PurplecometWebpage.DAO
{
    public class UserDAO
    {
        public static User Login(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"select * from users where active = 1 and username = @username and password = @password";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", Crypto.SHA512(password));

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User usr = new User();

                        usr.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        usr.Name = reader.GetString(reader.GetOrdinal("nombre"));
                        usr.Appat = reader.GetString(reader.GetOrdinal("appat"));
                        usr.Apmat = reader.GetString(reader.GetOrdinal("apmat"));
                        usr.Email = reader.GetString(reader.GetOrdinal("email"));
                        usr.Username = reader.GetString(reader.GetOrdinal("username"));
                        usr.Password = reader.GetString(reader.GetOrdinal("password"));
                        usr.Type = reader.GetString(reader.GetOrdinal("usertype"));
                        usr.Institution = InstitutionDAO.GetInstitution(reader.GetInt32(reader.GetOrdinal("fk_institution")));
                        usr.Schedule = ScheduleDAO.GetSchedule(reader.GetInt32(reader.GetOrdinal("fk_schedule")));

                        return usr;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        public static Boolean UsernameExists(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select username from users where active = 1 and username = @username";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Debug.WriteLine("username exists: " + username);
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            return false;
        }

        public static User GetUser(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select * from users where active = 1 and id = @id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User usr = new User();

                        usr.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        usr.Name = reader.GetString(reader.GetOrdinal("nombre"));
                        usr.Appat = reader.GetString(reader.GetOrdinal("appat"));
                        usr.Apmat = reader.GetString(reader.GetOrdinal("apmat"));
                        usr.Email = reader.GetString(reader.GetOrdinal("email"));
                        usr.Username = reader.GetString(reader.GetOrdinal("username"));
                        usr.Password = reader.GetString(reader.GetOrdinal("password"));
                        usr.Type = reader.GetString(reader.GetOrdinal("usertype"));
                        usr.Institution = InstitutionDAO.GetInstitution(reader.GetInt32(reader.GetOrdinal("fk_institution")));
                        usr.Schedule = ScheduleDAO.GetSchedule(reader.GetInt32(reader.GetOrdinal("fk_schedule")));

                        return usr;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        public static List<User> GetUsers()
        {
            List<User> list = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select * from users where active = 1";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User usr = new User();

                        usr.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        usr.Name = reader.GetString(reader.GetOrdinal("nombre"));
                        usr.Appat = reader.GetString(reader.GetOrdinal("appat"));
                        usr.Apmat = reader.GetString(reader.GetOrdinal("apmat"));
                        usr.Email = reader.GetString(reader.GetOrdinal("email"));
                        usr.Username = reader.GetString(reader.GetOrdinal("username"));
                        usr.Password = reader.GetString(reader.GetOrdinal("password"));
                        usr.Type = reader.GetString(reader.GetOrdinal("usertype"));
                        usr.Institution = InstitutionDAO.GetInstitution(reader.GetInt32(reader.GetOrdinal("fk_institution")));
                        usr.Schedule = ScheduleDAO.GetSchedule(reader.GetInt32(reader.GetOrdinal("fk_schedule")));

                        list.Add(usr);
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

        public static List<string> GetUserTypes()
        {
            List<string> list = new List<string>();
           
            list.Add("agent");
            list.Add("manager");
            list.Add("admin");


            return list;
        }

        public static void AddUser(User usr)
        {
            if (UsernameExists(usr.Username))
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"insert into users (nombre, appat, apmat, email, username, password, usertype
                                    , fk_institution, fk_schedule, active) 
                                    values (@name, @appat, @apmat, @email, @username, @password, @usertype
                                    , @fk_institution, @fk_schedule, 1)";
                    SqlCommand command = new SqlCommand(query, connection);

                    
                    command.Parameters.AddWithValue("@id", usr.Id);
                    command.Parameters.AddWithValue("@name", usr.Name);
                    command.Parameters.AddWithValue("@appat", usr.Appat);
                    command.Parameters.AddWithValue("@apmat", usr.Apmat);
                    command.Parameters.AddWithValue("@email", usr.Email);
                    command.Parameters.AddWithValue("@username", usr.Username);
                    command.Parameters.AddWithValue("@password", Crypto.SHA512(usr.Password));
                    command.Parameters.AddWithValue("@usertype", usr.Type);
                    command.Parameters.AddWithValue("@fk_institution", usr.Institution.Id);
                    command.Parameters.AddWithValue("@fk_schedule", usr.Schedule.Id);

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

        public static void RemoveUser(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"update users set active = 0 where id = @id";
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

        public static void ModUser(User usr)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"update users set nombre = @name, appat = @appat, apmat = @apmat, email = @email, username = @username, 
                                    password = @password, usertype = @usertype, fk_institution = @fk_institution, fk_schedule = @fk_schedule 
                                    where id = @id and active = 1";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", usr.Id);
                    command.Parameters.AddWithValue("@name", usr.Name);
                    command.Parameters.AddWithValue("@appat", usr.Appat);
                    command.Parameters.AddWithValue("@apmat", usr.Apmat);
                    command.Parameters.AddWithValue("@email", usr.Email);
                    command.Parameters.AddWithValue("@username", usr.Username);
                    command.Parameters.AddWithValue("@password", Crypto.SHA512(usr.Password));
                    command.Parameters.AddWithValue("@usertype", usr.Type);
                    command.Parameters.AddWithValue("@fk_institution", usr.Institution.Id);
                    command.Parameters.AddWithValue("@fk_schedule", usr.Schedule.Id);

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
        public static List<User> GetUsersByInstitution(int institution_fk)
        {
            List<User> list = new List<User>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select * from users where active = 1 and fk_institution = @fk";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fk", institution_fk);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        User usr = new User();

                        usr.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        usr.Name = reader.GetString(reader.GetOrdinal("nombre"));
                        usr.Appat = reader.GetString(reader.GetOrdinal("appat"));
                        usr.Apmat = reader.GetString(reader.GetOrdinal("apmat"));
                        usr.Email = reader.GetString(reader.GetOrdinal("email"));
                        usr.Username = reader.GetString(reader.GetOrdinal("username"));
                        usr.Password = reader.GetString(reader.GetOrdinal("password"));
                        usr.Type = reader.GetString(reader.GetOrdinal("usertype"));
                        usr.Institution = InstitutionDAO.GetInstitution(reader.GetInt32(reader.GetOrdinal("fk_institution")));
                        usr.Schedule = ScheduleDAO.GetSchedule(reader.GetInt32(reader.GetOrdinal("fk_schedule")));

                        list.Add(usr);
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
    }
}