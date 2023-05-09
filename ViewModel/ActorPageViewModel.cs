using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.tools;
using System;
using System.Collections.ObjectModel;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class ActorPageViewModel : BaseViewModel
    {
        public Company Company { get; set; }
        public Series Series { get; set; }
        public Paging Paging { get; set; }
        public int ActorType { get; set; }
        public String Search { get; set; }
        private ObservableCollection<Actor> _Actors;
        private ObservableCollection<PageButton> _PageButtons;
        public ObservableCollection<Actor> Actors
        {
            get
            {
                return _Actors;
            }
            set
            {
                _Actors = value;
                OnPropertyChanged("Actors");
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

        public ActorPageViewModel(Paging _Paging)
        {
            this.Paging = _Paging;
            this.ActorType = 1;
            this.GetPaging();
            this.GetActors();
            this.GetPageButtons();
        }

        public void GetPaging()
        {
            this.Paging = ActorService.GetActorService().GetAllActorsPaging(ActorType, Search);
        }

        public void GetActors()
        {
            Actors = ActorService.GetActorService().GetAllActors(ActorType, Search, Paging);
        }

        public void GetPageButtons()
        {
            ObservableCollection<PageButton> NewPageButtons = new ObservableCollection<PageButton>();
            for (int i = this.Paging.CurrentPage - 5; i < this.Paging.CurrentPage + 5; i++)
            {
                if (i <= this.Paging.TotalPage && i > 0)
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
