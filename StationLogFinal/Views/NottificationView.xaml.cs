using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StationLogFinal.SessionTools;
using StationLogFinal.ViewModel;
using StationLogWebApplication1;

namespace StationLogFinal.Views
{
    public sealed partial class NottificationView : Page
    {
        public NottificationView()
        {
            
        }
        #region navigation
        private void NavigateToMeasurmentsPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MeasurmentsView));
        }

        private void NavigateToHomeView(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomeView));
        }

        private void NavigateToTaskView(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TasksView));
        }

        private void NavigateToHistoryView(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HistoryView));
        }

        private void NavigateToCommentsView(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CommentsView));
        }

        private void NavigateToLoginPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void NavigateToMessagesPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MessagesView));
        }
        private void NavigateToNotificationPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NotificationView));
        }

        #endregion



    }
}
