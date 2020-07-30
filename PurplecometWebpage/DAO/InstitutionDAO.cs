using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using PurplecometWebpage.DTO;
using PurplecometWebpage.Utils;

namespace PurplecometWebpage.DAO
{    
    public class InstitutionDAO
    {
        public static Institution GetInstitution(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"select * from institutions where active = 1 and id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Institution inst = new Institution();

                        inst.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        inst.Name = reader.GetString(reader.GetOrdinal("name"));
                        inst.Description = reader.GetString(reader.GetOrdinal("description"));
                        inst.Notes = reader.GetString(reader.GetOrdinal("notes"));

                        return inst;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            return new Institution();
        }

        public static List<Institution> GetInstitutions()
        {
            List<Institution> list = new List<Institution>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"select * from institutions where active = 1";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Institution inst = new Institution();

                        inst.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        inst.Name = reader.GetString(reader.GetOrdinal("name"));
                        inst.Description = reader.GetString(reader.GetOrdinal("description"));
                        inst.Notes = reader.GetString(reader.GetOrdinal("notes"));

                        list.Add(inst);
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

        public static void AddInstitution(Institution inst)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"insert into institutions (name, description, notes, active) 
                                    values (@name, @description, @notes, 1)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@name", inst.Name);
                    command.Parameters.AddWithValue("@description", inst.Description);
                    command.Parameters.AddWithValue("@notes", inst.Notes);

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

        public static void RemoveInstitution(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"update institutions set active = 0 where id = @id";
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

        public static void ModInstitution(Institution inst)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"update institutions set name = @name, description = @description, notes = @notes where id = @id and active = 1";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", inst.Id);
                    command.Parameters.AddWithValue("@name", inst.Name);
                    command.Parameters.AddWithValue("@description", inst.Description);
                    command.Parameters.AddWithValue("@notes", inst.Notes);

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