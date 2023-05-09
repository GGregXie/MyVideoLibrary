using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.tools;
using System;
using System.Collections.ObjectModel;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class FansPageViewModel : BaseViewModel
    {
        public Company Company { get; set; }
        public Series Series { get; set; }
        public Paging Paging { get; set; }
        public Actor Actor { get; set; }
        public int HasVideo { get; set; }
        public String Search { get; set; }
        public String CompanySeries 
        {
            get
            {
                String Result = Company.Name;
                if (Series != null) Result = Result + " - " + Series.Name;
                return Result;
            }
        }
        private ObservableCollection<Clip> _Clips;
        private ObservableCollection<PageButton> _PageButtons;
        public ObservableCollection<Clip> Clips
        {
            get
            {
                return _Clips;
            }
            set
            {
                _Clips = value;
                OnPropertyChanged("Clips");
            }
        }
        public ObservableCollection<PageButton> PageButtons
        {
            get
            {
                return _PageButtons;
            }
            set
            {
                _PageButtons = value;
                OnPropertyChanged("PageButtons");
            }
        }

        public FansPageViewModel(Company _Company, Series _Series, Actor _Actor, Paging _Paging, int _HasVideo)
        {
            this.Company = _Company;
            this.Series = _Series;
            this.Paging = _Paging;
            this.HasVideo = _HasVideo;
            this.Actor = _Actor;
            if(this.Paging == null) this.GetPaging();
            this.GetClips();
            this.GetPageButtons();
        }

        public void GetPaging()
        {
            if (this.Actor == null)
            {
                if (this.Series == null)
                {
                    this.Paging = ClipService.GetClipService().GetAllClipsPagingFromCompany(this.Company, HasVideo, Search);
                }
                else
                {
                    this.Paging = ClipService.GetClipService().GetAllClipsPagingFromSeries(this.Series, HasVideo, Search);
                }
            }
            else
            {
                this.Paging = ClipService.GetClipService().GetAllClipsPagingFromActor(this.Actor);
            }
        }

        public void GetClips()
        {
            if (this.Actor == null)
            {
                if (this.Series == null)
                {
                    Clips = ClipService.GetClipService().GetAllClipsFromCompany(this.Company, HasVideo, Search, this.Paging);
                }
                else
                {
                    Clips = ClipService.GetClipService().GetAllClipsFromSeries(this.Series, HasVideo, Search, this.Paging);
                }
            }
            else
            {
                Clips = ClipService.GetClipService().GetAllClipsFromActor(this.Actor, this.Paging);
            }

        }

        public void GetPageButtons()
        {
            ObservableCollection<PageButton> NewPageButtons = new ObservableCollection<PageButton>();
            for (int i = this.Paging.CurrentPage - 5; i < this.Paging.CurrentPage + 5; i++)
            {
                if(i <= this.Paging.TotalPage && i > 0)
                {
                    if (i == Paging.CurrentPage)
                    {
                        PageButton _Page = new PageButton
                        {
                            PageString = "[" + i + "]",
                            PageInt = i
                        };
                        NewPageButtons.Add(_Page);
                    }
                    else 
                    {
                        PageButton _Page = new PageButton
                        {
                            PageString = "" + i,
                            PageInt = i
                        };
                        NewPageButtons.Add(_Page);
                    }
                }
            }
            this.PageButtons = NewPageButtons;
        }
    }
}
