﻿using StationLogFinal.ViewModel;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using StationLogWebApplication1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StationLogFinal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HistoryView : Page
    {
        private int check;
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
            if (check == 0)
            {
                //var query = MeasurementsSorter.SortMeasurmentsByUserAndStation(Int32.Parse(UserIdTextBox.Text),
                //    Int32.Parse(StationidTextBox.Text));
                var query = MeasurementsSorter.SortMeasurmentsByUser(Int32.Parse(UserIdTextBox.Text));
                VM.MeasurementsOC = new ObservableCollection<Measurement>(query);
            }


        }

        private void Showcomments_OnClick(object sender, RoutedEventArgs e)
        {
            check = 0;
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
            check = 1;
            measurementsListcView.ItemsSource = VM.MeasurementsOC;
        }
    }
}
