using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TriviaAPI
{
    public class DBHandler
    {
        const string CON_STR = "Server=localhost; database=trivia; UID=root; password=123123Aa*";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

        const string GetPlayerQuery = "SELECT Name FROM trivia.players WHERE PlayerID = ";
        const string GetQuestionQuery = "SELECT * FROM trivia.questions WHERE CategoryID = @categoryId ORDER BY RAND() LIMIT 1;";
        const string AddPlayerQuery = "INSERT INTO `trivia`.`players` (`Name`) VALUES ('*');";
        const string GetScoreQuery = "SELECT Score FROM trivia.players WHERE PlayerID = ";
        const string UpdateScoreQuery = "INSERT INTO `trivia`.`players` (`Score`) VALUES ('*');";
        const string GetTimeQuery = "SELECT Time FROM trivia.players WHERE PlayerID = ";
        const string UpdateTimeQuery = "INSERT INTO `trivia`.`players` (`Time`) VALUES ('*');";
        const string DeletePlayerQuery = "DELETE FROM trivia.players;" +
                                         "\nALTER TABLE trivia.players AUTO_INCREMENT = 1;";
        const string GetPlayerCountQuery = "SELECT COUNT(`PlayerID`) FROM trivia.players;";
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
        public void RunDeleteQuery(string query)
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
        public string RunPlayerCountQuery(string query)
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
        public void DeletePlayer()
        {
            RunDeleteQuery(DeletePlayerQuery);
        }
        public void UpdateScore(string score)
        {
            RunAddQuery(UpdateScoreQuery.Replace("*", score));
        }
        public string GetPlayerTime(int id)
        {
            return RunstringQuery(GetTimeQuery + id);
        }
        public string GetPlayerScore(int id)
        {
            return RunstringQuery(GetScoreQuery + id);
        }
        public void UpdateTime(string time)
        {
            RunAddQuery(UpdateTimeQuery.Replace("*", time));
        }
        public string GetPlayerCount()
        {
            return RunPlayerCountQuery(GetPlayerCountQuery);
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
