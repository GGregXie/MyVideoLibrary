using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.Dao.SQLite
{
    class SeriesDao
    {
        private static SeriesDao seriesDao = null;
        public static SeriesDao GetSeriesDao()
        {
            if (seriesDao == null)
            {
                seriesDao = new SeriesDao();
            }
            return seriesDao;
        }

        public int CreateSeries(string seriesName, string seriesPic, int companyId)
        {
            BaseDao.getBaseDao().ExecuteSQL("insert into series values(null, '" + seriesName + "', '" + seriesPic + "', " + companyId + ", 0)");
            return BaseDao.getBaseDao().GetLastID();
        }

        //public SeriesEntity GetSeriesById(int seriesId)
        //{
        //    return GetSeriesEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL("select * from series where id = " + seriesId));
        //}

        //public List<SeriesEntity> GetAllSeriesByCompanyId(int companyId)
        //{
        //    return GetSeriesEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL("select * from series where company_id = " + companyId + " and isdeleted = 0 order by name"));
        //}

        //public List<SeriesEntity> GetAllSeriesByPICSHA(string strSearch)
        //{

        //    string strSQL = "select * from series where pic like '%" + strSearch + "%'";
        //    return GetSeriesEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        //}


        public string GetSeriesPicFileNameById(int companyId)
        {
            return BaseDao.getBaseDao().GetRowBySQL("select * from series where id = " + companyId)["pic"].ToString();
        }

        public void UpdateSeries(int seriesId, String seriesName, String seriesPic, int companyId)
        {
            BaseDao.getBaseDao().ExecuteSQL("update series set name = '" + seriesName + "', pic = '" + seriesPic + "', company_id = " + companyId + ", isdeleted = 0 where id = " + seriesId);
        }

        public void DeleteSeries(int seriesId)
        {
            BaseDao.getBaseDao().ExecuteSQL("update series set isdeleted = 1 where id = " + seriesId);
        }

        //private List<SeriesEntity> GetSeriesEntitiesFromDataTable(DataTable companyDataTable)
        //{
        //    List<SeriesEntity> seriesEntities = new List<SeriesEntity>();

        //    foreach (DataRow companyDataRow in companyDataTable.Rows)
        //    {
        //        seriesEntities.Add(GetSeriesEntityFromDataRow(companyDataRow));
        //    }
        //    return seriesEntities;
        //}

        //private SeriesEntity GetSeriesEntityFromDataRow(DataRow seriesDataRow)
        //{
        //    SeriesEntity seriesEntity = new SeriesEntity();
        //    seriesEntity.Id = Convert.ToInt32(seriesDataRow["id"].ToString());
        //    seriesEntity.Name = seriesDataRow["name"].ToString();
        //    seriesEntity.Pic = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/" + seriesDataRow["pic"].ToString(), UriKind.RelativeOrAbsolute));
        //    seriesEntity.CompanyEntity = CompanyDao.GetCompanyDao().getCompanyById(Convert.ToInt32(seriesDataRow["company_id"].ToString()));
        //    return seriesEntity;
        //}


    }
}
