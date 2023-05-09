using com.gestapoghost.entertainment.entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace com.gestapoghost.entertainment.Dao.MySQL
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
            MySqlParameter[] parameters = { 
                new MySqlParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = companyId },
                new MySqlParameter() { ParameterName = "@series_id",       DbType = DbType.Int32,      Value = seriesId },
                new MySqlParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = movieTitle },
                new MySqlParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = movieDate },
                new MySqlParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = movieDescription },
                new MySqlParameter() { ParameterName = "@pic_front",       DbType = DbType.String,     Value = moviePicFront },
                new MySqlParameter() { ParameterName = "@pic_back",        DbType = DbType.String,     Value = moviePicBack },
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
            return BaseDao.getBaseDao().GetLastID();
        }


        public void UpdateMovie(int movieId, string movieTitle, DateTime movieDate, string movieDescription, string movieFrontPic, string movieBackPic)
        {
            string strSQL = "update movie set title = @title, date = @date, description = @description, pic_front = @pic_front, pic_back = @pic_back, isdeleted = 0 where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = movieId },
                new MySqlParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = movieTitle },
                new MySqlParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = movieDate },
                new MySqlParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = movieDescription },
                new MySqlParameter() { ParameterName = "@pic_front",       DbType = DbType.String,     Value = movieFrontPic },
                new MySqlParameter() { ParameterName = "@pic_back",        DbType = DbType.String,     Value = movieBackPic }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }



        //public List<MovieEntity> GetAllMoviesByCompanyId(int companyId, Paging paging)
        //{
        //    string strSQL = "select * from movie where company_id = @company_id and isdeleted = 0 order by title limit @pageitemnum offset @itembeforenum";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@company_id", DbType = DbType.Int32, Value = companyId },
        //        new MySqlParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new MySqlParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetMovieEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        public ObservableCollection<Movie> GetAllMovieByPICSHA(string strSearch)
        {
            string strSQL = "select * from movie where pic_front like '%" + strSearch + "%' or pic_back like '%" + strSearch + "%'";
            return GetMoviesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        }


        public int GetAllMovieByCompanyIdCount(int companyId)
        {
            string strSQL = "select count(id) from movie where company_id = @company_id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@company_id", DbType = DbType.Int32, Value = companyId}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        //public List<MovieEntity> GetAllMoviesBySeriesId(int seriesId, Paging paging)
        //{
        //    string strSQL = "select * from movie where series_id = @series_id and isdeleted = 0 order by title limit @pageitemnum offset @itembeforenum";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@series_id", DbType = DbType.Int32, Value = seriesId },
        //        new MySqlParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new MySqlParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetMovieEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        public int GetAllMovieBySeriesIdCount(int seriesId)
        {
            string strSQL = "select count(id) from movie where series_id = @series_id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id", DbType = DbType.Int32, Value = seriesId}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        //public MovieEntity GetMovieById(int movieId)
        //{
        //    string strSQL = "select * from movie where id = @id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
        //    };
        //    return GetMovieEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters));
        //}

        public string GetMovieFrontPicFileNameById(int movieId)
        {
            string strSQL = "select * from movie where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
            };
            return BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)["pic_front"].ToString();
        }

        public string GetMovieBackPicFileNameById(int movieId)
        {
            string strSQL = "select * from movie where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = movieId }
            };
            return BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)["pic_back"].ToString();
        }


        private ObservableCollection<Movie> GetMoviesFromDataTable(DataTable movieDataTable)
        {
            ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

            foreach (DataRow movieDataRow in movieDataTable.Rows)
            {
                movies.Add(GetMovieFromDataRow(movieDataRow));
            }
            return movies;
        }

        private Movie GetMovieFromDataRow(DataRow movieDataRow)
        {
            Movie movie = new Movie();
            movie.Id = Convert.ToInt32(movieDataRow["id"].ToString());
            movie.Title = movieDataRow["title"].ToString();
            movie.Date = Convert.ToDateTime(movieDataRow["date"].ToString());
            movie.Description = movieDataRow["description"].ToString();
            movie.Pic_Front = movieDataRow["pic_front"].ToString();
            movie.Pic_Back = movieDataRow["pic_back"].ToString();
            movie.Source = Convert.ToInt32(movieDataRow["source"].ToString());
            movie.Code = Convert.ToInt32(movieDataRow["code"].ToString());
            return movie;
        }

        public void SetMovieSource(int movie_id, int source_id)
        {
            string strSQL = "update movie set source = @source_id where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id",        DbType = DbType.Int32, Value = movie_id },
                new MySqlParameter(){ ParameterName = "@source_id", DbType = DbType.Int32, Value = source_id }
            };
            BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        }

        public void SetMovieCode(int movie_id, int code_id)
        {
            string strSQL = "update movie set code = @code_id where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id",        DbType = DbType.Int32, Value = movie_id },
                new MySqlParameter(){ ParameterName = "@code_id",   DbType = DbType.Int32, Value = code_id }
            };
            BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        }

        
    }
}
