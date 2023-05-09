using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.Service;
using com.gestapoghost.movie;
using com.gestapoghost.movie.Entity;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using MyMovie.Service;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MyMovie.xaml.Movie
{
    /// <summary>
    /// Company.xaml 的交互逻辑
    /// </summary>
    public partial class MovieWindow : MetroWindow
    {
        private MovieEntity movieEntity = null;
        private List<ActorEntity> actorEntities = null;
        private int CompanyId = 0;
        private int SeriesId = 0;

        public MovieWindow()
        {
            InitializeComponent();
        }

        public void Reload(MovieEntity reloadMovieEntity)
        {
            if ((Application.Current as App).CompanyEntity != null)
                CompanyId = (Application.Current as App).CompanyEntity.Id;

            if ((Application.Current as App).SeriesEntity != null)
                SeriesId = (Application.Current as App).SeriesEntity.Id;

            movieEntity = reloadMovieEntity;
            CompanySeries.Text = ClipService.GetClipService().GetCompanySeriesString((Application.Current as App).CompanyEntity, (Application.Current as App).SeriesEntity);
            if (reloadMovieEntity == null)
            {

                actorEntities = new List<ActorEntity>();
                MovieDate.Text = "1980/1/1";
                FrontImage.Source = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/MovieNull", UriKind.RelativeOrAbsolute));
                BackImage.Source = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/MovieNull", UriKind.RelativeOrAbsolute));
                MovieTitle.Text = "";
                ActorList.Children.Clear();
                MovieDescription.Text = "";

            }
            else
            {
                actorEntities = ActorService.GetActorService().GetActorsByMovieId(movieEntity.Id);
                MovieDate.Text = "" + movieEntity.Date.Year + "/" + movieEntity.Date.Month + "/" + movieEntity.Date.Day;
                FrontImage.Source = movieEntity.Pic_front;
                BackImage.Source = movieEntity.Pic_back;
                MovieTitle.Text = movieEntity.Title;
                MovieDescription.Text = movieEntity.Description;
            }
            ReloadActorGrid(actorEntities);

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)

        {
            if (((MainWindow)Application.Current.MainWindow) != null)
            { 
                e.Cancel = true;
                (Application.Current as App).MovieWindow.Hide();
            }
        }


        private void FrontImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif;*.jfif|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                FrontImage.Source = ImageFileService.GetImage(openfiledialog.FileName); //new BitmapImage(new Uri(openfiledialog.FileName));
            }

        }
        private void BackImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif;*.jfif|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                BackImage.Source = ImageFileService.GetImage(openfiledialog.FileName); //new BitmapImage(new Uri(openfiledialog.FileName));
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (movieEntity == null)
            {
                movieEntity = EditMovieByControl(new MovieEntity());
                movieEntity.Id = MovieService.GetMovieService().CreateMovie(movieEntity, CompanyId, SeriesId);
                MessageBox.Show("保存成功!");
            }
            else {
                movieEntity = EditMovieByControl(movieEntity);
                MovieService.GetMovieService().UpdateMovie(movieEntity, CompanyId, SeriesId);
                MessageBox.Show("更新成功!");

            }
            (Application.Current as App).MovieWindow.Hide();
            (Application.Current as App).MoviePage.InitPage();
        }

        private void AddActorButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReloadActorGrid(List<ActorEntity> actorEntities)
        {
            /**
            ActorList.Children.Clear();
            foreach(ActorEntity actorEntity in actorEntities)
            { 
                ActorList.Children.Add(GetGridWithActor(actorEntity));
            }
    */
        }

        private Grid GetGridWithActor(ActorEntity actorEntity)
        {

            //<Grid Margin = "0,0,10,0">
            //  <Grid.RowDefinitions>
            //      <RowDefinition Height = "180" />
            //      <RowDefinition Height = "30" />
            //  </Grid.RowDefinitions >
            //  <Image Grid.Row = "0" Width = "120" Height = "180" Source = "pack://siteoforigin:,,,/Resources/Images/Temp" />
            //  <TextBlock Grid.Row = "1" Text = "Greg Xie" HorizontalAlignment = "Center" VerticalAlignment = "Center" />
            //</Grid>
            Grid ActorGrid = new Grid()
            {
                Margin = new Thickness(0, 0, 10, 0),
                RowDefinitions = {
                            new RowDefinition() { Height = new GridLength(180)},
                            new RowDefinition() { Height = new GridLength(30) }
                        }
            };
            Image ActorImage = new Image()
            {
                Width = 120,
                Height = 180,
                Source = actorEntity.Pic,
                ContextMenu = new ContextMenu()
            };

            MenuItem updateItemMenu = new MenuItem() { Header = "更换照片", Tag = actorEntity };
            updateItemMenu.Click += UpdateActorItemMenu_Click; ;
            MenuItem deleteItemMenu = new MenuItem() { Header = "删除演员", Tag = actorEntity };
            deleteItemMenu.Click += DeleteActorItemMenu_Click; ;
            ActorImage.ContextMenu.Items.Add(updateItemMenu);
            ActorImage.ContextMenu.Items.Add(deleteItemMenu);


            TextBlock ActorText = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = actorEntity.Name
            };

            Grid.SetRow(ActorImage, 0);
            Grid.SetRow(ActorText, 1);
            ActorGrid.Children.Add(ActorImage);
            ActorGrid.Children.Add(ActorText);
            return ActorGrid;
        }

        private void UpdateActorItemMenu_Click(object sender, RoutedEventArgs e)
        {
            ActorEntity actorEntity = (ActorEntity)((MenuItem)sender).Tag;
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif;*.jfif|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                actorEntity.Pic = ImageFileService.GetImage(openfiledialog.FileName); //new BitmapImage(new Uri(openfiledialog.FileName));
                ActorService.GetActorService().UpdateActor(actorEntity);
                ReloadActorGrid(actorEntities);
            }
        }

        private void DeleteActorItemMenu_Click(object sender, RoutedEventArgs e)
        {
            actorEntities.Remove((ActorEntity)((MenuItem)sender).Tag);
            ReloadActorGrid(actorEntities);
        }

        private MovieEntity EditMovieByControl(MovieEntity oldMovieEntity)
        {
            
            oldMovieEntity.Title = MovieTitle.Text;
            oldMovieEntity.Date = MovieDate.SelectedDate.Value;
            oldMovieEntity.Description = MovieDescription.Text;
            oldMovieEntity.Pic_front = (BitmapImage)(FrontImage.Source);
            oldMovieEntity.Pic_back = (BitmapImage)(BackImage.Source);
            return oldMovieEntity;

        }

    }
}
