using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using StationLogFinal.SessionTools;
using StationLogFinal.ViewModel;
using StationLogWebApplication1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StationLogFinal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MeasurmentsView : Page
    {
        MeasurementsViewModel VM = new MeasurementsViewModel();
        public MeasurmentsView()
        {
            this.InitializeComponent();
          
        }

      
            private void Add(object sender, RoutedEventArgs e)
            {
                Frame.Navigate(typeof(MeasurmentsView));
            }



        #region navigation

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

        #endregion


       
    }
}
