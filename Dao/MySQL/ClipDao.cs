using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace com.gestapoghost.entertainment.Dao.MySQL
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

        public int CreateClip(int companyId, int seriesId, int clipNumber, string clipTitle, DateTime clipDate, string clipDescription, string clipPic, string filePath, int start, string clipUrl)
        {
            string strSQL = "insert into clip values (null, @company_id, @series_id, 0, @number, 0, @title, @date, @description, @pic, @filepath, @start, 0, 0, 0, @clipUrl, 0)";
            MySqlParameter[] parameters = { 
                new MySqlParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = companyId },
                new MySqlParameter() { ParameterName = "@series_id",       DbType = DbType.Int32,      Value = seriesId },
                new MySqlParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = clipNumber },
                new MySqlParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = clipTitle },
                new MySqlParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = clipDate },
                new MySqlParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = clipDescription },
                new MySqlParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = clipPic },
                new MySqlParameter() { ParameterName = "@filepath",        DbType = DbType.String,     Value = filePath },
                new MySqlParameter() { ParameterName = "@start",           DbType = DbType.Int32,     Value = start },
                new MySqlParameter() { ParameterName = "@clipUrl",         DbType = DbType.String,     Value = clipUrl }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
            return BaseDao.getBaseDao().GetLastID();
        }

        public void UpdateClip(int clipId, int clipNumber, string clipTitle, DateTime clipDate, string clipDescription, string clipPic, string filePath, int start, string clipUrl)
        {
            string strSQL = "update clip set number = @number, title = @title, date = @date, description = @description, pic = @pic, filepath = @filepath, start = @start, clipUrl = @clipUrl, isdeleted = 0 where id = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = clipId },
                new MySqlParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = clipNumber },
                new MySqlParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = clipTitle },
                new MySqlParameter() { ParameterName = "@date",            DbType = DbType.Date,       Value = clipDate.Date },
                new MySqlParameter() { ParameterName = "@description",     DbType = DbType.String,     Value = clipDescription },
                new MySqlParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = clipPic },
                new MySqlParameter() { ParameterName = "@filepath",        DbType = DbType.String,     Value = filePath },
                new MySqlParameter() { ParameterName = "@start",           DbType = DbType.Int32,      Value = start },
                new MySqlParameter() { ParameterName = "@clipUrl",         DbType = DbType.String,      Value = clipUrl }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public  void UpdateClipTitle(int id, string title)
        {
            string strSQL = "update clip set title = @title where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = id },
                new MySqlParameter() { ParameterName = "@title",           DbType = DbType.String,     Value = title }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void UpdateClipNumber(int id, int number)
        {
            string strSQL = "update clip set number = @number where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = id },
                new MySqlParameter() { ParameterName = "@number",          DbType = DbType.String,     Value = number }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }


        public void CreateOrUpdateMovieScene(int movie_id, int clip_id, int movie_scene)
        {
            string deleteSQL = "delete from movie_clip where movie_id = @movie_id and clip_id = @clip_id";
            string createSQL = "insert into movie_clip values (@movie_id, @movie_scene, @clip_id)";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@movie_id",         DbType = DbType.Int32,      Value = movie_id },
                new MySqlParameter() { ParameterName = "@clip_id",          DbType = DbType.Int32,      Value = clip_id },
                new MySqlParameter() { ParameterName = "@movie_scene",      DbType = DbType.Int32,      Value = movie_scene }
            };
            BaseDao.getBaseDao().ExecuteSQL(deleteSQL, parameters);
            BaseDao.getBaseDao().ExecuteSQL(createSQL, parameters);
        }

        public void DeleteClipActor(int clip_id)
        {
            string strSQL = "delete from clip_actor where clip_id = @clip_id";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@clip_id",          DbType = DbType.Int32,      Value = clip_id }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void CreateClipActor(int clip_id, int actor_id)
        {
            string strSQL = "insert into clip_actor values (@clip_id, @actor_id)";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@clip_id",          DbType = DbType.Int32,      Value = clip_id },
                new MySqlParameter() { ParameterName = "@actor_id",         DbType = DbType.Int32,      Value = actor_id }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public ObservableCollection<Clip> GetAllClipsByPICSHA(string strSearch)
        {
            string strSQL = "select * from clip where pic like '%" + strSearch + "%'";
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        }

        //public ClipEntity GetClipByNumberWithSeries(int number, int series_id)
        //{
        //    string strSQL = "select * from clip where number = @number and series_id = @series_id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = number },
        //        new MySqlParameter() { ParameterName = "@series_id",      DbType = DbType.Int32,      Value = series_id }
        //        };
        //    DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        //    if (DataRow == null)
        //        return null;
        //    else
        //        //return GetClipEntityFromDataRow(DataRow);
        //        return null;
        //}

        //public ClipEntity GetClipByNumberWithCompany(int number, int company_id)
        //{
        //    string strSQL = "select * from clip where number = @number and company_id = @company_id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = number },
        //        new MySqlParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = company_id }
        //        };
        //    DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        //    if (DataRow == null)
        //        return null;
        //    else
        //        //return GetClipEntityFromDataRow(DataRow);
        //        return null;
        //}





        //public void SetActorsByClipId(int clipId, List<ActorEntity> actorEntities)
        //{
        //    string strSQL = "delete from clip_actor where clip_id = @clip_id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@clip_id",             DbType = DbType.Int32,      Value = clipId }
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
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@clip_id",             DbType = DbType.Int32,      Value = clipId },
        //        new MySqlParameter() { ParameterName = "@actor_id",            DbType = DbType.Int32,      Value = actorEntitiy.Id }
        //    };
        //    BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        //}


        //public List<ClipEntity> GetAllClipsByActor(ActorEntity actorEntity, Paging paging)
        //{
        //    string strSQL = "select clip.* from clip, clip_actor where clip.id = clip_actor.clip_id and actor_id = @star_id order by id desc, title asc limit @pageitemnum offset @itembeforenum";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@star_id", DbType = DbType.Int32, Value = actorEntity.Id },
        //        new MySqlParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new MySqlParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    //return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //    return null;
        //}

        //public List<ClipEntity> GetAllClipsByActorWithFinish(ActorEntity actorEntity, Paging paging, int finish)
        //{
        //    string strSQL = "";
        //    if (finish == 1)
        //    {
        //        strSQL = "select clip.* from clip, clip_actor where clip.id = clip_actor.clip_id and actor_id = @star_id and finish > 0 order by id desc limit @pageitemnum offset @itembeforenum";
        //    }
        //    else
        //    {
        //        strSQL = "select clip.* from clip, clip_actor where clip.id = clip_actor.clip_id and actor_id = @star_id and finish = 0 order by id desc limit @pageitemnum offset @itembeforenum";
        //    }
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@star_id",                  DbType = DbType.Int32,              Value = actorEntity.Id },
        //        new MySqlParameter(){ ParameterName = "@pageitemnum",              DbType = DbType.Int32,              Value = paging.PageItemNum },
        //        new MySqlParameter(){ ParameterName = "@itembeforenum",            DbType = DbType.Int32,              Value = paging.GetItemBeforeNum() }
        //    };
        //    //return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //    return null;
        //}

        //public List<ClipEntity> GetAllClipsByPICSHA(string strSearch)
        //{
        //    string strSQL = "select * from clip where pic like '%" + strSearch + "%'";
        //    //return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        //    return null;
        //}

        //public int GetAllClipByActorCount(ActorEntity actorEntity)
        //{
        //    string strSQL = "select count(clip_id) from clip_actor where actor_id = @actor_id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@actor_id",                 DbType = DbType.Int32,              Value = actorEntity.Id }
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        //public int GetAllClipByActorCountWithFinish(ActorEntity actorEntity, int finish)
        //{
        //    string strSQL = "";
        //    if (finish == 1)
        //    {
        //        strSQL = "select count(clip_id) from clip, clip_actor where clip.id = clip_actor.clip_id and actor_id = @actor_id and finish > 0";
        //    }
        //    else
        //    {
        //        strSQL = "select count(clip_id) from clip, clip_actor where clip.id = clip_actor.clip_id and actor_id = @actor_id and finish = 0";
        //    }
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@actor_id",                 DbType = DbType.Int32,              Value = actorEntity.Id }
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        /**
        public List<ClipEntity> GetAllClipsByMovieId(int movieId)
        {
            string strSQL = "select * from clip where movie_id = @movie_id and isdeleted = 0";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@movie_id", DbType = DbType.Int32, Value = movieId }
            };
            return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));

        }
        public List<ClipEntity> GetAllClipsByMovieId(int movieId, Paging paging)
        {
            string strSQL = "select * from clip where movie_id = @movie_id and isdeleted = 0 order by scene limit @pageitemnum offset @itembeforenum";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@movie_id", DbType = DbType.Int32, Value = movieId },
                new MySqlParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
            };
            return GetClipEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }
        **/

        //public List<ClipEntity> GetAllClipsByMovieId(int movieId)
        //{
        //    List<ClipEntity> clipEntities = new List<ClipEntity>();
        //    string strSQL = "select * from movie_clip where movie_id = @movie_id order by movie_scene";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@movie_id",              DbType = DbType.Int32,      Value = movieId }
        //    };
        //    DataTable movieSceneTable = BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters);

        //    foreach (DataRow movieSceneRow in movieSceneTable.Rows)
        //    {

        //        string strSQL2 = "select * from clip where id = @clip_id";
        //        MySqlParameter[] parameters2 = {
        //            new MySqlParameter() { ParameterName = "@clip_id",              DbType = DbType.Int32,      Value = Convert.ToInt32(movieSceneRow["clip_id"].ToString()) }
        //        };
        //        //ClipEntity clip = GetClipEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL2, parameters2));
        //        //clip.Scene = Convert.ToInt32(movieSceneRow["movie_scene"].ToString());
        //        //clipEntities.Add(clip);
        //    }
        //    return clipEntities;
        //}

        public int GetAllClipByMovieIdCount(int movieId)
        {
            string strSQL = "select count(id) from clip where movie_id = @movie_id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@movie_id", DbType = DbType.Int32, Value = movieId}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        //public ClipEntity GetClipById(int clipId)
        //{
        //    string strSQL = "select * from clip where id = @id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
        //    };
        //    //return GetClipEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters));
        //    return null;
        //}

        public string GetClipPicFileNameById(int clipId)
        {
            string strSQL = "select * from clip where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
            };
            return BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)["pic"].ToString();
        }

        private ObservableCollection<Clip> GetClipsFromDataTable(DataTable _ClipDataTable)
        {
            ObservableCollection<Clip> clips = new ObservableCollection<Clip>();
            foreach (DataRow _ClipDataRow in _ClipDataTable.Rows)
            {
                clips.Add(GetClipFromDataRow(_ClipDataRow));
            }
            return clips;
        }

        private Clip GetClipFromDataRow(DataRow _ClipDataRow) 
        {
            Clip clip = new Clip();
            clip.Id = Convert.ToInt32(_ClipDataRow["id"].ToString());
            clip.Number = Convert.ToInt32(_ClipDataRow["number"].ToString());
            clip.Scene = Convert.ToInt32(_ClipDataRow["scene"].ToString());
            clip.Title = _ClipDataRow["title"].ToString();
            clip.Date = Convert.ToDateTime(_ClipDataRow["date"].ToString());
            clip.Description = _ClipDataRow["description"].ToString();
            clip.Pic = _ClipDataRow["pic"].ToString();
            clip.FilePath = _ClipDataRow["filepath"].ToString();
            clip.Start = Convert.ToInt32(_ClipDataRow["start"].ToString());
            clip.Code = Convert.ToInt32(_ClipDataRow["code"].ToString());
            clip.Size = Convert.ToInt32(_ClipDataRow["size"].ToString());
            clip.Finish = Convert.ToInt32(_ClipDataRow["finish"].ToString());
            clip.ClipUrl = _ClipDataRow["clipurl"].ToString();
            return clip;
        }

        private void addMovieClip(int movieId, int movie_scene, int clipId) 
        {
            string strSQL = "insert into movie_clip values (@movie_id, @movie_scene, @clip_id)";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@movie_id",        DbType = DbType.Int32,      Value = movieId },
                new MySqlParameter() { ParameterName = "@movie_scene",     DbType = DbType.Int32,      Value = movie_scene },
                new MySqlParameter() { ParameterName = "@clip_id",         DbType = DbType.Int32,      Value = clipId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);

        }

        private void updateMovieClip(int movieId, int movie_scene, int clipId)
        {
            string strSQL = "update movie_clip set movie_scene = @movie_scene where movie_id = @movie_id and clip_id = @clip_id";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@movie_id",        DbType = DbType.Int32,      Value = movieId },
                new MySqlParameter() { ParameterName = "@movie_scene",     DbType = DbType.Int32,      Value = movie_scene },
                new MySqlParameter() { ParameterName = "@clip_id",         DbType = DbType.Int32,      Value = clipId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void SetClipCodeById(int clipId, int code)
        {
            string strSQL = "update clip set code = @code where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@code", DbType = DbType.Int32, Value = code },
                new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void SetClipSizeById(int clipId, int size)
        {
            string strSQL = "update clip set size = @size where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@size", DbType = DbType.Int32, Value = size },
                new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void SetClipNSPFinishById(int clipId, int size)
        {

            string strSQL = "update clip set finish = 2, size = @size where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id",    DbType = DbType.Int32, Value = clipId },
                new MySqlParameter(){ ParameterName = "@size",  DbType = DbType.Int32, Value = size }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void SetFinishClearById(int clipId, int size)
        {

            string strSQL = "update clip set finish = 0, size = @size where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id",    DbType = DbType.Int32, Value = clipId },
                new MySqlParameter(){ ParameterName = "@size",  DbType = DbType.Int32, Value = size }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void SetClipXCIFinishById(int clipId, int size)
        {
            string strSQL = "update clip set finish = 3, size = @size where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id",    DbType = DbType.Int32, Value = clipId },
                new MySqlParameter(){ ParameterName = "@size",  DbType = DbType.Int32, Value = size }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void SetClipNSZFinishById(int clipId, int size)
        {
            string strSQL = "update clip set finish = 5, size = @size where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id",    DbType = DbType.Int32, Value = clipId },
                new MySqlParameter(){ ParameterName = "@size",  DbType = DbType.Int32, Value = size }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }


        public void SetClipCIAFinishById(int clipId, int finish)
        {
            string strSQL = "update clip set finish = 4 where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = clipId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public int GetAllClipCountByCompany(int company_id)
        {
            string strSQL = "select count(id) from clip where company_id = @company_id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = company_id}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        public int GetAllClipCountByCompany(int company_id, string _Search)
        {
            _Search = "%" + _Search + "%";

            string strSQL = "select count(distinct clip.id) from clip left join (select * from clip_actor where clip_actor.actor_id in (select actor.id from actor where actor.name like @search)) as new_clip_actor on clip.id = new_clip_actor.clip_id where (clip.description like @search or clip.title like @search) and company_id = @company_id order by number desc, title asc";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = company_id},
                new MySqlParameter(){ ParameterName = "@search",               DbType = DbType.String,              Value = _Search}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        public int GetAllClipCountByCompanyWithFinish(int company_id, bool HasVideo)
        {
            string strSQL = "";
            if (HasVideo)
            {
                strSQL = "select count(id) from clip where company_id = @company_id and finish > 0";
            }
            else
            {
                strSQL = "select count(id) from clip where company_id = @company_id and finish = 0";
            }
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@company_id",               DbType = DbType.Int32,              Value = company_id }
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        public int GetAllClipCountBySeries(int series_id)
        {
            string strSQL = "select count(id) from clip where series_id = @series_id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = series_id }
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        public int GetAllClipCountBySeries(int series_id, string _Search)
        {

            _Search = "%" + _Search + "%";
            string strSQL = "select count(distinct clip.id) from clip left join (select * from clip_actor where clip_actor.actor_id in (select actor.id from actor where actor.name like @search)) as new_clip_actor on clip.id = new_clip_actor.clip_id where (clip.description like @search or clip.title like @search) and series_id = @series_id order by number desc, title asc";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = series_id },
                new MySqlParameter(){ ParameterName = "@search",                DbType = DbType.String,              Value = _Search }
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        public int GetAllClipCountBySeriesWithFinish(int series_id, bool HasVideo)
        {
            string strSQL = "";
            if (HasVideo)
            {
                strSQL = "select count(id) from clip where series_id = @series_id and finish > 0";
            }
            else
            {
                strSQL = "select count(id) from clip where series_id = @series_id and finish = 0";
            }

            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",                DbType = DbType.Int32,              Value = series_id }

            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        public int GetAllClipCountByActor(int actor_id)
        {
            string strSQL = "select count(clip_id) from clip_actor where actor_id = @actor_id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@actor_id",                DbType = DbType.Int32,              Value = actor_id }
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }


        public ObservableCollection<Clip> GetAllClips()
        {
            string strSQL = "select * from clip";
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        }

        public ObservableCollection<Clip> GetAllFinishClips()
        {
            string strSQL = "select * from clip where finish != 0";
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        }


        /// <summary>
        /// 更新视频信息
        /// </summary>
        /// <param name="company_id"></param>
        /// <returns></returns>
        public ObservableCollection<Clip> GetAllClipsByCompany(int company_id)
        {
            string strSQL = "select * from clip where company_id = @company_id and finish > 0 order by number desc, title asc";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@company_id",    DbType = DbType.Int32, Value = company_id }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllHasVideoClips()
        {
            string strSQL = "select * from clip where finish > @finish and size = 0 order by number desc, title asc";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@finish",    DbType = DbType.Int32, Value = 0 }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }



        /// <summary>
        /// 更新视频信息
        /// </summary>
        /// <param name="series_id"></param>
        /// <param name="_Paging"></param>
        /// <returns></returns>
        public ObservableCollection<Clip> GetAllClipsBySeries(int series_id)
        {
            string strSQL = "select * from clip where series_id = @series_id and finish > 0 order by number desc, title asc";

            //string strSQL = "select * from clip where series_id = @series_id  order by number";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",     DbType = DbType.Int32, Value = series_id }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsFromXhamster(int series_id)
        {
            string strSQL = "select * from clip where series_id = @series_id and finish = 0 order by number desc, title asc";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",     DbType = DbType.Int32, Value = series_id }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsFromJFF(int series_id)
        {
            string strSQL = "select * from clip where series_id = @series_id and finish = 0 order by number desc, title asc";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",     DbType = DbType.Int32, Value = series_id }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsByCompany(int company_id, Paging _Paging)
        {
            string strSQL = "select * from clip where company_id = @company_id and isdeleted = 0 order by number desc, title asc limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@company_id",    DbType = DbType.Int32, Value = company_id },
                new MySqlParameter(){ ParameterName = "@start_item",    DbType = DbType.Int32, Value = (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",      DbType = DbType.Int32, Value = _Paging.PageItemNum }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsByCompany(int company_id, string _Search, Paging _Paging)
        {

            _Search = "%" + _Search + "%";
            string strSQL = "select distinct clip.* from clip left join (select * from clip_actor where clip_actor.actor_id in (select actor.id from actor where actor.name like @search)) as new_clip_actor on clip.id = new_clip_actor.clip_id where (clip.description like @search or clip.title like @search) and company_id = @company_id order by number desc, title asc limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@company_id",    DbType = DbType.Int32, Value = company_id },
                new MySqlParameter(){ ParameterName = "@start_item",    DbType = DbType.Int32, Value = (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",      DbType = DbType.Int32, Value = _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@search",      DbType = DbType.String, Value = _Search }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetClipById(int clip_id)
        {
            string strSQL = "select * from clip where id = @clip_id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@clip_id",    DbType = DbType.Int32, Value = clip_id }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsByCompanyWithFinish(int company_id, bool HasVideo, Paging _Paging)
        {
            string strSQL = "";
            if (HasVideo)
            {
                strSQL = "select * from clip where company_id = @company_id and finish > 0 and isdeleted = 0 order by number desc, title asc limit @start_item, @item_num";
            }
            else
            {
                strSQL = "select * from clip where company_id = @company_id and finish = 0 and isdeleted = 0 order by number desc, title asc limit @start_item, @item_num";
            }
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@company_id",    DbType = DbType.Int32,              Value = company_id },
                new MySqlParameter(){ ParameterName = "@start_item",    DbType = DbType.Int32,              Value = (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",      DbType = DbType.Int32,              Value = _Paging.PageItemNum }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsBySeries(int series_id, Paging _Paging)
        {
            string strSQL = "select * from clip where series_id = @series_id and isdeleted = 0 order by number desc, title asc limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",     DbType = DbType.Int32, Value = series_id },
                new MySqlParameter(){ ParameterName = "@start_item",    DbType = DbType.Int32, Value = (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",      DbType = DbType.Int32, Value = _Paging.PageItemNum }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsBySeries(int series_id, string _Search, Paging _Paging)
        {

            _Search = "%" + _Search + "%";
            string strSQL = "select distinct clip.* from clip left join (select * from clip_actor where clip_actor.actor_id in (select actor.id from actor where actor.name like @search)) as new_clip_actor on clip.id = new_clip_actor.clip_id where (clip.description like @search or clip.title like @search) and series_id = @series_id order by number desc, title asc limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",     DbType = DbType.Int32, Value = series_id },
                new MySqlParameter(){ ParameterName = "@start_item",    DbType = DbType.Int32, Value = (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",      DbType = DbType.Int32, Value = _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@search",        DbType = DbType.String, Value = _Search }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsBySeriesWithFinish(int series_id, bool HasVideo, Paging _Paging)
        {
            string strSQL = "";
            if (HasVideo)
            {
                strSQL = "select * from clip where series_id = @series_id and finish > 0 and isdeleted = 0 order by number desc, title asc limit @start_item, @item_num";
            }
            else
            {
                strSQL = "select * from clip where series_id = @series_id and finish = 0 and isdeleted = 0 order by number desc, title asc limit @start_item, @item_num";
            }
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@series_id",     DbType = DbType.Int32,              Value = series_id },
                new MySqlParameter(){ ParameterName = "@start_item",    DbType = DbType.Int32, Value = (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",      DbType = DbType.Int32, Value = _Paging.PageItemNum }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Clip> GetAllClipsByActor(int actor_id, Paging _Paging)
        {
            string strSQL = "select * from clip where clip.id in (select clip_id from clip_actor where actor_id = @actor_id) order by number desc, title asc limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@actor_id",      DbType = DbType.Int32, Value = actor_id },
                new MySqlParameter(){ ParameterName = "@start_item",    DbType = DbType.Int32, Value = (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",      DbType = DbType.Int32, Value = _Paging.PageItemNum }
            };
            return GetClipsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        /// <summary>
        /// ScraperService 的数据库调用
        /// </summary>
        public Clip GetLastClipWithCompanyId(int company_id)
        {
            string strSQL = "select * from clip where company_id = @company_id and number = (select max(number) from clip where company_id = @company_id)";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@company_id",      DbType = DbType.Int32,      Value = company_id }
                };
            DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
            return GetClipFromDataRow(DataRow);
        }

        /// <summary>
        /// ScraperService 的数据库调用
        /// </summary>
        public Clip GetLastClipWithSeriesId(int series_id)
        {
            string strSQL = "select * from clip where series_id = @series_id and number = (select max(number) from clip where series_id = @series_id)";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@series_id",       DbType = DbType.Int32,      Value = series_id }
                };
            DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
            return GetClipFromDataRow(DataRow);
        }

        public Clip getClipBySeriesAndNumber(int series_id, int number)
        {
            string strSQL = "select * from clip where series_id = @series_id and number = @number";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@series_id",       DbType = DbType.Int32,      Value = series_id },
                new MySqlParameter() { ParameterName = "@number",          DbType = DbType.Int32,      Value = number }
                };
            DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
            return GetClipFromDataRow(DataRow);
        }

        //public Clip getClipByTitle(string title)
        //{
        //    string strSQL = "select * from clip where title = @title";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@title",       DbType = DbType.String,      Value = title }
        //        };
        //    DataRow DataRow = BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters);
        //    return GetClipFromDataRow(DataRow);
        //}


    }
}
