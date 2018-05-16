using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
        private void CheckBox_Checked(object sender, TappedRoutedEventArgs e)
        {
            CheckBox checkBox = new CheckBox();
            //Task1 task=checkBox.DataContext as Task1;
            //task.IsDone = (bool) checkBox.IsChecked;
            TaskHandler taskHandler = new TaskHandler(
                new TaskViewModel());
            taskHandler.UpdateTask((bool)checkBox.IsChecked,
                (TaskModel)MyListView.SelectedItem);

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
            CheckBox checkBox = new CheckBox();
            //Task1 task=checkBox.DataContext as Task1;
            //task.IsDone = (bool) checkBox.IsChecked;
            TaskHandler taskHandler = new TaskHandler(
                new TaskViewModel());
            taskHandler.UpdateTask((bool)checkBox.IsChecked,
                (TaskModel)MyListView.SelectedItem);
        }
    }
}
