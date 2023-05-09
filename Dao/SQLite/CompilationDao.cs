using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.Dao.SQLite
{
    public class CompilationDao
    {
        private static CompilationDao compilationDao = null;

        public static CompilationDao GetCompilationDao() 
        {
            if (compilationDao == null)
            {
                compilationDao = new CompilationDao();
            }
            return compilationDao;
        }

        //public List<CompilationEntity> GetAllCompilationBySeriesId(int seriesId)
        //{
        //    return GetCompilationEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL("select * from compilation where series_id = " + seriesId + " order by name"));
        //}

        //public List<CompilationEntity> GetAllCompilationByCompanyId(int companyId)
        //{
        //    return GetCompilationEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL("select * from compilation where company_id = " + companyId + " order by name"));
        //}

        //private List<CompilationEntity> GetCompilationEntitiesFromDataTable(DataTable compilationDataTable)
        //{
        //    List<CompilationEntity> compilationEntities = new List<CompilationEntity>();

        //    foreach(DataRow compilationDataRow in compilationDataTable.Rows)
        //    {
        //        compilationEntities.Add(GetCompilationEntityFromDataRow(compilationDataRow));
        //    }
        //    return compilationEntities;
        //}

        //private CompilationEntity GetCompilationEntityFromDataRow(DataRow compilationDataRow)
        //{
        //    CompilationEntity compilationEntity = new CompilationEntity();
        //    compilationEntity.Id = Convert.ToInt32(compilationDataRow["id"].ToString());
        //    compilationEntity.Name = compilationDataRow["name"].ToString();
        //    compilationEntity.Pic = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/" + compilationDataRow["pic"].ToString(), UriKind.RelativeOrAbsolute));
        //    return compilationEntity;
        //}
    }
}
