using com.gestapoghost.entertainment.Dao.MySQL;
using com.gestapoghost.entertainment.entity;
using System;

namespace com.gestapoghost.entertainment.service
{
    class SeriesService
    {
        private static SeriesService seriesService = null;

        public static SeriesService GetSeriesService()
        {
            if (seriesService == null) 
            {
                seriesService = new SeriesService();
            }
            return seriesService;
        }

        //public SeriesEntity GetSeriesById(int seriesId) 
        //{
        //    return SeriesDao.GetSeriesDao().GetSeriesById(seriesId);
        //}

        public bool SaveOrUpdateSeries(Series _Series, Company _Company)
        {
            if (_Series.Id == 0)
            {
                try
                {
                    SeriesDao.GetSeriesDao().CreateSeries(_Series.Name, _Series.Pic, _Company.Id);
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
                    SeriesDao.GetSeriesDao().UpdateSeries(_Series.Id, _Series.Name, _Series.Pic, _Company.Id);
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
