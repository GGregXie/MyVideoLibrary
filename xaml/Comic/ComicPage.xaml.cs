using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using com.gestapoghost.entertainment;
using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.tools;
using com.gestapoghost.entertainment.viewmodel;

namespace MyMovie.xaml.Comic
{
    public partial class ComicPage : Page
    {
        private ComicPageViewModel _ComicPageViewModel;

        public ComicPage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            DataContext = _ComicPageViewModel = new ComicPageViewModel((Application.Current as App).Movie);
        }

        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Movie = _ComicPageViewModel.Movie;
            (Application.Current as App).Comic = (sender as MenuItem).Tag as Clip;
            (Application.Current as App).ComicWindow.InitWindow();
            (Application.Current as App).ComicWindow.Show();
        }

        private void FinishMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clip _Clip = (sender as MenuItem).Tag as Clip;
            if (File.Exists(_Clip.FilePath))
            {
                string extension = _Clip.FilePath.Substring(_Clip.FilePath.Length - 3);
                if ("cbz".Equals(extension))
                {
                    FileInfo file = new FileInfo(_Clip.FilePath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("X:/OtherRoms/" + VideoFile.intToMd5(_Clip.Id) + ".cia");
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                    ClipService.GetClipService().FinishClipCIA(_Clip.Id);
                    _Clip.Finish = 4;
                }
                else
                {
                    MessageBox.Show("不支持");
                }
            }
            else
            {
                MessageBox.Show("文件不存在");
            }
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ComicTools.Playing(((sender as Grid).Tag as Clip));
            }
        }

        //private void FinishItemMenu_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Movie = _ComicPageViewModel.Movie;
            (Application.Current as App).Comic = null;
            (Application.Current as App).ComicWindow.InitWindow();
            (Application.Current as App).ComicWindow.Show();
        }


        private void PickupMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("是否提取？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Clip _Clip = (sender as MenuItem).Tag as Clip;
                    string filepath = "";
                    if (_Clip.Finish == 2)
                    {
                        filepath = "Y:\\Roms\\Games\\NSP\\" + VideoFile.intToMd5(_Clip.Id) + ".nsp";
                    }
                    else if (_Clip.Finish == 3)
                    {
                        filepath = "Y:\\Roms\\Games\\XCI\\" + VideoFile.intToMd5(_Clip.Id) + ".xci";
                    }
                    else if (_Clip.Finish == 4)
                    {
                        filepath = "X:\\OtherRoms\\" + VideoFile.intToMd5(_Clip.Id) + ".cia";
                    }
                    FileInfo file = new FileInfo(filepath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("D:\\VideoTemp\\move\\" + file.Name);
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }

        }



    }
}
