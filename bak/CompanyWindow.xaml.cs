using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.Service;
using com.gestapoghost.movie.Entity;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.movie.xaml.Company
{
    /// <summary>
    /// Company.xaml 的交互逻辑
    /// </summary>
    public partial class CompanyWindow : MetroWindow
    {
        private int CompanyTypeId = 0;
        private CompanyEntity CompanyEntity = null;

        public CompanyWindow()
        {
            InitializeComponent();

        }

        public void Reload()
        {
            CompanyTypeId = (Application.Current as App).CompanyTypeId;
            CompanyEntity = (Application.Current as App).CompanyEntity;
            if (CompanyEntity == null)
            {
                CompanyImage.Source = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/Logs/CompanyNull", UriKind.RelativeOrAbsolute));
                CompanyName.Text = "";
            }
            else
            {
                CompanyImage.Source = CompanyEntity.Pic;
                CompanyName.Text = CompanyEntity.Name;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if(Application.Current.MainWindow != null)
            {
                e.Cancel = true;
                (Application.Current as App).CompanyWindow.Hide();
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
                CompanyImage.Source = ImageFileService.GetImage(openfiledialog.FileName); //new BitmapImage(new Uri(openfiledialog.FileName));
            }
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).CompanyWindow.Reload();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CompanyEntity == null)
            {
                CompanyEntity = new CompanyEntity();
                CompanyEntity.Name = CompanyName.Text;
                CompanyEntity.Pic = (BitmapImage)(CompanyImage.Source);
                CompanyEntity.Type = CompanyTypeId;
                CompanyService.GetCompanyService().CreateCompany(CompanyEntity);
            }
            else {
                CompanyEntity.Name = CompanyName.Text;
                CompanyEntity.Pic = (BitmapImage)(CompanyImage.Source);
                CompanyEntity.Type = CompanyTypeId;
                CompanyService.GetCompanyService().UpdateCompany(CompanyEntity);
            }
            (Application.Current as App).CompanyWindow.Hide();
            (Application.Current as App).CompanyTypeId = CompanyEntity.Type;
            (Application.Current as App).CompanyPage.InitPage();
            MessageBox.Show("保存成功!");
        }
    }
}
