using com.gestapoghost.entertainment.viewmodel;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace com.gestapoghost.entertainment.xaml.company
{
    public partial class CompanyPage : Page
    {
        private CompanyPageViewModel _CompanyPageViewModel;

        public CompanyPage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            CompanyListBox.DataContext = _CompanyPageViewModel = new CompanyPageViewModel((Application.Current as App).CompanyTypeId);
            if(_CompanyPageViewModel.Companies.Count > 0) CompanyListBox.ScrollIntoView(CompanyListBox.Items[0]);
        }

        private void NewCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Company = null;
            (Application.Current as App).CompanyWindow.InitWindow();
            (Application.Current as App).CompanyWindow.Show();
        }

        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Company = (sender as MenuItem).Tag as Company;
            (Application.Current as App).CompanyWindow.InitWindow();
            (Application.Current as App).CompanyWindow.Show();
        }

        private void NewSeriesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Company = (sender as MenuItem).Tag as Company;
            (Application.Current as App).SeriesWindow.InitWindow();
            (Application.Current as App).SeriesWindow.Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (Application.Current as App).Company = (sender as Grid).Tag as Company;
                (Application.Current as App).Series = null;
                if (WebService.GetWebService().GetAllSeriesCountFromCompany((sender as Grid).Tag as Company) > 0)
                {
                    (Application.Current as App).SeriesPage.InitPage();
                    (Application.Current as App).MainFrame.Content = (Application.Current as App).SeriesPage;
                }
                else
                {
                    if ((Application.Current as App).CompanyTypeId == 1 || (Application.Current as App).CompanyTypeId == 3)
                    {
                        (Application.Current as App).MoviePage.InitPage();
                        (Application.Current as App).MainFrame.Content = (Application.Current as App).MoviePage;
                    }
                    else if ((Application.Current as App).CompanyTypeId == 2 || 
                            (Application.Current as App).CompanyTypeId == 4 ||
                            (Application.Current as App).CompanyTypeId == 5 ||
                            (Application.Current as App).CompanyTypeId == 6 ||
                            (Application.Current as App).CompanyTypeId == 7 ||
                            (Application.Current as App).CompanyTypeId == 8)
                    {
                        (Application.Current as App).ClipPaging = null;
                        (Application.Current as App).ClipHasVideo = 0;
                        (Application.Current as App).ClipPage.InitPage();
                        (Application.Current as App).MainFrame.Content = (Application.Current as App).ClipPage;
                    }
                }
            }
        }
    }
}
