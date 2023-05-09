using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using System;
using System.Collections.Generic;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class ScenePageViewModel
    {
        public String ScraperUrl { get; set; }

        private List<Clip> _Scenes;

        public List<Clip> Scenes
        {
            get { return _Scenes; }
            set { _Scenes = value; }
        }

        public ScenePageViewModel(Movie _Movie)
        {
            this._Scenes = WebService.GetWebService().GetAllScenesFromMovie(_Movie);
        }
    }
}
