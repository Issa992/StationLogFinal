using System;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using StationLogWebApplication1;
using StationLogFinal.SessionTools;
using StationLogFinal.ViewModel;
using Windows.UI.Xaml.Media.Animation;

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
            //ApplicationView.PreferredLaunchViewSize = new Size(200, 100);
            //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            UserHandler.GetAllUsers();

        }


        protected override  void OnNavigatedTo(NavigationEventArgs e)
        {
            int change = 1;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += (o, a) =>
            {
                // If we'd go out of bounds then reverse
                int newIndex = FlipView.SelectedIndex + change;
                if (newIndex >= FlipView.Items.Count || newIndex < 0)
                {
                    change *= -1;
                }

                FlipView.SelectedIndex += change;
            };
            timer.Start();

            RefreshItems();
        }

        private void Navigate(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(TasksView));
            ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("loginButton", logInButton);
            


            User userInput = new User();
            userInput.UserId = Convert.ToInt16(userIdBox.Text);
            userInput.HashPass = userPasswordBox.Password;
            LoginTool.LoginUser(userInput);

            


        }
    
        private async void RefreshItems()
        {
            try
            {

                await new TaskViewModel().LoadTasks();
                await new CommentsViewModel().LoadComments();
                await new MeasurementsViewModel().LoadMeasurments();


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

    }
}
