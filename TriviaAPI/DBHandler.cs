using MySql.Data.MySqlClient;

namespace TriviaAPI
{
    public class DBHandler
    {
        MySqlConnection? _connection;
        MySqlCommand? _cmd;
        MySqlDataReader? _reader;

        const string CONNECTION_STRING = "Server=localhost; database=trivia; UID=root; password=123123Aa*";
        const string GET_PLAYER_QUERY = "SELECT Name FROM trivia.players WHERE PlayerID = ";
        const string GET_QUESTION_QUERY = "SELECT * FROM trivia.questions ORDER BY RAND() LIMIT 1;";
        const string ADD_PLAYER_QUERY = "INSERT INTO `trivia`.`players` (`Name`) VALUES ('*');";
        const string DELETE_PLAYER_QUERY = "DELETE FROM trivia.players;" +
                                         "\nALTER TABLE trivia.players AUTO_INCREMENT = 1;";
        const string GET_PLAYER_COUNT_QUERY = "SELECT COUNT(`PlayerID`) FROM trivia.players;";
        const string GET_PLAYER_SCORE_QUERY = "SELECT Score FROM trivia.players WHERE PlayerID = ";
        const string GET_PLAYER_TIME_QUERY = "SELECT Time FROM trivia.players WHERE PlayerID = ";
        const string GET_QUESTION_COUNT_QUERY = "SELECT QuestionCount FROM trivia.players WHERE PlayerID = ";
        public string RunStringQuery(string query)
        {
            string result = "";
            try
            {
                Connect();
                _cmd = new MySqlCommand(query, _connection);
                _reader = _cmd.ExecuteReader();
                if (_reader.Read())
                {
                    result = _reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Disconnect();
            return result;
        }
        public int RunIntQuery(string query)
        {
            int score = 0;
            try
            {
                Connect();
                
                _cmd = new MySqlCommand(query, _connection);
                
                _reader = _cmd.ExecuteReader();

                if (_reader.Read())
                {
                    score = _reader.GetInt32(0);
                }
            }
            catch (Exception ex) 
            { 
              throw new Exception(ex.Message);
            }

            Disconnect();
            return score;
        }
        public float RunFloatQuery(string query)
        {
            float score = 0;
            try
            {
                Connect();

                _cmd = new MySqlCommand(query, _connection);

                _reader = _cmd.ExecuteReader();

                if (_reader.Read())
                {
                    score = _reader.GetFloat(0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Disconnect();
            return score;
        }
        public void RunDeleteQuery(string query)
        {
            try
            {
                Connect();
                _cmd = new MySqlCommand(query, _connection);
                _reader = _cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Disconnect();
        }
        public void RunAddQuery(string query)
        {
            try
            {
                Connect();
                _cmd = new MySqlCommand(query, _connection);
                _reader = _cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Disconnect();
        }
        public void UpdatePlayerScoreQuery(int newScore, int id)
        {
            try
            {
                Connect();
                string query = "UPDATE trivia.players SET Score = Score + @newScore WHERE PlayerID = @id";
                _cmd = new MySqlCommand(query, _connection);
                _cmd.Parameters.AddWithValue("@newScore", newScore);
                _cmd.Parameters.AddWithValue("@id", id);
                _reader = _cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Disconnect();
        }
        public void UpdatePlayerTimeQuery(float newTime, int id)
        {
            try
            {
                Connect();
                string query = "UPDATE trivia.players SET Time = Time + @newTime WHERE PlayerID = @id";
                _cmd = new MySqlCommand(query, _connection);
                _cmd.Parameters.AddWithValue("@newTime", newTime);
                _cmd.Parameters.AddWithValue("@id", id);
                _reader = _cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Disconnect();
        }
        public void UpdatePlayerQuestionCountQuery(int newCount, int id)
        {
            try
            {
                Connect();
                string query = "UPDATE trivia.players SET QuestionCount = @newCount WHERE PlayerID = @id";
                _cmd = new MySqlCommand(query, _connection);
                _cmd.Parameters.AddWithValue("@newCount", newCount);
                _cmd.Parameters.AddWithValue("@id", id);
                _reader = _cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Disconnect();
        }
        public Question RunQuestionQuery(string query)
        {
            Question? question = null;
            try
            {
                Connect();
                
                _cmd = new MySqlCommand(query, _connection);
                _reader = _cmd.ExecuteReader();
                if (_reader.Read())
                {
                    question = new Question(_reader.GetString("Question"),
                                            _reader.GetString("Answer1"),
                                            _reader.GetString("Answer2"),
                                            _reader.GetString("Answer3"),
                                            _reader.GetString("Answer4"),
                                            _reader.GetInt16("Correctanswer"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Disconnect();
            return question;
        }
        public string RunPlayerCountQuery(string query)
        {
            string result = "";
            try
            {
                Connect();
                _cmd = new MySqlCommand(query, _connection);
                _reader = _cmd.ExecuteReader();
                if (_reader.Read())
                {
                    result = _reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Disconnect();
            return result;
        }
        public string GetPlayerCount()
        {
            return RunPlayerCountQuery(GET_PLAYER_COUNT_QUERY);
        }
        public Question GetQuestion()
        {
            return RunQuestionQuery(GET_QUESTION_QUERY);
        }
        public string GetPlayerName(int id)
        {
            return RunStringQuery(GET_PLAYER_QUERY + id);
        }
        public void AddPlayer(string name)
        {
            RunAddQuery(ADD_PLAYER_QUERY.Replace("*", name));
        }
        public void UpdateScore(int score, int id)
        {
            UpdatePlayerScoreQuery(score, id);
        }
        public void UpdateTime(float time, int id)
        {
            UpdatePlayerTimeQuery(time, id);
        }
        public void UpdateQuestionCount(int count, int id)
        {
            UpdatePlayerQuestionCountQuery(count, id);
        }
        public float GetPlayerTime(int id)
        {
            return RunFloatQuery(GET_PLAYER_TIME_QUERY + id);
        }
        public int GetPlayerScore(int id )
        {
            return RunIntQuery(GET_PLAYER_SCORE_QUERY + id);
        }
        public int GetPlayerQuestionCount(int id)
        {
            return RunIntQuery(GET_QUESTION_COUNT_QUERY + id);
        }
        public void DeletePlayer()
        {
            RunDeleteQuery(DELETE_PLAYER_QUERY);
        }
        public void Connect()
        {
            try
            {
                _connection = new MySqlConnection(CONNECTION_STRING);
                _connection.Open();
                Console.WriteLine(_connection.State);
            }
            catch
            {
                _connection.Close();
            }
        }
        public void Disconnect()
        {
            _connection.Close();
        }
    }
}
