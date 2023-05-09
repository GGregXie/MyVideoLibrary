using com.gestapoghost.movie;
using com.gestapoghost.movie.Entity;
using MyMovie.Entity;
using MyMovie.Service;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyMovie.xaml.Series
{
    /// <summary>
    /// ClipsCompanyPage.xaml 的交互逻辑
    /// </summary>
    public partial class SeriesPage : Page
    {
        public SeriesPage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            ListPanel.Children.Clear();
            ShowList();
            ShowAddButton();
        }

        private void ShowList()
        {
            
            List<SeriesEntity> seriesEntities = SeriesService.GetSeriesService().GetAllSeriesByCompanyId((Application.Current as App).CompanyEntity.Id);
            foreach(SeriesEntity seriesEntity in seriesEntities)
            {
                Grid ItemGrid = new Grid() {
                    Margin = new Thickness(5, 5, 5, 5),
                    RowDefinitions = {
                        new RowDefinition() { Height = new GridLength(130) },
                        new RowDefinition() { Height = new GridLength(25) }
                    },
                };

                Grid ImageGrid = new Grid() {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D3D3D3")),
                    Children = {
                        new Image() { Width = 260, Height = 100, Source = seriesEntity.Pic }
                    },
                    ContextMenu = new ContextMenu(),
                    Tag = seriesEntity
                };
                ImageGrid.MouseLeftButtonDown += ImageGrid_MouseLeftButtonDown;


                MenuItem updateItemMenu = new MenuItem() { Header = "修改", Tag = seriesEntity };
                updateItemMenu.Click += UpdateItemMenu_Click;
                MenuItem deleteItemMenu = new MenuItem() { Header = "删除", Tag = seriesEntity };
                deleteItemMenu.Click += DeleteItemMenu_Click;
                ImageGrid.ContextMenu.Items.Add(updateItemMenu);
                ImageGrid.ContextMenu.Items.Add(deleteItemMenu);


                Grid TextGrid = new Grid() {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Children = {
                        new TextBlock() { Text = seriesEntity.Name }
                    }
                };

                Grid.SetRow(ImageGrid, 0);
                Grid.SetRow(TextGrid, 1);

                ItemGrid.Children.Add(ImageGrid);
                ItemGrid.Children.Add(TextGrid);
                ListPanel.Children.Add(ItemGrid);
            }
            
        }

        private void ImageGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((Application.Current as App).CompanyTypeId == 1)
            {
                (Application.Current as App).MoviePage.SetPagingToNull();
                (Application.Current as App).SeriesEntity = (sender as Grid).Tag as SeriesEntity;
                (Application.Current as App).MoviePage.InitPage();
                (Application.Current as App).MainFrame.Content = (Application.Current as App).MoviePage;
            }
            else if ((Application.Current as App).CompanyTypeId == 2)
            {
                (Application.Current as App).ClipPage.SetPagingToNull();
                (Application.Current as App).SeriesEntity = (sender as Grid).Tag as SeriesEntity;
                (Application.Current as App).SearchTxt = "";
                (Application.Current as App).ClipPage.InitPage();
                (Application.Current as App).MainFrame.Content = (Application.Current as App).ClipPage;
            }
        }

        private void UpdateItemMenu_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).SeriesEntity = (sender as MenuItem).Tag as SeriesEntity;
            (Application.Current as App).SeriesWindow.Reload();
            (Application.Current as App).SeriesWindow.Show();
        }

        private void DeleteItemMenu_Click(object sender, RoutedEventArgs e)
        {
            SeriesService.GetSeriesService().DeleteSeriesById((int)((MenuItem)sender).Tag);
            InitPage();
        }

        private void ShowAddButton() 
        {
            Grid ItemGrid = new Grid()
            {
                Margin = new Thickness(5, 5, 5, 5),
                RowDefinitions = {
                        new RowDefinition() { Height = new GridLength(130) },
                        new RowDefinition() { Height = new GridLength(25) }
                    },
            };

            Grid ImageGrid = new Grid()
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D3D3D3")),
                Children = {
                        new Image() { Width = 260 , Height = 100 , Source = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/Add", UriKind.RelativeOrAbsolute)) }
                    }
            };

            Grid TextGrid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Children = {
                        new TextBlock() { Text = "添加" }
                    }
            };

            Grid.SetRow(ImageGrid, 0);
            Grid.SetRow(TextGrid, 1);

            ItemGrid.Children.Add(ImageGrid);
            ItemGrid.Children.Add(TextGrid);
            ItemGrid.MouseLeftButtonDown += new MouseButtonEventHandler(AddButtonLeftButtonDown);
            ListPanel.Children.Add(ItemGrid);
        }

        private void AddButtonLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (Application.Current as App).SeriesEntity = null;
            (Application.Current as App).SeriesWindow.Reload();
            (Application.Current as App).SeriesWindow.Show();
        }
    }
}
