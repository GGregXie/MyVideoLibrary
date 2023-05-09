using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using com.gestapoghost.entertainment.viewmodel;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;

namespace com.gestapoghost.entertainment.xaml.movie
{
    public partial class MoviePage : Page
    {

        public MoviePage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            MovieListBox.DataContext = new MoviePageViewModel((Application.Current as App).Company, (Application.Current as App).Series);
            if(MovieListBox.Items.Count > 0) MovieListBox.ScrollIntoView(MovieListBox.Items[0]);
        }


        private void NewMovieButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Movie = null;
            (Application.Current as App).MovieWindow.InitWindow();
            (Application.Current as App).MovieWindow.Show();
        }

        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Movie = (sender as MenuItem).Tag as Movie;
            (Application.Current as App).MovieWindow.InitWindow();
            (Application.Current as App).MovieWindow.Show();
        }

        private void CodeHEVCMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieCode((sender as MenuItem).Tag as Movie, "HEVC");
            MessageBox.Show("设置编码HEVC成功");
            InitPage();
        }

        private void CodeNVENCMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieCode((sender as MenuItem).Tag as Movie, "NVENC");
            MessageBox.Show("设置编码NVENC成功");
            InitPage();
        }

        private void SourceDVDMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieSource((sender as MenuItem).Tag as Movie, "DVD");
            MessageBox.Show("设置来源DVD成功");
            InitPage();
        }

        private void SourceBluRayMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieSource((sender as MenuItem).Tag as Movie, "BluRay");
            MessageBox.Show("设置来源BluRay成功");
            InitPage();
        }

        private void SourceDVDRemuxMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieSource((sender as MenuItem).Tag as Movie, "DVDRemux");
            MessageBox.Show("设置来源DVD.Remux成功");
            InitPage();
        }


        private void SourceBDRemuxMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieSource((sender as MenuItem).Tag as Movie, "BDRemux");
            MessageBox.Show("设置来源BD.Remux成功");
            InitPage();
        }



        private void SourceWebMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieSource((sender as MenuItem).Tag as Movie, "Web");
            MessageBox.Show("设置来源Web成功");
            InitPage();
        }

        private void ClearTagMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieCode((sender as MenuItem).Tag as Movie, "");
            MovieService.GetMovieService().SetMovieSource((sender as MenuItem).Tag as Movie, "");
            MessageBox.Show("成功清除标记");
            InitPage();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (Application.Current as App).Movie = (sender as Grid).Tag as Movie;
                if ((Application.Current as App).CompanyTypeId == 1)
                {
                    (Application.Current as App).ScenePage.InitPage();
                    (Application.Current as App).MainFrame.Content = (Application.Current as App).ScenePage;

                }
                else if((Application.Current as App).CompanyTypeId == 3)
                {
                    (Application.Current as App).ComicPage.InitPage();
                    (Application.Current as App).MainFrame.Content = (Application.Current as App).ComicPage;
                }
            }
        }
    }
}
