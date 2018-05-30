using StationLogFinal.ViewModel;
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
        private int check = 1;
        public static int ID;
        public static int Station;
        public static DateTime date;
        MeasurementsViewModel VM = new MeasurementsViewModel();
        CommentsViewModel CommentVM = new CommentsViewModel();
        public HistoryView()
        {
          
            this.InitializeComponent();
            date = LogsDatePicker.Date.Date;
            

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

        private async void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
           

        }
        private void NavigateToMessagesPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MessagesView));
        }
        private void NavigateToNotificationPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NotificationView));
        }
        private void Showcomments_OnClick(object sender, RoutedEventArgs e)
        {
            check = 0;
            HistoryListView.ItemsSource = CommentVM.CommentsOC;
            
        }

        private async Task RefreshItems()
        {
            try
            {
                HistoryListView.ItemsSource = await new MeasurementsViewModel().LoadMeasurments();

             
            }
            catch (Exception e)
            {
               
            }
        }
      

        private async void ShowMeasurements_OnClick(object sender, RoutedEventArgs e)
        {
            check = 1;
            HistoryListView.ItemsSource = VM.MeasurementsOC;
            await RefreshItems();
        }

        private void sortByUser_OnClick(object sender, RoutedEventArgs e)
        {
            ID = Int32.Parse(UserIdTextBox.Text);
            if (UserIdTextBox.Text.Length == 0)
            {
                EmptyTaskFieldsPopUp();
            }
            else
            {
                if (check == 1)
                {

                    
                    VM.SortElementsByUser();
                    HistoryListView.ItemsSource = VM.SortednMeasurements;

                }
                else
                {
                  CommentVM.SortElementsByUser();
                    HistoryListView.ItemsSource = CommentVM.SortedComments;
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

        private void sortByDate_OnClick(object sender, RoutedEventArgs e)
        {
         
            
                if (check == 1)
                {

                    VM.SortElementsByDate();
                    HistoryListView.ItemsSource = VM.SortednMeasurements;

                }
                else
                {
                    CommentVM.SortElementsByDate();
                    HistoryListView.ItemsSource = CommentVM.SortedComments;
                }
            
        }

        private async void sortByStation_OnClick(object sender, RoutedEventArgs e)
        {
            Station = Int32.Parse(StationidTextBox.Text);
            if (StationidTextBox.Text.Length == 0)
            {
                EmptyTaskFieldsPopUp();
            }
            else
            {
                if (check == 1)
                {

                    VM.SortElementsByStation();
                    HistoryListView.ItemsSource = VM.SortednMeasurements;

                }
                else
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("Cannot sort comments by station", "Sorry");
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 1 });
                    dialog.CancelCommandIndex = 1;
                    await dialog.ShowAsync();
                }
            }

        }
    }
}
