using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class SceneWindowViewModel : BaseViewModel
    {
        public Company Company { get; set; }
        public Series Series { get; set; }
        public Movie Movie { get; set; }
        private Clip _Scene;
        public Clip Scene
        {
            get { return _Scene; }
            set
            {
                _Scene = value;
                OnPropertyChanged("Scene");
            }
        }
        private ObservableCollection<Actor> _Actors;
        public ObservableCollection<Actor> Actors
        {
            get { return _Actors; }
            set
            {
                _Actors = value;
                OnPropertyChanged("Actors");
            }
        }

        public SceneWindowViewModel(Company __Company, Series __Series, Movie __Movie, Clip __Clip)
        {
            this.Company = __Company;
            this.Series = __Series;
            this.Movie = __Movie;
            if (__Clip == null)
                this._Scene = new Clip() { Pic = "ClipNull", Date = Convert.ToDateTime("1980-1-1") };
            else
                this._Scene = new Clip(__Clip);
            this._Actors = WebService.GetWebService().GetAllActorsFromClip(this._Scene);
        }

        public String CompanySeriesMovie
        {
            get
            { 
                string CompanySeriesMovie = "";
                CompanySeriesMovie += Company.Name;
                if (Series != null) CompanySeriesMovie = CompanySeriesMovie + " - " + Series.Name;
                CompanySeriesMovie = CompanySeriesMovie + " - " + Movie.Title;
                return CompanySeriesMovie;
            }
        }

        public String ActorString
        {
            get
            {
                List<string> _Actors = new List<string>();
                foreach (Actor _Actor in Actors)
                {
                    _Actors.Add(_Actor.Name);
                }
                return string.Join(", ", _Actors);
            }
        }
    }
}
