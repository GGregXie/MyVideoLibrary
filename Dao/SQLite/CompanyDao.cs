using com.gestapoghost.entertainment.Dao.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.Dao.SQLite
{
    public class CompanyDao
    {
        private static CompanyDao companyDao = null;

        public static CompanyDao GetCompanyDao() 
        {
            if (companyDao == null)
            {
                companyDao = new CompanyDao();
            }
            return companyDao;
        }

        public int CreateCompany(String companyName, String companyPic, int companyType)
        {
            BaseDao.getBaseDao().ExecuteSQL("insert into company values(null, '" + companyName + "', '" + companyPic + "', " + companyType + ", 0)");
            return BaseDao.getBaseDao().GetLastID();
        }

        public void UpdateCompany(int companyId, String companyName, String companyPic, int companyType)
        {
            BaseDao.getBaseDao().ExecuteSQL("update company set name = '" + companyName + "', pic = '" + companyPic + "', type = " + companyType + ", isdeleted = 0 where id = " + companyId);
        }

        public void DeleteCompany(int companyId)
        {
            BaseDao.getBaseDao().ExecuteSQL("update company set isdeleted = 1 where id = " + companyId);
        }

        //public List<CompanyEntity> GetAllCompanyByType(int typeid)
        //{
        //    return GetCompanyEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL("select * from company where type = " + typeid + " and isdeleted = 0 order by name"));
        //}

        //public List<CompanyEntity> GetAllCompanyByPICSHA(string strSearch)
        //{

        //    string strSQL = "select * from company where pic like '%" + strSearch + "%'";
        //    return GetCompanyEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        //}




        //public CompanyEntity getCompanyById(int companyId)
        //{
        //    return GetCompanyEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL("select * from company where id = " + companyId));
        //}

        //public string GetCompanyPicFileNameById(int companyId)
        //{
        //    return BaseDao.getBaseDao().GetRowBySQL("select * from company where id = " + companyId)["pic"].ToString();
        //}


        //private List<CompanyEntity> GetCompanyEntitiesFromDataTable(DataTable companyDataTable)
        //{
        //    List<CompanyEntity> companyEntities = new List<CompanyEntity>();

        //    foreach(DataRow companyDataRow in companyDataTable.Rows)
        //    {
        //        companyEntities.Add(GetCompanyEntityFromDataRow(companyDataRow));
        //    }
        //    return companyEntities;
        //}

        //private CompanyEntity GetCompanyEntityFromDataRow(DataRow companyDataRow)
        //{
        //    CompanyEntity companyEntity = new CompanyEntity();
        //    companyEntity.Id = Convert.ToInt32(companyDataRow["id"].ToString());
        //    companyEntity.Name = companyDataRow["name"].ToString();
        //    companyEntity.Pic = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/" + companyDataRow["pic"].ToString(), UriKind.RelativeOrAbsolute));
        //    companyEntity.Type = Convert.ToInt32(companyDataRow["type"].ToString());
        //    return companyEntity;
        //}


    }
}
