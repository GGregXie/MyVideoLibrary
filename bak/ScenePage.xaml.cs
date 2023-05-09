using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.Service;
using com.gestapoghost.movie;
using com.gestapoghost.movie.Entity;
using MyMovie.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyMovie.xaml.Scene
{
    /// <summary>
    /// ClipsCompanyPage.xaml 的交互逻辑
    /// </summary>
    public partial class ScenePage : Page
    {
        private int movieId = 0;
        private Paging paging = null;

        public ScenePage()
        {
            InitializeComponent();
        }

        public void InitPage(int movie_id)
        {
            movieId = movie_id;
            ListPanel.Children.Clear();

            ShowList();
            ShowPageButton();
        }

        private void ShowList()
        {

            List<ClipEntity> clipEntities = null;
            ReloadPaging();
            clipEntities = ClipService.GetClipService().GetAllClipByMovieId(movieId);

            //MessageBox.Show("当前页: " + paging.CurrentPage + "/总数量: " + paging.ItemNum + "/每页 " + paging.PageItemNum + " 个/可上一页: " + paging.canback().ToString() +  "/可下一页: " + paging.cannext().ToString() +  "/共 " + paging.TotalPage +  " 页");

            foreach (ClipEntity clipEntity in clipEntities)
            {
                Grid ItemGrid = new Grid()
                {
                    Margin = new Thickness(5, 5, 5, 5),
                    RowDefinitions = {
                        new RowDefinition() { Height = new GridLength(216) },
                        new RowDefinition() { Height = new GridLength(25) }
                    },
                };
                /**
                Grid ImageGrid = new Grid() {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D3D3D3")),
                    Children = {
                        new Image() { Width = 384, Height = 216, Source = clipEntity.pic }
                    },
                    ContextMenu = new ContextMenu(),
                    Tag = clipEntity
                };
                ImageGrid.MouseLeftButtonDown += ImageGrid_MouseLeftButtonDown;
    */



                Canvas ImageCanvas = new Canvas()
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D3D3D3")),
                    Children = {
                        new Image() { Width = 384, Height = 216, Source = clipEntity.Pic },
                    },
                    ContextMenu = new ContextMenu(),
                    Tag = clipEntity
                };
                ImageCanvas.MouseLeftButtonDown += ImageCanvas_MouseLeftButtonDown;



                Image NVENCImage = new Image()
                {
                    Width = 48,
                    Height = 18,
                    Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/NVENC", UriKind.RelativeOrAbsolute))
                };

                NVENCImage.SetValue(Canvas.TopProperty, Double.NaN);
                NVENCImage.SetValue(Canvas.LeftProperty, Double.NaN);
                NVENCImage.SetValue(Canvas.RightProperty, 48.0);
                NVENCImage.SetValue(Canvas.BottomProperty, -2.0);

                Image b1500Image = new Image()
                {
                    Width = 48,
                    Height = 18,
                    Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/1500", UriKind.RelativeOrAbsolute))
                };

                b1500Image.SetValue(Canvas.TopProperty, Double.NaN);
                b1500Image.SetValue(Canvas.LeftProperty, Double.NaN);
                b1500Image.SetValue(Canvas.RightProperty, 0.0);
                b1500Image.SetValue(Canvas.BottomProperty, -2.0);


                Image b5000Image = new Image()
                {
                    Width = 48,
                    Height = 18,
                    Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/5000", UriKind.RelativeOrAbsolute))
                };

                b5000Image.SetValue(Canvas.TopProperty, Double.NaN);
                b5000Image.SetValue(Canvas.LeftProperty, Double.NaN);
                b5000Image.SetValue(Canvas.RightProperty, 0.0);
                b5000Image.SetValue(Canvas.BottomProperty, -2.0);



                if (clipEntity.Code == 1)
                {
                    ImageCanvas.Children.Add(NVENCImage);
                }

                if (clipEntity.Size == 5000)
                {
                    ImageCanvas.Children.Add(b5000Image);
                }
                else if (clipEntity.Size == 1500)
                {
                    ImageCanvas.Children.Add(b1500Image);

                }





                MenuItem updateItemMenu = new MenuItem() { Header = "修改", Tag = clipEntity.Id };
                updateItemMenu.Click += UpdateItemMenu_Click;
                MenuItem NVENCItemMenu = new MenuItem() { Header = "NVENC", Tag = clipEntity.Id };
                NVENCItemMenu.Click += NVENCItemMenu_Click;
                MenuItem size1500ItemMenu = new MenuItem() { Header = "比特率1500", Tag = clipEntity.Id };
                size1500ItemMenu.Click += size1500ItemMenu_Click;
                MenuItem size5000ItemMenu = new MenuItem() { Header = "比特率5000", Tag = clipEntity.Id };
                size5000ItemMenu.Click += size5000ItemMenu_Click;
                MenuItem deleteItemMenu = new MenuItem() { Header = "删除", Tag = clipEntity.Id };
                deleteItemMenu.Click += DeleteItemMenu_Click;
                MenuItem finishItemMenu = new MenuItem() { Header = "完成", Tag = clipEntity };
                finishItemMenu.Click += FinishItemMenu_Click;

                ImageCanvas.ContextMenu.Items.Add(updateItemMenu);
                ImageCanvas.ContextMenu.Items.Add(NVENCItemMenu);
                ImageCanvas.ContextMenu.Items.Add(size1500ItemMenu);
                ImageCanvas.ContextMenu.Items.Add(size5000ItemMenu);
                ImageCanvas.ContextMenu.Items.Add(deleteItemMenu);
                ImageCanvas.ContextMenu.Items.Add(finishItemMenu);


                Grid TextGrid = new Grid()
                {
                    Width = 384,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Children = {
                        new TextBlock() { Text = clipEntity.Scene + ". " + clipEntity.Title }
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
            InitPage(movieId);
        }

        private void ImageCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ClickCount)
            {
                case 1://单击
                    {
                        break;
                    }
                case 2://双击
                    {

                        ClipEntity clip = (ClipEntity)(sender as Canvas).Tag;

                        if (clip.Finish == 0)
                        {
                            if (File.Exists(clip.FilePath))
                            {
                                //System.Diagnostics.Process.Start(filepath);
                                DPLFile.CreatePlayDPL(clip.FilePath, clip.Start);
                                DPLFile.PlayDPL();

                            }
                            else
                            {
                                MessageBox.Show("文件不存在");
                            }
                            break;
                        }
                        else if (clip.Finish > 0)
                        {
                            if (File.Exists("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(clip.Id) + ".nsp"))
                            {
                                DPLFile.CreatePlayDPL("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(clip.Id) + ".nsp", clip.Start);
                                DPLFile.PlayDPL();
                            }
                            else if (File.Exists("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(clip.Id) + ".xci"))
                            {
                                DPLFile.CreatePlayDPL("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(clip.Id) + ".xci", clip.Start);
                                DPLFile.PlayDPL();
                            }
                            else
                            {
                                MessageBox.Show("播放异常");
                            }
                            break;
                        }
                        else
                        {
                            MessageBox.Show("播放异常");
                            break;
                        }
                    }
            }

        }

        private void UpdateItemMenu_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).SceneWindow.Reload(movieId, ClipService.GetClipService().GetClipById((int)((MenuItem)sender).Tag));
            (Application.Current as App).SceneWindow.Show();
        }
        private void NVENCItemMenu_Click(object sender, RoutedEventArgs e)
        {
            ClipService.GetClipService().SetClipCodeById((int)((MenuItem)sender).Tag, 1);
            InitPage(movieId);

        }
        private void size1500ItemMenu_Click(object sender, RoutedEventArgs e)
        {

            ClipService.GetClipService().SetClipSizeById((int)((MenuItem)sender).Tag, 1500);
            InitPage(movieId);
        }
        private void size5000ItemMenu_Click(object sender, RoutedEventArgs e)
        {

            ClipService.GetClipService().SetClipSizeById((int)((MenuItem)sender).Tag, 5000);
            InitPage(movieId);
        }

        private void DeleteItemMenu_Click(object sender, RoutedEventArgs e)
        {
            //CompanyService.GetCompanyService().DeleteCompanyById((int)((MenuItem)sender).Tag);
            //InitPage(companyTypeId);
        }
        private void FinishItemMenu_Click(object sender, RoutedEventArgs e)
        {
            ClipEntity clip = (ClipEntity)((MenuItem)sender).Tag;
            if (File.Exists(clip.FilePath))
            {

                string extension = clip.FilePath.Substring(clip.FilePath.Length - 3);
                if ("mp4".Equals(extension) || "nsp".Equals(extension))
                {
                    FileInfo file = new FileInfo(clip.FilePath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(clip.Id) + ".nsp");
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                    ClipService.GetClipService().FinishNSPClipById(clip.Id);
                    InitPage(movieId);
                }
                else if ("mkv".Equals(extension) || "xci".Equals(extension))
                {
                    FileInfo file = new FileInfo(clip.FilePath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(clip.Id) + ".xci");
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                    ClipService.GetClipService().FinishXCIClipById(clip.Id);
                    InitPage(movieId);
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).SceneWindow.Reload(movieId, null);
            (Application.Current as App).SceneWindow.Show();
        }

        public void ReloadPaging()
        {
            if ((Application.Current as App).CompanyEntity != null)
            {
                int currentPage = 1;
                if (paging != null)
                    currentPage = paging.CurrentPage;
                paging = ClipService.GetClipService().GetPagingByCompany((Application.Current as App).CompanyEntity, "HasContext");
                paging.CurrentPage = currentPage;
            }
            if ((Application.Current as App).SeriesEntity != null)
            {
                int currentPage = 1;
                if (paging != null)
                    currentPage = paging.CurrentPage;
                paging = ClipService.GetClipService().GetPagingBySeries((Application.Current as App).SeriesEntity, "HasContext");
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
                InitPage(movieId);
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
                InitPage(movieId);
            }
        }

        public void SetPagingToNull()
        {
            paging = null;
        }
    }

}
