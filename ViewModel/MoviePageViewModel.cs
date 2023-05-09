using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using System.Collections.Generic;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class MoviePageViewModel
    {
        private List<Movie> _Movies;

        public List<Movie> Movies
        {
            get { return _Movies; }
            set { _Movies = value; }
        }

        public MoviePageViewModel(Company _Company, Series _Series)
        {
            this._Movies = WebService.GetWebService().GetAllMoviesFromCompanyOrSeries(_Company, _Series);
        }
    }
}
