using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.entity;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.xaml.series
{
    /// <summary>
    /// Company.xaml 的交互逻辑
    /// </summary>
    public partial class SeriesWindow : MetroWindow
    {
        private int _CompanyTypeId = 0;
        private Series _Series = null;
        private Company _Company = null;

        public SeriesWindow()
        {
            InitializeComponent();
        }

        public void InitWindow()
        {
            _CompanyTypeId = (Application.Current as App).CompanyTypeId;
            _Series = (Application.Current as App).Series;
            _Company = (Application.Current as App).Company;

            if (_Series == null)
            {
                _Series = new Series();
                _Series.Pic = "CompanyNull";
            }
            DataContext = _Series;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (Application.Current.MainWindow != null)
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
                SeriesImage.Source = ImageFileService.GetImage(openfiledialog.FileName);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _Series.Name = SeriesName.Text;
            _Series.Pic = ImageFileService.SaveBitmapImage((BitmapImage)(SeriesImage.Source));
            if (SeriesService.GetSeriesService().SaveOrUpdateSeries(_Series, _Company))
                MessageBox.Show("保存成功!");
            else
                MessageBox.Show("保存失败!");
            (Application.Current as App).SeriesWindow.Hide();
            (Application.Current as App).Company = _Company;
            (Application.Current as App).SeriesPage.InitPage();
        }
    }
}
