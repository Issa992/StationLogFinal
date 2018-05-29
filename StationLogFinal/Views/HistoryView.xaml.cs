﻿using StationLogFinal.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using StationLogWebApplication1;
using StationLogWebApplication1.Models;

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

        private async void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
           

        }

        private void Showcomments_OnClick(object sender, RoutedEventArgs e)
        {
            check = 0;
            measurementsListcView.ItemsSource = CommentVM.CommentsOC;
            
        }

        private async Task RefreshItems()
        {
            try
            {
                measurementsListcView.ItemsSource = await new MeasurementsViewModel().LoadMeasurments();

             
            }
            catch (Exception e)
            {
               
            }
        }
        private async Task RefreshComments()
        {
            try
            {
                measurementsListcView.ItemsSource = await new CommentsViewModel().LoadComments();

             
            }
            catch (Exception e)
            {
               
            }
        }

        private async void ShowMeasurements_OnClick(object sender, RoutedEventArgs e)
        {
            check = 1;
            measurementsListcView.ItemsSource = VM.MeasurementsOC;
            await RefreshItems();
        }

        private async void sortByUser_OnClick(object sender, RoutedEventArgs e)
        {
            if (UserIdTextBox.Text.Length == 0)
            {
                EmptyTaskFieldsPopUp();
            }
            else
            {
                if (check == 0)
                {

                    var query = MeasurementsSorter.SortMeasurmentsByUser(Convert.ToInt32(UserIdTextBox.Text));
                    VM.MeasurementsOC = new ObservableCollection<Measurement>(query);
                    await RefreshItems();

                }
                else
                {
                    var query = CommentsSorter.SortMeasurmentsByUser(Convert.ToInt32(UserIdTextBox.Text));
                    CommentVM.CommentsOC = new ObservableCollection<Comment>(query);
                    await RefreshComments();
                }
            }
          

        }

        private async void EmptyTaskFieldsPopUp()
        {
            var dialog = new Windows.UI.Popups.MessageDialog("Please provide user ID", "Try again");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 1 });
            dialog.CancelCommandIndex = 1;
             await dialog.ShowAsync();
        }

        private async void sortByDate_OnClick(object sender, RoutedEventArgs e)
        {
            if (check == 0)
            {

                var query = MeasurementsSorter.SortMeasurmentsByDate(LogsDatePicker.Date.Date);
                VM.MeasurementsOC = new ObservableCollection<Measurement>(query);
                await RefreshItems();

            }
        }
    }
}
