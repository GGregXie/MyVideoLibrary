using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.tools;
using com.gestapoghost.entertainment.viewmodel;
using MediaInfoLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace com.gestapoghost.entertainment.xaml.clip
{
    public partial class ClipPage : Page
    {
        public ClipPageViewModel _ClipPageViewModel;

        public ClipPage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            DataContext = _ClipPageViewModel = new ClipPageViewModel((Application.Current as App).Company, (Application.Current as App).Series, (Application.Current as App).Actor, (Application.Current as App).ClipPaging, (Application.Current as App).ClipHasVideo);
            AllVideoRadio.IsChecked = true;
            if (_ClipPageViewModel.HasVideo == 0)
            {
                AllVideoRadio.IsChecked = true;
            }
            if (_ClipPageViewModel.HasVideo == 1)
            {
                HasVideoRadio.IsChecked = true;
            }
            if (_ClipPageViewModel.HasVideo == 2)
            {
                NoHasVideoRadio.IsChecked = true;
            }

        }

        private void NewClipButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Clip = null;
            (Application.Current as App).ClipPaging = _ClipPageViewModel.Paging;
            (Application.Current as App).ClipHasVideo = _ClipPageViewModel.HasVideo;
            (Application.Current as App).ClipWindow.InitWindow();
            (Application.Current as App).ClipWindow.Show();
        }

        private void ScraperButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ClipPageViewModel.Company.Type == 4)
            {
                ScraperService.GetScraperService().ScraperXhamsterClip(_ClipPageViewModel.Series);
            }
            else if (_ClipPageViewModel.Company.Id == 207)
            {
                ScraperService.GetScraperService().ScraperJustForfansClipAll(_ClipPageViewModel.Series);
            }
            else
            {
                ScraperService.GetScraperService().ScraperUpdateClip(_ClipPageViewModel.CompanySeries);
            }
        }

        private void JFFVideoButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ClipPageViewModel.Company.Id == 207)
            {
                ScraperService.GetScraperService().ScraperJustForfansClipVideoFile(_ClipPageViewModel.Series);
            }
        }

        private void JFFPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ClipPageViewModel.Company.Id == 207)
            {
                ScraperService.GetScraperService().ScraperJustForfansClipPhoto(_ClipPageViewModel.Series);
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (_ClipPageViewModel.Company.Type == 4)
            {
                ScraperService.GetScraperService().ScraperXhamsterClipVideo(_ClipPageViewModel.Series);
            }
            else if (_ClipPageViewModel.Company.Id == 207)
            {
                ScraperService.GetScraperService().ScraperJustForfansClipVideo(_ClipPageViewModel.Series);
            }
            else
            {
                MessageBox.Show("无法下载");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ScraperService.GetScraperService().ScraperUpdateClip(_ClipPageViewModel.CompanySeries);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Clip _Clip = ((sender as Grid).Tag as Clip);
                if (_Clip.Finish == 4)
                {
                    ComicTools.Playing(_Clip);
                }
                else
                {
                    VideoTools.Playing(_Clip, _ClipPageViewModel);
                }
            }
        }

        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Clip = (sender as MenuItem).Tag as Clip;
            (Application.Current as App).ClipPaging = _ClipPageViewModel.Paging;
            (Application.Current as App).ClipHasVideo = _ClipPageViewModel.HasVideo;
            (Application.Current as App).ClipWindow.InitWindow();
            (Application.Current as App).ClipWindow.Show();
        }

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

                        if (_ClipPageViewModel.Company.Id == 9 || _ClipPageViewModel.Company.Id == 134 || _ClipPageViewModel.Company.Id == 288 || _ClipPageViewModel.Company.Id == 70 || _ClipPageViewModel.Company.Id == 124 || _ClipPageViewModel.Company.Id == 164 || _ClipPageViewModel.Company.Id > 999)
                        {
                            string file_path = "";
                            if (_ClipPageViewModel.Series == null) file_path = "U:/" + _ClipPageViewModel.Company.Name + "/";
                            else file_path = "U:/" + _ClipPageViewModel.Company.Name + "/" + _ClipPageViewModel.Series.Name + "/";
                            if (!Directory.Exists(file_path)) Directory.CreateDirectory(file_path);
                            file.MoveTo(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".mp4");
                        }
                        else
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
                        if (_ClipPageViewModel.Company.Id == 9 || _ClipPageViewModel.Company.Id == 134 || _ClipPageViewModel.Company.Id == 288 || _ClipPageViewModel.Company.Id == 70 || _ClipPageViewModel.Company.Id == 124 || _ClipPageViewModel.Company.Id == 164 || _ClipPageViewModel.Company.Id > 999)
                        {
                            string file_path = "";
                            if (_ClipPageViewModel.Series == null) file_path = "U:/" + _ClipPageViewModel.Company.Name + "/";
                            else file_path = "U:/" + _ClipPageViewModel.Company.Name + "/" + _ClipPageViewModel.Series.Name + "/";
                            if (!Directory.Exists(file_path)) Directory.CreateDirectory(file_path);
                            file.MoveTo(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".mkv");
                        }
                        else
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
                        if (_ClipPageViewModel.Company.Id == 9 || _ClipPageViewModel.Company.Id == 134 || _ClipPageViewModel.Company.Id == 288 || _ClipPageViewModel.Company.Id == 70 || _ClipPageViewModel.Company.Id == 124 || _ClipPageViewModel.Company.Id == 164 || _ClipPageViewModel.Company.Id > 999)
                        {
                            string file_path = "";
                            if (_ClipPageViewModel.Series == null) file_path = "U:/" + _ClipPageViewModel.Company.Name + "/";
                            else file_path = "U:/" + _ClipPageViewModel.Company.Name + "/" + _ClipPageViewModel.Series.Name + "/";
                            if (!Directory.Exists(file_path)) Directory.CreateDirectory(file_path);
                            file.MoveTo(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".wmv");
                        }
                        else
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


                        if (file.Exists)
                        {
                            file.MoveTo(new_filepath);
                            MessageBox.Show("已完成");
                        }
                        else
                        {
                            MessageBox.Show("文件不存在");
                        }
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

        private void CopyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("是否复制到D盘？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);

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
                        String new_filepath = "D:\\VideoTemp\\copy\\";
                        Console.WriteLine(new_filepath);
                        Console.WriteLine(_Clip.Finish);
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
                        Console.WriteLine(new_filepath);
                        file.CopyTo(new_filepath);
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

        private void SupplementMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clip _Clip = (sender as MenuItem).Tag as Clip;
            string filepath = "D:/VideoTemp/xhamster/" + _ClipPageViewModel.Series.Name + "_" + _Clip.Number;
            if (Directory.Exists(filepath))
            {
                ArrayList videoUrls = new ArrayList();
                string json_filepath = filepath + "/" + "meta.json";
                using (System.IO.StreamReader jsonFile = System.IO.File.OpenText(json_filepath))
                {
                    using (JsonTextReader reader = new JsonTextReader(jsonFile))
                    {
                        JObject _AllJson = (JObject)JToken.ReadFrom(reader);
                        JEnumerable<JToken> Jvideos = _AllJson["m3u8Info"]["segments"][0].Children();

                        foreach (JToken Jvideo in Jvideos)
                        {
                            videoUrls.Add("" + Jvideo["index"].ToString() + "||" + Jvideo["segUri"].ToString());
                        }
                    }
                }


                Console.WriteLine(videoUrls.Count);

                foreach (string video in videoUrls)
                {
                    string _index = "";
                    string _url = video.Split(new string[] { "||" }, StringSplitOptions.None)[1];
                    if (videoUrls.Count > 0 && videoUrls.Count < 10)
                    {
                        _index = int.Parse(video.Split(new string[] { "||" }, StringSplitOptions.None)[0]).ToString("0");
                    }
                    else if (videoUrls.Count >= 10 && videoUrls.Count < 100)
                    {
                        _index = int.Parse(video.Split(new string[] { "||" }, StringSplitOptions.None)[0]).ToString("00");
                    }
                    else if (videoUrls.Count >= 100 && videoUrls.Count < 1000)
                    {
                        _index = int.Parse(video.Split(new string[] { "||" }, StringSplitOptions.None)[0]).ToString("000");
                    }
                    else if (videoUrls.Count >= 1000 && videoUrls.Count < 10000)
                    {
                        _index = int.Parse(video.Split(new string[] { "||" }, StringSplitOptions.None)[0]).ToString("0000");
                    }
                    string VideoOutPutPath = filepath + "/Part_0/";
                    string VideoFileName = _index + ".ts";
                    string videopath = VideoOutPutPath + VideoFileName;
                    if (!File.Exists(videopath))
                    {
                        Console.WriteLine("index: " + _index + " | url: " + _url);
                        IDMFile.IDMDownloadXhamster(_url, VideoOutPutPath, VideoFileName);
                    }
                }

            }
            else
            {
                MessageBox.Show("尚未开始下载");
            }
        }

        private void PageBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_ClipPageViewModel.Paging.canback())
            {
                MessageBox.Show("无上一页");
            }
            else
            {
                _ClipPageViewModel.Paging.back();
                _ClipPageViewModel.GetClips();
                _ClipPageViewModel.GetPageButtons();
            }
        }

        private void PageNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_ClipPageViewModel.Paging.cannext())
            {
                MessageBox.Show("无下一页");
            }
            else
            {
                _ClipPageViewModel.Paging.next();
                _ClipPageViewModel.GetClips();
                _ClipPageViewModel.GetPageButtons();

            }
        }

        private void PageButton_Click(object sender, RoutedEventArgs e)
        {
            _ClipPageViewModel.Paging.CurrentPage = ((sender as Button).Tag as PageButton).PageInt;
            _ClipPageViewModel.GetClips();
            _ClipPageViewModel.GetPageButtons();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _ClipPageViewModel.HasVideo = 0;
            _ClipPageViewModel.GetPaging();
            _ClipPageViewModel.GetClips();
            _ClipPageViewModel.GetPageButtons();
        }

        private void ClearTagMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clip _Clip = (sender as MenuItem).Tag as Clip;
            ClipService.GetClipService().SetFinishClipClear(_Clip);
            _Clip.Finish = 0;
            MessageBox.Show("成功清除标记");
            InitPage();
        }

        private void HasVideoRadio_Click(object sender, RoutedEventArgs e)
        {
            if (AllVideoRadio.IsChecked == true)
                _ClipPageViewModel.HasVideo = 0;
            if (HasVideoRadio.IsChecked == true)
                _ClipPageViewModel.HasVideo = 1;
            if (NoHasVideoRadio.IsChecked == true)
                _ClipPageViewModel.HasVideo = 2;
            _ClipPageViewModel.Search = "";
            _ClipPageViewModel.GetPaging();
            _ClipPageViewModel.GetClips();
            _ClipPageViewModel.GetPageButtons();
        }
    }
}
