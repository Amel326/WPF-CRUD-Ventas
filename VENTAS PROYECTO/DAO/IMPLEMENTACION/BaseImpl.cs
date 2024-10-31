using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAO.IMPLEMENTACION
{
    public class BaseImpl
    {
        string connectionString = "server=localhost;database=bdincos2023;Uid=root;pwd=incos;Port=3307";
        public string query = "";

        public MySqlCommand CreateBasicCommand()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            return command;
        }

        public MySqlCommand CreateBasicCommand(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            return command;
        }

        public int ExecuteBasicCommand(MySqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataTable ExecuteDataTableCommand(MySqlCommand command)
        {
            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return table;
        }
    }
}

