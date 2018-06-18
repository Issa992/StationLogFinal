using StationLogFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StationLogFinal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MessageView : Page
    {
        public NotAlMesVM notalmesVM;
        public MessageView()
        {
            notalmesVM = new NotAlMesVM();
            this.InitializeComponent();
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
            Frame.Navigate(typeof(MessageView));
        }
        private void NavigateToNotificationPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NotificationView));
        }


        #endregion

        private void MyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            notalmesVM.messagesHandler.ReadMessage(notalmesVM.SelectedMessage);
        }
    }
}
