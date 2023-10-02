using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace com.gestapoghost.entertainment.Dao.MySQL
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
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@name",            DbType = DbType.String,     Value = actorName },
                new MySqlParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = actorPic }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
            return BaseDao.getBaseDao().GetLastID();
        }

        //public ActorEntity GetActorById(int actorId)
        //{
        //    string strSQL = "select * from actor where id = @id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@id",             DbType = DbType.Int32,     Value = actorId }
        //    };
        //    return GetActorEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters));
        //}

        //public ActorEntity FindActorByName(string actorName)
        //{
        //    string strSQL = "select * from actor where name = @name";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@name",             DbType = DbType.String,     Value = actorName }
        //    };
        //    return GetActorEntityFromDataRow(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters));
        //}

        public void UpdateActor(int actorId, String actorName, String actorPic)
        {
            string strSQL = "update actor set name = @name, pic = @pic, isdeleted = 0 where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@id",              DbType = DbType.Int32,      Value = actorId },
                new MySqlParameter() { ParameterName = "@name",            DbType = DbType.String,     Value = actorName },
                new MySqlParameter() { ParameterName = "@pic",             DbType = DbType.String,     Value = actorPic }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }

        public string GetActorPicFileNameById(int actorId)
        {
            string strSQL = "select * from actor where id = @id";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@id", DbType = DbType.Int32, Value = actorId }
            };
            return BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)["pic"].ToString();
        }

        //public List<ActorEntity> GetAllActorsByClipId(int clipId)
        //{
        //    List<ActorEntity> actorEntities = new List<ActorEntity>();

        //    string strSQL = "select * from clip_actor where clip_id = @clip_id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter() { ParameterName = "@clip_id",              DbType = DbType.Int32,      Value = clipId }
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



        //public List<ActorEntity> GetAllActorsBySearch(Paging paging, string strSearch)
        //{
        //    string strSQL = "select * from actor where name like '%" + strSearch + "%' order by name limit @pageitemnum offset @itembeforenum";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@pageitemnum",     DbType = DbType.Int32,  Value = paging.PageItemNum },
        //        new MySqlParameter(){ ParameterName = "@itembeforenum",   DbType = DbType.Int32,  Value = paging.GetItemBeforeNum() }
        //    };
        //    return GetActorEntitiesFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        //}

        public ObservableCollection<Actor> GetAllActorsByPICSHA(string strSearch)
        {
            string strSQL = "select * from actor where pic like '%" + strSearch + "%'";
            return GetActorsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        }



        //public List<ActorEntity> GetAllLikeActors(Paging paging)
        //{
        //    string strSQL = "select * from actor where like = 1 order by name limit @pageitemnum offset @itembeforenum";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@pageitemnum", DbType = DbType.Int32, Value = paging.PageItemNum },
        //        new MySqlParameter(){ ParameterName = "@itembeforenum", DbType = DbType.Int32, Value = paging.GetItemBeforeNum() }
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

        private Actor GetActorFromDataRow(DataRow _ActorDataRow)
        {
            if (_ActorDataRow != null)
            {
                Actor _Actor = new Actor();
                _Actor.Id = Convert.ToInt32(_ActorDataRow["id"].ToString());
                _Actor.Name = _ActorDataRow["name"].ToString();
                _Actor.Pic = _ActorDataRow["pic"].ToString();
                String CountString = "";
                try
                {
                    CountString = _ActorDataRow["count"].ToString();
                }
                catch (Exception e)
                { 
                }
                if (CountString != "") _Actor.Count = Convert.ToInt32(CountString);
                return _Actor;
            }
            return null;
        }

        private ObservableCollection<Actor> GetActorsFromDataTable(DataTable _ActorDataTable)
        {
            ObservableCollection<Actor> _Actors = new ObservableCollection<Actor>();

            foreach (DataRow _ActorDataRow in _ActorDataTable.Rows)
            {
                _Actors.Add(GetActorFromDataRow(_ActorDataRow));
            }
            return _Actors;
        }

        //public int getClipCountByActorId(int actorId)
        //{
        //    string strSQL = "select count(actor_id) from clip_actor where actor_id = @actor_id";
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter(){ ParameterName = "@actor_id", DbType = DbType.Int32, Value = actorId}
        //    };
        //    return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        //}

        public int GetAllActorsCount()
        {
            string strSQL = "select count(id) from actor";
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL)[0].ToString());
        }
        public int GetAllActorsCount(string _Search)
        {
            _Search = "%" + _Search + "%";
            Console.WriteLine("test: " + _Search);
            string strSQL = "select count(id) from actor where name like @search";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@search",                DbType = DbType.String,              Value = _Search }
            };
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL, parameters)[0].ToString());
        }

        public int GetAllActorsCountByLove(int _Love)
        {
            string strSQL = "select count(id) from actor where love = " + _Love;
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL)[0].ToString());
        }

        public int GetAllActorsCountByLoveWithPic(int _Love)
        {
            string strSQL = "select count(id) from actor where love = " + _Love + " and pic != 'ActorNull'";
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL)[0].ToString());
        }

        public int GetAllActorsCountByLoveWithoutPic(int _Love)
        {
            string strSQL = "select count(id) from actor where love = " + _Love + " and pic = 'ActorNull'";
            return Convert.ToInt32(BaseDao.getBaseDao().GetRowBySQL(strSQL)[0].ToString());
        }

        public ObservableCollection<Actor> GetAllActors()
        {
            string strSQL = "select id, name, pic, love, count from actor";
            return GetActorsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL));
        }

        public ObservableCollection<Actor> GetAllActors(Paging _Paging)
        {
            string strSQL = "select id, name, pic, love, count from actor left join (select actor_id, count(actor_id) as count from clip_actor group by actor_id) actor_count on actor.id = actor_count.actor_id order by name limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@start_item",        DbType = DbType.Int32, Value =  (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",          DbType = DbType.Int32, Value = _Paging.PageItemNum }
            };
            return GetActorsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Actor> GetAllActors(String _Search, Paging _Paging)
        {
            _Search = "%" + _Search + "%";
            string strSQL = "select id, name, pic, love, count from actor left join (select actor_id, count(actor_id) as count from clip_actor group by actor_id) actor_count on actor.id = actor_count.actor_id where name like @search order by name limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@start_item",        DbType = DbType.Int32, Value =  (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",          DbType = DbType.Int32, Value = _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@search",          DbType = DbType.String, Value = _Search}
            };
            return GetActorsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Actor> GetAllActorsByLove(int _Love, Paging _Paging)
        {
            string strSQL = "select id, name, pic, love, count from actor left join (select actor_id, count(actor_id) as count from clip_actor group by actor_id) actor_count on actor.id = actor_count.actor_id where love = @love order by name limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@love",              DbType = DbType.Int32, Value = _Love },
                new MySqlParameter(){ ParameterName = "@start_item",        DbType = DbType.Int32, Value =  (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",          DbType = DbType.Int32, Value = _Paging.PageItemNum }
            };
            return GetActorsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Actor> GetAllActorsByLoveWithPic(int _Love, Paging _Paging)
        {
            string strSQL = "select id, name, pic, love, count from actor left join (select actor_id, count(actor_id) as count from clip_actor group by actor_id) actor_count on actor.id = actor_count.actor_id where love = @love and pic != 'ActorNull' order by name limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@love",              DbType = DbType.Int32, Value = _Love },
                new MySqlParameter(){ ParameterName = "@start_item",        DbType = DbType.Int32, Value =  (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",          DbType = DbType.Int32, Value = _Paging.PageItemNum }
            };
            return GetActorsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }

        public ObservableCollection<Actor> GetAllActorsByLoveWithoutPic(int _Love, Paging _Paging)
        {
            string strSQL = "select id, name, pic, love, count from actor left join (select actor_id, count(actor_id) as count from clip_actor group by actor_id) actor_count on actor.id = actor_count.actor_id where love = @love and pic = 'ActorNull' order by name limit @start_item, @item_num";
            MySqlParameter[] parameters = {
                new MySqlParameter(){ ParameterName = "@love",              DbType = DbType.Int32, Value = _Love },
                new MySqlParameter(){ ParameterName = "@start_item",        DbType = DbType.Int32, Value =  (_Paging.CurrentPage - 1) * _Paging.PageItemNum },
                new MySqlParameter(){ ParameterName = "@item_num",          DbType = DbType.Int32, Value = _Paging.PageItemNum }
            };
            return GetActorsFromDataTable(BaseDao.getBaseDao().GetTableBySQL(strSQL, parameters));
        }


        public void UpdateActorLike(int actor_id, int love)
        {
            string strSQL = "update actor set love = @love where id = @actor_id";
            MySqlParameter[] parameters = {
                new MySqlParameter() { ParameterName = "@actor_id",         DbType = DbType.Int32,      Value = actor_id },
                new MySqlParameter() { ParameterName = "@love",             DbType = DbType.String,     Value = love }
            };
            BaseDao.getBaseDao().ExecuteSQL(strSQL, parameters);
        }
    }
}
