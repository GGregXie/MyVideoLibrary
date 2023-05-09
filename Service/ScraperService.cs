using HtmlAgilityPack;
using System;
using System.Collections;
using System.Windows;
using System.IO;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.Dao.MySQL;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Net;
using System.Drawing;
using com.gestapoghost.entertainment.AllFile;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using OpenQA.Selenium.Interactions;

namespace com.gestapoghost.entertainment.service
{
    class ScraperService
    {
        private static ScraperService scraperService = null;
        IWebDriver driver;

        public static ScraperService GetScraperService()
        {
            if (scraperService == null)
            {
                scraperService = new ScraperService();
            }
            return scraperService;
        }

        public void ScraperAllClip(string webString)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document;
            HtmlNodeCollection clipNodes;
            HtmlNodeCollection imageNodes;
            bool IsOver = false;
            int resultNum = 1;
            ArrayList clips = new ArrayList();

            switch (webString)
            {


                /** Tim Tales
                case "Tim Tales":
                    for (int i = 1; !IsOver; i++)
                    {
                        //FromUrlToHtml("https://www.timtales.com/videos/list/" + i, "D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        document = web.Load("D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'video-item video-item-odd') or contains(@class, 'video-item video-item-even')]");

                        if (clipNodes == null) IsOver = true;
                        else
                        {
                            foreach (HtmlNode clipNode in clipNodes)
                            {
                                string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/h2").InnerText.Trim();
                                string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "/div").GetAttributeValue("style", "").Replace("background-image: url('", "").Replace("')", "");
                                string clipUrl = "https://www.timtales.com" + clipNode.SelectSingleNode(clipNode.XPath + "/div/a").GetAttributeValue("href", "").Trim();
                                string clipDate = "";
                                string clipDescription = "";
                                clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                                resultNum++;
                            }
                        }
                    }
                    ConsoleWrite(0, clips);
                    ScraperClips(0, clips, 9, 0);
                    break;
                */
                /** Kristen Bjorn - Casting Couch
            case "Kristen Bjorn - Casting Couch":
                for (int i = 1; !IsOver; i++)
                {
                    FromUrlToHtml("https://www.kristenbjorn.com/web/model/video/gayporn/CC&idg=&oc=0&page=" + i, "D:/VideoTemp/html/" + webString + ".html");
                    document = web.Load("D:/VideoTemp/html/" + webString + ".html");
                    clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-4 col-sm-6 col-xs-12')]");

                    if (clipNodes == null) IsOver = true;
                    else
                    {
                        foreach (HtmlNode clipNode in clipNodes)
                        {
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("title", "").Trim();
                            string clipImgUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a/video").GetAttributeValue("poster", "").Trim();
                            string clipUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("href", "").Trim();
                            string clipDate = "";
                            string clipDescription = "";
                            if (clipTitle.Contains("Casting Couch"))
                            {
                                clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                                resultNum++;
                            }
                        }
                    }
                }
                ConsoleWrite(0, clips);
                //ScraperClips(0, clips, 70, 24);
                break;
                */
                /** Kristen Bjorn - Lover's Lane
        case "Kristen Bjorn - Lover's Lane":
            for (int i = 1; !IsOver; i++)
            {
                FromUrlToHtml("https://www.kristenbjorn.com/web/model/video/gayporn/CC&idg=&oc=0&page=" + i, "D:/VideoTemp/html/" + webString + ".html");
                document = web.Load("D:/VideoTemp/html/" + webString + ".html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-4 col-sm-6 col-xs-12')]");

                if (clipNodes == null) IsOver = true;
                else
                {
                    foreach (HtmlNode clipNode in clipNodes)
                    {
                        string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("title", "").Trim();
                        string clipImgUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a/video").GetAttributeValue("poster", "").Trim();
                        string clipUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("href", "").Trim();
                        string clipDate = "";
                        string clipDescription = "";
                        if (clipTitle.Contains("Lover's Lane"))
                        {
                            clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                            resultNum++;
                        }
                    }
                }
            }
            ConsoleWrite(0, clips);
            //ScraperClips(0, clips, 70, 60);
            break;
            */
                /**Kristen Bjorn - Web Scenes
            case "Kristen Bjorn - Web Scenes":
                for (int i = 1; !IsOver; i++)
                {
                    FromUrlToHtml("https://www.kristenbjorn.com/web/model/video/gayporn/WS&idg=&oc=0&page=" + i, "D:/VideoTemp/html/" + webString + ".html");
                    document = web.Load("D:/VideoTemp/html/" + webString + ".html");
                    clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-4 col-sm-6 col-xs-12')]");
                    if (clipNodes == null) IsOver = true;
                    else
                    {
                        foreach (HtmlNode clipNode in clipNodes)
                        {
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("title", "").Trim();
                            string clipImgUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a/video").GetAttributeValue("poster", "").Trim();
                            string clipUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("href", "").Trim();
                            string clipDate = "";
                            string clipDescription = "";
                            clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                            resultNum++;
                        }
                    }
                }
                ConsoleWrite(0, clips);
                //ScraperClips(0, clips, 70, 25);
                break;
                */
                /** Masqulin
            case "Masqulin":
                for (int i = 1; !IsOver; i++)
                {
                    FromUrlToHtml("https://www.masqulin.com/categories/movies_" + i + "_d.html", "D:/VideoTemp/html/" + webString + ".html");
                    document = web.Load("D:/VideoTemp/html/" + webString + ".html");
                    clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-xs-12 col-md-6 col-lg-4 col-xl-4 sceneTour modelTour')]");
                    if (clipNodes == null) IsOver = true;
                    else
                    {
                        foreach (HtmlNode clipNode in clipNodes)
                        {
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//h4").InnerHtml.Trim();
                            string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "/a/img").GetAttributeValue("data-src", "").Trim();
                            string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();
                            string clipDate = "";
                            string clipDescription = "";
                            clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                            resultNum++;
                        }
                    }
                }
                ConsoleWrite(-1, clips);
                ScraperClips(-1, clips, 89, 0);
                break;
            */
                /** Fist Alley
                case "Fist Alley":
                    for (int i = 1; i < 6; i++)
                    {
                        FromUrlToHtml("https://fistalley.com/scenes/page/" + i + "/", "D:/VideoTemp/html/" + webString + ".html");
                        document = web.Load("D:/VideoTemp/html/" + webString + ".html");
                        clipNodes = document.DocumentNode.SelectNodes("//div[contains(@id, 'video-card')]");
                        foreach (HtmlNode clipNode in clipNodes)
                        {
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//h4").InnerHtml.Trim();
                            string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "/a/img").GetAttributeValue("src", "").Trim();
                            string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();
                            string clipDate = "";
                            string clipDescription = "";
                            clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                            resultNum++;
                        }
                    }
                    ConsoleWrite(0, clips);
                    ScraperClips(0, clips, 176, 0);
                    break;
                */
                /** Pride Studio - High Performance Men
                case "Pride Studio - High Performance Men":
                    for (int i = 1; i < 8; i++)
                    {
                        //FromUrlToHtml("https://www.pridestudios.com/en/videos/highperformancemen/latest/All+Categories/0/All+Models/0/" + i, "D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        document = web.Load("D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        clipNodes = document.DocumentNode.SelectNodes("//ul[contains(@class, 'sceneList')]/li");
                        foreach (HtmlNode clipNode in clipNodes)
                        {
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//h3/a").InnerText.Trim();
                            string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "/div/a/img").GetAttributeValue("data-original", "").Trim().Replace("?width=627&height=356&enlarge=true", "?width=960&height=544&enlarge=true");
                            string clipUrl = "https://www.pridestudios.com/" + clipNode.SelectSingleNode(clipNode.XPath + "//h3/a").GetAttributeValue("href", "").Trim();
                            string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneDate')]").InnerText.Trim();
                            string clipDescription = "";
                            if (clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]") != null)
                                clipDescription = "||**  " + clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]").InnerText.Trim() + "  **|";
                            string[] lastclip = { "", "", "", "", "", "" };
                            if (clips.Count > 1)
                                lastclip = clips[clips.Count - 1] as string[];
                            if (!string.Equals(lastclip[1], clipTitle))
                            {
                                clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                                resultNum++;
                            }
                        }
                    }
                    ConsoleWrite(0, clips);
                    ScraperClips(0, clips, 11, 10);
                    break;
        */
                /** Butch Dixon - Butch Dixon
                case "Butch Dixon - Butch Dixon":
                    for (int i = 1; i < 33; i++)
                    {
                        FromUrlToHtml("https://www.butchdixon.com/tour/show.php?a=744_" + i + "&uvar=MC4yLjQwLjEyNy4wLjAuMC4wLjA", "D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        document = web.Load("D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'itemv')]");
                        foreach (HtmlNode clipNode in clipNodes)
                        {
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/div/div/a").InnerText.Trim();
                            string clipImgUrl = "https://www.butchdixon.com/tour/" + clipNode.SelectSingleNode(clipNode.XPath + "/a/img").GetAttributeValue("src", "").Trim();
                            string clipUrl = "https://www.butchdixon.com/tour/" + clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();
                            string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'nm-name')]/p").InnerText.Trim();
                            string clipDescription = "";
                            DateTime dt = DateTime.Parse(clipDate);
                            clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                            resultNum++;
                        }
                    }
                    ConsoleWrite(0, clips);
                    ScraperClips(0, clips, 2, 45);
                    break;
                    */
                /** Butch Dixon - Uk Naked Men
                case "Butch Dixon - UK Naked Men":
                    for (int i = 1; i < 36; i++)
                    {
                        //FromUrlToHtml("https://www.uknakedmen.com/tour/show.php?a=669_" + i, "D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        document = web.Load("D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'itemv')]");
                        foreach (HtmlNode clipNode in clipNodes)
                        {
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/div/div/a").InnerText.Trim();
                            string clipImgUrl = "https://www.uknakedmen.com/tour/" + clipNode.SelectSingleNode(clipNode.XPath + "/a/img").GetAttributeValue("src", "").Trim();
                            string clipUrl = "https://www.uknakedmen.com/tour/" + clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();
                            string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'nm-name')]/p").InnerText.Trim();
                            string clipDescription = "";
                            DateTime dt = DateTime.Parse(clipDate);
                            clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                            resultNum++;
                        }
                    }
                    ConsoleWrite(0, clips);
                    ScraperClips(0, clips, 2, 46);
                    break;
                */
                /** Men At Play

                case "Men At Play":
                    for (int i = 1; i < 66; i++)
                    {
                        FromUrlToHtml("https://www.menatplay.com/categories/movies_" + i + "_d.html", "D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        document = web.Load("D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'updateDetails')]");
                        imageNodes = document.DocumentNode.SelectNodes("//a[contains(@class, 'control_thumb')]");
                        for (int n = 0; n < clipNodes.Count; n++)
                        {
                            HtmlNode clipNode = clipNodes[n];
                            HtmlNode imageNode = imageNodes[n];
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//h4/a").InnerText.Trim();
                            string clipImgUrl = imageNode.SelectSingleNode(imageNode.XPath + "//div[contains(@class, 'test')]/img").GetAttributeValue("src0_1x", "").Trim();
                            string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//h4/a").GetAttributeValue("href", "").Trim();
                            string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'availdate')]").InnerText.Trim();
                            string clipDescription = "";
                            DateTime dt = DateTime.Parse(clipDate);
                            clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                            resultNum++;
                        }
                    }
                    ConsoleWrite(0, clips);
                    ScraperClips(0, clips, 12, 0);
                    break;
                    */
                /** Hot Older Male
                case "Hot Older Male":
                    for (int i = 1; i < 27; i++)
                    {
                        FromUrlToHtml("https://www.hotoldermale.com/scenes?Page=" + i, "D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        document = web.Load("D:/VideoTemp/html/" + webString + "_" + i + ".html");
                        clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'lstEachScene')]");
                        for (int n = 0; n < clipNodes.Count; n++)
                        {
                            HtmlNode clipNode = clipNodes[n];
                            string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'lstSceneTitle')]").InnerText.Trim();
                            string clipImgUrl = "";
                            string clipUrl = "https://www.hotoldermale.com" + clipNode.SelectSingleNode(clipNode.XPath + "/div/img").GetAttributeValue("data-href", "").Trim();
                            string clipNum = Regex.Match(clipUrl, @"\d+").ToString();
                            string clipDate = "1980-1-1";
                            string clipDescription = "";
                            DateTime dt = DateTime.Parse(clipDate);
                            clips.Add(new string[] { clipNum.ToString(), clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                            resultNum++;
                        }
                    }
                    ConsoleWrite(0, clips);
                    ScraperClips(0, clips, 10, 0);
                    break;
                */
                default:
                    break;
            }
        }

        public void ScraperXhamsterClip(Series _Series)
        {
            if (ClipDao.GetClipDao().GetAllClipCountBySeries(_Series.Id) == 0)
            {
                Thread th = new Thread(delegate ()
                {
                    MessageBoxResult dr = MessageBox.Show("是否准备就绪？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (dr == MessageBoxResult.OK)
                    {
//                        FromUrlToHtml("https://xhamster48.com/users/" + _Series.Name.ToLower() + "/videos", "D:/VideoTemp/html/xhamster.html");
                        HtmlDocument _Document = new HtmlWeb().Load("https://xhamster48.com/users/" + _Series.Name.ToLower() + "/videos");

                        Console.WriteLine(_Document.Text);

                        HtmlNode _TotalNumNode = _Document.DocumentNode.SelectSingleNode("//a[contains(@class, 'active current-tab followable videos')]/span");


                        ArrayList clips = new ArrayList();
                        int totalNum = int.Parse(_TotalNumNode.InnerText);
                        int totalPage = totalNum / 30;
                        int index = 0;
                        if (totalNum % 30 != 0) totalPage++;
                        for (int i = 1; i <= totalPage; i++)
                        {
                            _Document = new HtmlWeb().Load("https://xhamster48.com/users/" + _Series.Name + "/videos/" + i);
                            HtmlNodeCollection _ClipNodes = _Document.DocumentNode.SelectNodes("//div[contains(@class, 'thumb-list__item video-thumb role-pop')]");
                            foreach (HtmlNode clipNode in _ClipNodes)
                            {
                                int _ClipNum = totalNum - index;
                                string _ClipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'video-thumb-info__name role-pop')]").InnerText.Trim();
                                string _ClipImageUrl = "ClipNull";
                                if (clipNode.SelectSingleNode(clipNode.XPath + "//img[contains(@class, 'thumb-image-container__image')]") != null)
                                {
                                    _ClipImageUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img[contains(@class, 'thumb-image-container__image')]").GetAttributeValue("src", "");
                                }
                                string _ClipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'video-thumb__image-container role-pop thumb-image-container')]").GetAttributeValue("href", "");
                                clips.Add(new string[] { _ClipNum.ToString(), _ClipTitle, _ClipImageUrl, _ClipUrl });
                                index++;
                            }
                        }

                        foreach (string[] clipString in clips)
                        {
                            int clipNum = int.Parse(clipString[0]);
                            string imageUrl = clipString[2];
                            string clipPic = "";
                            clipPic = FromUrlToImage(imageUrl, "D:/VideoTemp/html/" + _Series.Name + "_small_" + clipNum + ".jpg");
                            //clipPic = "ClipNull";
                            try
                            {
                                ClipDao.GetClipDao().CreateClip(203, _Series.Id, clipNum, clipString[1], DateTime.Parse("1980-1-1"), "", clipPic, "", 0, clipString[3]);
                                Console.WriteLine(clipNum.ToString() + " / " + clipString[3] + imageUrl + " / " + clipPic + "--> success");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(clipNum.ToString() + " / " + clipString[3] + imageUrl + " / " + clipPic + "--> error");
                            }
                        }
                        driver = null;
                    }
                    else
                    {
                        MessageBox.Show("已取消操作");
                        driver = null;

                    }
                });
                th.Start();
                th.IsBackground = true;
            }
            else
            {
                Thread th = new Thread(delegate ()
                {
                    string url = "https://www.xhamster.com/gay/creators/" + _Series.Name.ToLower() + "/newest";
                    Console.WriteLine(url);
                    HtmlDocument _Document = new HtmlWeb().Load(url);

                    string VideoNum = _Document.DocumentNode.SelectSingleNode("//div[contains(@class, 'landing-info__metric-value')]").InnerText;
                    Console.WriteLine(VideoNum);

                    ArrayList clips = new ArrayList();
                    Clip _LastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(_Series.Id); 


                    HtmlNodeCollection _ClipNodes = _Document.DocumentNode.SelectNodes("//div[contains(@class, 'thumb-list__item')]");
                    bool isLast = false;
                    int index = 1;
                    foreach (HtmlNode clipNode in _ClipNodes)
                    {
                        string _ClipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'video-thumb-info__name')]").InnerText.Trim();

                        string _ClipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'video-thumb-info__name')]").GetAttributeValue("href", "").Replace("xhamster.com", "localxh2.com") ;
                        if (string.Equals(_ClipTitle, _LastClip.Title)) isLast = true;
                        if (!isLast) clips.Add(new string[] { index.ToString(), _ClipTitle, _ClipUrl });
                        index++;
                    }
                    foreach (string[] clipString in clips)
                    {
                        int clipNum = _LastClip.Number + clips.Count - int.Parse(clipString[0]) + 1;
                        Console.WriteLine("ClipNum: " + clipNum + " / Title: " + clipString[1] + "Url: " + clipString[2]);
                        ClipDao.GetClipDao().CreateClip(203, _Series.Id, clipNum, clipString[1], DateTime.Parse("1980-1-1"), "", "ClipNull", "", 0, clipString[2]);
                    }


                });
                th.Start();
                th.IsBackground = true;
            }
        }

        public void ScraperXhamsterClipVideo(Series _Series)
        {
            Thread th = new Thread(delegate ()
            {
                int overnum = 0;
                ArrayList videoUrls = new ArrayList();
                MessageBoxResult dr = MessageBox.Show("是否准备就绪？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (dr == MessageBoxResult.OK)
                {
                    ObservableCollection<Clip> _Clips = ClipDao.GetClipDao().GetAllClipsFromXhamster(_Series.Id);
                    foreach (Clip _Clip in _Clips)
                    {
                        if (overnum < 1)
                        {
                            if (_Clip.Finish == 0)
                            {
                                Console.WriteLine(_Clip.ClipUrl);
                                HtmlDocument _Document = null;

                                Boolean isload = false;
                                int testnum = 1;
                                while (!isload)
                                {
                                    try
                                    {
                                        Console.WriteLine("第" + testnum + "次尝试");
                                        testnum++;
                                        _Document = new HtmlWeb().Load(_Clip.ClipUrl);
                                        isload = true;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("ExceptionFrom: " + _Clip.Number);
                                        Console.WriteLine(ex.Message);
                                    }
                                }

                                //_Document.DocumentNode.SelectSingleNode("//a[contains(@class, 'active current-tab followable videos')]/span");
                                Console.WriteLine("####" + _Document.DocumentNode.SelectSingleNode("//link[contains(@as, 'fetch')]").GetAttributeValue("href", ""));
                                Console.WriteLine("####" + _Document.DocumentNode.SelectSingleNode("//link[contains(@as, 'image')]").GetAttributeValue("href", ""));

                                videoUrls.Add(new string[] { "D:/VideoTemp/html/m3u8/" + _Series.Name + "_" + _Clip.Number + ".m3u8", _Document.DocumentNode.SelectSingleNode("//link[contains(@as, 'fetch')]").GetAttributeValue("href", ""), _Series.Name + "_" + _Clip.Number });
                                FromUrlToImage(_Document.DocumentNode.SelectSingleNode("//link[contains(@as, 'image')]").GetAttributeValue("href", ""), "D:/VideoTemp/html/" + _Series.Name + "_" + _Clip.Number + ".jpg");
                                ClipDao.GetClipDao().UpdateClip(_Clip.Id, _Clip.Number, _Clip.Title, _Clip.Date, _Clip.Description, ImageFileService.SaveBitmapImage(ImageFileService.GetImage("D:/VideoTemp/html/" + _Series.Name + "_" + _Clip.Number + ".jpg")), _Clip.FilePath, _Clip.Start, _Clip.ClipUrl);
                            }
                            overnum++;
                        }
                    }
                    foreach (string[] videoUrl in videoUrls)
                    {
                        string webserverurl = videoUrl[1].Replace("https://", "").Split("/".ToCharArray())[0];
                        string BestM3U8Url = "";
                        if (videoUrl[1].Contains("_TPL_.h264.mp4.m3u8"))
                        {
                            BestM3U8Url = videoUrl[1].Replace("_TPL_.h264.mp4.m3u8", FromUrlSelectBestVideo(videoUrl[1]));


                            
                        }
                        else
                        {
                            BestM3U8Url = "https://" + webserverurl + videoUrl[1].Split("/hls/".ToCharArray())[0] + FromUrlSelectBestVideo(videoUrl[1]);
                        }



                        Console.WriteLine("========videoUrl[0]" + videoUrl[0]);
                        Console.WriteLine("========videoUrl[1]" + videoUrl[1]);
                        Console.WriteLine("========BestM3U8Url" + BestM3U8Url);



                        FromUrlToFile(BestM3U8Url, videoUrl[0]);
                        System.Diagnostics.Process process = System.Diagnostics.Process.Start(@"C:\Program Tools\Media Tools\N_m3u8DL-CLI\N_m3u8DL-CLI.exe", videoUrl[0] + " --workDir D:\\VideoTemp\\xhamster --saveName " + videoUrl[2] + " --headers \"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.146 Safari/537.36\" --retryCount 3");
                        //process.WaitForExit();
                    }
                }
                else
                {
                    MessageBox.Show("已取消操作");
                }

            });
            th.Start();
            th.IsBackground = true;
        }

        public void ScraperJustForfansClipAll(Series _Series)
        {
            HtmlWeb web = new HtmlWeb();
            String _ScraperUrl1 = "";
            String _ScraperUrl2 = "";
            ArrayList clips = new ArrayList();
            JObject download_json = new JObject();
            int photoi = 0;

            int _index = 0;
            switch (_Series.Id)
            {
                case 293:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=1166582&PosterID=229524&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=df55cdd0a539dca48436e0877941f262";
                    break;

                case 296:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=394&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=b357fddc69a4446e0733952621888252";
                    break;

                case 297:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=444054&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=09a1239cdc5d963a32fa6f4b49b37d99";
                    break;

                case 302:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=726842&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 307:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=786549&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 309:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=1272949&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 310:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=533437&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                default:
                    _ScraperUrl1 = "";
                    _ScraperUrl2 = "";
                    break;
            }
            Console.WriteLine(_ScraperUrl1 + _index + _ScraperUrl2);
            HtmlDocument doc = web.Load(_ScraperUrl1 + _index + _ScraperUrl2);


            while (doc.DocumentNode.SelectNodes("//div[contains(@class, 'jffPostClass')]") != null)
            {
                foreach (HtmlNode bookNode in doc.DocumentNode.SelectNodes("//div[contains(@class, 'jffPostClass')]"))
                {
                    DateTime clip_date = new DateTime();
                    string str_clip_title = bookNode.GetAttributeValue("id", "");
                    string str_clip_date = "";
                    string str_clip_description = "";
                    string str_clip_url = "";

                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]") != null) str_clip_date = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]").InnerText.Trim();
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'post-text-content')]") != null) str_clip_description = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'post-text-content')]").InnerText.Trim();
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]") != null) str_clip_url = "https://justfor.fans" + bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]").GetAttributeValue("onclick", "").Replace("location.href='", "").Replace("'", "").Trim();

                    DateTime.TryParse(str_clip_date, out clip_date);

                    Clip _Clip = new Clip();
                    _Clip.Title = str_clip_title;
                    _Clip.Date = clip_date.Date;
                    _Clip.ClipUrl = str_clip_url;
                    _Clip.Description = str_clip_description;
                    clips.Add(_Clip);

                    //下载video
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'videoBlock')]/a") != null)
                    {
                        string str_video_json = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'videoBlock')]/a").GetAttributeValue("onclick", "").Trim();
                        Regex rgx = new Regex(@"(?i)(?<=\{)(.*)(?=\})");
                        string video_json = rgx.Match(str_video_json).Value;
                        JObject jo = (JObject)JsonConvert.DeserializeObject("{" + video_json + "}");
                        if (jo["1080p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["1080p"]);
                            //IDMFile.IDMDownloadJFF(jo["1080p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");

                        }
                        else if (jo["720p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["720p"]);
                            //IDMFile.IDMDownloadJFF(jo["720p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");
                        }
                        else if (jo["540p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["540p"]);
                            //IDMFile.IDMDownloadJFF(jo["540p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");
                        }
                        else
                        {
                            Console.WriteLine("video error");
                        }
                    }

                    //下载photo

                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'galleryWrapper')]/div[contains(@class, 'galleryLarge')]") != null)
                    {
                        foreach (HtmlNode photonode in bookNode.SelectNodes(bookNode.XPath + "//div[contains(@class, 'galleryWrapper')]/div[contains(@class, 'galleryLarge')]//img"))
                        {
                            if (!System.IO.Directory.Exists(@"D:\VideoTemp\JFF\" + _index + @"\"))
                            {
                                IDMFile.IDMDownloadJFF(photonode.GetAttributeValue("src", ""), @"D:\VideoTemp\JFF\" + _index + @"\");
                                photoi++;
                                if (photoi > 10)
                                {
                                    MessageBox.Show("10个图片了");
                                    photoi = 0;
                                }

                            }
                        }
                    }
                    _index++;
                }

                doc = web.Load(_ScraperUrl1 + _index + _ScraperUrl2);
                //MessageBox.Show(_index.ToString());
                Console.WriteLine(_index.ToString());

            }

            MessageBoxResult jffphotombr = MessageBox.Show("图片是否下载完毕？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (jffphotombr == MessageBoxResult.OK)
            {

                for (int aaa = 0; aaa <= _index; aaa++)
                {
                    if (System.IO.Directory.Exists(@"D:\VideoTemp\JFF\" + aaa + @"\"))
                    {
                        if (!System.IO.Directory.Exists(@"D:\VideoTemp\JFF\Photo"))
                        {
                            System.IO.Directory.CreateDirectory(@"D:\VideoTemp\JFF\Photo");
                        }
                        System.IO.Directory.Move(@"D:\VideoTemp\JFF\" + aaa + @"\", @"D:\VideoTemp\JFF\Photo\" + (_index - aaa) + @"\");
                    }
                }
            }


            System.IO.File.WriteAllText(@"D:\VideoTemp\JFF\" + _Series.Id + ".json", download_json.ToString());


            int i = 0;
            foreach (Clip _Clip in clips)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Number: " + (clips.Count - i).ToString() + " / Title: " + _Clip.Title + " / Date: " + _Clip.Date.ToString() + " / Url: " + _Clip.ClipUrl + " / Desc: " + _Clip.Description);
                Console.WriteLine("-----------------------------------------------------");

                //Clip _OldClip = ClipDao.GetClipDao().getClipBySeriesAndNumber(_Series.Id, clips.Count - i);
                //ClipDao.GetClipDao().UpdateClipTitle(_OldClip.Id, _Clip.Title);


                ClipDao.GetClipDao().CreateClip(207, _Series.Id, clips.Count - i, _Clip.Title, _Clip.Date, _Clip.Description, "ClipNull", "", 0, _Clip.ClipUrl);
                i++;


            }


        }

        public void ScraperJustForfansClipPhoto(Series _Series)
        {
            HtmlWeb web = new HtmlWeb();
            String _ScraperUrl1 = "";
            String _ScraperUrl2 = "";
            ArrayList clips = new ArrayList();
            JObject download_json = new JObject();
            int photoi = 0;

            int _index = 0;
            switch (_Series.Id)
            {
                case 293:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=1166582&PosterID=229524&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=df55cdd0a539dca48436e0877941f262";
                    break;

                case 296:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=394&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=b357fddc69a4446e0733952621888252";
                    break;

                case 297:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=444054&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=09a1239cdc5d963a32fa6f4b49b37d99";
                    break;

                case 302:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=726842&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 307:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=786549&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 309:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=1272949&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 310:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=533437&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                default:
                    _ScraperUrl1 = "";
                    _ScraperUrl2 = "";
                    break;
            }

            HtmlDocument doc = web.Load(_ScraperUrl1 + _index + _ScraperUrl2);


            while (doc.DocumentNode.SelectNodes("//div[contains(@class, 'jffPostClass')]") != null)
            {
                foreach (HtmlNode bookNode in doc.DocumentNode.SelectNodes("//div[contains(@class, 'jffPostClass')]"))
                {
                    DateTime clip_date = new DateTime();
                    string str_clip_title = bookNode.GetAttributeValue("id", "");
                    string str_clip_date = "";
                    string str_clip_description = "";
                    string str_clip_url = "";

                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]") != null) str_clip_date = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]").InnerText.Trim();
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'post-text-content')]") != null) str_clip_description = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'post-text-content')]").InnerText.Trim();
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]") != null) str_clip_url = "https://justfor.fans" + bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]").GetAttributeValue("onclick", "").Replace("location.href='", "").Replace("'", "").Trim();

                    DateTime.TryParse(str_clip_date, out clip_date);

                    Clip _Clip = new Clip();
                    _Clip.Title = str_clip_title;
                    _Clip.Date = clip_date.Date;
                    _Clip.ClipUrl = str_clip_url;
                    _Clip.Description = str_clip_description;
                    clips.Add(_Clip);

                    //下载video
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'videoBlock')]/a") != null)
                    {
                        string str_video_json = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'videoBlock')]/a").GetAttributeValue("onclick", "").Trim();
                        Regex rgx = new Regex(@"(?i)(?<=\{)(.*)(?=\})");
                        string video_json = rgx.Match(str_video_json).Value;
                        JObject jo = (JObject)JsonConvert.DeserializeObject("{" + video_json + "}");
                        if (jo["1080p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["1080p"]);
                            //IDMFile.IDMDownloadJFF(jo["1080p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");

                        }
                        else if (jo["720p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["720p"]);
                            //IDMFile.IDMDownloadJFF(jo["720p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");
                        }
                        else if (jo["540p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["540p"]);
                            //IDMFile.IDMDownloadJFF(jo["540p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");
                        }
                        else
                        {
                            Console.WriteLine("video error");
                        }
                    }
                    //下载photo
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'galleryWrapper')]/div[contains(@class, 'galleryLarge')]") != null)
                    {
                        foreach (HtmlNode photonode in bookNode.SelectNodes(bookNode.XPath + "//div[contains(@class, 'galleryWrapper')]/div[contains(@class, 'galleryLarge')]//img"))
                        {
                            if (!System.IO.Directory.Exists(@"D:\VideoTemp\JFF\" + _index + @"\"))
                            {
                                IDMFile.IDMDownloadJFF(photonode.GetAttributeValue("src", ""), @"D:\VideoTemp\JFF\" + _index + @"\");
                                Thread.Sleep(1000);

                                photoi++;
                                if (photoi > 10)
                                {
                                    MessageBox.Show("10个图片了");
                                    photoi = 0;
                                }

                            }
                        }
                    }
                    _index++;

                }

                doc = web.Load(_ScraperUrl1 + _index + _ScraperUrl2);
                //MessageBox.Show(_index.ToString());
                Console.WriteLine(_index.ToString());

            }


            MessageBoxResult jffphotombr = MessageBox.Show("图片是否下载完毕？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (jffphotombr == MessageBoxResult.OK)
            { 

                for (int aaa = 0; aaa <= _index; aaa++)
                {
                    if (System.IO.Directory.Exists(@"D:\VideoTemp\JFF\" + aaa + @"\"))
                    {
                        if (!System.IO.Directory.Exists(@"D:\VideoTemp\JFF\Photo"))
                        {
                            System.IO.Directory.CreateDirectory(@"D:\VideoTemp\JFF\Photo");
                        }
                        System.IO.Directory.Move(@"D:\VideoTemp\JFF\" + aaa + @"\", @"D:\VideoTemp\JFF\Photo\" + (_index - aaa) + @"\");
                    }
                }
            }

        System.IO.File.WriteAllText(@"D:\VideoTemp\JFF\" + _Series.Id + ".json", download_json.ToString());


        }

        public void ScraperJustForfansClipVideoFile(Series _Series)
        {
            HtmlWeb web = new HtmlWeb();
            String _ScraperUrl1 = "";
            String _ScraperUrl2 = "";
            ArrayList clips = new ArrayList();
            JObject download_json = new JObject();
            int photoi = 0;

            int _index = 0;
            switch (_Series.Id)
            {
                case 293:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=1166582&PosterID=229524&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=df55cdd0a539dca48436e0877941f262";
                    break;

                case 296:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=394&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=b357fddc69a4446e0733952621888252";
                    break;

                case 297:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=444054&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=09a1239cdc5d963a32fa6f4b49b37d99";
                    break;

                case 302:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=726842&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 307:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=786549&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 309:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=1272949&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                case 310:
                    _ScraperUrl1 = "https://justfor.fans/ajax/getPosts.php?UserID=262598&PosterID=533437&Type=One&StartAt=";
                    _ScraperUrl2 = "&Page=Profile&UserHash4=deef72308d2a2a4a861ce3b06f889c28";
                    break;

                default:
                    _ScraperUrl1 = "";
                    _ScraperUrl2 = "";
                    break;
            }

            HtmlDocument doc = web.Load(_ScraperUrl1 + _index + _ScraperUrl2);


            while (doc.DocumentNode.SelectNodes("//div[contains(@class, 'jffPostClass')]") != null)
            {
                foreach (HtmlNode bookNode in doc.DocumentNode.SelectNodes("//div[contains(@class, 'jffPostClass')]"))
                {
                    DateTime clip_date = new DateTime();
                    string str_clip_title = bookNode.GetAttributeValue("id", "");
                    string str_clip_date = "";
                    string str_clip_description = "";
                    string str_clip_url = "";

                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]") != null) str_clip_date = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]").InnerText.Trim();
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'post-text-content')]") != null) str_clip_description = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'post-text-content')]").InnerText.Trim();
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]") != null) str_clip_url = "https://justfor.fans" + bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'mbsc-card-subtitle')]").GetAttributeValue("onclick", "").Replace("location.href='", "").Replace("'", "").Trim();

                    DateTime.TryParse(str_clip_date, out clip_date);

                    Clip _Clip = new Clip();
                    _Clip.Title = str_clip_title;
                    _Clip.Date = clip_date.Date;
                    _Clip.ClipUrl = str_clip_url;
                    _Clip.Description = str_clip_description;
                    clips.Add(_Clip);

                    //下载video
                    if (bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'videoBlock')]/a") != null)
                    {
                        string str_video_json = bookNode.SelectSingleNode(bookNode.XPath + "//div[contains(@class, 'videoBlock')]/a").GetAttributeValue("onclick", "").Trim();
                        Regex rgx = new Regex(@"(?i)(?<=\{)(.*)(?=\})");
                        string video_json = rgx.Match(str_video_json).Value;
                        JObject jo = (JObject)JsonConvert.DeserializeObject("{" + video_json + "}");
                        if (jo["1080p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["1080p"]);
                            //IDMFile.IDMDownloadJFF(jo["1080p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");

                        }
                        else if (jo["720p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["720p"]);
                            //IDMFile.IDMDownloadJFF(jo["720p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");
                        }
                        else if (jo["540p"] != null)
                        {
                            download_json.Add(str_clip_title, jo["540p"]);
                            //IDMFile.IDMDownloadJFF(jo["540p"].ToString(), @"D:\VideoTemp\JFF\" + clip_date.Date.ToString("yyyyMMddhhmmss") + @"\");
                        }
                        else
                        {
                            Console.WriteLine("video error");
                        }
                    }

                    _index++;
                }

                doc = web.Load(_ScraperUrl1 + _index + _ScraperUrl2);
                //MessageBox.Show(_index.ToString());
                Console.WriteLine(_index.ToString());

            }


            System.IO.File.WriteAllText(@"D:\VideoTemp\JFF\" + _Series.Id + ".json", download_json.ToString());


            int i = 0;
            foreach (Clip _Clip in clips)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Number: " + (clips.Count - i).ToString() + " / Title: " + _Clip.Title + " / Date: " + _Clip.Date.ToString() + " / Url: " + _Clip.ClipUrl + " / Desc: " + _Clip.Description);
                Console.WriteLine("-----------------------------------------------------");

                //Clip _OldClip = ClipDao.GetClipDao().getClipBySeriesAndNumber(_Series.Id, clips.Count - i);
                //ClipDao.GetClipDao().UpdateClipTitle(_OldClip.Id, _Clip.Title);


                ClipDao.GetClipDao().CreateClip(207, _Series.Id, clips.Count - i, _Clip.Title, _Clip.Date, _Clip.Description, "ClipNull", "", 0, _Clip.ClipUrl);
                i++;


            }


        }

        public void ScraperJustForfansClipVideo(Series _Series)
        {
            string jsonfile = @"D:\VideoTemp\JFF\" + _Series.Id +  ".json";//JSON文件路径
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);

                    int overnum = 0;
                    ObservableCollection<Clip> _Clips = ClipDao.GetClipDao().GetAllClipsFromJFF(_Series.Id);
                    foreach (Clip _Clip in _Clips)
                    {
                        if (overnum < 10)
                        {
                            Console.WriteLine(_Clip.Number + " / url: " + o[_Clip.Title]);
                            if (o[_Clip.Title] != null)
                            {
                                IDMFile.IDMDownloadJFF(o[_Clip.Title].ToString(), @"D:\VideoTemp\JFF\" + _Clip.Number);
                                overnum++;
                            }
                        }
                    }










                }
            }

        }

        public void ScraperUpdateClip(string webString)
        {
            Thread th = new Thread(delegate () {

                MessageBoxResult dr = MessageBox.Show("是否准备就绪？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (dr == MessageBoxResult.OK)
                {
                    ScraperUpdate(webString);
                    MessageBox.Show("更新完毕");
                }
                else
                {
                    MessageBox.Show("已取消操作");
                }
            });
            th.Start();
            th.IsBackground = true;
        }

        public void ScraperAllUpdateClip()
        {

            Thread th = new Thread(delegate () {

                //StartChrome();
                MessageBoxResult dr = MessageBox.Show("是否准备就绪？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (dr == MessageBoxResult.OK)
                {
                    //ScraperUpdate("Tim Tales");
                    //ScraperUpdate("Men At Play");
                    //ScraperUpdate("Lucas Entertainment - Lucas Entertainment");
                    //ScraperUpdate("Kristen Bjorn - Casting Couch");
                    //ScraperUpdate("Kristen Bjorn - Web Scenes");
                    //ScraperUpdate("Mania Media - Bareback That Hole");
                    //ScraperUpdate("Mania Media - Breed Me Raw");
                    //ScraperUpdate("Masqulin");
                    //ScraperUpdate("Pride Studio - Extra Big Dicks");
                    //ScraperUpdate("Pride Studio - Men Over 30");
                    //ScraperUpdate("Pride Studio - Bear Back");
                    //ScraperUpdate("Pride Studio - Family Creep");
                    //ScraperUpdate("Butch Dixon - Butch Dixon");
                    //ScraperUpdate("Butch Dixon - UK Naked Men");
                    //ScraperUpdate("Raw Fuck Club - Raw Fuck Club");
                    //QuitChrome();


                    for (int i = 20; i > 0; i--)
                    {
                        ScraperUpdate("Older 4 Me - Older 4 Me" + i);
                    }




                    MessageBox.Show("更新完毕");
                }
                else
                {
                    QuitChrome();
                    MessageBox.Show("已取消操作");
                }
            });
            th.Start();
            th.IsBackground = true;

        }

        private void ScraperUpdate(string webString)
        {
            HtmlDocument document;
            HtmlNodeCollection clipNodes;
            HtmlNodeCollection imageNodes;
            ArrayList clips = new ArrayList();
            int resultNum = 1;
            bool isLast = false;
            Clip lastClip;

            if (string.Equals(webString, "Tim Tales - Tim Tales"))
            {
                document = new HtmlWeb().Load("https://www.timtales.com/videos/latest/page-1/");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'video-item video-item-odd') or contains(@class, 'video-item video-item-even')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(498);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/h2").InnerText.Trim().Replace("&amp;", "&").Replace("&#039;", "'");
                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "/div").GetAttributeValue("style", "").Replace("background-image: url('", "").Replace("')", "");
                        string clipUrl = "https://www.timtales.com" + clipNode.SelectSingleNode(clipNode.XPath + "/div/a").GetAttributeValue("href", "").Trim();

                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                        string clipDate = clipDocument.DocumentNode.SelectSingleNode("//p[contains(@class, 'date')]").InnerText.Trim().Split("–".ToCharArray())[0].Trim();
                        string clipDescription = clipDocument.DocumentNode.SelectSingleNode("//p[contains(@class, 'bodytext')]").InnerText.Trim().Replace("&amp;", "&").Replace("&#039;", "'");

                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    }
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 9, 498);
            }
            else if (string.Equals(webString, "Raw Fuck Club - Raw Fuck Club"))
            {
                document = new HtmlWeb().Load("https://www.rawfuckclub.com/rawfuckclub/newest?page=1");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'last-update-item-inner')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(3);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipNum = resultNum.ToString();
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'last-update-title')]/a").InnerText.Trim().Replace("&amp;", "&");
                    string clipImgUrl = "";
                    string clipUrl = "https://www.rawfuckclub.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'last-update-title')]/a").GetAttributeValue("href", "").Trim();
                    string clipDate = "";
                    string clipDescription = "";
                    if (clipTitle.ToLower().Trim().Equals(lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 7, 3);

            }
            else if (string.Equals(webString, "Kristen Bjorn - Casting Couch"))
            {
                document = new HtmlWeb().Load("https://www.kristenbjorn.com/web/model/video/gayporn/CC");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-4 col-sm-6 col-xs-12')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(24);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipNum = resultNum.ToString();
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("title", "").Trim().Replace("&amp;", "&"); ;
                    string clipImgUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a/video").GetAttributeValue("poster", "").Trim();
                    string clipUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("href", "").Trim();
                    string clipDate = "";
                    string clipDescription = "";
                    if ((clipTitle.Contains("Casting Couch") || clipTitle.Contains("CASTING COUCH")) && !clipTitle.Contains("Behind The Scenes"))
                    {
                        if (int.Parse(Regex.Match(clipTitle, @"\d+").ToString()) == lastClip.Number) isLast = true;
                        if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                        resultNum++;
                    }
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 70, 24);
            }
            else if (string.Equals(webString, "Kristen Bjorn - Web Scenes"))
            {
                document = new HtmlWeb().Load("https://www.kristenbjorn.com/web/model/video/gayporn/WS");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-4 col-sm-6 col-xs-12')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(25);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToLower(clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("title", "").Split(":".ToCharArray())[0])).Trim();
                    string clipImgUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a/video").GetAttributeValue("poster", "").Trim();
                    string clipUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("href", "").Trim();
                    string clipDate = "";

                    HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                    string clipDescription = clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'med-text')]").InnerText.Trim();


                    if (clipTitle.ToLower().Contains(lastClip.Title.ToLower())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 70, 25);
            }
            else if (string.Equals(webString, "Kristen Bjorn - Movie Scenes"))
            {
                document = new HtmlWeb().Load("https://www.kristenbjorn.com/web/model/video/gayporn/VD&idg=&oc=0&page=1");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-4 col-sm-6 col-xs-12')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(25);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToLower(clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("title", "").Split(":".ToCharArray())[0])).Trim();
                    //string clipImgUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim();
                    //Console.WriteLine(clipImgUrl);
                    string clipUrl = "https://www.kristenbjorn.com" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'videoSlate scene-item')]/a").GetAttributeValue("href", "").Trim();
                    string clipDate = "";

                    //HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                    //string clipDescription = clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'med-text')]").InnerText.Trim();


                    if (clipTitle.ToLower().Contains(lastClip.Title.ToLower())) isLast = true;
                    if (!isLast) clips.Add(new string[] { "0", clipTitle, "", clipUrl, clipDate, "" });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                //ScraperClips(clips, 70, 25);
            }
            else if (string.Equals(webString, "Mania Media - Bareback That Hole"))
            {
                document = new HtmlWeb().Load("https://barebackthathole.com/tour/categories/Episodes_1_d.html?nats=MC4yLjEuMS4wLjAuMC4wLjA");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'item')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(553);

                Console.WriteLine(clipNodes.Count);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'update_photos')]").InnerText.Trim();
                    Console.WriteLine("#" + clipTitle + "#");


                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = "";
                        string clipUrl = "https://barebackthathole.com/tour/updates/" + clipTitle.Replace(" ", "-") +  ".html?nats=MC4yLjEuMS4wLjAuMC4wLjA";
                        Console.WriteLine(clipUrl);

                        string clipDescription = "";
                        string clipDate = "";

                        //HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                        //Console.WriteLine(clipDocument.Text);
                        //clipDescription += clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'p-5')]/p").InnerText.Trim();
                        //clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//video").GetAttributeValue("data-poster", "").Trim();
                        //clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//img[contains(@class, 'img-responsive')]").GetAttributeValue("src", "").Trim();
                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });

                    }
                    resultNum++;
                }


                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                //ScraperClips(clips, 124, 553);
            }
            else if (string.Equals(webString, "Mania Media - Breed Me Raw"))
            {
                FromUrlToHtml("https://www.breedmeraw.com/tour/?nats=MC4yLjEuMS4wLjAuMC4wLjA", "D:/VideoTemp/html/" + webString + ".html");
                document = new HtmlWeb().Load("D:/VideoTemp/html/" + webString + ".html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'item')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(43);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    if (clipNode.ChildNodes.Count == 5)
                    {
                        string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/div/b").InnerHtml.Trim().Replace("&amp;", "&"); ;
                        string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "/a/img").GetAttributeValue("data-src", "").Trim();
                        string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();
                        string clipDate = "";
                        string clipDescription = "";
                        if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                        if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                        resultNum++;
                    }
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 124, 43);
            }
            else if (string.Equals(webString, "Masqulin"))
            {
                FromUrlToHtml("https://www.masqulin.com/categories/movies_1_d.html", "D:/VideoTemp/html/" + webString + ".html");
                document = new HtmlWeb().Load("D:/VideoTemp/html/" + webString + ".html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-xs-12 col-md-6 col-lg-4 col-xl-4 sceneTour modelTour')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithCompanyId(89);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//h4").InnerHtml.Trim().Replace("&amp;", "&"); ;
                    string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "/a/img").GetAttributeValue("data-src", "").Trim();
                    string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();
                    string clipDate = "";
                    string clipDescription = "";
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 89, 0);
            }
            else if (string.Equals(webString, "Pride Studio - Extra Big Dicks"))
            {
                //"https://www.pridestudios.com/en/videos/sites/extrabigdicks"
                document = new HtmlWeb().Load("D:/VideoTemp/html/1.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'ListingGrid-ListingGridItem')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(7);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").InnerText.Trim().Replace("&amp;", "&");
                    string clipUrl = "https://www.pridestudios.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").GetAttributeValue("href", "").Trim();


                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'SceneDetail-DatePublished-Text')]").InnerText.Trim();

                    //"https://transform.gammacdn.com/movies/24261/24261_01/previews/5/49/top_1_1200x650/24261_01_01.jpg?width=1300&format=webp"
                    string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim().Replace("width=350&amp;height=196&amp;format=webp", "width=1300&format=jpg"); ;
                    string clipDescription = "//**  ";


                    HtmlNodeCollection actionNodes = clipNode.SelectNodes(clipNode.XPath + "//div[contains(@class, 'SceneThumb-SceneInfo-Actors-WordList')]/a");
                    int actionnum = 1;

                    foreach (HtmlNode actionNode in actionNodes)
                    {
                        clipDescription += actionNode.InnerText;
                        if (actionnum != actionNodes.Count) clipDescription += ", ";
                        actionnum++;
                    }

                    clipDescription += "  **//";

                    //if (clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]") != null)
                    //clipDescription = "//**  " + clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]").InnerText.Trim() + "  **//";
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1111, 7);
            }
            else if (string.Equals(webString, "Pride Studio - Men Over 30"))
            {
                //"https://www.pridestudios.com/en/videos/sites/menover30"
                document = new HtmlWeb().Load("D:/VideoTemp/html/1.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'ListingGrid-ListingGridItem')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(9);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").InnerText.Trim().Replace("&amp;", "&");
                    string clipUrl = "https://www.pridestudios.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").GetAttributeValue("href", "").Trim();


                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'SceneDetail-DatePublished-Text')]").InnerText.Trim();

                    //"https://transform.gammacdn.com/movies/24261/24261_01/previews/5/49/top_1_1200x650/24261_01_01.jpg?width=1300&format=webp"
                    string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim().Replace("width=350&amp;height=196&amp;format=webp", "width=1300&format=jpg"); ;
                    string clipDescription = "//**  ";


                    HtmlNodeCollection actionNodes = clipNode.SelectNodes(clipNode.XPath + "//div[contains(@class, 'SceneThumb-SceneInfo-Actors-WordList')]/a");
                    int actionnum = 1;

                    foreach (HtmlNode actionNode in actionNodes)
                    {
                        clipDescription += actionNode.InnerText;
                        if (actionnum != actionNodes.Count) clipDescription += ", ";
                        actionnum++;
                    }

                    clipDescription += "  **//";

                    //if (clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]") != null)
                    //clipDescription = "//**  " + clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]").InnerText.Trim() + "  **//";
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1111, 9);
            }
            else if (string.Equals(webString, "Pride Studio - Bear Back"))
            {
                //"https://www.pridestudios.com/en/videos/sites/menover30"
                document = new HtmlWeb().Load("D:/VideoTemp/html/1.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'ListingGrid-ListingGridItem')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(6);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").InnerText.Trim().Replace("&amp;", "&");
                    string clipUrl = "https://www.pridestudios.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").GetAttributeValue("href", "").Trim();


                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'SceneDetail-DatePublished-Text')]").InnerText.Trim();

                    //"https://transform.gammacdn.com/movies/24261/24261_01/previews/5/49/top_1_1200x650/24261_01_01.jpg?width=1300&format=webp"
                    string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim().Replace("width=350&amp;height=196&amp;format=webp", "width=1300&format=jpg"); ;
                    string clipDescription = "//**  ";


                    HtmlNodeCollection actionNodes = clipNode.SelectNodes(clipNode.XPath + "//div[contains(@class, 'SceneThumb-SceneInfo-Actors-WordList')]/a");
                    int actionnum = 1;

                    foreach (HtmlNode actionNode in actionNodes)
                    {
                        clipDescription += actionNode.InnerText;
                        if (actionnum != actionNodes.Count) clipDescription += ", ";
                        actionnum++;
                    }

                    clipDescription += "  **//";

                    //if (clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]") != null)
                    //clipDescription = "//**  " + clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]").InnerText.Trim() + "  **//";
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1111, 6);
            }
            else if (string.Equals(webString, "Pride Studio - Family Creep"))
            {
                //"https://www.pridestudios.com/en/videos/sites/familycreep"
                document = new HtmlWeb().Load("D:/VideoTemp/html/1.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'ListingGrid-ListingGridItem')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(143);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").InnerText.Trim().Replace("&amp;", "&");
                    string clipUrl = "https://www.pridestudios.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").GetAttributeValue("href", "").Trim();


                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'SceneDetail-DatePublished-Text')]").InnerText.Trim();

                    //"https://transform.gammacdn.com/movies/24261/24261_01/previews/5/49/top_1_1200x650/24261_01_01.jpg?width=1300&format=webp"
                    string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim().Replace("width=350&amp;height=196&amp;format=webp", "width=1300&format=jpg"); ;
                    string clipDescription = "//**  ";


                    HtmlNodeCollection actionNodes = clipNode.SelectNodes(clipNode.XPath + "//div[contains(@class, 'SceneThumb-SceneInfo-Actors-WordList')]/a");
                    int actionnum = 1;

                    foreach (HtmlNode actionNode in actionNodes)
                    {
                        clipDescription += actionNode.InnerText;
                        if (actionnum != actionNodes.Count) clipDescription += ", ";
                        actionnum++;
                    }

                    clipDescription += "  **//";

                    //if (clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]") != null)
                    //clipDescription = "//**  " + clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]").InnerText.Trim() + "  **//";
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1111, 143);
            }
            else if (string.Equals(webString, "Pride Studio - Dylan Lucas"))
            {
                //"https://www.pridestudios.com/en/videos/sites/dylanlucas/page/3"
                document = new HtmlWeb().Load("D:/VideoTemp/html/1.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'ListingGrid-ListingGridItem')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(568);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").InnerText.Trim().Replace("&amp;", "&");
                    string clipUrl = "https://www.pridestudios.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").GetAttributeValue("href", "").Trim();


                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'SceneDetail-DatePublished-Text')]").InnerText.Trim();

                    //"https://transform.gammacdn.com/movies/24261/24261_01/previews/5/49/top_1_1200x650/24261_01_01.jpg?width=1300&format=webp"
                    string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim().Replace("width=350&amp;height=196&amp;format=webp", "width=1300&format=jpg"); ;
                    string clipDescription = "//**  ";


                    HtmlNodeCollection actionNodes = clipNode.SelectNodes(clipNode.XPath + "//div[contains(@class, 'SceneThumb-SceneInfo-Actors-WordList')]/a");
                    int actionnum = 1;

                    foreach (HtmlNode actionNode in actionNodes)
                    {
                        clipDescription += actionNode.InnerText;
                        if (actionnum != actionNodes.Count) clipDescription += ", ";
                        actionnum++;
                    }

                    clipDescription += "  **//";

                    //if (clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]") != null)
                    //clipDescription = "//**  " + clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]").InnerText.Trim() + "  **//";
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1111, 568);
            }
            else if (string.Equals(webString, "Pride Studio - Pride Studio"))
            {
                //"https://www.pridestudios.com/en/videos/sites/pridestudios/page/3"
                document = new HtmlWeb().Load("D:/VideoTemp/html/1.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'ListingGrid-ListingGridItem')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(8);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").InnerText.Trim().Replace("&amp;", "&");
                    string clipUrl = "https://www.pridestudios.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").GetAttributeValue("href", "").Trim();


                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'SceneDetail-DatePublished-Text')]").InnerText.Trim();

                    //"https://transform.gammacdn.com/movies/24261/24261_01/previews/5/49/top_1_1200x650/24261_01_01.jpg?width=1300&format=webp"
                    string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim().Replace("width=350&amp;height=196&amp;format=webp", "width=1300&format=jpg"); ;
                    string clipDescription = "//**  ";


                    HtmlNodeCollection actionNodes = clipNode.SelectNodes(clipNode.XPath + "//div[contains(@class, 'SceneThumb-SceneInfo-Actors-WordList')]/a");
                    int actionnum = 1;
                    if (actionNodes != null)
                    {
                        foreach (HtmlNode actionNode in actionNodes)
                        {
                            clipDescription += actionNode.InnerText;
                            if (actionnum != actionNodes.Count) clipDescription += ", ";
                            actionnum++;
                        }
                    }

                    clipDescription += "  **//";

                    //if (clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]") != null)
                    //clipDescription = "//**  " + clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]").InnerText.Trim() + "  **//";
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1111, 8);
            }
            else if (string.Equals(webString, "Pride Studio - Cock Virgins"))
            {
                //"https://www.pridestudios.com/en/videos/sites/cockvirgins"
                document = new HtmlWeb().Load("D:/VideoTemp/html/1.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'ListingGrid-ListingGridItem')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(569);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").InnerText.Trim().Replace("&amp;", "&");
                    string clipUrl = "https://www.pridestudios.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'SceneThumb-SceneInfo-SceneTitle-Link')]").GetAttributeValue("href", "").Trim();


                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'SceneDetail-DatePublished-Text')]").InnerText.Trim();

                    //https://transform.gammacdn.com/movies/24207/24207_01/previews/5/65/top_1_1200x650/24207_01_01.jpg?width=350&height=196&format=webp
                    //https://transform.gammacdn.com/movies/24207/24207_01/previews/5/65/top_1_1200x650/24207_01_01.jpg?width=1300&format=jpg
                    //"https://transform.gammacdn.com/movies/24261/24261_01/previews/5/49/top_1_1200x650/24261_01_01.jpg?width=1300&format=webp"
                    string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim().Replace("width=350&amp;height=196&amp;format=webp", "width=1300&format=jpg"); ;
                    string clipDescription = "//**  ";


                    HtmlNodeCollection actionNodes = clipNode.SelectNodes(clipNode.XPath + "//div[contains(@class, 'SceneThumb-SceneInfo-Actors-WordList')]/a");
                    int actionnum = 1;
                    if (actionNodes != null)
                    {
                        foreach (HtmlNode actionNode in actionNodes)
                        {
                            clipDescription += actionNode.InnerText;
                            if (actionnum != actionNodes.Count) clipDescription += ", ";
                            actionnum++;
                        }
                    }

                    clipDescription += "  **//";

                    //if (clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]") != null)
                    //clipDescription = "//**  " + clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'sceneActors')]").InnerText.Trim() + "  **//";
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1111, 569);
            }
            else if (string.Equals(webString, "Butch Dixon - Butch Dixon"))
            {
                document = new HtmlWeb().Load("https://www.butchdixon.com/tour/show.php?a=744_1&uvar=MC4yLjQwLjEyNy4wLjAuMC4wLjA");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'itemv')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(45);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/div/div/a").InnerText.Trim().Replace("&amp;", "&"); ;
                    string clipImgUrl = "https://www.butchdixon.com/tour/" + clipNode.SelectSingleNode(clipNode.XPath + "/a/img").GetAttributeValue("src", "").Trim();
                    string clipUrl = "https://www.butchdixon.com/tour/" + clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();
                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'nm-name')]/p").InnerText.Trim();
                    string clipDescription = "";
                    DateTime dt = DateTime.Parse(clipDate);
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 2, 45);
            }
            else if (string.Equals(webString, "Butch Dixon - UK Naked Men"))
            {
                FromUrlToHtml("https://www.uknakedmen.com/tour/show.php?a=669_1&uvar=MC4yLjQwLjEyNy4wLjAuMC4wLjA", "D:/VideoTemp/html/" + webString + ".html");
                document = new HtmlWeb().Load("D:/VideoTemp/html/" + webString + ".html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'itemv')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(46);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/div/div/a").InnerText.Trim().Replace("&amp;", "&"); ;
                    string clipImgUrl = "https://www.uknakedmen.com/tour/" + clipNode.SelectSingleNode(clipNode.XPath + "/a/img").GetAttributeValue("src", "").Trim();
                    string clipUrl = "https://www.uknakedmen.com/tour/" + clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();
                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'nm-name')]/p").InnerText.Trim();
                    string clipDescription = "";
                    DateTime dt = DateTime.Parse(clipDate);
                    if (string.Equals(clipTitle.ToLower().Trim(), lastClip.Title.ToLower().Trim())) isLast = true;
                    if (!isLast) clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 2, 46);
            }
            else if (string.Equals(webString, "Men At Play"))
            {
                document = new HtmlWeb().Load("https://www.menatplay.com/categories/movies_1_d.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'updateDetails')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithCompanyId(12);


                for (int n = 0; n < clipNodes.Count; n++)
                {
                    HtmlNode clipNode = clipNodes[n];
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//a/h4").InnerText.Trim().Replace("&amp;", "&"); ;
                    string clipImgUrl = "";
                    string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();
                    string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'availdate')]").InnerText.Trim();
                    string clipDescription = "####" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'details')]").InnerText.Trim() + "####";
                    DateTime dt = DateTime.Parse(clipDate);
                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                        clipDescription += "\n\n" + clipDocument.DocumentNode.SelectSingleNode("//p[contains(@class, 'update_description')]").InnerText.Trim();
                        clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//video-js").GetAttributeValue("poster", "").Trim();
                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                    }
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 12, 0);
            }
            else if (string.Equals(webString, "M2MClub"))
            {
                document = new HtmlWeb().Load("http://www.m2mclub.com/categories/movies_1_d.html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'updateItem')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithCompanyId(273);


                for (int n = 0; n < clipNodes.Count; n++)
                {
                    HtmlNode clipNode = clipNodes[n];
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div/h4").InnerText.Trim().Replace("&amp;", "&"); ;
                    string clipImgUrl = "";
                    string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();
                    string clipDate = "01/01/1980";
                    string clipDescription = "";
                    if (clipNode.SelectNodes(clipNode.XPath + "//span").Count == 1)
                        clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[1]").InnerText.Trim();
                    if (clipNode.SelectNodes(clipNode.XPath + "//span").Count == 2)
                    {
                        clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[2]").InnerText.Trim();
                        clipDescription = "####\n" + clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'tour_update_models')]").InnerText.Trim() + "\n####\n";
                    }
                    DateTime dt = DateTime.Parse(clipDate);
                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                        clipDescription += "\n\n" + clipDocument.DocumentNode.SelectSingleNode("//span[contains(@class, 'latest_update_description')]").InnerText.Trim();
                        clipImgUrl = "https://www.m2mclub.com/" + clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'update_image')]/a[2]/img").GetAttributeValue("src", "").Trim();
                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                    }
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 273, 0);
            }
            else if (string.Equals(webString, "Hot Older Male"))
            {
                FromUrlToHtml("https://www.hotoldermale.com/scenes?Page=1", "D:/VideoTemp/html/" + webString + ".html");
                document = new HtmlWeb().Load("D:/VideoTemp/html/" + webString + ".html");
                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'lstEachScene')]");
                lastClip = ClipDao.GetClipDao().GetLastClipWithCompanyId(10);
                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'lstSceneTitle')]").InnerText.Trim().Replace("&amp;", "&"); ;
                    string clipImgUrl = "";
                    string clipUrl = "https://www.hotoldermale.com" + clipNode.SelectSingleNode(clipNode.XPath + "/div/img").GetAttributeValue("data-href", "").Trim();
                    string clipNum = Regex.Match(clipUrl, @"\d+").ToString();
                    string clipDate = "1980-1-1";
                    string clipDescription = "";
                    DateTime dt = DateTime.Parse(clipDate);
                    if (int.Parse(clipNum) == lastClip.Number) isLast = true;
                    if (!isLast) clips.Add(new string[] { clipNum, clipTitle, clipImgUrl, clipUrl, "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                    resultNum++;
                }

                ConsoleWrite(webString, clips);
                ScraperClips(clips, 10, 0);
            }
            else if (webString.Contains("Older 4 Me - Older 4 Me"))
            {
                document = new HtmlWeb().Load("https://www.older4me.com/scenes?Page=" + webString.Replace("Older 4 Me - Older 4 Me", ""));

                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'eachScene')]");

                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(559);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'sceneTitle')]").InnerText.Trim();


                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = "" + clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim();
                        string clipUrl = "";

                        string clipDescription = "[" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'sceneDescription')]").InnerText.Trim() + "]\n\n";
                        string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'sceneDetails')]").InnerText.Trim().Replace("Details: ", "").Split(new string[] { "&nbsp;&nbsp;" }, StringSplitOptions.None)[0];

                        HtmlNodeCollection _StarNodes = clipNode.SelectNodes(clipNode.XPath + "//div[contains(@class, 'scenePerformers')]//span[contains(@class, 'perfName')]");
                        if(_StarNodes != null) { 

                            foreach (HtmlNode _StarNode in _StarNodes)
                            {
                                clipDescription += _StarNode.InnerText;
                                clipDescription += ", ";
                            }
                        }

                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                    }
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1001, 559);
            }
            else if (string.Equals(webString, "Older 4 Me - My First Daddy"))
            {
                document = new HtmlWeb().Load(@"D:\VideoTemp\html\1.html");

                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'row equal')]/div");

                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(416);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'scene_title')]/div[1]").InnerText.Trim();


                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = "";
                        string clipUrl = "https://www.myfirstdaddy.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();

                        string clipDescription = "[" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'scene_title')]/div[2]").InnerText.Trim() + "]\n\n";
                        string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'scene_title')]/div[3]/span[1]").InnerText.Trim();
                        clipDate = clipDate.Replace("Jan", "1,").Replace("Feb", "2,").Replace("Mar", "3,").Replace("Apr", "4,").Replace("May", "5,").Replace("Jun", "6,").Replace("Jul", "7,").Replace("Aug", "8,").Replace("Sep", "9,").Replace("Oct", "10,").Replace("Nov", "11,").Replace("Dec", "12,");
                        DateTime dt = DateTime.Parse(clipDate);

                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                        //Console.WriteLine(clipDocument.Text);
                        clipDescription += clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'p-5')]/p").InnerText.Trim();
                        //clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//video").GetAttributeValue("data-poster", "").Trim();
                        clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//img[contains(@class, 'img-responsive')]").GetAttributeValue("src", "").Trim();
                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                    }
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                //ScraperClips(clips, 1, 416);
            }
            else if (string.Equals(webString, "Older 4 Me - Top Latin Daddies"))
            {
                document = new HtmlWeb().Load("https://www.toplatindaddies.com/scenes?Page=1");

                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'eachScene')]");

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(418);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'sceneTitle')]").InnerText.Trim();

                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'bgScene')]/img").GetAttributeValue("src", "").Trim();

                        string clipDescription = "[" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'scenePerformers')]").InnerText.Trim() + "]\n\n";
                        clipDescription += clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'sceneDescription')]").InnerText.Trim();

                        string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'sceneDetails')]").InnerText.Split(new string[] { "&nbsp;&nbsp;" }, StringSplitOptions.None)[0].Trim();
                        DateTime dt = DateTime.Parse(clipDate);


                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, "", "" + dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });
                    }
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1, 418);
            }
            else if (string.Equals(webString, "Older 4 Me - Blacks on Daddies"))
            {
                document = new HtmlWeb().Load(@"D:\VideoTemp\html\1.html");

                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'row equal')]/div");

                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(458);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'scene_title')]/div[1]").InnerText.Trim();


                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = "";
                        string clipUrl = "https://www.blacksondaddies.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();

                        string clipDescription = "[" + clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'scene_title')]/div[2]").InnerText.Trim() + "]\n\n";
                        string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'scene_title')]/div[3]/span[1]").InnerText.Trim();
                        clipDate = clipDate.Replace("Jan", "1,").Replace("Feb", "2,").Replace("Mar", "3,").Replace("Apr", "4,").Replace("May", "5,").Replace("Jun", "6,").Replace("Jul", "7,").Replace("Aug", "8,").Replace("Sep", "9,").Replace("Oct", "10,").Replace("Nov", "11,").Replace("Dec", "12,");
                        DateTime dt = DateTime.Parse(clipDate);

                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                        //Console.WriteLine(clipDocument.Text);
                        clipDescription += clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'p-5')]/p").InnerText.Trim();
                        //clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//video").GetAttributeValue("data-poster", "").Trim();
                        clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//img[contains(@class, 'img-responsive')]").GetAttributeValue("src", "").Trim();
                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });

                    }
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 1, 458);
            }
            else if (string.Equals(webString, "Lucas Entertainment - Lucas Entertainment"))
            {
                document = new HtmlWeb().Load("https://www.lucasentertainment.com/tour/scenes/page/1");



                HtmlNode clipListNodes = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'scenes-list')]");
                clipNodes = clipListNodes.SelectNodes(clipListNodes.XPath + "/div[contains(@class, 'col-md-4')]");

                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(415);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'box-over')]/h5").InnerHtml.Trim();
                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//a[contains(@class, 'scene-box')]//img").GetAttributeValue("data-original", "").Trim();
                        string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();

                        string clipDate = "";
                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                        string clipDescription = clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'large-text')]").InnerText.Trim();
                        DateTime dt = new DateTime();

                        foreach (string testStr in clipDescription.Split("\n".ToCharArray()))
                        {
                            if (testStr.Contains("Release Date"))
                            {
                                clipDate = testStr.Split(new string[] { "Release Date: ", "From: ", "Performers: " }, StringSplitOptions.RemoveEmptyEntries)[0].Trim().Replace("1st", "1").Replace("2nd", "2").Replace("3rd", "3").Replace("th ", " ");
                                dt = DateTime.Parse(clipDate);
                            }
                        }

                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, dt.Year + "-" + dt.Month + "-" + dt.Day, clipDescription });

                    }

                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 80, 415);
            }
            else if (string.Equals(webString, "Cutlers Den"))
            {
                document = new HtmlWeb().Load("https://cutlersden.com/categories/movies_1_d.html");


                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'items items-2-per-row')]/div[contains(@class, 'item')]");


                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithCompanyId(288);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'item-info')]/h3").InnerText.Trim();
                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = "https://cutlersden.com/" + clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim();
                        string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();

                        string clipDate = "";
                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);

                        clipDate = clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'content-date')]").InnerText.Split("|".ToCharArray())[0].Trim();

                        string clipDescription = "";
                        
                        
                        if (clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'content-details')]/p") != null)
                            clipDescription = clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'content-details')]/p").InnerText.Trim();


                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });

                    }

                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 288, 0);
            }
            else if (string.Equals(webString, "Stud Fist - Stud Fist"))
            {
                document = new HtmlWeb().Load("https://www.mansurfer.com/channel/101/stud-fist/1/");


                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'video_link')]");


                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(554);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/div[1]/a").GetAttributeValue("title", "").Trim().Replace("&amp;", "&");
                    Console.WriteLine(clipTitle);
                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {

                        string clipUrl = "https://www.mansurfer.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();

                        string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "/div[2]").InnerHtml.Trim();
                        
                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);

                        string clipDescription = clipDocument.DocumentNode.SelectSingleNode("//meta[contains(@name, 'description')]").GetAttributeValue("content", "");
                        string clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//link[contains(@rel, 'image_src')]").GetAttributeValue("href", "").Replace("/thumbs/", "/temp/");
                        clipDescription = clipDescription + "\n\n" + clipImgUrl;


                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });

                    }

                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 164, 554);
            }
            else if (string.Equals(webString, "Treasure Island Media - Tim Fuck"))
            {
                document = new HtmlWeb().Load("https://timfuck.treasureislandmedia.com/scenes?page=0");


                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'edit-in-system')]");


                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(483);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'thumbnail-title-a')]").InnerText.Trim();
                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Trim();
                        string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'thumbnail-title-a')]//a").GetAttributeValue("href", "").Trim();

                        string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "//p[contains(@class, 'scene-thumb-schedule')]").InnerText.Trim();
                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);

                        string clipDescription = "";
                        if (clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'timglobal-well-description')]") != null)
                            clipDescription = clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'timglobal-well-description')]").InnerText;


                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });

                    }

                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 82, 483);
            }
            else if (webString.Contains("Richard XXX - Richard XXX"))
            {
                Console.WriteLine("https://www.richard.xxx/new-porn-videos?page=" + webString.Replace("Richard XXX - Richard XXX", "") + "#pageTop");
                document = new HtmlWeb().Load("https://www.richard.xxx/new-porn-videos?page=" + webString.Replace("Richard XXX - Richard XXX", "") + "#pageTop");
                



                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'col-md-4')]");

                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(460);

                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'scene-actors')]").InnerText.Trim().Replace("  ", "");
                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = "";
                        
                        string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();

                        string clipDate = "";

                        string clipDescription = "";
                        clipDescription += "Date: " + clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'scene-date')]").InnerText.Trim() + "\n\n";
                        clipDescription += "Title: " + clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'scene-title')]").InnerText.Trim() + "\n\n";

                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);

                        clipDescription += clipDocument.DocumentNode.SelectSingleNode("//p[contains(@class, 'scene-copy')]").InnerText.Trim();
                        clipImgUrl = "https:" + clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'overlays')]/img").GetAttributeValue("src", "").Trim();



                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, "", clipDescription });

                    }

                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 149, 460);
            }
            else if (webString.Contains("Carnal - Twink Top"))
            {

                document = new HtmlWeb().Load("https://twinktop.com/videos?page=" + webString.Replace("Carnal - Twink Top", "") + "&l=b");



                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'singleVid')]");

                Console.WriteLine(clipNodes.Count);

                lastClip = ClipDao.GetClipDao().GetLastClipWithSeriesId(417);

                foreach (HtmlNode clipNode in clipNodes)
                {
                    string clipTitle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'dvdTitleScene')]").InnerText.Trim()) + " - " + clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'chapterNumber')]").InnerText.Trim() + " - " + clipNode.SelectSingleNode(clipNode.XPath + "//span[contains(@class, 'sceneTitle')]").InnerText.Trim();

                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'bigLatest')]/img").GetAttributeValue("data-src", "").Trim();
                        string clipUrl = clipNode.SelectSingleNode(clipNode.XPath + "//div[contains(@class, 'sceneTitleModel')]/h3/a").GetAttributeValue("href", "").Trim();

                        string clipDate = "";
                        HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);

                        string clipDescription = clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'model-vids')]").InnerText.Trim() + "\n\n" + clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'full-txt')]").InnerText.Trim();

                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });

                    }

                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 278, 417);
            }
            else if (string.Equals(webString, "Disruptive Films"))
            {
                document = new HtmlWeb().Load(@"D:\VideoTemp\html\1.html");


                //https://www.disruptivefilms.com/en/videos

                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'ListingGrid-ListingGridItem')]/div");

                lastClip = ClipDao.GetClipDao().GetLastClipWithCompanyId(210);

                int i = 0;

                foreach (HtmlNode clipNode in clipNodes)
                {
                    if (resultNum < 9)
                    {
                        string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/div[1]/div[2]/div[1]/div[1]/div[1]").InnerText.Trim();

                        if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                        if (!isLast)
                        {
                            string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Replace("?width=500&amp;height=281&amp;format=webp", "").Replace("?width=350&amp;height=196&amp;format=webp", "");
                            string clipUrl = "https://www.disruptivefilms.com" + clipNode.SelectSingleNode(clipNode.XPath + "//a").GetAttributeValue("href", "").Trim();

                            string clipDescription = "";
                            foreach (HtmlNode actionNode in clipNode.SelectNodes(clipNode.XPath + "/div[1]/div[2]/div[1]/div[1]/div[2]/a"))
                            {
                                clipDescription += actionNode.InnerText.Trim();
                                clipDescription += " ,";
                            }
                            clipDescription += "\n\n";

                            string clipDate = clipNode.SelectSingleNode(clipNode.XPath + "/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/div[2]/span[1]").InnerText.Trim();

                            //HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                            //Console.WriteLine(clipDocument.Text);
                            //clipDescription += clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'p-5')]/p").InnerText.Trim();
                            //clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//video").GetAttributeValue("data-poster", "").Trim();
                            //clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//img[contains(@class, 'img-responsive')]").GetAttributeValue("src", "").Trim();
                            clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });
                        }
                        resultNum++;
                    }




                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 210, 0);
            }
            else if (string.Equals(webString, "Eric Videos"))
            {
                document = new HtmlWeb().Load(@"D:\VideoTemp\html\1.html");


                //https://www.ericvideos.com/EN/vod/1/page1

                clipNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'panel-vod-item-list')]");

                lastClip = ClipDao.GetClipDao().GetLastClipWithCompanyId(282);

                Console.WriteLine(clipNodes.Count);
                foreach (HtmlNode clipNode in clipNodes)
                {

                    string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("title", "").Trim();

                    if (string.Equals(clipTitle, lastClip.Title)) isLast = true;
                    if (!isLast)
                    {
                        string clipImgUrl = "https://www.ericvideos.com" + clipNode.SelectSingleNode(clipNode.XPath + "//img").GetAttributeValue("src", "").Replace("-cache", "").Replace("/380x272", "").Trim();
                        string clipUrl = "https://www.ericvideos.com" + clipNode.SelectSingleNode(clipNode.XPath + "/a").GetAttributeValue("href", "").Trim();

                        string clipDescription = "";

                        string clipDate = "1980-1-1";

                        //HtmlDocument clipDocument = new HtmlWeb().Load(clipUrl);
                        //Console.WriteLine(clipDocument.Text);
                        //clipDescription += clipDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'p-5')]/p").InnerText.Trim();
                        //clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//video").GetAttributeValue("data-poster", "").Trim();
                        //clipImgUrl = clipDocument.DocumentNode.SelectSingleNode("//img[contains(@class, 'img-responsive')]").GetAttributeValue("src", "").Trim();
                        clips.Add(new string[] { resultNum.ToString(), clipTitle, clipImgUrl, clipUrl, clipDate, clipDescription });

                    }
                    resultNum++;
                }
                ChangeClipsNum(lastClip.Number, clips);
                ConsoleWrite(webString, clips);
                ScraperClips(clips, 282, 0);
            }
            else if (string.Equals(webString, "Test"))
            {
                Thread th = new Thread(delegate ()
                {
                    HtmlDocument _Document = new HtmlWeb().Load("https://www.timtales.com/videos/list/1");
                    foreach (HtmlNode clipNode in _Document.DocumentNode.SelectNodes("//div[contains(@class, 'video-item video-item-odd') or contains(@class, 'video-item video-item-even')]"))
                    {
                        string clipTitle = clipNode.SelectSingleNode(clipNode.XPath + "/h2").InnerText.Trim().Replace("&amp;", "&");
                        string clipImgUrl = clipNode.SelectSingleNode(clipNode.XPath + "/div").GetAttributeValue("style", "").Replace("background-image: url('", "").Replace("')", "");
                        string clipUrl = "https://www.timtales.com" + clipNode.SelectSingleNode(clipNode.XPath + "/div/a").GetAttributeValue("href", "").Trim();
                        string clipDate = "";
                        string clipDescription = "";
                        Console.WriteLine("title: " + clipTitle);
                    }

                });
                th.Start();
                th.IsBackground = true;
            }
            else
            {
                MessageBox.Show("暂时无法刮削");
            }
        }

        private void FromUrlToHtml(string webUrl, string htmlUrl)
        {
            driver.Url = webUrl;
            string source = driver.PageSource;
            StreamWriter streamwriter = new StreamWriter(new FileStream(htmlUrl, FileMode.Create));
            streamwriter.Write(source);
            streamwriter.Close();
            Console.WriteLine("html download success");
        }

        private string FromUrlToImage(string webUrl, string imageUrl)
        {
            try
            {
                Console.WriteLine("开始下载图片：" + webUrl);
                HttpWebRequest imgwebrequest = WebRequest.Create(ProxyFromWebUrl(webUrl)[0]) as HttpWebRequest;
                imgwebrequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
                imgwebrequest.Method = "GET";


                if (!string.Equals(ProxyFromWebUrl(webUrl)[1], ""))
                    imgwebrequest.Host = ProxyFromWebUrl(webUrl)[1];
                if (!new FileInfo(imageUrl).Exists)
                    Image.FromStream(imgwebrequest.GetResponse().GetResponseStream()).Save(imageUrl);
                return ImageFileService.SaveBitmapImage(new BitmapImage(new Uri(imageUrl, UriKind.RelativeOrAbsolute)));
                Console.WriteLine("图片下载成功：" + webUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine("图片下载失败：" + webUrl);
                return "ClipNull";
            }
        }

        private void FromUrlToFile(string webUrl, string fileUrl)
        {
            try
            {
                Console.WriteLine("2222开始读取m3u8：" + webUrl);
                HttpWebRequest filewebrequest = WebRequest.Create(webUrl) as HttpWebRequest;


                HttpWebResponse res = (HttpWebResponse)filewebrequest.GetResponse();

                Stream responseStream = null;
                string m3u8 = "";


                if ("gzip".Equals(res.ContentEncoding))
                {
                    responseStream = new System.IO.Compression.GZipStream(res.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                    Console.WriteLine("Gzip");
                }
                else if ("deflate".Equals(res.ContentEncoding))
                {
                    responseStream = new System.IO.Compression.DeflateStream(res.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                    Console.WriteLine("Deflate");
                }
                else
                {
                    responseStream = res.GetResponseStream();
                }


                if (responseStream != null)
                {
                    StreamReader streamReader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    m3u8 = streamReader.ReadToEnd();
                }

                string[] lines = m3u8.Split("\n".ToCharArray());


                string urlhead = webUrl.Replace(webUrl.Split("/".ToCharArray())[webUrl.Split("/".ToCharArray()).Length - 1], "");
                


                Console.WriteLine("URLHEAD:" + urlhead);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (!lines[i].Contains("#"))
                    {
                        if (!string.Equals(lines[i], "") && !lines[i].Contains("https"))
                        {
                            if (lines[i][0] != '/')
                            {
                                lines[i] = webUrl.Replace(webUrl.Split("/".ToCharArray())[webUrl.Split("/".ToCharArray()).Length - 1], "") + lines[i];
                            }
                            else
                            {
                                lines[i] = urlhead + lines[i];
                            }
                            
                        }
                    }
                }
                if (File.Exists(fileUrl)) File.Delete(fileUrl);
                using (StreamWriter sw = new StreamWriter(fileUrl, true, System.Text.Encoding.Default))
                {
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private string FromUrlSelectBestVideo(string webUrl)
        {
            Console.WriteLine("1111开始读取m3u8：" + webUrl);
            HttpWebRequest filewebrequest = WebRequest.Create(webUrl) as HttpWebRequest;
            filewebrequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
            filewebrequest.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)filewebrequest.GetResponse();

            Stream responseStream = null;
            string m3u8 = "";


            if ("gzip".Equals(res.ContentEncoding))
             {
                 responseStream = new System.IO.Compression.GZipStream(res.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                Console.WriteLine("Gzip");
             }
             else if ("deflate".Equals(res.ContentEncoding))
             {
                 responseStream = new System.IO.Compression.DeflateStream(res.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                Console.WriteLine("Deflate");
            }
             else
             {
                 responseStream = res.GetResponseStream();
             }


             if (responseStream != null)
             {
                 StreamReader streamReader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                 m3u8 = streamReader.ReadToEnd();
             }

            string[] lines = m3u8.Split("\n".ToCharArray());

            ArrayList videos = new ArrayList();

            Console.WriteLine(m3u8);

            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].Contains("#EXTM3U"))
                {
                    if (lines[i].Contains("#EXT-X-STREAM-INF:"))
                    {
                        string[] ext_x_stream_inf = lines[i].Replace("#EXT-X-STREAM-INF:", "").Split(",".ToCharArray());
                        foreach (string inf in ext_x_stream_inf)
                        {
                            if (inf.Contains("RESOLUTION"))
                            {
                                videos.Add(new string[] { inf.Replace("RESOLUTION=", "").Split("x".ToCharArray())[1], lines[i + 1] });
                            }
                        }
                    }
                }
            }
            foreach (string[] video in videos)
            {
                Console.WriteLine("video[0]" + video[0]);
                Console.WriteLine("video[1]" + video[1]);
                if (video[0].Contains("1080")) return video[1];
            }
            foreach (string[] video in videos)
            {
                if (video[0].Contains("720")) return video[1];
            }
            foreach (string[] video in videos)
            {
                if (video[0].Contains("480")) return video[1];
            }
            foreach (string[] video in videos)
            {
                if (video[0].Contains("240")) return video[1];
            }
            foreach (string[] video in videos)
            {
                if (video[0].Contains("144")) return video[1];
            }
            return null;
        }

        private void ConsoleWrite(string webString, ArrayList clips)
        {
            if (clips.Count == 0)
            {
                Console.WriteLine("暂无更新");
            }
            else
            {
                Console.WriteLine(webString + "共计" + clips.Count + "条更新");
            }
            foreach (string[] clip in clips)
            {
                Console.WriteLine((int.Parse(clip[0])).ToString() + " / " + clip[1] + " / " + clip[2] + " / " + clip[3] + " / " + clip[4] + " / " + clip[5]);
            }
        }

        private void ScraperClips(ArrayList clips, int companyId, int seriesId)
        {
            foreach (string[] clip in clips)
            {
                //
                int clipNum = int.Parse(clip[0]);
                string imageUrl = clip[2].Replace("&amp;", "&");
                string clipPic = "";
                clipPic = FromUrlToImage(imageUrl, "D:/VideoTemp/html/" + clipNum + ".jpg");
                if (string.Equals(clip[4], "")) clip[4] = "1980-1-1";
                try
                {
                    ClipDao.GetClipDao().CreateClip(companyId, seriesId, clipNum, clip[1], DateTime.Parse(clip[4]), clip[5], clipPic, "", 0, clip[3]);
                    Console.WriteLine(clipNum.ToString() + " / " + clip[1] + " / " + clip[2] + " / " + clip[3] + " / " + clip[4] + " / " + clip[5] + "--> success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(clipNum.ToString() + " / " + clip[1] + " / " + clip[2] + " / " + clip[3] + " / " + clip[4] + " / " + clip[5] + "--> error");
                }
            }
        }

        private string[] ProxyFromWebUrl(string webUrl)
        {
            if (webUrl.Contains("www.kristenbjorn.com"))
                return new string[] { webUrl.Replace("www.kristenbjorn.com", "68.232.188.216"), "www.kristenbjorn.com", "68.232.188.216" };
            if (webUrl.Contains("www.barebackthathole.com"))
                return new string[] { webUrl.Replace("www.barebackthathole.com", "151.139.128.11"), "barebackthathole.com", "151.139.128.10" };
            if (webUrl.Contains("www.breedmeraw.com"))
                return new string[] { webUrl.Replace("www.breedmeraw.com", "151.139.128.11"), "breedmeraw.com", "151.139.128.10" };
            if (webUrl.Contains("www.masqulin.com"))
                return new string[] { webUrl.Replace("www.masqulin.com", "64.59.126.194"), "www.masqulin.com", "64.59.126.194" };
            if (webUrl.Contains("www.pridestudios.com"))
                return new string[] { webUrl.Replace("www.pridestudios.com", "104.23.131.77"), "www.pridestudios.com", "104.23.131.77" };
            if (webUrl.Contains("www.butchdixon.com"))
                return new string[] { webUrl.Replace("www.butchdixon.com", "99.192.155.52"), "www.butchdixon.com", "99.192.155.52" };
            if (webUrl.Contains("www.uknakedmen.com"))
                return new string[] { webUrl.Replace("www.uknakedmen.com", "99.192.155.52"), "www.uknakedmen.com", "99.192.155.52" };
            if (webUrl.Contains("www.menatplay.com"))
                return new string[] { webUrl.Replace("www.menatplay.com", "64.59.126.194"), "menatplay.com", "64.59.126.194" };
            if (webUrl.Contains("www.hotoldermale.com"))
                return new string[] { webUrl.Replace("www.hotoldermale.com", "52.86.52.217"), "www.hotoldermale.com", "52.86.52.217" };
            return new string[] { webUrl, "", "" };
        }

        private void StartChrome()
        {
            if (driver == null)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--ignore-certificate-errors");
                options.AddArgument("--user-data-dir=C:/Program Tools/Download Tools/lrts.me/懒人听书下载工具/Cache");
                options.AddArgument("--window-size=1440,900");
                //options.AddArgument("--headless");
                options.AddUserProfilePreference("profile", new { default_content_setting_values = new { images = 2 } });
                driver = new ChromeDriver(System.Environment.CurrentDirectory, options);
            }
        }

        private void QuitChrome()
        {
            driver.Quit();
            driver.Dispose();
            driver = null;
        }

        private void ChangeClipsNum(int _LastClipNum, ArrayList _Clips)
        {
            foreach (string[] clip in _Clips)
            {
                clip[0] = (_LastClipNum + 1 + _Clips.Count - int.Parse(clip[0])).ToString();
            }
        }
    }
}
