using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// @author: 房上的猫
/// 
/// @博客地址: https://www.cnblogs.com/lsy131479/
/// </summary>

namespace com.gestapoghost.entertainment.Dao.MySQL
{
    public class BaseDao
    {
        private static BaseDao baseDao = null;

        public static BaseDao getBaseDao()
        {
            if (baseDao == null)
            {
                baseDao = new BaseDao("server=192.168.0.50;port=43306;user id=entertainment;password=NEEC8rLi8aeXAKWr;database=entertainment");
            }
            return baseDao;
        }
        // Fields
        private MySqlConnection mysqlConnection;

        // Methods
        private BaseDao(string sqlConnection)
        {
            mysqlConnection = new MySqlConnection(sqlConnection);
            mysqlConnection.Open();
        }

        public void OpenConnection()
        {
            mysqlConnection.Open();
        }

        public void CloseConnection()
        {
            mysqlConnection.Close();
        }

        public void ExecuteSQL(string strSQL)
        {
            Console.WriteLine(strSQL);

            MySqlCommand mysqlCommand = new MySqlCommand(strSQL, mysqlConnection);
            mysqlCommand.CommandType = System.Data.CommandType.Text;
            mysqlCommand.CommandText = strSQL;

            mysqlCommand.ExecuteNonQuery();
            mysqlCommand.Dispose();
        }

        public void ExecuteSQL(string strSQL, MySqlParameter[] parameters)
        {
            Console.WriteLine(strSQL);

            MySqlCommand mysqlCommand = new MySqlCommand(null, mysqlConnection);
            mysqlCommand.CommandType = System.Data.CommandType.Text;
            mysqlCommand.CommandText = strSQL;
            mysqlCommand.Parameters.AddRange(parameters);

            mysqlCommand.ExecuteNonQuery();
            mysqlCommand.Dispose();
        }

        public void ExecuteSQL(List<String> listSql)//, System.Data.SQLite.SQLiteTransaction tran)
        {
            MySqlCommand mysqlCommand = new MySqlCommand(null, mysqlConnection);
            mysqlCommand.Transaction = mysqlConnection.BeginTransaction(); ;// tran;
            foreach (string strSQL in listSql)
            {
                mysqlCommand.CommandType = CommandType.Text;
                mysqlCommand.CommandText = strSQL;
                mysqlCommand.ExecuteNonQuery();
            }
            mysqlCommand.Transaction.Commit();
            mysqlCommand.Dispose();
        }

        public bool FieldExists(string strTableName, string strFieldName)
        {
            DataTable table = this.GetTableBySQL(String.Format("select * from '{0}' limit 0,1", strTableName));
            if (table.Columns.Contains(strFieldName))
                return true;
            return false;
        }

        public int GetLastID()
        {
            MySqlCommand mysqlCommand = new MySqlCommand(null, mysqlConnection)
            {
                CommandType = CommandType.Text,
                CommandText = "select last_insert_id()"
            };
            return Convert.ToInt32(mysqlCommand.ExecuteScalar());
        }

        public DataTable GetTableBySQL(string strSQL, bool bAddWithKey = false)
        {
            Console.WriteLine(strSQL);

            MySqlCommand selectCommand = new MySqlCommand(null, mysqlConnection)
            {
                CommandType = CommandType.Text,
                CommandText = strSQL,
            };
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            if (bAddWithKey) adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetTableBySQL(string strSQL, MySqlParameter[] parameters, bool bAddWithKey = false)
        {
            Console.WriteLine(strSQL);

            MySqlCommand selectCommand = new MySqlCommand(null, mysqlConnection)
            {
                CommandType = CommandType.Text,
                CommandText = strSQL,
            };
            selectCommand.Parameters.AddRange(parameters);
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand);
            if (bAddWithKey) adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataRow GetRowBySQL(string strSQL)
        {
            Console.WriteLine(strSQL);

            DataTable dTable = GetTableBySQL(strSQL);

            if (dTable.Rows.Count == 0)
                return null;
            else
                return dTable.Rows[0];
        }

        public DataRow GetRowBySQL(string strSQL, MySqlParameter[] parameters)
        {
            DataTable dTable = GetTableBySQL(strSQL, parameters);

            if (dTable.Rows.Count == 0)
                return null;
            else
                return dTable.Rows[0];
        }

        public List<string> GetTableName()
        {
            List<string> list = new List<string>();
            foreach (DataRow row in this.GetTableBySQL("show tables").Rows)
            {
                list.Add(row[0].ToString().ToUpper());
            }
            return list;
        }

        public System.Data.Common.DbCommand NewCommand(string strCommandText)
        {
            return new MySqlCommand(strCommandText, mysqlConnection);
        }

        public MySqlTransaction BeginTransaction()
        {
            return mysqlConnection.BeginTransaction();
        }

        public void ExecuteNonQueryTransaction(string sql, List<MySqlParameter> listMySqlParameter, MySqlTransaction targetTransaction, int commandTimeout = 600)
        {
            MySqlCommand mysqlCommand = new MySqlCommand(sql, mysqlConnection, targetTransaction);
            mysqlCommand.CommandTimeout = commandTimeout;
            mysqlCommand.Parameters.AddRange(listMySqlParameter.ToArray());
            mysqlCommand.ExecuteNonQuery();

            mysqlCommand.Dispose();
        }

        public bool TableExists(string strTableName)
        {
            List<string> listTableName = GetTableName();
            foreach (string s in listTableName)
            {
                if (string.Compare(s, strTableName, true) == 0)
                    return true;
            }
            return false;
        }

        public DataTable GetColumnTable(string strTableName)
        {
            throw new NotImplementedException();
        }

    }
}