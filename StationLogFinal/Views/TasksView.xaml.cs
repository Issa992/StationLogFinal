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
    public sealed partial class TasksView : Page
    {
        public TasksView()
        {
            this.InitializeComponent();
        }



        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MyCommandBar.IsOpen = true;
            MyCommandBar.IsDynamicOverflowEnabled = false;
        }
        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            
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

        private async void AddNewTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNewTaskView));

            //ContentDialog d = new ContentDialog();
            //d.Title = "Add New Task";
            //d.Content = "Here is going to appear the contenent of the new Task ";
            //d.PrimaryButtonText = "OK";

            //await d.ShowAsync();
        }
    }
}
