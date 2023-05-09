using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;

namespace com.gestapoghost.entertainment.service
{
    class CountResult
    {
        public int Result { get; set; }
    }

    public class WebService
    {
        private static WebService _WebService = null;

        public static WebService GetWebService()
        {
            if (_WebService == null)
            {
                _WebService = new WebService();
            }
            return _WebService;
        }

        public ObservableCollection<Company> GetAllCompaniesFromWeb(int _CompanyTypeId)
        {
            string url = "http://192.168.0.50:45000/GetAllCompanyByTypeId/" + _CompanyTypeId;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            ObservableCollection<Company> _Companies = new ObservableCollection<Company>();
            foreach (Company _Company in JsonConvert.DeserializeObject<List<Company>>(myStreamReader.ReadToEnd())) _Companies.Add(_Company);
            myStreamReader.Close();
            if (response != null) response.Close();
            if (request != null) request.Abort();
            return _Companies;
        }

        public List<Series> GetAllSeriesFromCompany(Company _Company)
        {
            string url = "http://192.168.0.50:45000/GetAllSeriesByCompanyId/" + _Company.Id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            List<Series> _Series = JsonConvert.DeserializeObject<List<Series>>(myStreamReader.ReadToEnd());
            myStreamReader.Close();
            if (response != null) response.Close();
            if (request != null) request.Abort();
            return _Series;
        }

        public int GetAllSeriesCountFromCompany(Company _Company)
        {
            string url = "http://192.168.0.50:45000/GetAllSeriesCountByCompanyId/" + _Company.Id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            List<CountResult> CountResults = JsonConvert.DeserializeObject<List<CountResult>>(myStreamReader.ReadToEnd());
            int _Count = CountResults[0].Result;
            myStreamReader.Close();
            if (response != null) response.Close();
            if (request != null) request.Abort();
            return _Count;
        }

        internal List<Movie> GetAllMoviesFromCompanyOrSeries(Company _Company, Series _Series)
        {
            if (_Series == null)
            {
                string url = "http://192.168.0.50:45000/movie/GetAllMovieByCompanyId/" + _Company.Id;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                List<Movie> _Movies = JsonConvert.DeserializeObject<List<Movie>>(myStreamReader.ReadToEnd());
                myStreamReader.Close();
                if (response != null) response.Close();
                if (request != null) request.Abort();
                return _Movies;
            }
            else
            {
                string url = "http://192.168.0.50:45000/movie/GetAllMovieBySeriesId/" + _Series.Id;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                List<Movie> _Movies = JsonConvert.DeserializeObject<List<Movie>>(myStreamReader.ReadToEnd());
                myStreamReader.Close();
                if (response != null) response.Close();
                if (request != null) request.Abort();
                return _Movies;
            }
        }


        public List<Clip> GetAllScenesFromMovie(Movie _Movie)
        {
            string url = "http://192.168.0.50:45000/movie/GetAllClipsByMovieId2/" + _Movie.Id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            List<Clip> _Scenes = JsonConvert.DeserializeObject<List<Clip>>(myStreamReader.ReadToEnd());

            myStreamReader.Close();
            if (response != null) response.Close();
            if (request != null) request.Abort();
            return _Scenes;
        }

        public ObservableCollection<Actor> GetAllActorsFromClip(Clip _Clip)
        {
            string url = "http://192.168.0.50:45000/GetAllActorsFromClipId/" + _Clip.Id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            ObservableCollection<Actor> _Actors = new ObservableCollection<Actor>();
            foreach (Actor _Actor in JsonConvert.DeserializeObject<List<Actor>>(myStreamReader.ReadToEnd())) _Actors.Add(_Actor);
            myStreamReader.Close();
            if (response != null) response.Close();
            if (request != null) request.Abort();
            return _Actors;
        }

        public Actor GetActorByName(string actorName)
        {
            string url = "http://192.168.0.50:45000/GetActorByName/" + actorName;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            List<Actor> _Actors = JsonConvert.DeserializeObject<List<Actor>>(myStreamReader.ReadToEnd());
            myStreamReader.Close();
            if (response != null) response.Close();
            if (request != null) request.Abort();
            if (_Actors.Count > 0) return _Actors[0];
            else return null;
        }

        public List<Clip> GetAllComicsFromMovie(Movie _Movie)
        {
            string url = "http://192.168.0.50:45000/movie/GetAllClipsByMovieId2/" + _Movie.Id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            List<Clip> _Scenes = JsonConvert.DeserializeObject<List<Clip>>(myStreamReader.ReadToEnd());
            myStreamReader.Close();
            if (response != null) response.Close();
            if (request != null) request.Abort();
            return _Scenes;
        }

    }
}
