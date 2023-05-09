using com.gestapoghost.entertainment;
using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.viewmodel;
using com.gestapoghost.entertainment.xaml.main;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Windows;

namespace MyMovie.xaml.Comic
{
    /// <summary>
    /// Company.xaml 的交互逻辑
    /// </summary>
    public partial class ComicWindow : MetroWindow
    {
        ComicWindowViewModel _ComicWindowViewModel;

        public ComicWindow()
        {
            InitializeComponent();

        }

        public void InitWindow()
        {
            DataContext = _ComicWindowViewModel = new ComicWindowViewModel((Application.Current as App).Company, (Application.Current as App).Series, (Application.Current as App).Movie, (Application.Current as App).Comic);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(((MainWindow)Application.Current.MainWindow)  != null)
            { 
                e.Cancel = true;
                (Application.Current as App).ComicWindow.Hide();
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
                _ComicWindowViewModel.Comic.Pic = ImageFileService.SaveBitmapImage(ImageFileService.GetImage(openfiledialog.FileName));

            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClipService.GetClipService().CreateOrUpdateComic(_ComicWindowViewModel.Comic, _ComicWindowViewModel.Company, _ComicWindowViewModel.Movie))
                MessageBox.Show("保存成功!");
            else
                MessageBox.Show("保存失败!");
            (Application.Current as App).ComicWindow.Hide();
            (Application.Current as App).Company = _ComicWindowViewModel.Company;
            (Application.Current as App).Movie = _ComicWindowViewModel.Movie;
            (Application.Current as App).ComicPage.InitPage();
        }

         private void AddVideoFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "漫画文件|*.cbz;*.cia|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                _ComicWindowViewModel.Comic.FilePath = openfiledialog.FileName;

            }
        }
    }
}
