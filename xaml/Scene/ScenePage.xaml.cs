using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.tools;
using com.gestapoghost.entertainment.viewmodel;
using MediaInfoLib;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace com.gestapoghost.entertainment.xaml.scene
{
    public partial class ScenePage : Page
    {
        public ScenePage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            SceneListBox.DataContext = new ScenePageViewModel((Application.Current as App).Movie);
            if (SceneListBox.Items.Count > 0) SceneListBox.ScrollIntoView(SceneListBox.Items[0]);
        }

        private void NewSceneButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Scene = null;
            (Application.Current as App).SceneWindow.InitWindow();
            (Application.Current as App).SceneWindow.Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                VideoTools.Playing(((sender as Grid).Tag as Clip), null);
            }

        }

        
        private void ThumbMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Scene = (sender as MenuItem).Tag as Clip;
            (Application.Current as App).SceneThumb.InitWindow();
            (Application.Current as App).SceneThumb.Show();
        }


        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Scene = (sender as MenuItem).Tag as Clip;
            (Application.Current as App).SceneWindow.InitWindow();
            (Application.Current as App).SceneWindow.Show();
        }
        /**
        private void FinishMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clip _Clip = (sender as MenuItem).Tag as Clip;
            if (File.Exists(_Clip.FilePath))
            {
                MediaInfo _MediaInfo = new MediaInfo();
                Console.WriteLine(_Clip.FilePath);
                _MediaInfo.Open(_Clip.FilePath);
                int size = int.Parse(_MediaInfo.Get(StreamKind.Video, 0, "Height"));
                string extension = _Clip.FilePath.Substring(_Clip.FilePath.Length - 3);
                if ("mp4".Equals(extension) || "nsp".Equals(extension))
                {
                    FileInfo file = new FileInfo(_Clip.FilePath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(_Clip.Id) + ".nsp");
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                    ClipService.GetClipService().FinishClipNSP(_Clip, size);
                    _Clip.Finish = 2;
                    _Clip.Size = size;
                }
                else if ("mkv".Equals(extension) || "xci".Equals(extension))
                {
                    FileInfo file = new FileInfo(_Clip.FilePath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(_Clip.Id) + ".xci");
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                    ClipService.GetClipService().FinishClipXCI(_Clip, size);
                    _Clip.Finish = 3;
                    _Clip.Size = size;
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
        */
        private void FinishMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clip _Clip = (sender as MenuItem).Tag as Clip;
            if (File.Exists(_Clip.FilePath))
            {

                string extension = _Clip.FilePath.Substring(_Clip.FilePath.Length - 3);
                if ("mp4".Equals(extension) || "nsp".Equals(extension))
                {
                    MediaInfo _MediaInfo = new MediaInfo();
                    Console.WriteLine(_Clip.FilePath);
                    _MediaInfo.Open(_Clip.FilePath);
                    int size = int.Parse(_MediaInfo.Get(StreamKind.Video, 0, "Height"));

                    FileInfo file = new FileInfo(_Clip.FilePath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(_Clip.Id) + ".nsp");
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                    ClipService.GetClipService().FinishClipNSP(_Clip, size);
                    _Clip.Finish = 2;
                    _Clip.Size = size;
                }
                else if ("mkv".Equals(extension) || "xci".Equals(extension))
                {
                    MediaInfo _MediaInfo = new MediaInfo();
                    Console.WriteLine(_Clip.FilePath);
                    _MediaInfo.Open(_Clip.FilePath);
                    int size = int.Parse(_MediaInfo.Get(StreamKind.Video, 0, "Height"));

                    FileInfo file = new FileInfo(_Clip.FilePath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(_Clip.Id) + ".xci");
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                    ClipService.GetClipService().FinishClipXCI(_Clip, size);
                    _Clip.Finish = 3;
                    _Clip.Size = size;
                }
                else if ("wmv".Equals(extension) || "nsz".Equals(extension))
                {
                    MediaInfo _MediaInfo = new MediaInfo();
                    Console.WriteLine(_Clip.FilePath);
                    _MediaInfo.Open(_Clip.FilePath);
                    int size = int.Parse(_MediaInfo.Get(StreamKind.Video, 0, "Height"));

                    FileInfo file = new FileInfo(_Clip.FilePath);
                    Thread th = new Thread(delegate ()
                    {
                        file.MoveTo("Y:/Roms/Games/NSZ/" + VideoFile.intToMd5(_Clip.Id) + ".nsz");
                        MessageBox.Show("已完成");
                    });
                    th.Start();
                    th.IsBackground = true;
                    ClipService.GetClipService().FinishClipNSZ(_Clip, size);
                    _Clip.Finish = 5;
                    _Clip.Size = size;
                }
                else if ("cbz".Equals(extension))
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
        /**
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
        */
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
                    else if (_Clip.Finish == 5)
                    {
                        filepath = "Y:\\Roms\\Games\\NSZ\\" + VideoFile.intToMd5(_Clip.Id) + ".nsz";
                    }
                    else if (_Clip.Finish == 4)
                    {
                        filepath = "X:\\OtherRoms\\" + VideoFile.intToMd5(_Clip.Id) + ".cia";
                    }
                    FileInfo file = new FileInfo(filepath);
                    Thread th = new Thread(delegate ()
                    {
                        String new_filepath = "D:\\VideoTemp\\move\\";
                        new_filepath += _Clip.Number + "_" + file.Name.Split(".".ToCharArray())[0];
                        if (_Clip.Finish == 2)
                        {
                            new_filepath += ".mp4";
                        }
                        else if (_Clip.Finish == 3)
                        {
                            new_filepath += ".mkv";
                        }
                        else if (_Clip.Finish == 4)
                        {
                            new_filepath += ".cbz";
                        }
                        else if (_Clip.Finish == 5)
                        {
                            new_filepath += ".wmv";
                        }

                        file.MoveTo(new_filepath);
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
