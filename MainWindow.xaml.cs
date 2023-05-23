using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.Dao.MySQL;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using MahApps.Metro.Controls;
using MyMovie.xaml.Comic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;

namespace com.gestapoghost.entertainment.xaml.main
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            (Application.Current as App).MainFrame = this.MainFrame;

            (Application.Current as App).ComicWindow = new ComicWindow();

            (Application.Current as App).ComicPage = new ComicPage();

            (Application.Current as App).CompanyWindow = new com.gestapoghost.entertainment.xaml.company.CompanyWindow();
            (Application.Current as App).CompanyPage = new com.gestapoghost.entertainment.xaml.company.CompanyPage();
            (Application.Current as App).SeriesWindow = new com.gestapoghost.entertainment.xaml.series.SeriesWindow();
            (Application.Current as App).SeriesPage = new com.gestapoghost.entertainment.xaml.series.SeriesPage();
            (Application.Current as App).MovieWindow = new com.gestapoghost.entertainment.xaml.movie.MovieWindow();
            (Application.Current as App).MoviePage = new com.gestapoghost.entertainment.xaml.movie.MoviePage();
            (Application.Current as App).SceneWindow = new com.gestapoghost.entertainment.xaml.scene.SceneWindow();
            (Application.Current as App).ScenePage = new com.gestapoghost.entertainment.xaml.scene.ScenePage();
            (Application.Current as App).SceneThumb = new com.gestapoghost.entertainment.xaml.scene.SceneThumb();
            (Application.Current as App).ClipWindow = new com.gestapoghost.entertainment.xaml.clip.ClipWindow();
            (Application.Current as App).ClipPage = new com.gestapoghost.entertainment.xaml.clip.ClipPage();
            (Application.Current as App).FansWindow = new com.gestapoghost.entertainment.xaml.fans.FansWindow();
            (Application.Current as App).FansPage = new com.gestapoghost.entertainment.xaml.fans.FansPage();
            (Application.Current as App).ActorPage = new com.gestapoghost.entertainment.xaml.actor.ActorPage();

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void IndexButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("IndexPage.xaml", UriKind.Relative);
        }

        private void FilmButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 1;
            (Application.Current as App).Actor = null;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }

        private void DVDButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 10;
            (Application.Current as App).Actor = null;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }

        private void ClipButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 2;
            (Application.Current as App).Actor = null;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }


        private void XhamsterButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 4;
            (Application.Current as App).Actor = null;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }
        private void XtubeButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 5;
            (Application.Current as App).Actor = null;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }
        private void OnlyfansButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 6;
            (Application.Current as App).Actor = null;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }
        private void JustforfansButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 7;
            (Application.Current as App).Actor = null;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }
        private void Cam4Button_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 8;
            (Application.Current as App).Actor = null;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }

        private void ActorButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).ActorPage.InitPage();
            MainFrame.Content = (Application.Current as App).ActorPage;
        }

        private void ComicButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyTypeId = 3;
            (Application.Current as App).CompanyPage.InitPage();
            MainFrame.Content = (Application.Current as App).CompanyPage;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Thread th = new Thread(delegate ()
            {
                DirectoryInfo root = new DirectoryInfo(@"Y:\Tools\Tinfoil\Logs");
                FileInfo[] fileinfos = root.GetFiles("*.*");
                int allCount = fileinfos.Length;
                int count = 0;
                foreach (FileInfo file in fileinfos)
                {
                    count++;
                    ClearButton.Invoke(delegate ()
                    {
                        ClearButton.Content = "清理中：" + count.ToString() + @"/" + allCount.ToString();
                    });

                    if (file.Name.Split('_')[0].Length == 32)
                    {
                        int actorCount = 0;
                        int clipCount = 0;
                        int companyCount = 0;
                        int seriesCount = 0;
                        int movieCount = 0;
                        ObservableCollection<Actor> actors = ActorDao.GetActorDao().GetAllActorsByPICSHA(file.Name.Split('_')[0]);
                        foreach (Actor actor in actors)
                        {
                            actorCount++;
                        }
                        ObservableCollection<Clip> clips = ClipDao.GetClipDao().GetAllClipsByPICSHA(file.Name.Split('_')[0]);
                        foreach (Clip clip in clips)
                        {
                            clipCount++;
                        }
                        ObservableCollection<Company> companys = CompanyDao.GetCompanyDao().GetAllCompanyByPICSHA(file.Name.Split('_')[0]);
                        foreach (Company company in companys)
                        {
                            companyCount++;
                        }
                        ObservableCollection<Series> seriess = SeriesDao.GetSeriesDao().GetAllSeriesByPICSHA(file.Name.Split('_')[0]);
                        foreach (Series series in seriess)
                        {
                            seriesCount++;
                        }
                        ObservableCollection<Movie> movies = MovieDao.GetMovieDao().GetAllMovieByPICSHA(file.Name.Split('_')[0]);
                        foreach (Movie movie in movies)
                        {
                            movieCount++;
                        }
                        if ((actorCount + clipCount + companyCount + seriesCount + movieCount) == 0)
                        {
                            Console.WriteLine(file.Name + "无对应");
                            file.MoveTo(@"Y:\Temp\" + file.Name);
                        }
                    }
                    Console.WriteLine(count.ToString() + @"\" + allCount.ToString());
                }
                ClearButton.Invoke(delegate ()
                {
                    ClearButton.Content = "清理";
                });
                MessageBox.Show("Finish");
            });
            th.Start();
            th.IsBackground = true;
        }

        private void ClearFileButton_Click(object sender, RoutedEventArgs e)
        {
            Thread th = new Thread(delegate ()
            {
                int allCount = 0;
                DirectoryInfo rootnsp = new DirectoryInfo(@"Y:\Roms\Games\NSP");
                FileInfo[] fileinfosnsp = rootnsp.GetFiles("*.*");

                DirectoryInfo rootxci = new DirectoryInfo(@"Y:\Roms\Games\XCI");
                FileInfo[] fileinfosxci = rootxci.GetFiles("*.*");

                DirectoryInfo rootnsz = new DirectoryInfo(@"Y:\Roms\Games\NSZ");
                FileInfo[] fileinfosnsz = rootxci.GetFiles("*.*");

                DirectoryInfo rootcia = new DirectoryInfo(@"X:\OtherRoms");
                FileInfo[] fileinfoscia = rootcia.GetFiles("*.*");

                List<FileInfo> fileinfos = new List<FileInfo>();

                foreach (FileInfo _FileInfo in fileinfosnsp) fileinfos.Add(_FileInfo);
                foreach (FileInfo _FileInfo in fileinfosxci) fileinfos.Add(_FileInfo);
                foreach (FileInfo _FileInfo in fileinfoscia) fileinfos.Add(_FileInfo);
                foreach (FileInfo _FileInfo in fileinfosnsz) fileinfos.Add(_FileInfo);

                allCount = fileinfos.Count;

                ObservableCollection<Clip> _Clips = ClipDao.GetClipDao().GetAllFinishClips();

                Console.WriteLine(_Clips.Count);
                List<String> md5s = new List<String>();

                foreach (Clip _Clip in _Clips) md5s.Add(VideoFile.intToMd5(_Clip.Id));

                FileInfo myFile = new FileInfo(@"D:\Temp2.txt");
                StreamWriter sw = myFile.CreateText();

                List<String> md5s2 = new List<String>();

                //List<String> md5s2 = new List<String>();
                //foreach (FileInfo _FileInfo in fileinfos)
                //{
                //    md5s2.Add(_FileInfo.Name.Split('.')[0]);
                //}

                int count = 0;
                foreach (FileInfo _FileInfo in fileinfos)
                {
                    count++;
                    ClearButton.Invoke(delegate ()
                    {
                        ClearButton.Content = "清理中：" + count.ToString() + @"/" + allCount.ToString();
                    });

                    bool hasFile = false;

                    int num = 0;
                    int resultnum = 0;
                    foreach (String _MD5 in md5s)
                    {
                        if (string.Equals(_FileInfo.Name.Split('.')[0], _MD5))
                        {
                            resultnum = num;
                            hasFile = true;
                        }
                        num++;
                    }
                    if (hasFile)
                    {
                        Console.WriteLine("success ! [" + _FileInfo.Name + "]" + "[" + _FileInfo.Name.Split('.')[0] + "]" + "[" + md5s[resultnum] + "]");
                        //md5s.Remove(md5s[resultnum]);
                        md5s2.Add(_FileInfo.Name.Split('.')[0]);

                    }
                    else
                    {
                        sw.WriteLine("error ! [" + _FileInfo.Name + "]" + "[" + _FileInfo.Name.Split('.')[0] + "]" + "[" + md5s[resultnum] + "]");
                        Console.WriteLine(_FileInfo.Name);
                        _FileInfo.MoveTo(@"Y:\Temp\" + _FileInfo.Name);
                    }
                }

                sw.Close();

                //foreach (String md5database in md5s)
                //{

                //    bool ishas = false;
                //    foreach (String md5file in md5s2)
                //    {
                //        if (String.Equals(md5file, md5database))
                //        {
                //            ishas = true;
                //        }
                //    }
                //    if (ishas == false)
                //    {
                //        Console.WriteLine(md5database);
                //    }
                //    else
                //    {
                //        md5s2.Remove(md5database);
                //    }

                //}


                ClearButton.Invoke(delegate ()
                {
                    ClearButton.Content = "清理";
                });
                MessageBox.Show("Finish");
            });
            th.Start();
            th.IsBackground = true;
        }

        private void GobackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) { MainFrame.GoBack(); }
            else { MessageBox.Show("无法后退"); }
        }

        private void GoonButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward) { MainFrame.GoForward(); }
            else { MessageBox.Show("无法前进"); }
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            if (TestText.Text.Equals("370172"))
            {
                FilmsButton.Visibility = Visibility.Visible;
                ClipsButton.Visibility = Visibility.Visible;
                XhamsterButton.Visibility = Visibility.Visible;
                XtubeButton.Visibility = Visibility.Visible;
                OnlyfansButton.Visibility = Visibility.Visible;
                JustforfansButton.Visibility = Visibility.Visible;
                Cam4Button.Visibility = Visibility.Visible;
                ActorButton.Visibility = Visibility.Visible;
                ComicButton.Visibility = Visibility.Visible;
                ClearButton.Visibility = Visibility.Visible;
                ClearFileButton.Visibility = Visibility.Visible;
                UpdateButton.Visibility = Visibility.Visible;
                VideoInfoUpdateButton.Visibility = Visibility.Visible;
                DVDsButton.Visibility = Visibility.Visible;
            }
            else
            {
                FilmsButton.Visibility = Visibility.Hidden;
                ClipsButton.Visibility = Visibility.Hidden;
                XhamsterButton.Visibility = Visibility.Hidden;
                XtubeButton.Visibility = Visibility.Hidden;
                OnlyfansButton.Visibility = Visibility.Hidden;
                JustforfansButton.Visibility = Visibility.Hidden;
                Cam4Button.Visibility = Visibility.Hidden;
                ActorButton.Visibility = Visibility.Hidden;
                ComicButton.Visibility = Visibility.Hidden;
                ClearButton.Visibility = Visibility.Hidden;
                ClearFileButton.Visibility = Visibility.Hidden;
                UpdateButton.Visibility = Visibility.Hidden;
                VideoInfoUpdateButton.Visibility = Visibility.Hidden;
                this.IndexButton_Click(sender, e);
                MessageBox.Show("输入内容为" + TestText.Text + "测试成功!");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ScraperService.GetScraperService().ScraperAllUpdateClip();
        }

        private void VideoInfoUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Thread th = new Thread(delegate ()
            {
                VideoInfoService.GetVideoInfoService().UpdateAllClipVideoInfo();
            });
            th.Start();
            th.IsBackground = true;

            //ClipDao.GetClipDao().Test();

        }
    }
}
