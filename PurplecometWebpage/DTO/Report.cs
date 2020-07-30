using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PurplecometWebpage.DTO
{
    public class Report
    {
        private int id = 0;
        private int user_fk = 0;
        private DateTime date = new DateTime();
        private int words = 0;
        private string log = "";

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Words { get => words; set => words = value; }
        public string Log { get => log; set => log = value; }
        public int User_fk { get => user_fk; set => user_fk = value; }

        public int Wordcount(string log)
        {
            int counter = 0;

            string[] strings = Regex.Split(log, Environment.NewLine);

            foreach (string str in strings)
            {
                try
                {
                    if (str.StartsWith("###") && str.EndsWith("###"))
                        continue; //skip this string
                }
                catch (Exception ex) { Debug.WriteLine(ex.ToString()); }

                counter += CountWords(str);
            }

            return counter;
        }
        public int Wordcount()
        {
            int counter = 0;

            string[] strings = Regex.Split(log, Environment.NewLine);

            foreach (string str in strings)
            {
                try
                {
                    if (str.StartsWith("###") && str.EndsWith("###"))
                        continue; //skip this string
                }
                catch (Exception ex) { Debug.WriteLine(ex.ToString()); }

                counter += CountWords(str);
            }

            return counter;
        }
        public int Charcount()
        {
            int counter = 0;

            string[] strings = Regex.Split(log, Environment.NewLine);

            foreach (string str in strings)
            {
                try
                {
                    if (str.StartsWith("###") && str.EndsWith("###"))
                        continue; //skip this string
                }
                catch (Exception ex) { Debug.WriteLine(ex.ToString()); }

                counter += str.Length;
            }

            return counter;
        }

        public int Charcount(string log)
        {
            int counter = 0;

            string[] strings = Regex.Split(log, Environment.NewLine);

            foreach (string str in strings)
            {
                try
                {
                    if (str.StartsWith("###") && str.EndsWith("###"))
                        continue; //skip this string
                }
                catch (Exception ex) { Debug.WriteLine(ex.ToString()); }

                counter += str.Length;
            }

            return counter;
        }


        public static int CountWords(string s)
        {
            MatchCollection collection = Regex.Matches(s, @"[\S]+");
            return collection.Count;
        }

    }
}