using com.gestapoghost.entertainment.Dao.MySQL;
using com.gestapoghost.entertainment.entity;
using System;

namespace com.gestapoghost.entertainment.service
{
    public class MovieService
    {
        private static MovieService movieService = null;

        public static MovieService GetMovieService()
        {
            if (movieService == null)
            {
                movieService = new MovieService();
            }
            return movieService;
        }

        public void SetMovieCode(Movie _Movie, string tag)
        {
            int code_id = 0;
            switch (tag)
            {
                case "NVENC":
                    code_id = 1;
                    break;
                case "HEVC":
                    code_id = 2;
                    break;
            }
            MovieDao.GetMovieDao().SetMovieCode(_Movie.Id, code_id);
        }

        public void SetMovieSource(Movie _Movie, string tag)
        {
            int source_id = 0;
            switch (tag)
            {
                case "DVD":
                    source_id = 1;
                    break;
                case "BluRay":
                    source_id = 2;
                    break;
                case "Web":
                    source_id = 3;
                    break;
                case "DVDRemux":
                    source_id = 4;
                    break;
                case "BDRemux":
                    source_id = 5;
                    break;
            }
            MovieDao.GetMovieDao().SetMovieSource(_Movie.Id, source_id);
        }



        public bool SaveOrUpdateMovie(Movie _Movie, Company _Company, Series _Series)
        {
            if (_Movie.Id == 0)
            {
                try
                {
                    int _SeriesId = 0;
                    if (_Series != null) _SeriesId = _Series.Id;
                    MovieDao.GetMovieDao().CreateMovie(_Company.Id, _SeriesId, _Movie.Title, _Movie.Date, _Movie.Description, _Movie.Pic_Front, _Movie.Pic_Back);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                try
                {
                    MovieDao.GetMovieDao().UpdateMovie(_Movie.Id, _Movie.Title, _Movie.Date, _Movie.Description, _Movie.Pic_Front, _Movie.Pic_Back);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
    }
}
