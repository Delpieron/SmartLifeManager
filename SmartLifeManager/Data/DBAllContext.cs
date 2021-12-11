using Microsoft.Data.Sqlite;
using SmartLifeManager.Models;
using System;
using System.Data;
using System.IO;

namespace SmartLifeManager.Data
{
    internal class DBAllContext
    {
        private readonly string connection;
        public DBAllContext(string connection)
        {
            this.connection = connection;
            if (!File.Exists(connection))
            {
                File.Create(connection);
            }

            CreateStructure("schedule");

        }

        public bool CreateStructure(string tableName)
        {
            SqliteTransaction transaction = null;
            try
            {
                SqliteCommand cmd = new SqliteCommand();
                string connect = $"Data Source={connection}";
                SqliteConnection conn = new SqliteConnection(GenerateConnectionString(connection));
                conn.Open();
                cmd.Connection = conn;
                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.CommandText = "CREATE TABLE '" + tableName + "' (ID INTEGER PRIMARY KEY AUTOINCREMENT, Event TEXT NOT NULL , ExecutionTime TEXT NOT NULL, Temperature TEXT,Pressure TEXT,WindSpeed TEXT,WindDirection TEXT,Wet TEXT,RainFallSum TEXT);";
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (Exception ee)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                System.Diagnostics.Trace.WriteLine("ERROR: SQLiteOpenedDataBase.CreateStructure: " + ee.Message);
            }
            return false;
        }
        private string GenerateConnectionString(string path)
        {
            return "Data Source=" + path + ";";
        }
        public long AddTreeElement(ScheduleModel element)
        {
            try
            {
                SqliteCommand cmd = new SqliteCommand();
                SqliteConnection conn = new SqliteConnection(GenerateConnectionString(connection));
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO `schedule` "
                    + " (`Event`,`ExecutionTime`,`Temperature`,`Pressure`,`WindSpeed`,`WindDirection`,`Wet`,`RainFallSum`)"
                    + " VALUES "
                    + " (@Event,@ExecutionTime,@Temperature,@Pressure,@WindSpeed,@WindDirection,@Wet,@RainFallSum);";
                cmd.Parameters.Add("@Event", (SqliteType)DbType.String).Value = element.Event;
                cmd.Parameters.Add("@ExecutionTime", (SqliteType)DbType.String).Value = element.ExecutionTime;
                cmd.Parameters.Add("@Temperature", (SqliteType)DbType.String).Value = element.Temperature;
                cmd.Parameters.Add("@Pressure", (SqliteType)DbType.String).Value = element.Pressure;
                cmd.Parameters.Add("@WindSpeed", (SqliteType)DbType.String).Value = element.WindSpeed;
                cmd.Parameters.Add("@WindDirection", (SqliteType)DbType.String).Value = element.WindDirection;
                cmd.Parameters.Add("@Wet", (SqliteType)DbType.String).Value = element.Wet;
                cmd.Parameters.Add("@RainFallSum", (SqliteType)DbType.String).Value = element.RainfallSum;


                long newID = cmd.ExecuteNonQuery();

                cmd.Dispose();
                return newID;
            }
            catch (Exception ee)
            {
                System.Diagnostics.Trace.WriteLine("SQLiteSource.Add: " + ee.Message);
            }
            return -1;
        }
        public ScheduleModel GetElements()
        {
            try
            {
                SqliteDataReader reader = null;
                SqliteCommand cmd = new SqliteCommand();
                SqliteConnection conn = new SqliteConnection(GenerateConnectionString(connection));
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM schedule";

                reader = cmd.ExecuteReader();
                //cmd.Dispose();
                ScheduleModel element = new ScheduleModel();
                if (reader != null && reader.Read())
                {
                    element.Event = reader.GetString(reader.GetOrdinal("Event"));
                    element.ExecutionTime = reader.GetDateTime(reader.GetOrdinal("ExecutionTime"));
                    element.Pressure = reader.GetString(reader.GetOrdinal("Pressure"));
                    element.Temperature = reader.GetString(reader.GetOrdinal("Temperature"));
                    element.WindDirection = reader.GetString(reader.GetOrdinal("WindDirection"));
                    element.WindSpeed = reader.GetString(reader.GetOrdinal("WindSpeed"));
                    element.Wet = reader.GetString(reader.GetOrdinal("Wet"));
                    element.RainfallSum = reader.GetString(reader.GetOrdinal("RainfallSum"));

                }
                return element;

            }
            catch (Exception)
            {
                //System.Diagnostics.Trace.WriteLine("SQLiteSource.GetElements(ParetnID=" + parentID.ToString() + ": " + ee.Message);
            }
            return null;
        }
    }

}