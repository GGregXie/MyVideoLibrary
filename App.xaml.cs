using com.gestapoghost.entertainment.tools;
using MyMovie.xaml.Comic;
using System.Windows;
using System.Windows.Controls;

namespace com.gestapoghost.entertainment
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public ComicWindow ComicWindow;

        public ComicPage ComicPage;

        public com.gestapoghost.entertainment.xaml.company.CompanyWindow CompanyWindow;
        public com.gestapoghost.entertainment.xaml.series.SeriesWindow SeriesWindow;
        public com.gestapoghost.entertainment.xaml.movie.MovieWindow MovieWindow;
        public com.gestapoghost.entertainment.xaml.scene.SceneWindow SceneWindow;
        public com.gestapoghost.entertainment.xaml.clip.ClipWindow ClipWindow;
        public com.gestapoghost.entertainment.xaml.fans.FansWindow FansWindow;

        public com.gestapoghost.entertainment.xaml.company.CompanyPage CompanyPage;
        public com.gestapoghost.entertainment.xaml.series.SeriesPage SeriesPage;
        public com.gestapoghost.entertainment.xaml.movie.MoviePage MoviePage;
        public com.gestapoghost.entertainment.xaml.scene.ScenePage ScenePage;
        public com.gestapoghost.entertainment.xaml.clip.ClipPage ClipPage;
        public com.gestapoghost.entertainment.xaml.fans.FansPage FansPage;

        public com.gestapoghost.entertainment.xaml.actor.ActorPage ActorPage;

        public com.gestapoghost.entertainment.xaml.scene.SceneThumb SceneThumb;

        public com.gestapoghost.entertainment.entity.Company Company = null;
        public com.gestapoghost.entertainment.entity.Series Series = null;
        public com.gestapoghost.entertainment.entity.Movie Movie = null;
        public com.gestapoghost.entertainment.entity.Clip Scene = null;
        public com.gestapoghost.entertainment.entity.Clip Clip = null;
        public com.gestapoghost.entertainment.entity.Clip Comic = null;
        public com.gestapoghost.entertainment.entity.Actor Actor = null;
        public Paging ClipPaging = null;
        public int ClipHasVideo = 0;

        public Paging ActorPaging = null;


        public int CompanyTypeId = 0;

        public Frame MainFrame;

    }
}
