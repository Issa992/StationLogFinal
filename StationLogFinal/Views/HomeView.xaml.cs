using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StationLogFinal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : Page
    {
        public HomeView()
        {
            this.InitializeComponent();
            //ApplicationView.PreferredLaunchViewSize = new Size(500, 1080);
            //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MyCommandBar.IsOpen = true;
            MyCommandBar.IsDynamicOverflowEnabled = false;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog d = new ContentDialog();
            d.Title = "Not implemented";
            d.Content = "The buttons are for illustrative purposes only and do not perform any action yet";
            d.PrimaryButtonText = "OK";

            await d.ShowAsync();
        }
        private void NavigateToHomeView(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(typeof(HomeView));
            Frame.Navigate(typeof(HomeView));
        }

        private void NavigateToTaskView(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(typeof(TasksView));
            Frame.Navigate(typeof(TasksView));
        }

        private void NavigateToHistoryView(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(typeof(HistoryView));
            Frame.Navigate(typeof(HistoryView));
        }

        private void NavigateToCommentsView(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(typeof(CommentsView));
            Frame.Navigate(typeof(CommentsView));
        }
        private void NavigateToMeasurmentsPage(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(typeof(MeasurmentsView));
            Frame.Navigate(typeof(MeasurmentsView));
        }
        private void NavigateToLoginPage(object sender, RoutedEventArgs e)
        {
            
           Frame.Navigate(typeof(MainPage));
        }
        private void NavigateToMessagesPage(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(typeof(MessageView));
            Frame.Navigate(typeof(MessageView));
        }
        private void NavigateToNotificationPage(object sender, RoutedEventArgs e)
        {
            //HomeFrame.Navigate(typeof(NotificationView));
            Frame.Navigate(typeof(NotificationView));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation imageAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("loginButton");
            if (imageAnimation != null)
            {
                imageAnimation.TryStart(MyCommandBar);
            }
        }

    }
}
