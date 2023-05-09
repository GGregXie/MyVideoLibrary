using com.gestapoghost.entertainment.tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.Dao.SQLite
{
    public class MovieDao
    {
        private static MovieDao movieDao = null;

        public static MovieDao GetMovieDao() 
        {
            if (movieDao == null)
            {
                movieDao = new MovieDao();
            }
            return movieDao;
        }

        //public string GetCompanySeriesByCompanyId(int companyId)
        //{
        //    return CompanyDao.GetCompanyDao().getCompanyById(companyId).Name;
        //}

        //public string GetCompanySeriesBySeriesId(int seriesId)
        //{
        //    SeriesEntity seriesEntity = SeriesDao.GetSeriesDao().GetSeriesById(seriesId);
        //    CompanyEntity companyEntity = CompanyDao.GetCompanyDao().getCompanyById(seriesEntity.CompanyEntity.Id);
        //    return companyEntity.Name + " - " + seriesEntity.Name;
        //}


        public int CreateMovie(int companyId, int seriesId, string movieTitle, DateTime movieDate, string movieDescription, string moviePicFront, string moviePicBack)
        {
            string strSQL = "insert into movie values (null, @company_id, @series_id, @title, @date, @description, @pic_front, @pic_back, 0, 0, 0)";
            SQLiteParameter[] parameters = { 
                new SQLiteParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = companyId },
                new SQLiteParameter() { ParameterName = "@series_id",       DbType = DbType.Int32,      Value = seriesId },
                new SQLiteParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = movieTitle },
                new SQLiteParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = movieDate },
                new SQLiteParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = movieDescription },
                new SQLiteParameter() { ParameterName = "@pic_front",       DbType = DbType.String,     Value = moviePicFront },
                new SQLiteParameter() { ParameterName = "@pic_back",        DbType = DbType.String,     Value = moviePicBack },
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
            return BaseDao.getBaseDao().GetLastID();
        }


        public void UpdateMovie(int movieId, int companyId, int seriesId, string movieTitle, DateTime movieDate, string movieDescription, string movieFrontPic, string movieBackPic)
        {
            string strSQL = "update movie set company_id = @company_id, series_id = @series_id, title = @title, date = @date, description = @description, pic_front = @pic_front, pic_back = @pic_back, isdeleted = 0 where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = movieId },
                new SQLiteParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = companyId },
                new SQLiteParameter() { ParameterName = "@series_id",       DbType = DbType.Int32,      Value = seriesId },
                new SQLiteParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = movieTitle },
                new SQLiteParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = movieDate },
                new SQLiteParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = movieDescription },
                new SQLiteParameter() { ParameterName = "@pic_front",       DbType = DbType.String,     Value = movieFrontPic },
                new SQLiteParameter() { ParameterName = "@pic_back",        DbType = DbType.String,     Value = movieBackPic }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }



        /**


        public void SetActorsByClipId(int clipId, List<ActorEntity> actorEntities)
        {
            string strSQL = "delete from clip_actor where clip_id = @clip_id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@clip_id",             DbType = DbType.Int32,      Value = clipId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
            foreach (ActorEntity actorEntity in actorEntities)
            {
                AddActorByClipId(clipId, actorEntity);
            }

        }

        public void AddActorByClipId(int clipId, ActorEntity actorEntitiy) 
        {
            string strSQL = "insert into clip_actor values (@clip_id, @actor_id)";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@clip_id",             DbType = DbType.Int32,      Value = clipId },
                new SQLiteParameter() { ParameterName = "@actor_id",            DbType = DbType.Int32,      Value = actorEntitiy.id }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        //public void UpdateCompany(int companyId, String companyName, String companyPic, int companyType)
        //{
        //    BaseDao.getBaseDao().ExecuteSQL("update company set name = '" + companyName + "', pic = '" + companyPic + "', type = " + companyType + ", isdeleted = 0 where id = " + companyId);
        //}

        //public void DeleteCompany(int companyId)
        //{
        //    BaseDao.getBaseDao().ExecuteSQL("update company set isdeleted = 1 where id = " + companyId);
        //}
        */
        //public List<MovieEntity> GetAllMoviesByCompanyId(int companyId, Paging paging)
        //{
        //    string strSQL = "select * from movie where company_id = @company_id and isdeleted = 0 order by title limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id", DbType = DbType.Int32, Value = companyId },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetMovieEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<MovieEntity> GetAllMovieByPICSHA(string strSearch)
        //{
        //    string strSQL = "select * from movie where pic_front like '%" + strSearch + "%' or pic_back like '%" + strSearch + "%'";
        //    return GetMovieEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        //}


        public int GetAllMovieByCompanyIdCount(int companyId)
        {
            string strSQL = "select count(id) from movie where company_id = @company_id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@company_id", DbType = DbType.Int32, Value = companyId}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        //public List<MovieEntity> GetAllMoviesBySeriesId(int seriesId, Paging paging)
        //{
        //    string strSQL = "select * from movie where series_id = @series_id and isdeleted = 0 order by title limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id", DbType = DbType.Int32, Value = seriesId },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetMovieEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        public int GetAllMovieBySeriesIdCount(int seriesId)
        {
            string strSQL = "select count(id) from movie where series_id = @series_id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@series_id", DbType = DbType.Int32, Value = seriesId}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        /**

        public List<ClipEntity> GetAllClipsByMovieId(int movieId)
        {
            string strSQL = "select * from clip where movie_id = @movie_id and isdeleted = 0";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@movie_id", DbType = DbType.Int32, Value = movieId }
            };
            return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));

        }

            */

        //public MovieEntity GetMovieById(int movieId)
        //{
        //    string strSQL = "select * from movie where id = @id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
        //    };
        //    return GetMovieEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters));
        //}

        public string GetMovieFrontPicFileNameById(int movieId)
        {
            string strSQL = "select * from movie where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
            };
            return BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)["pic_front"].ToString();
        }

        public string GetMovieBackPicFileNameById(int movieId)
        {
            string strSQL = "select * from movie where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
            };
            return BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)["pic_back"].ToString();
        }


        //private List<MovieEntity> GetMovieEntitiesFromDataTable(DataTable movieDataTable)
        //{
        //    List<MovieEntity> movieEntities = new List<MovieEntity>();

        //    foreach (DataRow movieDataRow in movieDataTable.Rows)
        //    {
        //        movieEntities.Add(GetMovieEntityFromDataRow(movieDataRow));
        //    }
        //    return movieEntities;
        //}

        //private MovieEntity GetMovieEntityFromDataRow(DataRow movieDataRow)
        //{
        //    MovieEntity movieEntity = new MovieEntity();
        //    movieEntity.Id = Convert.ToInt32(movieDataRow["id"].ToString());
        //    movieEntity.Title = movieDataRow["title"].ToString();
        //    movieEntity.Date = Convert.ToDateTime(movieDataRow["date"].ToString());
        //    movieEntity.Description = movieDataRow["description"].ToString();
        //    movieEntity.Pic_front = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/" + movieDataRow["pic_front"].ToString(), UriKind.RelativeOrAbsolute));
        //    movieEntity.Pic_back = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/" + movieDataRow["pic_back"].ToString(), UriKind.RelativeOrAbsolute));
        //    movieEntity.Source = Convert.ToInt32(movieDataRow["source"].ToString());
        //    movieEntity.Code = Convert.ToInt32(movieDataRow["code"].ToString());
        //    return movieEntity;
        //}

        public void SetMovieFromDVDById(int movieId)
        {
            string strSQL = "update movie set source = 1 where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
            };
            BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        }

        public void SetMovieFromBluRayById(int movieId)
        {
            string strSQL = "update movie set source = 2 where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
            };
            BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        }

        public void SetMovieCodeById(int movieId, int code)
        {
            string strSQL = "update movie set code = @code where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@code", DbType = DbType.Int32, Value = code },
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
            };
            BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        }

        
    }
}
