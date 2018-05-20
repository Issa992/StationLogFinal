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
using StationLogFinal.Model;
using StationLogFinal.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StationLogFinal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewTaskView : Page
    {
        public AddNewTaskView()
        {
            this.InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TasksView));
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            datePicker.MinYear = DateTimeOffset.Now;
            datePicker.MaxYear = DateTimeOffset.Now.AddYears(5);
            DatePicker.MinYear = DateTimeOffset.Now;
            DatePicker.MaxYear = DateTimeOffset.Now.AddYears(5);

        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await new TaskViewModel().LoadTasks();
        }
    }
}
