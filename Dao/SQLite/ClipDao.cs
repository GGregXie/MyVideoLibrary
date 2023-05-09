using com.gestapoghost.entertainment.tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.Dao.SQLite
{
    public class ClipDao
    {
        private static ClipDao clipDao = null;

        public static ClipDao GetClipDao() 
        {
            if (clipDao == null)
            {
                clipDao = new ClipDao();
            }
            return clipDao;
        }

        public int CreateClip(int companyId, int seriesId, int movieId, int clipNumber,int clipScene, string clipTitle, DateTime clipDate, string clipDescription, string clipPic, string filePath, int start, string clipUrl)
        {
            string strSQL = "insert into clip values (null, @company_id, @series_id, @movie_id, @number,@scene, @title, @date, @description, @pic, @filepath, @start, 0, 0, 0, @clipUrl, 0)";
            SQLiteParameter[] parameters = { 
                new SQLiteParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = companyId },
                new SQLiteParameter() { ParameterName = "@series_id",       DbType = DbType.Int32,      Value = seriesId },
                new SQLiteParameter() { ParameterName = "@movie_id",        DbType = DbType.Int32,      Value = movieId },
                new SQLiteParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = clipNumber },
                new SQLiteParameter() { ParameterName = "@scene",           DbType = DbType.Int32,      Value = clipScene },
                new SQLiteParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = clipTitle },
                new SQLiteParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = clipDate },
                new SQLiteParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = clipDescription },
                new SQLiteParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = clipPic },
                new SQLiteParameter() { ParameterName = "@filepath",        DbType = DbType.String,     Value = filePath },
                new SQLiteParameter() { ParameterName = "@start",           DbType = DbType.Int32,     Value = start },
                new SQLiteParameter() { ParameterName = "@clipUrl",         DbType = DbType.String,     Value = clipUrl }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
            int newClipId = BaseDao.getBaseDao().GetLastID();
            if (movieId != 0)
                addMovieClip(movieId, clipScene, newClipId);

            return newClipId;
        }

        public void UpdateClip(int clipId, int clipNumber, int clipScene, string clipTitle, DateTime clipDate, string clipDescription, string clipPic, string filePath, int start, string clipUrl)
        {
            string strSQL = "update clip set number = @number, scene = @scene, title = @title, date = @date, description = @description, pic = @pic, filepath = @filepath, start = @start, clipUrl = @clipUrl, isdeleted = 0 where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = clipId },
                new SQLiteParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = clipNumber },
                new SQLiteParameter() { ParameterName = "@scene",           DbType = DbType.Int32,      Value = clipScene },
                new SQLiteParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = clipTitle },
                new SQLiteParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = clipDate },
                new SQLiteParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = clipDescription },
                new SQLiteParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = clipPic },
                new SQLiteParameter() { ParameterName = "@filepath",        DbType = DbType.String,     Value = filePath },
                new SQLiteParameter() { ParameterName = "@start",           DbType = DbType.Int32,      Value = start },
                new SQLiteParameter() { ParameterName = "@clipUrl",         DbType = DbType.String,      Value = clipUrl }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void UpdateClip(int clipId, int movieId, int clipNumber, int clipScene, string clipTitle, DateTime clipDate, string clipDescription, string clipPic, string filePath, int start, string clipUrl)
        {
            string strSQL = "update clip set movie_id = @movie_id, number = @number, scene = @scene, title = @title, date = @date, description = @description, pic = @pic, filepath = @filepath, start = @start, clipUrl = @clipUrl,  isdeleted = 0 where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = clipId },
                new SQLiteParameter() { ParameterName = "@movie_id",        DbType = DbType.Int32,      Value = movieId },
                new SQLiteParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = clipNumber },
                new SQLiteParameter() { ParameterName = "@scene",           DbType = DbType.Int32,      Value = clipScene },
                new SQLiteParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = clipTitle },
                new SQLiteParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = clipDate },
                new SQLiteParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = clipDescription },
                new SQLiteParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = clipPic },
                new SQLiteParameter() { ParameterName = "@filepath",        DbType = DbType.String,     Value = filePath },
                new SQLiteParameter() { ParameterName = "@start",           DbType = DbType.Int32,      Value = start },
                new SQLiteParameter() { ParameterName = "@clipUrl",         DbType = DbType.String,     Value = clipUrl }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
            if (movieId != 0)
                updateMovieClip(movieId, clipScene, clipId);
        }

        //public ClipEntity GetClipByNumberWithSeries(int number, int series_id)
        //{
        //    string strSQL = "select * from clip where number = @number and series_id = @series_id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = number },
        //        new SQLiteParameter() { ParameterName = "@series_id",      DbType = DbType.Int32,      Value = series_id }
        //        };
        //    DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        //    if (DataRow == null)
        //        return null;
        //    else
        //        return GetClipEntityFromDataRow(DataRow);
        //}

        //public ClipEntity GetClipByNumberWithCompany(int number, int company_id)
        //{
        //    string strSQL = "select * from clip where number = @number and company_id = @company_id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = number },
        //        new SQLiteParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = company_id }
        //        };
        //    DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        //    if (DataRow == null)
        //        return null;
        //    else
        //        return GetClipEntityFromDataRow(DataRow);
        //}

        //public ClipEntity GetLastClipWithCompanyId(int company_id)
        //{
        //    string strSQL = "select * from clip where company_id = @company_id and number = (select max(number) from clip where company_id = @company_id)";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = company_id }
        //        };
        //    DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        //    return GetClipEntityFromDataRow(DataRow);
        //}

        //public ClipEntity GetLastClipWithSeriesId(int series_id)
        //{
        //    string strSQL = "select * from clip where series_id = @series_id and number = (select max(number) from clip where series_id = @series_id)";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@series_id",       DbType = DbType.Int32,      Value = series_id }
        //        };
        //    DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        //    return GetClipEntityFromDataRow(DataRow);
        //}

        //public void SetActorsByClipId(int clipId, List<ActorEntity> actorEntities)
        //{
        //    string strSQL = "delete from clip_actor where clip_id = @clip_id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@clip_id",             DbType = DbType.Int32,      Value = clipId }
        //    };
        //    BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        //    foreach (ActorEntity actorEntity in actorEntities)
        //    {
        //        AddActorByClipId(clipId, actorEntity);
        //    }

        //}

        //public void AddActorByClipId(int clipId, ActorEntity actorEntitiy) 
        //{
        //    string strSQL = "insert into clip_actor values (@clip_id, @actor_id)";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@clip_id",             DbType = DbType.Int32,      Value = clipId },
        //        new SQLiteParameter() { ParameterName = "@actor_id",            DbType = DbType.Int32,      Value = actorEntitiy.Id }
        //    };
        //    BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        //}

        //public List<ClipEntity> GetAllClipsByCompany(CompanyEntity companyEntity)
        //{
        //    string strSQL = "select * from clip where company_id = @company_id and isdeleted = 0 order by number desc, title asc";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id", DbType = DbType.Int32, Value = companyEntity.Id }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsByCompany(CompanyEntity companyEntity, Paging paging)
        //{
        //    string strSQL = "select * from clip where company_id = @company_id and isdeleted = 0 order by number desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id", DbType = DbType.Int32, Value = companyEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsByCompany(CompanyEntity companyEntity, Paging paging, string search_txt)
        //{
        //    string strSQL = "select distinct clip.* from clip left join clip_actor on clip.id = clip_actor.clip_id left join actor on clip_actor.actor_id = actor.id where company_id = @company_id and (clip.title like '%" + search_txt + "%' or clip.description like '%" + search_txt + "%' or actor.name like '%" + search_txt + "%' ) order by number desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id", DbType = DbType.Int32, Value = companyEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsByCompanyWithFinish(CompanyEntity companyEntity, int finish)
        //{
        //    string strSQL = "select * from clip where company_id = @company_id and finish = @finish and isdeleted = 0 order by number desc, title asc";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = companyEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsByCompanyWithFinish(CompanyEntity companyEntity, Paging paging, int finish)
        //{
        //    string strSQL = "select * from clip where company_id = @company_id and finish = @finish and isdeleted = 0 order by number desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = companyEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum",              DbType = DbType.Int32,              Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum",            DbType = DbType.Int32,              Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsByCompanyWithFinish(CompanyEntity companyEntity, Paging paging, int finish, string search_txt)
        //{
        //    string strSQL = "select distinct clip.* from clip left join clip_actor on clip.id = clip_actor.clip_id left join actor on clip_actor.actor_id = actor.id where company_id = @company_id and finish = @finish and (clip.title like '%" + search_txt + "%' or clip.description like '%" + search_txt + "%' or actor.name like '%" + search_txt + "%' ) order by number desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = companyEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum",              DbType = DbType.Int32,              Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum",            DbType = DbType.Int32,              Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsBySeries(SeriesEntity seriesEntity)
        //{
        //    string strSQL = "select * from clip where series_id = @series_id and isdeleted = 0 order by number desc, title asc";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id", DbType = DbType.Int32, Value = seriesEntity.Id }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsBySeries(SeriesEntity seriesEntity, Paging paging)
        //{
        //    string strSQL = "select * from clip where series_id = @series_id and isdeleted = 0 order by number desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id", DbType = DbType.Int32, Value = seriesEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsBySeries(SeriesEntity seriesEntity, Paging paging, string search_txt)
        //{
        //    string strSQL = "select distinct clip.* from clip left join clip_actor on clip.id = clip_actor.clip_id left join actor on clip_actor.actor_id = actor.id where series_id = @series_id and (clip.title like '%" + search_txt + "%' or clip.description like '%" + search_txt + "%' or actor.name like '%" + search_txt + "%') order by number desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id", DbType = DbType.Int32, Value = seriesEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsBySeriesWithFinish(SeriesEntity seriesEntity, int finish)
        //{
        //    string strSQL = "select * from clip where series_id = @series_id and finish = @finish and isdeleted = 0 order by number desc, title asc";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = seriesEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsBySeriesWithFinish(SeriesEntity seriesEntity, Paging paging, int finish)
        //{
        //    string strSQL = "select * from clip where series_id = @series_id and finish = @finish and isdeleted = 0 order by number desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = seriesEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum",              DbType = DbType.Int32,              Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum",            DbType = DbType.Int32,              Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsBySeriesWithFinish(SeriesEntity seriesEntity, Paging paging, int finish, string search_txt)
        //{
        //    string strSQL = "select distinct clip.* from clip left join clip_actor on clip.id = clip_actor.clip_id left join actor on clip_actor.actor_id = actor.id where series_id = @series_id and finish = @finish and (clip.title like '%" + search_txt + "%' or clip.description like '%" + search_txt + "%' or actor.name like '%" + search_txt + "%' ) order by number desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = seriesEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum",              DbType = DbType.Int32,              Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum",            DbType = DbType.Int32,              Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsByActor(ActorEntity actorEntity, Paging paging)
        //{
        //    string strSQL = "select clip.* from clip, clip_actor where clip.id = clip_actor.clip_id and actor_id = @star_id order by id desc, title asc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@star_id", DbType = DbType.Int32, Value = actorEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsByActorWithFinish(ActorEntity actorEntity, Paging paging, int finish)
        //{
        //    string strSQL = "select clip.* from clip, clip_actor where clip.id = clip_actor.clip_id and actor_id = @star_id and finish = @finish order by id desc limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@star_id",                  DbType = DbType.Int32,              Value = actorEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish },
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum",              DbType = DbType.Int32,              Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum",            DbType = DbType.Int32,              Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ClipEntity> GetAllClipsByPICSHA(string strSearch)
        //{
        //    string strSQL = "select * from clip where pic like '%" + strSearch + "%'";
        //    return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        //}

        //public int GetAllClipByCompanyCount(CompanyEntity companyEntity)
        //{
        //    string strSQL = "select count(id) from clip where company_id = @company_id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = companyEntity.Id}
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipByCompanyCount(CompanyEntity companyEntity, string search_txt)
        //{
        //    string strSQL = "select count(DISTINCT  clip.id) from clip left join clip_actor on clip.id = clip_actor.clip_id left join actor on clip_actor.actor_id = actor.id where company_id = @company_id and (clip.title like '%" + search_txt + "%' or clip.description like '%" + search_txt + "%' or actor.name like '%" + search_txt + "%')";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = companyEntity.Id}
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipByCompanyCountWithFinish(CompanyEntity companyEntity, int finish)
        //{
        //    string strSQL = "select count(id) from clip where company_id = @company_id and finish = @finish";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = companyEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish }
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipByCompanyCountWithFinish(CompanyEntity companyEntity, int finish, string search_txt)
        //{
        //    string strSQL = "select count(distinct clip.id) from clip left join clip_actor on clip.id = clip_actor.clip_id left join actor on clip_actor.actor_id = actor.id where company_id = @company_id and finish = @finish and (clip.title like '%" + search_txt + "%' or clip.description like '%" + search_txt + "%' or actor.name like '%" + search_txt + "%' )";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = companyEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish }
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipBySeriesCount(SeriesEntity seriesEntity)
        //{
        //    string strSQL = "select count(id) from clip where series_id = @series_id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = seriesEntity.Id }
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipBySeriesCount(SeriesEntity seriesEntity, string search_txt)
        //{
        //    string strSQL = "select count(DISTINCT  clip.id) from clip left join clip_actor on clip.id = clip_actor.clip_id left join actor on clip_actor.actor_id = actor.id where series_id = @series_id and (clip.title like '%" + search_txt + "%' or clip.description like '%" + search_txt + "%' or actor.name like '%" + search_txt + "%')";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = seriesEntity.Id }
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipBySeriesCountWithFinish(SeriesEntity seriesEntity, int finish)
        //{
        //    string strSQL = "select count(id) from clip where series_id = @series_id and finish = @finish";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = seriesEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish }

        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipBySeriesCountWithFinish(SeriesEntity seriesEntity, int finish, string search_txt)
        //{
        //    string strSQL = "select count(distinct clip.id) from clip left join clip_actor on clip.id = clip_actor.clip_id left join actor on clip_actor.actor_id = actor.id where series_id = @series_id and finish = @finish and (clip.title like '%" + search_txt + "%' or clip.description like '%" + search_txt + "%' or actor.name like '%" + search_txt + "%' )";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = seriesEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish }

        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipByActorCount(ActorEntity actorEntity)
        //{
        //    string strSQL = "select count(clip_id) from clip_actor where actor_id = @actor_id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@actor_id",                 DbType = DbType.Int32,              Value = actorEntity.Id }
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipByActorCountWithFinish(ActorEntity actorEntity, int finish)
        //{
        //    string strSQL = "select count(clip_id) from clip, clip_actor where clip.id = clip_actor.clip_id and actor_id = @actor_id and finish = @finish";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@actor_id",                 DbType = DbType.Int32,              Value = actorEntity.Id },
        //        new SQLiteParameter(){ ParameterName = "@finish",                   DbType = DbType.Int32,              Value = finish }
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        /**
        public List<ClipEntity> GetAllClipsByMovieId(int movieId)
        {
            string strSQL = "select * from clip where movie_id = @movie_id and isdeleted = 0";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@movie_id", DbType = DbType.Int32, Value = movieId }
            };
            return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));

        }
        public List<ClipEntity> GetAllClipsByMovieId(int movieId, Paging paging)
        {
            string strSQL = "select * from clip where movie_id = @movie_id and isdeleted = 0 order by scene limit @pageitemnum offset @itembeforenum";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@movie_id", DbType = DbType.Int32, Value = movieId },
                new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
                new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
            };
            return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }
        **/
        //public List<ClipEntity> GetAllClipsByMovieId(int movieId)
        //{
        //    List<ClipEntity> clipEntities = new List<ClipEntity>();
        //    string strSQL = "select * from movie_clip where movie_id = @movie_id order by movie_scene";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@movie_id",              DbType = DbType.Int32,      Value = movieId }
        //    };
        //    DataTable movieSceneTable = BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters);

        //    foreach (DataRow movieSceneRow in movieSceneTable.Rows)
        //    {

        //        string strSQL2 = "select * from clip where id = @clip_id";
        //        SQLiteParameter[] parameters2 = {
        //            new SQLiteParameter() { ParameterName = "@clip_id",              DbType = DbType.Int32,      Value = Convert.ToInt32(movieSceneRow["clip_id"].ToString()) }
        //        };
        //        ClipEntity clip = GetClipEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL2, parameters2));
        //        clip.Scene = Convert.ToInt32(movieSceneRow["movie_scene"].ToString());
        //        clipEntities.Add(clip);
        //    }
        //    return clipEntities;
        //}

        public int GetAllClipByMovieIdCount(int movieId)
        {
            string strSQL = "select count(id) from clip where movie_id = @movie_id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@movie_id", DbType = DbType.Int32, Value = movieId}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        //public ClipEntity GetClipById(int clipId)
        //{
        //    string strSQL = "select * from clip where id = @id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
        //    };
        //    return GetClipEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters));
        //}

        public string GetClipPicFileNameById(int clipId)
        {
            string strSQL = "select * from clip where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
            };
            return BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)["pic"].ToString();
        }

        //private List<ClipEntity> GetClipEntitiesFromDataTable(DataTable clipDataTable)
        //{
        //    List<ClipEntity> clipEntities = new List<ClipEntity>();

        //    foreach (DataRow clipDataRow in clipDataTable.Rows)
        //    {
        //        clipEntities.Add(GetClipEntityFromDataRow(clipDataRow));
        //    }
        //    return clipEntities;
        //}

        //private ClipEntity GetClipEntityFromDataRow(DataRow clipDataRow)
        //{
        //    ClipEntity clipEntity = new ClipEntity();
        //    clipEntity.Id = Convert.ToInt32(clipDataRow["id"].ToString());
        //    clipEntity.Number = Convert.ToInt32(clipDataRow["number"].ToString());
        //    clipEntity.Scene = Convert.ToInt32(clipDataRow["scene"].ToString());
        //    clipEntity.Title = clipDataRow["title"].ToString();
        //    clipEntity.Date = Convert.ToDateTime(clipDataRow["date"].ToString());
        //    clipEntity.Description = clipDataRow["description"].ToString();
        //    clipEntity.Pic = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/" + clipDataRow["pic"].ToString(), UriKind.RelativeOrAbsolute));
        //    clipEntity.FilePath = clipDataRow["filepath"].ToString();
        //    clipEntity.Start = Convert.ToInt32(clipDataRow["start"].ToString());
        //    clipEntity.Code = Convert.ToInt32(clipDataRow["code"].ToString());
        //    clipEntity.Size = Convert.ToInt32(clipDataRow["size"].ToString());
        //    clipEntity.Finish = Convert.ToInt32(clipDataRow["finish"].ToString());
        //    clipEntity.ClipUrl = clipDataRow["clipurl"].ToString();
        //    return clipEntity;
        //}

        private void addMovieClip(int movieId, int movie_scene, int clipId) 
        {
            string strSQL = "insert into movie_clip values (@movie_id, @movie_scene, @clip_id)";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@movie_id",        DbType = DbType.Int32,      Value = movieId },
                new SQLiteParameter() { ParameterName = "@movie_scene",     DbType = DbType.Int32,      Value = movie_scene },
                new SQLiteParameter() { ParameterName = "@clip_id",         DbType = DbType.Int32,      Value = clipId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);

        }

        private void updateMovieClip(int movieId, int movie_scene, int clipId)
        {
            string strSQL = "update movie_clip set movie_scene = @movie_scene where movie_id = @movie_id and clip_id = @clip_id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@movie_id",        DbType = DbType.Int32,      Value = movieId },
                new SQLiteParameter() { ParameterName = "@movie_scene",     DbType = DbType.Int32,      Value = movie_scene },
                new SQLiteParameter() { ParameterName = "@clip_id",         DbType = DbType.Int32,      Value = clipId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void SetClipCodeById(int clipId, int code)
        {
            string strSQL = "update clip set code = @code where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@code", DbType = DbType.Int32, Value = code },
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
            };
            BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        }

        public void SetClipSizeById(int clipId, int size)
        {
            string strSQL = "update clip set size = @size where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@size", DbType = DbType.Int32, Value = size },
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
            };
            BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        }

        public void SetClipFinishById(int clipId, int finish)
        {
            string strSQL = "update clip set finish = @finish where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@finish", DbType = DbType.Int32, Value = finish },
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
            };
            BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        }
    }
}
