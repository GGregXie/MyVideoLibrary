using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.movie;
using com.gestapoghost.movie.Entity;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using MyMovie.Service;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MyMovie.xaml.Series
{
    /// <summary>
    /// Company.xaml 的交互逻辑
    /// </summary>
    public partial class SeriesWindow : MetroWindow
    {

        private int CompanyId;
        private SeriesEntity SeriesEntity = null;

        public SeriesWindow()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            CompanyId = (Application.Current as App).CompanyEntity.Id;
            SeriesEntity = (Application.Current as App).SeriesEntity;

            if (SeriesEntity == null)
            {
                SeriesImage.Source = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/CompanyNull", UriKind.RelativeOrAbsolute));
                SeriesName.Text = "";
            }
            else
            {
                SeriesImage.Source = SeriesEntity.Pic;
                SeriesName.Text = SeriesEntity.Name;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(((MainWindow)Application.Current.MainWindow)!= null) 
            { 
                e.Cancel = true;
                (Application.Current as App).SeriesWindow.Hide();
            }
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif;*.jfif|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                SeriesImage.Source = ImageFileService.GetImage(openfiledialog.FileName); //new BitmapImage(new Uri(openfiledialog.FileName));
            }

        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).SeriesWindow.Reload();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (SeriesEntity == null)
            {
                SeriesEntity = new SeriesEntity();
                SeriesEntity.Name = SeriesName.Text;
                SeriesEntity.Pic = (BitmapImage)(SeriesImage.Source);
                SeriesEntity.CompanyEntity = new CompanyEntity();
                SeriesEntity.CompanyEntity.Id = CompanyId;
                SeriesService.GetSeriesService().CreateSeries(SeriesEntity);
            }
            else {
                SeriesEntity.Name = SeriesName.Text;
                SeriesEntity.Pic = (BitmapImage)(SeriesImage.Source);
                SeriesService.GetSeriesService().UpdateSeries(SeriesEntity);
            }
            (Application.Current as App).SeriesWindow.Hide();
            (Application.Current as App).SeriesPage.InitPage();

            MessageBox.Show("保存成功!");


        }
    }
}
