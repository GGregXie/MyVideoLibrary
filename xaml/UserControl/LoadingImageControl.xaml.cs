using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace com.gestapoghost.entertainment.xaml.usercontrol
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class LoadingImageControl : UserControl
    {
        private Storyboard story;
        public LoadingImageControl()
        {
            InitializeComponent();
            this.story = (base.Resources["waiting"] as Storyboard);
        }
        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            this.story.Begin(this.image, true);
        }
        public void Stop()
        {
            base.Dispatcher.BeginInvoke(new Action(() => {
                this.story.Pause(this.image);
                base.Visibility = System.Windows.Visibility.Collapsed;
            }));
        }
    }
}
