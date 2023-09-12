using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;

namespace TriviaAPI
{
    public class DBHandler
    {
        const string CON_STR = "Server=localhost; database=trivia; UID=root; password=Sami2110.";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

        const string GetPlayerQuery = "SELECT Name FROM trivia.players where PlayerID = ";
        const string GetQuestionQuery = "SELECT * FROM trivia.questions WHERE CategoryID = @categoryId ORDER BY RAND() LIMIT 1;";
        const string AddPlayerQuery = "INSERT INTO `trivia`.`players` (`Name`) VALUES ('*');";
        public string RunstringQuery(string query)
        {
            string result = null;
            try
            {
                Connect();
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader.GetString(0);
                }
            }
            catch (Exception ex) { }
            Disconnect();
            return result;
        }
        public void RunAddQuery(string query)
        {
            try
            {
                Connect();
                cmd = new MySqlCommand(query, con);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { }
            Disconnect();
        }
        public Question RunQuestionQuery(string query ,int catigoryId)
        {
            Question question = null;
            try
            {
                Connect();
                
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@categoryId", catigoryId);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    question = new Question(reader.GetString("Question"),
                                            reader.GetString("Answer1"),
                                            reader.GetString("Answer2"),
                                            reader.GetString("Answer3"),
                                            reader.GetString("Answer4"),
                                            reader.GetInt16("Correctanswer"));
                }
            }
            catch (Exception ex) { }

            Disconnect();
            return question;
        }

        public Question GetQuestion(int id)
        {
            return RunQuestionQuery(GetQuestionQuery, id);
        }
        
        public string GetPlayerName(int id)
        {
            return RunstringQuery(GetPlayerQuery + id);
        }
        public void AddPlayer(string name)
        {
            RunAddQuery(AddPlayerQuery.Replace("*", name));
        }
        public void Connect()
        {
            try
            {
                con = new MySqlConnection(CON_STR);
                con.Open();
                Console.WriteLine(con.State);
            }
            catch
            {
                con.Close();
            }
        }
        public void Disconnect()
        {
            con.Close();
        }


    }
}
