using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.ViewModel;
using StationLogWebApplication1;

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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshItems();
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MyCommandBar.IsOpen = true;
            MyCommandBar.IsDynamicOverflowEnabled = false;
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

        private  void AddNewTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddNewTaskView));

            //ContentDialog d = new ContentDialog();
            //d.Title = "Add New TaskModel";
            //d.Content = "Here is going to appear the contenent of the new TaskModel ";
            //d.PrimaryButtonText = "OK";

            //await d.ShowAsync();
        }
        //
        //
        //
        //
        //
        //private void CheckBox_Checked(object sender, TappedRoutedEventArgs e)
        //{
        //    CheckBox checkBox=new CheckBox();
        //    TaskModel task=checkBox.DataContext as TaskModel;
        //    task.IsDone = (bool) checkBox.IsChecked;
            

            
        //}
        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //CheckBox checkBox = (CheckBox)sender;
            //TaskModel task = checkBox.DataContext as TaskModel;
            ////Debug.Assert(checkBox.IsChecked != null, "checkBox.IsChecked != null");
            ////if (task != null)
            ////{
            //task.IsDone = (bool)checkBox.IsChecked;
            //    TaskHandler taskHandler = new TaskHandler(new TaskViewModel());
            //    await taskHandler.UpdateTask(task);
            //}
            using (var client=new HttpClient())
            {
                CheckBox checkBox = (CheckBox)sender;
                //TaskModel task1 = checkBox.DataContext as TaskModel;
                TaskModel task1 = new TaskModel();
                task1=checkBox.DataContext as TaskModel;
                if (checkBox.IsChecked != null) task1.IsDone = (bool) checkBox.IsChecked;

                task1.TaskId = task1.TaskId;
                var taskJson= JsonConvert.SerializeObject(task1);
                var httpContent=new StringContent(taskJson);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                await client.PutAsync("http://stationlogwebapplication120180426012243.azurewebsites.net/api/Tasks" + task1.TaskId, httpContent);


            }

            //TaskHandler taskHandler = new TaskHandler(
            //    new TaskViewModel());
            //taskHandler.UpdateTask((bool)checkBox.IsChecked,
            //    (TaskModel)MyListView.SelectedItem);

        }
        //
        //
        //
        //
        private async void RefreshItems()
        {
            try
            {
                MyListView.ItemsSource = await new TaskViewModel().LoadTasks();
               

                //MyListView.ItemsSource = await new TaskViewModel().LoadTasks();
            }
            catch (Exception e)
            {
                //await new MessageDialog(e.Message, "Error loading tasks").ShowAsync();

            }
        }

        private void MyCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            //CheckBox checkBox = new CheckBox();
            //TaskModel task = checkBox.DataContext as TaskModel;
            //task.IsDone = (bool)checkBox.IsChecked;
            //TaskHandler taskHandler = new TaskHandler(
            //    new TaskViewModel());
            ////taskHandler.UpdateTask((bool)checkBox.IsChecked,
            ////    (TaskModel)MyListView.SelectedItem);
            //taskHandler.UpdateTask(task);
        }
    }
}
