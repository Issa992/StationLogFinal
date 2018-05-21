using StationLogFinal.Persistency;
using StationLogWebApplication1;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;


namespace StationLogFinal.SessionTools
{
    static class UserHandler
    {
        public static List<User> UserListToCheck { get; set; } = new List<User>();

        public static async void GetAllUsers()
        {
            //oldDB http://stationlogwebapplication120180426012243.azurewebsites.net
            //newDB http://stationlogsystemwebapplication20180521105958.azurewebsites.net

            WebAPIAsync<User> UserWebAPI = new WebAPIAsync<User>("http://stationlogsystemwebapplication20180521105958.azurewebsites.net", "api","Users");
            try
            {
                var users =  await UserWebAPI.Load();
                if (users != null)
                {
                    foreach (var user in users)
                    {
                        UserListToCheck.Add(user);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async void RegisterUser(User newUser)
        {
            WebAPIAsync<User> UserWebAPI = new WebAPIAsync<User>("http://stationlogwebapplication120180426012243.azurewebsites.net", "api", "Users");
            // WebApi.create(); has been changed to accepte only 1 argument instead of 2 ..
            //await UserWebAPI.Create(newUser.UserId, newUser);
        }
    }
}
