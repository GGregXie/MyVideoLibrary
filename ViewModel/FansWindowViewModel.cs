using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class FansWindowViewModel : BaseViewModel
    {
        public Company Company { get; set; }
        public Series Series { get; set; }
        public Paging ClipPaging { get; set; }
        public int ClipHasVideo { get; set; }

        private Clip _Clip;
        public Clip Clip
        {
            get { return _Clip; }
            set
            {
                _Clip = value;
                OnPropertyChanged("Clip");
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

        public FansWindowViewModel(Company __Company, Series __Series, Paging __ClipPaging,int __ClipHasVideo, Clip __Clip)
        {
            this.Company = __Company;
            this.Series = __Series;
            this.ClipPaging = __ClipPaging;
            this.ClipHasVideo = __ClipHasVideo;
            if (__Clip == null)
                this._Clip = new Clip() { Pic = "ClipNull", Date = Convert.ToDateTime("1980-1-1") };
            else
                this._Clip = new Clip(__Clip);
            this._Actors = WebService.GetWebService().GetAllActorsFromClip(this._Clip);
        }

        public String CompanySeries
        {
            get 
            { 
                string CompanySeries = "";
                if(Company != null) CompanySeries += Company.Name;
                if (Series != null) CompanySeries = CompanySeries + " - " + Series.Name;
                return CompanySeries;
            }
        }

        public String ActorString
        {
            get
            {
                List<string> _Actors = new List<string>() ;
                foreach (Actor _Actor in Actors)
                {
                    _Actors.Add(_Actor.Name);
                }
                return string.Join(", ", _Actors);
            }
        }
    }
}
