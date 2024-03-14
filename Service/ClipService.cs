using com.gestapoghost.entertainment.Dao.MySQL;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.tools;
using MediaInfoLib;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace com.gestapoghost.entertainment.service
{
    public class ClipService
    {
        private static ClipService clipService = null;

        public static ClipService GetClipService()
        {
            if (clipService == null)
            {
                clipService = new ClipService();
            }
            return clipService;
        }

        public void SetClipCodeById(int clipId, int code)
        {
            ClipDao.GetClipDao().SetClipCodeById(clipId, code);
        }

        public void SetClipSizeById(int clipId, int size)
        {
            ClipDao.GetClipDao().SetClipSizeById(clipId, size);
        }

        public void SetFinishClipClear(Clip _Clip)
        {
            ClipDao.GetClipDao().SetFinishClearById(_Clip.Id, 0);
        }

        public void SetOneDrive(Clip _Clip)
        {
            ClipDao.GetClipDao().SetOneDriveById(_Clip.Id, 0);
        }

        public void FinishClipNSP(Clip _Clip, int size)
        {
            ClipDao.GetClipDao().SetClipNSPFinishById(_Clip.Id, size);
        }

        public void FinishClipXCI(Clip _Clip, int size)
        {
            ClipDao.GetClipDao().SetClipXCIFinishById(_Clip.Id, size);
        }
        public void FinishClipNSZ(Clip _Clip, int size)
        {
            ClipDao.GetClipDao().SetClipNSZFinishById(_Clip.Id, size);
        }

        public void FinishClipCIA(int clipId)
        {
            ClipDao.GetClipDao().SetClipCIAFinishById(clipId, 1);
        }

        public bool CreateOrUpdateClip(Clip _Clip, Company _Company, Series _Series, Movie _Movie, ObservableCollection<Actor> _Actors)
        {
            if (_Clip.Id == 0)
            {
                int _SeriesId = 0;
                if (_Series != null) _SeriesId = _Series.Id;
                _Clip.Id = ClipDao.GetClipDao().CreateClip(_Company.Id, _SeriesId, _Clip.Number, _Clip.Title, _Clip.Date, _Clip.Description, _Clip.Pic, _Clip.FilePath, _Clip.Start, _Clip.ClipUrl);
            }
            else
            {
                ClipDao.GetClipDao().UpdateClip(_Clip.Id, _Clip.Number, _Clip.Title, _Clip.Date, _Clip.Description, _Clip.Pic, _Clip.FilePath, _Clip.Start, _Clip.ClipUrl);
            }

            ClipDao.GetClipDao().DeleteClipActor(_Clip.Id);
            foreach (Actor _Actor in _Actors)
            {
                ClipDao.GetClipDao().CreateClipActor(_Clip.Id, _Actor.Id);
            }

            ClipDao.GetClipDao().CreateOrUpdateMovieScene(_Movie.Id, _Clip.Id, _Clip.Scene);
            return true;
        }

        public bool CreateOrUpdateComic(Clip _Comic, Company _Company,Movie _Movie)
        {
            if (_Comic.Id == 0)
            {
                int _SeriesId = 0;
                _Comic.Id = ClipDao.GetClipDao().CreateClip(_Company.Id, _SeriesId, _Comic.Number, _Comic.Title, _Comic.Date, _Comic.Description, _Comic.Pic, _Comic.FilePath, _Comic.Start, _Comic.ClipUrl);
            }
            else
            {
                ClipDao.GetClipDao().UpdateClip(_Comic.Id, _Comic.Number, _Comic.Title, _Comic.Date, _Comic.Description, _Comic.Pic, _Comic.FilePath, _Comic.Start, _Comic.ClipUrl);
            }

            ClipDao.GetClipDao().CreateOrUpdateMovieScene(_Movie.Id, _Comic.Id, _Comic.Scene);
            return true;
        }



        public bool CreateOrUpdateComic(Clip _Clip, Movie _Movie)
        {
            if (_Clip.Id == 0)
            {
                int _SeriesId = 0;
                int _CompanyId = 0;
                _Clip.Id = ClipDao.GetClipDao().CreateClip(_CompanyId, _SeriesId, _Clip.Number, _Clip.Title, _Clip.Date, _Clip.Description, _Clip.Pic, _Clip.FilePath, _Clip.Start, _Clip.ClipUrl);
            }
            else
            {
                ClipDao.GetClipDao().UpdateClip(_Clip.Id, _Clip.Number, _Clip.Title, _Clip.Date, _Clip.Description, _Clip.Pic, _Clip.FilePath, _Clip.Start, _Clip.ClipUrl);
            }


            ClipDao.GetClipDao().CreateOrUpdateMovieScene(_Movie.Id, _Clip.Id, _Clip.Scene);
            return true;
        }

        public bool CreateOrUpdateClip(Clip _Clip, Company _Company, Series _Series, ObservableCollection<Actor> _Actors)
        {
            if (_Clip.Id == 0)
            {
                if (_Series == null)
                {
                    _Clip.Id = ClipDao.GetClipDao().CreateClip(_Company.Id, 0, _Clip.Number, _Clip.Title, _Clip.Date, _Clip.Description, _Clip.Pic, _Clip.FilePath, _Clip.Start, _Clip.ClipUrl);
                }
                else
                {
                    _Clip.Id = ClipDao.GetClipDao().CreateClip(_Company.Id, _Series.Id, _Clip.Number, _Clip.Title, _Clip.Date, _Clip.Description, _Clip.Pic, _Clip.FilePath, _Clip.Start, _Clip.ClipUrl);
                }
            }
            else
            {
                ClipDao.GetClipDao().UpdateClip(_Clip.Id, _Clip.Number, _Clip.Title, _Clip.Date, _Clip.Description, _Clip.Pic, _Clip.FilePath, _Clip.Start, _Clip.ClipUrl);
            }

            ClipDao.GetClipDao().DeleteClipActor(_Clip.Id);
            foreach (Actor _Actor in _Actors)
            {
                ClipDao.GetClipDao().CreateClipActor(_Clip.Id, _Actor.Id);
            }
            return true;
        }

        public Paging GetAllClipsPagingFromCompany(Company _Company, int _HasVideo, string _Search)
        {
            

            if (string.Equals("", _Search) || _Search == null)
            {
                switch (_HasVideo)
                {
                    case 1:
                        return new Paging(ClipDao.GetClipDao().GetAllClipCountByCompanyWithFinish(_Company.Id, true));
                    case 2:
                        return new Paging(ClipDao.GetClipDao().GetAllClipCountByCompanyWithFinish(_Company.Id, false));
                    default:
                        return new Paging(ClipDao.GetClipDao().GetAllClipCountByCompany(_Company.Id));
                }
            }
            else
            {
                return new Paging(ClipDao.GetClipDao().GetAllClipCountByCompany(_Company.Id, _Search));
            }
        }

        public Paging GetAllClipsPagingFromSeries(Series _Series, int _HasVideo, string _Search)
        {
            if (_Search != null) _Search = _Search.Replace("'", "\'");

            if (string.Equals("", _Search) || _Search == null)
            {
                switch (_HasVideo)
                {
                    case 1:
                        return new Paging(ClipDao.GetClipDao().GetAllClipCountBySeriesWithFinish(_Series.Id, true));
                    case 2:
                        return new Paging(ClipDao.GetClipDao().GetAllClipCountBySeriesWithFinish(_Series.Id, false));
                    default:
                        return new Paging(ClipDao.GetClipDao().GetAllClipCountBySeries(_Series.Id));
                }
            }
            else
            {
                return new Paging(ClipDao.GetClipDao().GetAllClipCountBySeries(_Series.Id, _Search));
            }
            return null;
        }

        public Paging GetAllClipsPagingFromActor(Actor _Actor)
        {
            return new Paging(ClipDao.GetClipDao().GetAllClipCountByActor(_Actor.Id));
        }

        public ObservableCollection<Clip> GetAllClipsFromCompany(Company _Company, int _HasVideo, string _Search, Paging _Paging)
        {
            

            if (string.Equals("", _Search) || _Search == null)
            {
                switch (_HasVideo)
                {
                    case 1:
                        return ClipDao.GetClipDao().GetAllClipsByCompanyWithFinish(_Company.Id, true, _Paging);
                    case 2:
                        return ClipDao.GetClipDao().GetAllClipsByCompanyWithFinish(_Company.Id, false, _Paging);
                    default:
                        return ClipDao.GetClipDao().GetAllClipsByCompany(_Company.Id, _Paging);
                }
            }
            else
            {
                return ClipDao.GetClipDao().GetAllClipsByCompany(_Company.Id, _Search, _Paging);
            }
        }

        public ObservableCollection<Clip> GetAllClipsFromSeries(Series _Series, int _HasVideo, string _Search, Paging _Paging)
        {
            

            if (string.Equals("", _Search) || _Search == null)
            {
                switch (_HasVideo)
                {
                    case 1:
                        return ClipDao.GetClipDao().GetAllClipsBySeriesWithFinish(_Series.Id, true, _Paging);
                    case 2:
                        return ClipDao.GetClipDao().GetAllClipsBySeriesWithFinish(_Series.Id, false, _Paging);
                    default:
                        return ClipDao.GetClipDao().GetAllClipsBySeries(_Series.Id, _Paging);
                }
            }
            else
            {
                return ClipDao.GetClipDao().GetAllClipsBySeries(_Series.Id, _Search, _Paging);
            }
        }

        public ObservableCollection<Clip> GetAllClipsFromActor(Actor _Actor, Paging _Paging)
        {
                return ClipDao.GetClipDao().GetAllClipsByActor(_Actor.Id, _Paging);
        }


        public ObservableCollection<Clip> GetAllHasVideoClips()
        {
            return ClipDao.GetClipDao().GetAllHasVideoClips();
        }

        public ObservableCollection<Clip> GetAllClipsFromCompany(int company_id)
        {
            return ClipDao.GetClipDao().GetAllClipsByCompany(company_id);
        }

        public ObservableCollection<Clip> GetAllClipsFromSeries(int series_id)
        {
            return ClipDao.GetClipDao().GetAllClipsBySeries(series_id);
        }

    }
}
