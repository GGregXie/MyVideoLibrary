using System.Windows.Controls;
using System.Windows;
using com.gestapoghost.entertainment.viewmodel;
using com.gestapoghost.entertainment.entity;
using System.Windows.Input;

namespace com.gestapoghost.entertainment.xaml.series
{
    /// <summary>
    /// ClipsCompanyPage.xaml 的交互逻辑
    /// </summary>
    public partial class SeriesPage : Page
    {

        public SeriesPage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            SeriesListBox.DataContext = new SeriesPageViewModel((Application.Current as App).Company);
            SeriesListBox.ScrollIntoView(SeriesListBox.Items[0]);
        }


        private void NewSeriesButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Series = null;
            (Application.Current as App).SeriesWindow.InitWindow();
            (Application.Current as App).SeriesWindow.Show();
        }

        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Series = (sender as MenuItem).Tag as Series;
            (Application.Current as App).SeriesWindow.InitWindow();
            (Application.Current as App).SeriesWindow.Show();
        }

        private void NewSeriesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("" + ((sender as MenuItem).Tag as Company).Id);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //if ((Application.Current as App).Company.Id == 207)
                //{
                //    (Application.Current as App).ClipPaging = null;
                //    (Application.Current as App).ClipHasVideo = 0;
                //    (Application.Current as App).FansPage.InitPage();
                //    (Application.Current as App).MainFrame.Content = (Application.Current as App).FansPage;
                //}
                //else
                //{
                    (Application.Current as App).Series = (sender as Grid).Tag as Series;
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
                //}
            }
        }
    }
}
