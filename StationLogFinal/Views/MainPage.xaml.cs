using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StationLogFinal.Views;
using StationLogWebApplication1;
using StationLogFinal.SessionTools;
using StationLogFinal.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StationLogFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            //formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            //CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            //coreTitleBar.ExtendViewIntoTitleBar = true;
            UserHandler.GetAllUsers();
        }

        private void Navigate(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(TasksView));
            User userInput = new User();
            userInput.UserId = Convert.ToInt16(userIdBox.Text);
            userInput.HashPass = userPasswordBox.Password;
            LoginTool.LoginUser(userInput);


        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshItems();

        }
        private async void RefreshItems()
        {
            try
            {

                await new TaskViewModel().LoadTasks();
                await new CommentsViewModel().LoadComments();


                //MyListView.ItemsSource = await new TaskViewModel().LoadTasks();
            }
            catch (Exception e)
            {
                //await new MessageDialog(e.Message, "Error loading tasks").ShowAsync();

            }
        }
        private void CurrentWindow_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (e.Size.Width > 640)
                VisualStateManager.GoToState(this, "WideState", false);
            else
                VisualStateManager.GoToState(this, "DefaultState", false);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(TestPage));
        }
    }
}
