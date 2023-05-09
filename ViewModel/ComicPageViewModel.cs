using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using System.Collections.Generic;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class ComicPageViewModel
    {
        public Movie Movie { get; set; }
        private List<Clip> _Comics;

        public List<Clip> Comics
        {
            get { return _Comics; }
            set { _Comics = value; }
        }

        public ComicPageViewModel(Movie _Movie)
        {
            this.Movie = _Movie;
            this._Comics = WebService.GetWebService().GetAllComicsFromMovie(_Movie);
        }
    }
}
