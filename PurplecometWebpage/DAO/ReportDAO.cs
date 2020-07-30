using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using PurplecometWebpage.DTO;
using PurplecometWebpage.Utils;

namespace PurplecometWebpage.DAO
{
    public class ReportDAO
    {
        public static List<Report> GetReportsByUser(int fk_user)
        {
            List<Report> list = new List<Report>();

            try
            {
                User usr = new User();

                try
                {
                    usr = UserDAO.GetUser(fk_user);

                    if (usr == null)
                        return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                    Debug.WriteLine(ex.Message);
                }

                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select * from reports where fk_user = @fk_user";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fk_user", fk_user);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Report report = new Report();

                        report.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        report.Date = reader.GetDateTime(reader.GetOrdinal("date"));
                        report.Words = reader.GetInt32(reader.GetOrdinal("words"));
                        report.User_fk = reader.GetInt32(reader.GetOrdinal("fk_user"));

                        list.Add(report);
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

        public static List<Report> GetReportList(bool onlyNewReports)
        {
            List<Report> list = new List<Report>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select * from reports";
                    if (onlyNewReports)
                        query += " where words = -1";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Report report = new Report();

                        report.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        report.Date = reader.GetDateTime(reader.GetOrdinal("date"));
                        report.Words = reader.GetInt32(reader.GetOrdinal("words"));
                        report.User_fk = reader.GetInt32(reader.GetOrdinal("fk_user"));

                        list.Add(report);
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

        public static void UpdateReportsWordcount(Boolean onlyNewReports)
        {
            List<Report> reports = GetReportList(onlyNewReports);

            foreach (Report report in reports)
            {
                UpdateReportWordcount(report);
            }
        }

        public static void UpdateReportWordcount(Report report)
        {
            try
            {
                string filePath = Config.LogsPath + @"\" + report.User_fk + @"\" + report.Date.ToString("yyyy-MM-dd") + ".log";

                if (File.Exists(filePath))
                {
                    report.Log = File.ReadAllText(filePath);

                    using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                    {
                        string query = @"update reports set words = @words where id = @id";
                        SqlCommand command = new SqlCommand(query, connection);

                        command.Parameters.AddWithValue("@id", report.Id);
                        command.Parameters.AddWithValue("@words", report.Wordcount());

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }

        public static Report GetReport(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = @"select * from reports where id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Report report = new Report();

                        report.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        report.Date = reader.GetDateTime(reader.GetOrdinal("date"));
                        report.Words = reader.GetInt32(reader.GetOrdinal("words"));
                        report.User_fk = reader.GetInt32(reader.GetOrdinal("fk_user"));
                        
                        try
                        {
                            User usr = UserDAO.GetUser(report.User_fk);

                            if (usr == null)
                                return null;

                            string textFile = Config.LogsPath + @"\" + usr.Id + @"\" + report.Date.ToString("yyyy-MM-dd") + ".log";

                            if (!File.Exists(textFile))
                                return null;

                            report.Log = File.ReadAllText(textFile);
                        }
                        catch (Exception ex) 
                        {
                            Debug.WriteLine(ex.StackTrace);
                            Debug.WriteLine(ex.Message);
                            
                            return null;
                        }
                        
                        return report;
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

        public static void AddReport(Report report)
        {
            try
            {
                if (!File.Exists(Config.LogsPath + @"\" + report.User_fk + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log"))
                {
                    Directory.CreateDirectory(Config.LogsPath + @"\" + report.User_fk + @"\");

                    using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
                    {
                        string query = @"insert into reports (fk_user, date, words) 
                                    values (@fk_user, @date, @words)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@fk_user", report.User_fk);
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.Parameters.AddWithValue("@words", -1);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                    

                File.AppendAllText(Config.LogsPath + @"\" + report.User_fk + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log", report.Log);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
        }
    }
}