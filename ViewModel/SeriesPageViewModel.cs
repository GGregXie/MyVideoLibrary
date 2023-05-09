using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using System.Collections.Generic;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class SeriesPageViewModel
    {
        private List<Series> _Series;

        public List<Series> Series
        {
            get { return _Series; }
            set { _Series = value; }
        }

        public SeriesPageViewModel(Company _Company)
        {
            this._Series = WebService.GetWebService().GetAllSeriesFromCompany(_Company);
        }
    }
}
