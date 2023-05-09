using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.viewmodel;
using com.gestapoghost.entertainment.xaml.main;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.xaml.scene
{
    public partial class SceneThumb : MetroWindow
    {


        private SceneThumbViewModel _SceneThumbViewModel;

        public SceneThumb()
        {
            InitializeComponent();
        }

        public void InitWindow()
        {
            DataContext = _SceneThumbViewModel = new SceneThumbViewModel((Application.Current as App).Company, (Application.Current as App).Series, (Application.Current as App).Movie, (Application.Current as App).Scene);
        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (((MainWindow)Application.Current.MainWindow) != null)
            {
                e.Cancel = true;
                (Application.Current as App).SceneThumb.Hide();
            }
        }

    }
}
