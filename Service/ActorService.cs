using com.gestapoghost.entertainment.Dao.MySQL;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.tools;
using System.Collections.ObjectModel;

namespace com.gestapoghost.entertainment.service
{
    public class ActorService
    {
        private static ActorService actorService = null;

        public static ActorService GetActorService()
        {
            if (actorService == null)
            {
                actorService = new ActorService();
            }
            return actorService;
        }

        public int CreateActor(Actor _Actor)
        {
            return ActorDao.GetActorDao().CreateActor(_Actor.Name, _Actor.Pic);
        }



        //public ActorEntity FindActorByName(string actorName)
        //{
        //    return ActorDao.GetActorDao().FindActorByName(actorName);
        //}

        //public List<ActorEntity> GetAllActors(Paging paging)
        //{
        //    return ActorDao.GetActorDao().GetAllActors(paging);
        //}
        //public List<ActorEntity> GetAllActorsByType(Paging paging, int listType)
        //{
        //    List<ActorEntity> actors = null;
        //    switch (listType)
        //    {
        //        case 1:
        //            actors = ActorDao.GetActorDao().GetAllActors(paging);
        //            break;
        //        case 2:
        //            actors = ActorDao.GetActorDao().GetAllLikeActors(paging);
        //            break;
        //        default:
        //            actors = null;
        //            break;
        //    }
        //    return actors;
        //}

        //public List<ActorEntity> GetAllActorsBySearch(Paging paging, string strSearch)
        //{
        //    List<ActorEntity> actors = null;
        //    actors = ActorDao.GetActorDao().GetAllActorsBySearch(paging, strSearch);

        //    return actors;
        //}



        //public List<ActorEntity> GetActorsByClipId(int clipId)
        //{
        //    return ActorDao.GetActorDao().GetAllActorsByClipId(clipId);
        //}

        //public List<ActorEntity> GetActorsByMovieId(int movieId)
        //{
        //    return ActorDao.GetActorDao().GetAllActorsByMovieId(movieId);
        //}

        public void UpdateActor(Actor _Actor)
        {
            ActorDao.GetActorDao().UpdateActor(_Actor.Id, _Actor.Name, _Actor.Pic);
        }

        public void UpdateActorLike(Actor _Actor, int likeId)
        {
            ActorDao.GetActorDao().UpdateActorLike(_Actor.Id, likeId);
        }

        //public Paging GetPaging()
        //{
        //    return new Paging(ActorDao.GetActorDao().GetAllActorCount(), 100);
        //}

        //public Paging GetPagingByType(int listType)
        //{
        //    Paging paging = null;

        //    switch (listType)
        //    {
        //        case 1:
        //            paging = new Paging(ActorDao.GetActorDao().GetAllActorCount(), 100);
        //            break;
        //        case 2:
        //            paging = new Paging(ActorDao.GetActorDao().GetAllLikeActorCount(),100);
        //            break;
        //        default:
        //            paging = null;
        //            break;
        //    }
        //    return paging;
        //}

        //public Paging GetPagingBySearch(string strSearch)
        //{
        //    Paging paging = null;

        //    paging = new Paging(ActorDao.GetActorDao().GetActorCountBySearch(strSearch), 100);

        //    return paging;
        //}

        //public int getClipCountByActorId(int actorId)
        //{
        //    return ActorDao.GetActorDao().getClipCountByActorId(actorId);
        //}

        public Paging GetAllActorsPaging(int _ActorType, string _Search)
        {
            if (string.Equals("", _Search) || _Search == null)
            {
                switch (_ActorType)
                {
                    case 1:
                        return new Paging(ActorDao.GetActorDao().GetAllActorsCountByLove(1));
                    case 2:
                        return new Paging(ActorDao.GetActorDao().GetAllActorsCountByLove(2));
                    case 3:
                        return new Paging(ActorDao.GetActorDao().GetAllActorsCountByLove(3));
                    case 4:
                        return new Paging(ActorDao.GetActorDao().GetAllActorsCountByLoveWithPic(1));
                    case 5:
                        return new Paging(ActorDao.GetActorDao().GetAllActorsCountByLoveWithoutPic(1));
                    default:
                        return new Paging(ActorDao.GetActorDao().GetAllActorsCount());
                }
            }
            else
            {
                return new Paging(ActorDao.GetActorDao().GetAllActorsCount(_Search));
            }
        }

        public ObservableCollection<Actor> GetAllActors(int _ActorType, string _Search, Paging _Paging)
        {
            if (string.Equals("", _Search) || _Search == null)
            {
                switch (_ActorType)
                {
                    case 1:
                        return ActorDao.GetActorDao().GetAllActorsByLove(1, _Paging);
                    case 2:
                        return ActorDao.GetActorDao().GetAllActorsByLove(2, _Paging);
                    case 3:
                        return ActorDao.GetActorDao().GetAllActorsByLove(3, _Paging);
                    case 4:
                        return ActorDao.GetActorDao().GetAllActorsByLoveWithPic(1, _Paging);
                    case 5:
                        return ActorDao.GetActorDao().GetAllActorsByLoveWithoutPic(1, _Paging);
                    default:
                        return ActorDao.GetActorDao().GetAllActors(_Paging);
                }
            }
            else
            {
                return ActorDao.GetActorDao().GetAllActors(_Search, _Paging);
            }
        }
    }
}
