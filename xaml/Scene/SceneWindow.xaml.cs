using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.viewmodel;
using com.gestapoghost.entertainment.xaml.main;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace com.gestapoghost.entertainment.xaml.scene
{
    public partial class SceneWindow : MetroWindow
    {


        private SceneWindowViewModel _SceneWindowViewModel;

        public SceneWindow()
        {
            InitializeComponent();
        }

        public void InitWindow()
        {
            DataContext = _SceneWindowViewModel = new SceneWindowViewModel((Application.Current as App).Company, (Application.Current as App).Series, (Application.Current as App).Movie, (Application.Current as App).Scene);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (((MainWindow)Application.Current.MainWindow) != null)
            {
                e.Cancel = true;
                (Application.Current as App).SceneWindow.Hide();
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
                _SceneWindowViewModel.Scene.Pic = ImageFileService.SaveBitmapImage(ImageFileService.GetImage(openfiledialog.FileName));
            }
        }

        private void AddVideoFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "视频文件|*.mp4;*.mkv;*.wmv;*.nsp;*.xci;*.nsz;*.cbz|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                _SceneWindowViewModel.Scene.FilePath = openfiledialog.FileName;
            }
        }

        private void AddActorButton_Click(object sender, RoutedEventArgs e)
        {

            string strActors = ActorsText.Text;
            string[] actorStrings = strActors.Split(new string[] { ",", " and " }, StringSplitOptions.None);

            foreach (string actorString in actorStrings)
            {
                bool isRepeat = false;
                foreach (Actor _Actor in _SceneWindowViewModel.Actors)
                {
                    if (string.Equals(_Actor.Name, actorString.Trim()))
                    {
                        isRepeat = true;
                    }
                }

                if (!isRepeat)
                {

                    Actor _Actor = WebService.GetWebService().GetActorByName(actorString.Trim());
                    if (_Actor == null)
                    {
                        _Actor = new Actor() { Name = actorString.Trim(), Pic = "ActorNull" };
                        _Actor.Id = ActorService.GetActorService().CreateActor(_Actor);
                    }
                    _SceneWindowViewModel.Actors.Add(_Actor);
                }
            }
        }

        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Filter = "图像文件|*.jpg;*.png;*.jpeg;*.bmp;*.gif;*.jfif|所有文件|*.*"
            };
            if ((bool)openfiledialog.ShowDialog())
            {
                Actor _Actor = (sender as MenuItem).Tag as Actor;
                _Actor.Pic = ImageFileService.SaveBitmapImage(ImageFileService.GetImage(openfiledialog.FileName));
                ActorService.GetActorService().UpdateActor(_Actor);
            }
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _SceneWindowViewModel.Actors.Remove((sender as MenuItem).Tag as Actor);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClipService.GetClipService().CreateOrUpdateClip(_SceneWindowViewModel.Scene, _SceneWindowViewModel.Company, _SceneWindowViewModel.Series, _SceneWindowViewModel.Movie, _SceneWindowViewModel.Actors))
                MessageBox.Show("保存成功!");
            else
                MessageBox.Show("保存失败!");
            (Application.Current as App).SceneWindow.Hide();
            (Application.Current as App).Company = _SceneWindowViewModel.Company;
            (Application.Current as App).Series = _SceneWindowViewModel.Series;
            (Application.Current as App).Movie = _SceneWindowViewModel.Movie;
            (Application.Current as App).ScenePage.InitPage();
        }

    }
}
