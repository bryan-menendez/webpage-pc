using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PurplecometWebpage.DTO;
using PurplecometWebpage.Utils;


namespace PurplecometWebpage.DAO
{
    public class MessageDAO
    {
        public static Message GetMessage(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"select * from messages where active = 1 and id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Message msg = new Message();
                        msg.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        msg.Name = reader.GetString(reader.GetOrdinal("name"));
                        msg.Email = reader.GetString(reader.GetOrdinal("email"));
                        msg.Subject = reader.GetString(reader.GetOrdinal("subject"));
                        msg.Content = reader.GetString(reader.GetOrdinal("msg_content"));

                        return msg;
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

        public static List<Message> GetMessages()
        {
            List<Message> list = new List<Message>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"select * from messages where active = 1";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Message msg = new Message();
                        msg.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        msg.Name = reader.GetString(reader.GetOrdinal("name"));
                        msg.Email = reader.GetString(reader.GetOrdinal("email"));
                        msg.Subject = reader.GetString(reader.GetOrdinal("subject"));
                        msg.Content = reader.GetString(reader.GetOrdinal("msg_content"));

                        list.Add(msg);
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }

            return list;
        }

        public static void AddMessage(Message msg)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {

                    string query = @"insert into messages (name, subject, email, msg_content, active) 
                                    values (@name, @subject, @email, @msg_content, 1)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", msg.Name);
                    command.Parameters.AddWithValue("@subject", msg.Subject);
                    command.Parameters.AddWithValue("@email", msg.Email);
                    command.Parameters.AddWithValue("@msg_content", msg.Content);

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

        public static void RemoveMessage(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"update messages set active = 0 where id = @id";
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

        public static void ModMessage(Message msg)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"update messages set name = @name, subject = @subject, email = @email, msg_content = @msg_content where id = @id and active = 1";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", msg.Id);
                    command.Parameters.AddWithValue("@name", msg.Name);
                    command.Parameters.AddWithValue("@subject", msg.Subject);
                    command.Parameters.AddWithValue("@email", msg.Email);
                    command.Parameters.AddWithValue("@msg_content", msg.Content);

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