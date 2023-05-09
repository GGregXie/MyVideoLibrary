using com.gestapoghost.entertainment.entity;
using System;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class ComicWindowViewModel : BaseViewModel
    {
        public Company Company { get; set; }
        public Series Series { get; set;  }
        public Movie Movie { get; set; }
        private Clip _Comic;
        public Clip Comic
        {
            get {
                return _Comic; 
            }
            set
            {
                _Comic = value;
                OnPropertyChanged("Comic");
            }
        }

        public ComicWindowViewModel(Company __Company, Series __Series, Movie __Movie, Clip __Comic)
        {
            this.Company = __Company;
            this.Series = __Series;
            this.Movie = __Movie;
            if (__Comic == null)
                this._Comic = new Clip() { Pic = "MovieNull", Date = Convert.ToDateTime("1980-1-1") };
            else
                this._Comic = new Clip(__Comic);

        }
    }
}
