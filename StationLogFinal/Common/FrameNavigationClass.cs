using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StationLogFinal.Common
{
    static class FrameNavigationClass
    {
        public static void ActivateFrameNavigation(Type type)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(type);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }
    }
}

