using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using com.gestapoghost.entertainment.viewmodel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace com.gestapoghost.entertainment.xaml.actor
{
    public partial class ActorPage : Page
    {
        private ActorPageViewModel _ActorPageViewModel;

        public ActorPage()
        {
            InitializeComponent();
        }

        public void InitPage()
        {
            DataContext = _ActorPageViewModel = new ActorPageViewModel((Application.Current as App).ActorPaging);
        }

        private void NameButton_Click(object sender, RoutedEventArgs e)
        {
            _ActorPageViewModel.ActorType = 0;
            _ActorPageViewModel.Search = "";
            _ActorPageViewModel.GetPaging();
            _ActorPageViewModel.GetActors();
            _ActorPageViewModel.GetPageButtons();

        }

        private void OtherLikeButton_Click(object sender, RoutedEventArgs e)
        {
            _ActorPageViewModel.ActorType = 1;
            _ActorPageViewModel.Search = "";
            _ActorPageViewModel.GetPaging();
            _ActorPageViewModel.GetActors();
            _ActorPageViewModel.GetPageButtons();
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            _ActorPageViewModel.ActorType = 2;
            _ActorPageViewModel.Search = "";
            _ActorPageViewModel.GetPaging();
            _ActorPageViewModel.GetActors();
            _ActorPageViewModel.GetPageButtons();
        }

        private void UnLikeButton_Click(object sender, RoutedEventArgs e)
        {
            _ActorPageViewModel.ActorType = 3;
            _ActorPageViewModel.Search = "";
            _ActorPageViewModel.GetPaging();
            _ActorPageViewModel.GetActors();
            _ActorPageViewModel.GetPageButtons();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            _ActorPageViewModel.ActorType = 0;
            _ActorPageViewModel.GetPaging();
            _ActorPageViewModel.GetActors();
            _ActorPageViewModel.GetPageButtons();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (Application.Current as App).Actor = (sender as Grid).Tag as Actor;
                (Application.Current as App).ClipPage.InitPage();
                (Application.Current as App).MainFrame.Content = (Application.Current as App).ClipPage;
            }
        }

        private void LikeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Actor _Actor = (sender as MenuItem).Tag as Actor;
            ActorService.GetActorService().UpdateActorLike(_Actor, 2);
        }

        private void UnLikeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Actor _Actor = (sender as MenuItem).Tag as Actor;
            ActorService.GetActorService().UpdateActorLike(_Actor, 3);
        }

        private void PageBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_ActorPageViewModel.Paging.canback())
            {
                MessageBox.Show("无上一页");
            }
            else
            {
                _ActorPageViewModel.Paging.back();
                _ActorPageViewModel.GetActors();
                _ActorPageViewModel.GetPageButtons();
            }
        }

        private void PageNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_ActorPageViewModel.Paging.cannext())
            {
                MessageBox.Show("无下一页");
            }
            else
            {
                _ActorPageViewModel.Paging.next();
                _ActorPageViewModel.GetActors();
                _ActorPageViewModel.GetPageButtons();

            }
        }

        private void PageButton_Click(object sender, RoutedEventArgs e)
        {
            _ActorPageViewModel.Paging.CurrentPage = ((sender as Button).Tag as PageButton).PageInt;
            _ActorPageViewModel.GetActors();
            _ActorPageViewModel.GetPageButtons();
        }

    }
}
