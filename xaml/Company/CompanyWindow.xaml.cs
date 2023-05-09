using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.movie;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.entertainment.xaml.company
{
    /// <summary>
    /// Company.xaml 的交互逻辑
    /// </summary>
    public partial class CompanyWindow : MetroWindow
    {
        private int _CompanyTypeId = 0;
        private Company _Company = null;

        public CompanyWindow()
        {
            InitializeComponent();
        }

        public void InitWindow()
        {
            _CompanyTypeId = (Application.Current as App).CompanyTypeId;
            _Company = (Application.Current as App).Company;

            if (_Company == null)
            {
                _Company = new Company();
                _Company.Pic = "CompanyNull";
            }
            DataContext = _Company;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (Application.Current.MainWindow != null)
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
                CompanyImage.Source = ImageFileService.GetImage(openfiledialog.FileName);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _Company.Name = CompanyName.Text;
            _Company.Pic = ImageFileService.SaveBitmapImage((BitmapImage)(CompanyImage.Source));
            _Company.Type = _CompanyTypeId;
            if (CompanyService.GetCompanyService().SaveOrUpdateCompany(_Company))
                MessageBox.Show("保存成功!");
            else
                MessageBox.Show("保存失败!");
            (Application.Current as App).CompanyWindow.Hide();
            (Application.Current as App).CompanyTypeId = _CompanyTypeId;
            (Application.Current as App).CompanyPage.InitPage();
        }
    }
}
