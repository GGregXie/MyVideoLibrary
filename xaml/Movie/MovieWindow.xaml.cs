using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.xaml.main;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.xaml.movie
{
    /// <summary>
    /// Company.xaml 的交互逻辑
    /// </summary>
    public partial class MovieWindow : MetroWindow
    {
        private Company _Company;
        private Series _Series;
        private Movie _Movie;

        public MovieWindow()
        {
            InitializeComponent();
        }

        public void InitWindow()
        {
            _Movie = (Application.Current as App).Movie;
            _Company = (Application.Current as App).Company;
            _Series = (Application.Current as App).Series;
            CompanySeries.Text = GetCompanySeriesString();
            if (_Movie == null)
            {
                _Movie = new Movie();
                _Movie.Pic_Front = "MovieNull";
                _Movie.Pic_Back = "MovieNull";
                _Movie.Date = Convert.ToDateTime("1980-1-1");
            }
            DataContext = _Movie;
        }

        private string GetCompanySeriesString()
        {
            string companyseries = _Company.Name;
            if (_Series != null)
                companyseries = companyseries + " - " + _Series.Name;
            return companyseries;
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
                //_SceneWindowViewModel.Scene.Pic = ImageFileService.SaveBitmapImage(ImageFileService.GetImage(openfiledialog.FileName));
                FrontImage.Source = ImageFileService.GetImage(openfiledialog.FileName); 
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
                BackImage.Source = ImageFileService.GetImage(openfiledialog.FileName); 
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _Movie.Title = MovieTitle.Text;
            _Movie.Pic_Front = ImageFileService.SaveBitmapImage((BitmapImage)(FrontImage.Source));
            _Movie.Pic_Back = ImageFileService.SaveBitmapImage((BitmapImage)(BackImage.Source));
            _Movie.Date = MovieDate.SelectedDate.Value;
            _Movie.Description = MovieDescription.Text;
            Console.WriteLine("ID: " + _Movie.Id + " / Title: " + _Movie.Title + " / PicF: " + _Movie.Pic_Front + " / PicB:" + _Movie.Pic_Back + " / Date: " + _Movie.Date.ToString());

            if (MovieService.GetMovieService().SaveOrUpdateMovie(_Movie, _Company, _Series))
                MessageBox.Show("保存成功!");
            else
                MessageBox.Show("保存失败!");
            (Application.Current as App).MovieWindow.Hide();
            (Application.Current as App).Company = _Company;
            (Application.Current as App).Series = _Series;
            (Application.Current as App).MoviePage.InitPage();
        }
    }
}
