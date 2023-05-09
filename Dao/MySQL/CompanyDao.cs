using com.gestapoghost.entertainment.Dao.SQLite;
using com.gestapoghost.entertainment.entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.Dao.MySQL
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

        public ObservableCollection<Company> GetAllCompanyByPICSHA(string strSearch)
        {

            string strSQL = "select * from company where pic like '%" + strSearch + "%'";
            return GetCompaniesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        }




        //public CompanyEntity getCompanyById(int companyId)
        //{
        //    return GetCompanyEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL("select * from company where id = " + companyId));
        //}

        //public string GetCompanyPicFileNameById(int companyId)
        //{
        //    return BaseDao.getBaseDao().GetRowBySQL("select * from company where id = " + companyId)["pic"].ToString();
        //}


        private ObservableCollection<Company> GetCompaniesFromDataTable(DataTable companyDataTable)
        {
            ObservableCollection<Company> companies = new ObservableCollection<Company>();

            foreach (DataRow companyDataRow in companyDataTable.Rows)
            {
                companies.Add(GetCompanyFromDataRow(companyDataRow));
            }
            return companies;
        }

        private Company GetCompanyFromDataRow(DataRow companyDataRow)
        {
            Company company = new Company();
            company.Id = Convert.ToInt32(companyDataRow["id"].ToString());
            company.Name = companyDataRow["name"].ToString();
            company.Pic = companyDataRow["pic"].ToString();
            company.Type = Convert.ToInt32(companyDataRow["type"].ToString());
            return company;
        }
    }
}
