using com.gestapoghost.movie.Entity;
using MyMovie.Service;
using MyMovie.Tools;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace com.gestapoghost.movie.xaml.Movie
{
    /// <summary>
    /// ClipsCompanyPage.xaml 的交互逻辑
    /// </summary>
    public partial class MoviePage : Page
    {

        private Paging paging = null;

        public MoviePage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            ListPanel.Children.Clear();

            ShowList();
            ShowPageButton();
        }

        private void ShowList()
        {

            List<MovieEntity> movieEntities = null;
            if ((Application.Current as App).SeriesEntity != null)
            {
                ReloadPaging();
                movieEntities = MovieService.GetMovieService().GetAllMovieBySeriesId((Application.Current as App).SeriesEntity.Id, paging);
            }
            else
            {
                ReloadPaging();
                movieEntities = MovieService.GetMovieService().GetAllMovieByCompanyId((Application.Current as App).CompanyEntity.Id, paging);
            }

            //MessageBox.Show("当前页: " + paging.CurrentPage + "/总数量: " + paging.ItemNum + "/每页 " + paging.PageItemNum + " 个/可上一页: " + paging.canback().ToString() +  "/可下一页: " + paging.cannext().ToString() +  "/共 " + paging.TotalPage +  " 页");

            foreach (MovieEntity movieEntity in movieEntities)
            {
                Grid ItemGrid = new Grid()
                {
                    Margin = new Thickness(5, 5, 5, 5),
                    RowDefinitions = {
                        new RowDefinition() { Height = new GridLength(270) },
                        new RowDefinition() { Height = new GridLength(32) }
                    },
                };

                Canvas ImageCanvas = new Canvas()
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D3D3D3")),
                    Children = {
                        new Image() { Width = 190, Height = 270, Source = movieEntity.Pic_front },
                    },
                    ContextMenu = new ContextMenu(),
                    Tag = movieEntity
                };
                ImageCanvas.MouseLeftButtonDown += ImageGrid_MouseLeftButtonDown;

                Image dvdImage = new Image()
                {
                    Width = 48,
                    Height = 18,
                    Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/DVD", UriKind.RelativeOrAbsolute))
                };
                dvdImage.SetValue(Canvas.TopProperty, Double.NaN);
                dvdImage.SetValue(Canvas.LeftProperty, Double.NaN);
                dvdImage.SetValue(Canvas.RightProperty, 0.0);
                dvdImage.SetValue(Canvas.BottomProperty, 0.0);

                Image blurayImage = new Image()
                {
                    Width = 48,
                    Height = 18,
                    Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/BluRay", UriKind.RelativeOrAbsolute))
                };
                blurayImage.SetValue(Canvas.TopProperty, Double.NaN);
                blurayImage.SetValue(Canvas.LeftProperty, Double.NaN);
                blurayImage.SetValue(Canvas.RightProperty, 0.0);
                blurayImage.SetValue(Canvas.BottomProperty, 0.0);

                Image nvencImage = new Image()
                {
                    Width = 60,
                    Height = 18,
                    Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/NVENC", UriKind.RelativeOrAbsolute))
                };
                nvencImage.SetValue(Canvas.TopProperty, Double.NaN);
                nvencImage.SetValue(Canvas.LeftProperty, Double.NaN);
                nvencImage.SetValue(Canvas.RightProperty, 48.0);
                nvencImage.SetValue(Canvas.BottomProperty, 0.0);

                Image hevcImage = new Image()
                {
                    Width = 48,
                    Height = 18,
                    Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/HEVC", UriKind.RelativeOrAbsolute))
                };
                hevcImage.SetValue(Canvas.TopProperty, Double.NaN);
                hevcImage.SetValue(Canvas.LeftProperty, Double.NaN);
                hevcImage.SetValue(Canvas.RightProperty, 48.0);
                hevcImage.SetValue(Canvas.BottomProperty, 0.0);


                if (movieEntity.Source == 1)
                {
                    ImageCanvas.Children.Add(dvdImage);
                }
                else if (movieEntity.Source == 2)
                {
                    ImageCanvas.Children.Add(blurayImage);
                }

                if (movieEntity.Code == 1)
                {
                    ImageCanvas.Children.Add(nvencImage);
                }
                else if (movieEntity.Code == 2) {
                    ImageCanvas.Children.Add(hevcImage);
                }



                if ((Application.Current as App).CompanyTypeId == 1)
                {
                    MenuItem updateItemMenu = new MenuItem() { Header = "修改", Tag = movieEntity.Id };
                    updateItemMenu.Click += UpdateItemMenu_Click;
                    MenuItem fromDVDItemMenu = new MenuItem() { Header = "来自DVD", Tag = movieEntity.Id };
                    fromDVDItemMenu.Click += FromDVDItemMenu_Click;
                    MenuItem fromBluRayItemMenu = new MenuItem() { Header = "来自BluRay", Tag = movieEntity.Id };
                    fromBluRayItemMenu.Click += FromBluRayItemMenu_Click;
                    MenuItem NVENCItemMenu = new MenuItem() { Header = "NVENC", Tag = movieEntity.Id };
                    NVENCItemMenu.Click += NVENCItemMenu_Click;
                    MenuItem HEVCItemMenu = new MenuItem() { Header = "HEVC", Tag = movieEntity.Id };
                    HEVCItemMenu.Click += HEVCItemMenu_Click;
                    MenuItem deleteItemMenu = new MenuItem() { Header = "删除", Tag = movieEntity.Id };
                    deleteItemMenu.Click += DeleteItemMenu_Click;
                    ImageCanvas.ContextMenu.Items.Add(updateItemMenu);
                    ImageCanvas.ContextMenu.Items.Add(fromBluRayItemMenu);
                    ImageCanvas.ContextMenu.Items.Add(fromDVDItemMenu);
                    ImageCanvas.ContextMenu.Items.Add(NVENCItemMenu);
                    ImageCanvas.ContextMenu.Items.Add(HEVCItemMenu);
                    ImageCanvas.ContextMenu.Items.Add(deleteItemMenu);
                }
                else if ((Application.Current as App).CompanyTypeId == 3)
                {
                    MenuItem updateItemMenu = new MenuItem() { Header = "修改", Tag = movieEntity.Id };
                    updateItemMenu.Click += UpdateItemMenu_Click;
                    MenuItem deleteItemMenu = new MenuItem() { Header = "删除", Tag = movieEntity.Id };
                    deleteItemMenu.Click += DeleteItemMenu_Click;
                    ImageCanvas.ContextMenu.Items.Add(updateItemMenu);
                    ImageCanvas.ContextMenu.Items.Add(deleteItemMenu);
                }


                Grid TextGrid = new Grid()
                {
                    Width = 190,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Children = {
                        new TextBlock() { Text = movieEntity.Title, TextWrapping = TextWrapping.Wrap }
                    }
                };

                Grid.SetRow(ImageCanvas, 0);
                Grid.SetRow(TextGrid, 1);

                ItemGrid.Children.Add(ImageCanvas);
                ItemGrid.Children.Add(TextGrid);
                ListPanel.Children.Add(ItemGrid);
            }

        }

        private void ShowPageButton()
        {
            PageButtonList.Children.Clear();
            //< Button Margin = "10, 0, 0, 0" Content = "1" Width = "25" Height = "25" />
            //< Button Margin = "10, 0, 0, 0" Content = "2" Width = "25" Height = "25" />
            //< Button Margin = "10, 0, 0, 0" Content = "3" Width = "25" Height = "25" />
            //< Button Margin = "10, 0, 0, 0" Content = "4" Width = "25" Height = "25" />
            //< Button Margin = "10, 0, 0, 0" Content = "5" Width = "25" Height = "25" />
            for (int i = 0; i < paging.TotalPage; i++)
            {
                Button pageButton = new Button() { Width = 25, Height = 25, Content = i + 1, Margin = new Thickness(10, 0, 0, 0), Tag = i + 1 };
                if (paging.CurrentPage == i + 1)
                {
                    pageButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007FFF"));
                }
                else
                {
                    pageButton.Click += PageButton_Click;
                }
                PageButtonList.Children.Add(pageButton);

            }
        }

        private void PageButton_Click(object sender, RoutedEventArgs e)
        {
            paging.CurrentPage = Convert.ToInt32(((Button)sender).Tag.ToString());
            InitPage();
        }

        private void ImageGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((Application.Current as App).CompanyTypeId == 1)
            {
                MovieEntity movieEntity = (MovieEntity)(((Canvas)sender).Tag);
                //(Application.Current as App).ScenePage.InitPage(movieEntity.Id);
                //(Application.Current as App).MainFrame.Content = (Application.Current as App).ScenePage;
            }
            else if ((Application.Current as App).CompanyTypeId == 3) 
            {
                MovieEntity movieEntity = (MovieEntity)(((Canvas)sender).Tag);
                (Application.Current as App).ComicPage.InitPage(movieEntity.Id);
                (Application.Current as App).MainFrame.Content = (Application.Current as App).ComicPage;

            }
        }

        private void UpdateItemMenu_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).MovieWindow.Reload(MovieService.GetMovieService().GetMovieById((int)((MenuItem)sender).Tag));
            (Application.Current as App).MovieWindow.Show();

        }

        private void DeleteItemMenu_Click(object sender, RoutedEventArgs e)
        {
            //CompanyService.GetCompanyService().DeleteCompanyById((int)((MenuItem)sender).Tag);
            //InitPage(companyTypeId);
        }

        private void FromDVDItemMenu_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieFromDVDById((int)((MenuItem)sender).Tag);
            InitPage();
        }

        private void FromBluRayItemMenu_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieFromBluRayById((int)((MenuItem)sender).Tag);
            InitPage();
        }

        private void NVENCItemMenu_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieCodeById((int)((MenuItem)sender).Tag, 1);
            InitPage();
        }

        private void HEVCItemMenu_Click(object sender, RoutedEventArgs e)
        {
            MovieService.GetMovieService().SetMovieCodeById((int)((MenuItem)sender).Tag, 2);
            InitPage();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).MovieWindow.Reload(null);
            (Application.Current as App).MovieWindow.Show();
        }

        public void ReloadPaging()
        {
            if ((Application.Current as App).CompanyEntity != null)
            {
                int currentPage = 1;
                if (paging != null)
                    currentPage = paging.CurrentPage;
                paging = MovieService.GetMovieService().GetPagingByCompanyId((Application.Current as App).CompanyEntity.Id);
                paging.CurrentPage = currentPage;
            }
            if ((Application.Current as App).SeriesEntity != null)
            {
                int currentPage = 1;
                if (paging != null)
                    currentPage = paging.CurrentPage;
                paging = MovieService.GetMovieService().GetPagingBySeriesId((Application.Current as App).SeriesEntity.Id);
                paging.CurrentPage = currentPage;
            }
        }

        private void PageBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!paging.canback())
            {
                MessageBox.Show("无上一页");
            }
            else
            {
                paging.back();
                InitPage();
            }
        }

        private void PageNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!paging.cannext())
            {
                MessageBox.Show("无下一页");
            }
            else
            {
                paging.next();
                InitPage();
            }
        }

        public void SetPagingToNull()
        {
            paging = null;
        }
    }
}

