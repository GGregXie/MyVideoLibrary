using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.Service;
using com.gestapoghost.movie.Entity;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.movie.xaml.Clip
{
    /// <summary>
    /// Company.xaml 的交互逻辑
    /// </summary>
    public partial class ClipWindow : MetroWindow
    {
        private ClipEntity clipEntity = null;
        private List<ActorEntity> actorEntities = null;
        private string filepath = "";

        private int CompanyId = 0;
        private int SeriesId = 0;


        public ClipWindow()
        {
            InitializeComponent();
        }

        public void Reload(ClipEntity reloadClipEntity)
        {
            if ((Application.Current as App).CompanyEntity != null)
                CompanyId = (Application.Current as App).CompanyEntity.Id;
            else
                CompanyId = 0;
            if ((Application.Current as App).SeriesEntity != null)
                SeriesId = (Application.Current as App).SeriesEntity.Id;
            else
                SeriesId = 0;
            clipEntity = reloadClipEntity;
            CompanySeries.Text = ClipService.GetClipService().GetCompanySeriesString((Application.Current as App).CompanyEntity, (Application.Current as App).SeriesEntity);
            if (reloadClipEntity == null)
            {

                actorEntities = new List<ActorEntity>();
                ClipNumber.Text = "0";
                ClipStart.Text = "0";
                ClipDate.Text = "1980/1/1";
                ClipImage.Source = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/ClipNull", UriKind.RelativeOrAbsolute));
                ClipTitle.Text = "";
                ActorList.Children.Clear();
                ActorsText.Text = "";
                ClipDescription.Text = "";
                filepath = "";
                ClipUrlText.Text = "";

            }
            else
            {
                actorEntities = ActorService.GetActorService().GetActorsByClipId(clipEntity.Id);
                ClipNumber.Text = clipEntity.Number.ToString();
                ClipStart.Text = clipEntity.Start.ToString();
                ClipDate.Text = "" + clipEntity.Date.Year + "/" + clipEntity.Date.Month + "/" + clipEntity.Date.Day;
                ClipImage.Source = clipEntity.Pic;
                ClipTitle.Text = clipEntity.Title;
                ClipDescription.Text = clipEntity.Description;
                ActorsText.Text = "";
                filepath = clipEntity.FilePath;
                ClipUrlText.Text = clipEntity.ClipUrl;
            }
            ReloadActorGrid(actorEntities);

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(((MainWindow)Application.Current.MainWindow)  != null)
            { 
                e.Cancel = true;
                (Application.Current as App).ClipWindow.Hide();
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
                ClipImage.Source = ImageFileService.GetImage(openfiledialog.FileName); //new BitmapImage(new Uri(openfiledialog.FileName));
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (clipEntity == null)
            {
                clipEntity = EditClipByControl(new ClipEntity());
                clipEntity.Id = ClipService.GetClipService().CreateClip(clipEntity, CompanyId, SeriesId, 0, actorEntities);
                MessageBox.Show("保存成功!");
            }
            else {
                clipEntity = EditClipByControl(clipEntity);
                ClipService.GetClipService().UpdateClip(clipEntity, actorEntities);
                MessageBox.Show("更新成功!");
            }
            (Application.Current as App).ClipWindow.Hide();
            (Application.Current as App).ClipPage.InitPage();
        }

        private void AddActorButton_Click(object sender, RoutedEventArgs e)
        {
            if (actorEntities == null)
            {
                actorEntities = new List<ActorEntity>();
            }
            string strActors = ActorsText.Text;
            string[] actors = strActors.Split(',');
            foreach(string actor in actors) {

                Boolean isRepeat = false;
                foreach (ActorEntity oldActorEntity in actorEntities)
                {
                    if (string.Equals(oldActorEntity.Name, actor.Trim()))
                    {
                        isRepeat = true;
                    }
                }

                if (!isRepeat) 
                { 

                    ActorEntity actorEntity = ActorService.GetActorService().FindActorByName(actor.Trim());
                    if (actorEntity == null)
                    {
                        actorEntity = new ActorEntity() { Name = actor.Trim(), Pic = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/ActorNull", UriKind.RelativeOrAbsolute)) };
                        actorEntity.Id = ActorService.GetActorService().CreateActor(actorEntity);
                    }

                    actorEntities.Add(actorEntity);
                }

                ReloadActorGrid(actorEntities);
            }
        }

        private void ReloadActorGrid(List<ActorEntity> actorEntities)
        {
            ActorList.Children.Clear();
            foreach(ActorEntity actorEntity in actorEntities)
            { 
                ActorList.Children.Add(GetGridWithActor(actorEntity));
            }
        }

        private Grid GetGridWithActor(ActorEntity actorEntity)
        {

            //<Grid Margin = "0,0,10,0">
            //  <Grid.RowDefinitions>
            //      <RowDefinition Height = "180" />
            //      <RowDefinition Height = "30" />
            //  </Grid.RowDefinitions >
            //  <Image Grid.Row = "0" Width = "120" Height = "180" Source = "pack://siteoforigin:,,,/Resources/Images/Temp" />
            //  <TextBlock Grid.Row = "1" Text = "Greg Xie" HorizontalAlignment = "Center" VerticalAlignment = "Center" />
            //</Grid>
            Grid ActorGrid = new Grid()
            {
                Margin = new Thickness(0, 0, 10, 0),
                RowDefinitions = {
                            new RowDefinition() { Height = new GridLength(180)},
                            new RowDefinition() { Height = new GridLength(30) }
                        }
            };
            Image ActorImage = new Image()
            {
                Width = 120,
                Height = 180,
                Source = actorEntity.Pic,
                ContextMenu = new ContextMenu()
            };

            MenuItem updateItemMenu = new MenuItem() { Header = "更换照片", Tag = actorEntity };
            updateItemMenu.Click += UpdateActorItemMenu_Click; ;
            MenuItem deleteItemMenu = new MenuItem() { Header = "删除演员", Tag = actorEntity };
            deleteItemMenu.Click += DeleteActorItemMenu_Click; ;
            ActorImage.ContextMenu.Items.Add(updateItemMenu);
            ActorImage.ContextMenu.Items.Add(deleteItemMenu);


            TextBlock ActorText = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = actorEntity.Name
            };

            Grid.SetRow(ActorImage, 0);
            Grid.SetRow(ActorText, 1);
            ActorGrid.Children.Add(ActorImage);
            ActorGrid.Children.Add(ActorText);
            return ActorGrid;
        }

        private void UpdateActorItemMenu_Click(object sender, RoutedEventArgs e)
        {
            ActorEntity actorEntity = (ActorEntity)((MenuItem)sender).Tag;
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif;*.jfif|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                actorEntity.Pic = ImageFileService.GetImage(openfiledialog.FileName); //new BitmapImage(new Uri(openfiledialog.FileName));
                ActorService.GetActorService().UpdateActor(actorEntity);
                ReloadActorGrid(actorEntities);
            }
        }

        private void DeleteActorItemMenu_Click(object sender, RoutedEventArgs e)
        {
            actorEntities.Remove((ActorEntity)((MenuItem)sender).Tag);
            ReloadActorGrid(actorEntities);
        }

        private ClipEntity EditClipByControl(ClipEntity oldClipEntity)
        {
            oldClipEntity.Number = Int32.Parse(ClipNumber.Text);
            oldClipEntity.Title = ClipTitle.Text;
            oldClipEntity.Date = ClipDate.SelectedDate.Value;
            oldClipEntity.Description = ClipDescription.Text;
            oldClipEntity.Pic = (BitmapImage)(ClipImage.Source);
            oldClipEntity.FilePath = filepath;
            //oldClipEntity.fileVideo = ClipVideoType.Text;
            //oldClipEntity.fileAudio = ClipAudioType.Text;
            oldClipEntity.Start = Int32.Parse(ClipStart.Text);
            oldClipEntity.ClipUrl = ClipUrlText.Text;
            return oldClipEntity;
        }

        private void AddVideoFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "视频文件|*.mp4;*.mkv;*.nsp;*.xci|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                filepath = openfiledialog.FileName;

            }
        }
    }
}
