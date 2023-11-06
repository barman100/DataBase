using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TriviaAPI
{
    public class DBHandler
    {
        const string CON_STR = "Server=localhost; database=trivia; UID=root; password=Sami2110.";
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader reader;

        const string GetPlayerQuery = "SELECT Name FROM trivia.players WHERE PlayerID = ";
        const string GetQuestionQuery = "SELECT * FROM trivia.questions ORDER BY RAND() LIMIT 1;";
        const string AddPlayerQuery = "INSERT INTO `trivia`.`players` (`Name`) VALUES ('*');";
        const string DeletePlayerQuery = "DELETE FROM trivia.players;" +
                                         "\nALTER TABLE trivia.players AUTO_INCREMENT = 1;";
        const string GetPlayerCountQuery = "SELECT COUNT(`PlayerID`) FROM trivia.players;";
        const string GetPlayerScoreQuery = "SELECT Score FROM trivia.players WHERE PlayerID = ";
        const string GetPlayerTimeQuery = "SELECT Time FROM trivia.players WHERE PlayerID = ";
        public string RunStringQuery(string query)
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
        public int RunIntQuery(string query)
        {
            int score = 0;
            try
            {
                Connect();
                
                cmd = new MySqlCommand(query, con);
                
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    score = reader.GetInt32(0);
                }
            }
            catch (Exception ex) { }
            Disconnect();
            return score;
        }
        public float RunFloatQuery(string query)
        {
            float score = 0;
            try
            {
                Connect();

                cmd = new MySqlCommand(query, con);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    score = reader.GetFloat(0);
                }
            }
            catch (Exception ex) { }
            Disconnect();
            return score;
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
        public void UpdatePlayerScoreQuery(int newScore, int id)
        {
            try
            {
                Connect();
                string query = "UPDATE trivia.players SET Score = Score + @newScore WHERE PlayerID = @id";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@newScore", newScore);
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { }
            Disconnect();
        }
        public void UpdatePlayerTimeQuery(float newTime, int id)
        {
            try
            {
                Connect();
                string query = "UPDATE trivia.players SET Time = Time + @newTime WHERE PlayerID = @id";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@newTime", newTime);
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { }
            Disconnect();
        }
        public Question RunQuestionQuery(string query)
        {
            Question question = null;
            try
            {
                Connect();
                
                cmd = new MySqlCommand(query, con);
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
        public string GetPlayerCount()
        {
            return RunPlayerCountQuery(GetPlayerCountQuery);
        }
        public Question GetQuestion()
        {
            return RunQuestionQuery(GetQuestionQuery);
        }
        public string GetPlayerName(int id)
        {
            return RunStringQuery(GetPlayerQuery + id);
        }
        public void AddPlayer(string name)
        {
            RunAddQuery(AddPlayerQuery.Replace("*", name));
        }
        public void UpdateScore(int score, int id)
        {
            UpdatePlayerScoreQuery(score, id);
        }
        public void UpdateTime(float time, int id)
        {
            UpdatePlayerTimeQuery(time, id);
        }
        public float GetPlayerTime(int id)
        {
            return RunFloatQuery(GetPlayerTimeQuery + id);
        }
        public int GetPlayerScore(int id )
        {
            return RunIntQuery(GetPlayerScoreQuery + id);
        }
        public void DeletePlayer()
        {
            RunDeleteQuery(DeletePlayerQuery);
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
