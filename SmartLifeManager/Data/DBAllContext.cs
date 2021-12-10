using Microsoft.Data.Sqlite;
using System;

namespace SmartLifeManager.Data
{
    class DBAllContext
    {
        private string connection;
        public DBAllContext(string connection)
        {
            this.connection = connection;
        }

        public bool CreateStructure(string tableName)
        {
            SqliteTransaction transaction = null;
            try
            {
                SqliteCommand cmd = new SqliteCommand();
                string connect = "Data Source=:memory:";
                SqliteConnection conn = new SqliteConnection(connect);
                conn.Open();
                cmd.Connection = conn;
                cmd.Connection.BeginTransaction();
                cmd.CommandText = "CREATE TABLE '" + tableName + "' (SETk_1_ID INTEGER PRIMARY KEY AUTOINCREMENT, SET_Key TEXT NOT NULL, SET_Value TEXT)";
                cmd.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                if (transaction != null) transaction.Rollback();
                System.Diagnostics.Trace.WriteLine("ERROR: SQLiteOpenedDataBase.CreateStructure: " + ee.Message);
            }
            return false;
        }
    }

}
