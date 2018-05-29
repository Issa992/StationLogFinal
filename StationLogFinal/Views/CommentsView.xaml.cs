using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using StationLogFinal.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StationLogFinal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CommentsView : Page
    {
        public CommentsView()
        {
            this.InitializeComponent();
           
           
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            datePicker.Date = DateTimeOffset.Now;
            datePicker.Opacity = 0;
        
            
           
        }

        private async Task RefreshItems()
        {
            try
            {

                MyListView.ItemsSource = await new CommentsViewModel().LoadComments();


                //MyListView.ItemsSource = await new TaskViewModel().LoadTasks();
            }
            catch (Exception e)
            {
                //await new MessageDialog(e.Message, "Error loading tasks").ShowAsync();

            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MyCommandBar.IsOpen = true;
            MyCommandBar.IsDynamicOverflowEnabled = false;
        }
        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    ContentDialog d = new ContentDialog();
        //    d.Title = "Add New Comment";
        //    d.Content = "Here is going to appear the contenent of the new comment ";
        //    d.PrimaryButtonText = "OK";

        //    await d.ShowAsync();
        //}
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

        private async void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            await RefreshItems();
            Frame.Navigate(typeof(TasksView));
           
        }
    }
}
