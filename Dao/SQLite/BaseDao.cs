using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace com.gestapoghost.entertainment.Dao.SQLite
{
    public class BaseDao
    {
        private static BaseDao baseDao = null;

        public static BaseDao getBaseDao() 
        {
            if (baseDao == null)
            {
                baseDao = new BaseDao("Y:/Tools/logs", "Ghost670519", false, false);
            }
            return baseDao;
        }

        // Fields
        private System.Data.SQLite.SQLiteConnection m_Connection;

        private string m_strFileName;

        // Methods
        private BaseDao(string strFileName, string strPassword, bool bReadOnly = false, bool b加载数据到内存 = false)
        {
            if (b加载数据到内存 == false)
            {
                m_strFileName = strFileName;
                if (bReadOnly)
                {
                    try
                    {
                        this.OpenReadOnly(strFileName, strPassword);
                    }
                    catch
                    {
                        this.OpenReadWrite(strFileName, strPassword);
                    }
                }
                else
                {
                    this.OpenReadWrite(strFileName, strPassword);
                }
            }
            else
            {
                m_Connection = new System.Data.SQLite.SQLiteConnection("Data Source=:memory:");
                m_Connection.Open();
            }
        }

        public string FileName
        {
            get
            {
                return m_strFileName;
            }
        }

        public static void CreateDBFile(string strFileName)
        {
            try
            {
                if (System.IO.File.Exists(strFileName)) System.IO.File.Delete(strFileName);
                System.Data.SQLite.SQLiteConnection.CreateFile(strFileName);
            }
            catch
            {
            }
        }

        private void ChangeNewConnection(System.Data.SQLite.SQLiteConnection m_NewConnection)
        {
            m_Connection.Clone();
            m_Connection = m_NewConnection;
        }

        public void CloseConnection()
        {
            m_Connection.ReleaseMemory();
            m_Connection.Close();
        }

        public void ExecuteSQL(string strSQL)
        {
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(null, m_Connection);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = strSQL;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void ExecuteSQL(string strSQL, SQLiteParameter[] parameters)
        {
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(null, m_Connection);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = strSQL;
            cmd.Parameters.AddRange(parameters);


            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void ExecuteSQL(List<String> listSql)//, System.Data.SQLite.SQLiteTransaction tran)
        {
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(null, m_Connection);
            cmd.Transaction = m_Connection.BeginTransaction(); ;// tran;
            foreach (string strSQL in listSql)
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();
            }
            cmd.Transaction.Commit();
            cmd.Dispose();
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
            System.Data.SQLite.SQLiteCommand command = new System.Data.SQLite.SQLiteCommand(null, m_Connection)
            {
                CommandType = CommandType.Text,
                CommandText = "select last_insert_rowid()"
            };
            return Convert.ToInt32(command.ExecuteScalar());
        }

        public DataTable GetTableBySQL(string strSQL, bool bAddWithKey = false)
        {
            System.Data.SQLite.SQLiteCommand selectCommand = new System.Data.SQLite.SQLiteCommand(null, m_Connection)
            {
                CommandType = CommandType.Text,
                CommandText = strSQL,
            };
            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(selectCommand);
            if (bAddWithKey) adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable GetTableBySQL(string strSQL, SQLiteParameter[] parameters, bool bAddWithKey = false)
        {
            System.Data.SQLite.SQLiteCommand selectCommand = new System.Data.SQLite.SQLiteCommand(null, m_Connection)
            {
                CommandType = CommandType.Text,
                CommandText = strSQL,
            };
            selectCommand.Parameters.AddRange(parameters);
            System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter(selectCommand);
            if (bAddWithKey) adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public DataRow GetRowBySQL(string strSQL)
        {
            DataTable dTable = GetTableBySQL(strSQL);

            if (dTable.Rows.Count == 0)
                return null;
            else
                return dTable.Rows[0];
        }

        public DataRow GetRowBySQL(string strSQL, SQLiteParameter[] parameters)
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
            foreach (DataRow row in this.GetTableBySQL("select * from sqlite_master where type='table'").Rows)
            {
                list.Add(row["name"].ToString().ToUpper());
            }
            return list;
        }

        public System.Data.Common.DbCommand NewCommand(string strCommandText)
        {
            return new System.Data.SQLite.SQLiteCommand(strCommandText, m_Connection);
        }

        public void OpenConnection()
        {
            m_Connection.Open();
        }

        private void OpenReadOnly(string strFileName, string strPassword)
        {
            m_Connection = new System.Data.SQLite.SQLiteConnection();
            System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            connstr.DataSource = strFileName;
            connstr.Password = strPassword;//设置密码，SQLite ADO.NET实现了数据库密码保护
            connstr.ReadOnly = true;
            m_Connection.ConnectionString = connstr.ToString();
            m_Connection.Open();
        }

        private void OpenReadWrite(string strFileName, string strPassword)
        {
            m_Connection = new System.Data.SQLite.SQLiteConnection();
            System.Data.SQLite.SQLiteConnectionStringBuilder connstr = new System.Data.SQLite.SQLiteConnectionStringBuilder();
            connstr.DataSource = strFileName;
            connstr.Password = strPassword;
            connstr.ReadOnly = false;
            m_Connection.ConnectionString = connstr.ToString();
            m_Connection.Open();
        }

        public System.Data.SQLite.SQLiteTransaction BeginTransaction()
        {
            return m_Connection.BeginTransaction();
        }

        public void ExecuteNonQueryTransaction(string sql, List<System.Data.SQLite.SQLiteParameter> listSQLiteParameter, System.Data.SQLite.SQLiteTransaction targetTransaction, int commandTimeout = 600)
        {
            System.Data.SQLite.SQLiteCommand sqliteCommand = new System.Data.SQLite.SQLiteCommand(sql, m_Connection, targetTransaction);
            sqliteCommand.CommandTimeout = commandTimeout;
            sqliteCommand.Parameters.AddRange(listSQLiteParameter.ToArray());
            sqliteCommand.ExecuteNonQuery();

            sqliteCommand.Dispose();
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

        //备份数据库到另一个连接
        public com.gestapoghost.entertainment.Dao.SQLite.BaseDao CreateNewMemeoyBackupDatabase()
        {
            com.gestapoghost.entertainment.Dao.SQLite.BaseDao newSQLiteDatabase = new com.gestapoghost.entertainment.Dao.SQLite.BaseDao("", "", false, true);

            System.Data.SQLite.SQLiteConnection m_ConnectionInMemeoy = new System.Data.SQLite.SQLiteConnection("Data Source=:memory:");
            m_ConnectionInMemeoy.Open();

            m_Connection.BackupDatabase(m_ConnectionInMemeoy, "main", "main", -1, null, 0);

            newSQLiteDatabase.ChangeNewConnection(m_ConnectionInMemeoy);

            return newSQLiteDatabase;
        }
    }
}
