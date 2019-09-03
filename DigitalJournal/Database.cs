using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;

namespace DigitalJournal
{
    class Database
    {
        public static bool Error;

        private static MySqlConnection Connection()
        {
            // строка подключения к БД
            string connStr = "server=localhost;user=root;database=journal;password='root';charset=utf8;";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            return conn;
        }

        public static List<List<string>> ExecuteQuery(string sql)
        {
            MySqlConnection conn = Connection();
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                // объект для чтения ответа сервера
                MySqlDataReader reader = command.ExecuteReader();
                var query = new List<List<string>>();
                int i = 0;
                while (reader.Read())
                {
                    query.Add(new List<string>());
                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        query[i].Add(reader[j].ToString());
                    }

                    i++;
                }

                conn.Close();
                Error = false;
                return query;
            }
            catch (MySqlException ex)
            {
                var query = new List<List<string>>(); //change
                Error = true;
                MessageBox.Show(ex.Message);
                Error = true;
                return query;
            }
        }
    }
}