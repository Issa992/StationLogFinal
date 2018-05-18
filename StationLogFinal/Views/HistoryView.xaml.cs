using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StationLogFinal.Handlers;
using StationLogFinal.Model;
using StationLogFinal.SessionTools;
using StationLogFinal.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StationLogFinal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HistoryView : Page
    {
        MeasurementsViewModel VM = new MeasurementsViewModel();
        CommentsViewModel CommentVM = new CommentsViewModel();
        public HistoryView()
        {
           
            this.InitializeComponent();


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshItems();
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

        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
          //MeasurementsSorter.SortMeasurmentsByAll(LogsDatePicker.Date.DateTime, Int32.Parse(MonitoridTextBox.Text), Int32.Parse(UserIdTextBox.Text));
        }

        private void Showcomments_OnClick(object sender, RoutedEventArgs e)
        {
            measurementsListcView.ItemsSource = CommentVM.CommentsOC;
        }

        private async void RefreshItems()
        {
            try
            {
                measurementsListcView.ItemsSource = await new MeasurementsViewModel().LoadMeasurments();

                //MyListView.ItemsSource = await new TaskViewModel().LoadTasks();
            }
            catch (Exception e)
            {
                //await new MessageDialog(e.Message, "Error loading tasks").ShowAsync();

            }
        }

        private void ShowMeasurements_OnClick(object sender, RoutedEventArgs e)
        {
            measurementsListcView.ItemsSource = VM.MeasurementsOC;
        }
    }
}
