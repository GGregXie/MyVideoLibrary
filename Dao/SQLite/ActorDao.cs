using com.gestapoghost.entertainment.tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.Dao.SQLite
{
    public class ActorDao
    {
        private static ActorDao actorDao = null;

        public static ActorDao GetActorDao() 
        {
            if (actorDao == null)
            {
                actorDao = new ActorDao();
            }
            return actorDao;
        }

        public int CreateActor(String actorName, String actorPic)
        {
            string strSQL = "insert into actor values (null, @name, @pic, 1, 0)";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@name",            DbType = DbType.String,     Value = actorName },
                new SQLiteParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = actorPic }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
            return BaseDao.getBaseDao().GetLastID();
        }

        //public ActorEntity GetActorById(int actorId)
        //{
        //    string strSQL = "select * from actor where id = @id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@id",             DbType = DbType.Int32,     Value = actorId }
        //    };
        //    return GetActorEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters));
        //}

        //public ActorEntity FindActorByName(string actorName)
        //{
        //    string strSQL = "select * from actor where name = @name";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@name",             DbType = DbType.String,     Value = actorName }
        //    };
        //    return GetActorEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters));
        //}

        public void UpdateActor(int actorId, String actorName, String actorPic)
        {
            string strSQL = "update actor set name = @name, pic = @pic, isdeleted = 0 where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = actorId },
                new SQLiteParameter() { ParameterName = "@name",            DbType = DbType.String,     Value = actorName },
                new SQLiteParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = actorPic }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public void UpdateActorLike(int actorId, int likeId)
        {
            string strSQL = "update actor set like = @like where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = actorId },
                new SQLiteParameter() { ParameterName = "@like",             DbType = DbType.String,     Value = likeId }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }


        public string GetActorPicFileNameById(int actorId)
        {
            string strSQL = "select * from actor where id = @id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = actorId }
            };
            return BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)["pic"].ToString();
        }

        //public List<ActorEntity> GetAllActorsByClipId(int clipId)
        //{
        //    List<ActorEntity> actorEntities = new List<ActorEntity>();

        //    string strSQL = "select * from clip_actor where clip_id = @clip_id";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter() { ParameterName = "@clip_id",              DbType = DbType.Int32,      Value = clipId }
        //    };
        //    DataTable clipActorTable = BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters);
        //    foreach (DataRow clipActorRow in clipActorTable.Rows)
        //    {
        //        actorEntities.Add(ActorDao.GetActorDao().GetActorById(Convert.ToInt32(clipActorRow["actor_id"])));
        //    }
        //    return actorEntities;
        //}

        //public List<ActorEntity> GetAllActorsByMovieId(int movieId)
        //{
        //    List<ActorEntity> actorEntities = new List<ActorEntity>();
        //    List<ClipEntity> allClips = ClipDao.GetClipDao().GetAllClipsByMovieId(movieId);

        //    foreach (ClipEntity clipEntity in allClips)
        //    {
        //        actorEntities.AddRange(GetAllActorsByClipId(clipEntity.Id));
        //    }

        //    return actorEntities;
        //}

        //public List<ActorEntity> GetAllActors(Paging paging)
        //{
        //    string strSQL = "select * from actor order by name limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetActorEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ActorEntity> GetAllActorsBySearch(Paging paging, string strSearch)
        //{
        //    string strSQL = "select * from actor where name like '%" + strSearch + "%' order by name limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum",     DbType = DbType.Int32,  Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum",   DbType = DbType.Int32,  Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetActorEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        //public List<ActorEntity> GetAllActorsByPICSHA(string strSearch)
        //{
        //    string strSQL = "select * from actor where pic like '%" + strSearch + "%'";
        //    return GetActorEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        //}



        //public List<ActorEntity> GetAllLikeActors(Paging paging)
        //{
        //    string strSQL = "select * from actor where like = 1 order by name limit @pageitemnum offset @itembeforenum";
        //    SQLiteParameter[] parameters = {
        //        new SQLiteParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new SQLiteParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetActorEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}



        //public void DeleteCompany(int companyId)
        //{
        //    BaseDao.getBaseDao().ExecuteSQL("update company set isdeleted = 1 where id = " + companyId);
        //}

        //public List<CompanyEntity> GetAllCompanyByType(int typeid)
        //{
        //    return GetCompanyEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL("select * from company where type = " + typeid + " and isdeleted = 0"));
        //}

        //public CompanyEntity getCompanyById(int companyId)
        //{
        //    return GetCompanyEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL("select * from company where id = " + companyId));
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

        //private ActorEntity GetActorEntityFromDataRow(DataRow companyDataRow)
        //{
        //    if (companyDataRow != null)
        //    {
        //        ActorEntity actorEntity = new ActorEntity();
        //        actorEntity.Id = Convert.ToInt32(companyDataRow["id"].ToString());
        //        actorEntity.Name = companyDataRow["name"].ToString();
        //        actorEntity.Pic = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/" + companyDataRow["pic"].ToString(), UriKind.RelativeOrAbsolute));

        //        return actorEntity;
        //    }
        //    else {
        //        return null;
        //    }
        //}

        //private List<ActorEntity> GetActorEntitiesFromDataTable(DataTable actorDataTable)
        //{
        //    List<ActorEntity> actorEntities = new List<ActorEntity>();

        //    foreach (DataRow actorDataRow in actorDataTable.Rows)
        //    {
        //        actorEntities.Add(GetActorEntityFromDataRow(actorDataRow));
        //    }
        //    return actorEntities;
        //}

        public int GetAllActorCount()
        {
            string strSQL = "select count(id) from actor";
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL)[0].ToString());
        }
        public int GetActorCountBySearch(string strSearch)
        {
            string strSQL = "select count(id) from actor where name like '%" + strSearch + "%'";
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL)[0].ToString());
        }

        public int GetAllLikeActorCount()
        {
            string strSQL = "select count(id) from actor where like = 1";
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL)[0].ToString());
        }

        public int getClipCountByActorId(int actorId)
        {
            string strSQL = "select count(actor_id) from clip_actor where actor_id = @actor_id";
            SQLiteParameter[] parameters = {
                new SQLiteParameter(){ ParameterName = "@actor_id", DbType = DbType.Int32, Value = actorId}
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }
    }
}
